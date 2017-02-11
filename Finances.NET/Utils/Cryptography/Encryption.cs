#region

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Finances.NET.Properties;

#endregion

namespace Finances.NET.Utils.Cryptography
{
    /// <summary>
    ///     Class Encryption.
    /// </summary>
    public class Encryption
    {
        #region Fields

        /// <summary>
        ///     The random
        /// </summary>
        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

        #endregion

        #region Public properties

        //Preconfigured Encryption Parameters
        /// <summary>
        ///     The block bit size
        /// </summary>
        public static readonly int BlockBitSize = 128;

        /// <summary>
        ///     The key bit size
        /// </summary>
        public static readonly int KeyBitSize = Settings.Default.KeyBitSize;

        //Preconfigured Password Key Derivation Parameters
        /// <summary>
        ///     The salt bit size
        /// </summary>
        public static readonly int SaltBitSize = Settings.Default.SaltBitSize;

        /// <summary>
        ///     The iterations
        /// </summary>
        public static readonly int Iterations = Settings.Default.Iterations;

        /// <summary>
        ///     The minimum password length
        /// </summary>
        public static readonly int MinPasswordLength = Settings.Default.MinPasswordLength;

        /// <summary>
        ///     Helper that generates a random key on each call.
        /// </summary>
        /// <returns>System.Byte[][].</returns>
        public static byte[] NewKey()
        {
            var key = new byte[KeyBitSize/8];
            Random.GetBytes(key);
            return key;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Simple Encryption (AES) then Authentication (HMAC) for a UTF8 Message.
        /// </summary>
        /// <param name="encryptString">The secret message.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="authKey">The auth key.</param>
        /// <param name="nonSecretPayload">(Optional) Non-Secret Payload.</param>
        /// <returns>Encrypted Message</returns>
        /// <exception cref="System.ArgumentException">Secret Message Required!;secretMessage</exception>
        /// <remarks>
        ///     Adds overhead of (Optional-Payload + BlockSize(16) + Message-Padded-To-Blocksize +  HMac-Tag(32)) * 1.33
        ///     Base64
        /// </remarks>
        public static string SimpleEncrypt(string encryptString, byte[] cryptKey, byte[] authKey,
            byte[] nonSecretPayload = null)
        {
            if (string.IsNullOrEmpty(encryptString))
                throw new ArgumentException(@"String to encrypt is required!", "encryptString");

            var plainText = Encoding.UTF8.GetBytes(encryptString);
            var cipherText = SimpleEncrypt(plainText, cryptKey, authKey, nonSecretPayload);
            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        ///     Simple Authentication (HMAC) then Decryption (AES) for a secrets UTF8 Message.
        /// </summary>
        /// <param name="encryptString">The encrypted message.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="authKey">The auth key.</param>
        /// <param name="nonSecretPayloadLength">Length of the non secret payload.</param>
        /// <returns>Decrypted Message</returns>
        /// <exception cref="System.ArgumentException">Encrypted Message Required!;encryptedMessage</exception>
        public static string SimpleDecrypt(string encryptString, byte[] cryptKey, byte[] authKey,
            int nonSecretPayloadLength = 0)
        {
            if (string.IsNullOrWhiteSpace(encryptString))
                throw new ArgumentException(@"String to encrypt is required!", "encryptString");

            var cipherText = Convert.FromBase64String(encryptString);
            var plainText = SimpleDecrypt(cipherText, cryptKey, authKey, nonSecretPayloadLength);
            return Encoding.UTF8.GetString(plainText);
        }

        /// <summary>
        ///     Simple Encryption (AES) then Authentication (HMAC) of a UTF8 message
        ///     using Keys derived from a Password (PBKDF2).
        /// </summary>
        /// <param name="encryptString">The secret message.</param>
        /// <param name="password">The password.</param>
        /// <param name="nonSecretPayload">The non secret payload.</param>
        /// <returns>Encrypted Message</returns>
        /// <exception cref="System.ArgumentException">password</exception>
        /// <remarks>
        ///     Significantly less secure than using random binary keys.
        ///     Adds additional non secret payload for key generation parameters.
        /// </remarks>
        public static string SimpleEncryptWithPassword(string encryptString, string password,
            byte[] nonSecretPayload = null)
        {
            if (string.IsNullOrEmpty(encryptString))
                throw new ArgumentException(@"String to encrypt is required!", "encryptString");

            var plainText = Encoding.UTF8.GetBytes(encryptString);
            var cipherText = SimpleEncryptWithPassword(plainText, password, nonSecretPayload);
            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        ///     Simple Authentication (HMAC) and then Descryption (AES) of a UTF8 Message
        ///     using keys derived from a password (PBKDF2).
        /// </summary>
        /// <param name="encryptedString">The encrypted message.</param>
        /// <param name="password">The password.</param>
        /// <param name="nonSecretPayloadLength">Length of the non secret payload.</param>
        /// <returns>Decrypted Message</returns>
        /// <exception cref="System.ArgumentException">Encrypted Message Required!;encryptedMessage</exception>
        /// <remarks>Significantly less secure than using random binary keys.</remarks>
        public static string SimpleDecryptWithPassword(string encryptedString, string password,
            int nonSecretPayloadLength = 0)
        {
            if (string.IsNullOrWhiteSpace(encryptedString))
                throw new ArgumentException(@"String to decrypt is required!", "encryptedString");

            var cipherText = Convert.FromBase64String(encryptedString);
            var plainText = SimpleDecryptWithPassword(cipherText, password, nonSecretPayloadLength);
            return Encoding.UTF8.GetString(plainText);
        }

        /// <summary>
        ///     Simple Encryption(AES) then Authentication (HMAC) for a UTF8 Message.
        /// </summary>
        /// <param name="encryptString">The secret message.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="authKey">The auth key.</param>
        /// <param name="nonSecretPayload">(Optional) Non-Secret Payload.</param>
        /// <returns>Encrypted Message</returns>
        /// <exception cref="System.ArgumentException">
        ///     cryptKey
        ///     or
        ///     authKey
        ///     or
        ///     Secret Message Required!;secretMessage
        /// </exception>
        /// <remarks>
        ///     Adds overhead of (Optional-Payload + BlockSize(16) + Message-Padded-To-Blocksize +  HMac-Tag(32)) * 1.33
        ///     Base64
        /// </remarks>
        public static byte[] SimpleEncrypt(byte[] encryptString, byte[] cryptKey, byte[] authKey,
            byte[] nonSecretPayload = null)
        {
            //User Error Checks
            if (cryptKey == null || cryptKey.Length != KeyBitSize/8)
                throw new ArgumentException(String.Format("Key needs to be {0} bit!", KeyBitSize), "cryptKey");

            if (authKey == null || authKey.Length != KeyBitSize/8)
                throw new ArgumentException(String.Format("Key needs to be {0} bit!", KeyBitSize), "authKey");

            if (encryptString == null || encryptString.Length < 1)
                throw new ArgumentException(@"String to encrypt is required!", "encryptString");

            //non-secret payload optional
            nonSecretPayload = nonSecretPayload ?? new byte[] {};

            byte[] cipherText;
            byte[] iv;

            using (var aes = new AesManaged
            {
                KeySize = KeyBitSize,
                BlockSize = BlockBitSize,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            })
            {
                //Use random IV
                aes.GenerateIV();
                iv = aes.IV;

                using (var encrypter = aes.CreateEncryptor(cryptKey, iv))
                using (var cipherStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                    using (var binaryWriter = new BinaryWriter(cryptoStream))
                    {
                        //Encrypt Data
                        binaryWriter.Write(encryptString);
                    }

                    cipherText = cipherStream.ToArray();
                }
            }

            //Assemble encrypted message and add authentication
            using (var hmac = new HMACSHA256(authKey))
            using (var encryptedStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(encryptedStream))
                {
                    //Prepend non-secret payload if any
                    binaryWriter.Write(nonSecretPayload);
                    //Prepend IV
                    binaryWriter.Write(iv);
                    //Write Ciphertext
                    binaryWriter.Write(cipherText);
                    binaryWriter.Flush();

                    //Authenticate all data
                    var tag = hmac.ComputeHash(encryptedStream.ToArray());
                    //Postpend tag
                    binaryWriter.Write(tag);
                }
                return encryptedStream.ToArray();
            }
        }

        /// <summary>
        ///     Simple Authentication (HMAC) then Decryption (AES) for a secrets UTF8 Message.
        /// </summary>
        /// <param name="encryptedString">The encrypted message.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="authKey">The auth key.</param>
        /// <param name="nonSecretPayloadLength">Length of the non secret payload.</param>
        /// <returns>Decrypted Message</returns>
        /// <exception cref="System.ArgumentException">
        ///     cryptKey
        ///     or
        ///     authKey
        ///     or
        ///     Encrypted Message Required!;encryptedMessage
        /// </exception>
        public static byte[] SimpleDecrypt(byte[] encryptedString, byte[] cryptKey, byte[] authKey,
            int nonSecretPayloadLength = 0)
        {
            //Basic Usage Error Checks
            if (cryptKey == null || cryptKey.Length != KeyBitSize/8)
                throw new ArgumentException(String.Format("CryptKey needs to be {0} bit!", KeyBitSize), "cryptKey");

            if (authKey == null || authKey.Length != KeyBitSize/8)
                throw new ArgumentException(String.Format("AuthKey needs to be {0} bit!", KeyBitSize), "authKey");

            if (encryptedString == null || encryptedString.Length == 0)
                throw new ArgumentException(@"Encrypted string to decryt is required!", "encryptedString");

            using (var hmac = new HMACSHA256(authKey))
            {
                var sentTag = new byte[hmac.HashSize/8];
                //Calculate Tag
                var calcTag = hmac.ComputeHash(encryptedString, 0, encryptedString.Length - sentTag.Length);
                var ivLength = (BlockBitSize/8);

                //if message length is to small just return null
                if (encryptedString.Length < sentTag.Length + nonSecretPayloadLength + ivLength)
                    return null;

                //Grab Sent Tag
                Array.Copy(encryptedString, encryptedString.Length - sentTag.Length, sentTag, 0, sentTag.Length);

                //Compare Tag with constant time comparison
                var compare = 0;
                for (var i = 0; i < sentTag.Length; i++)
                    compare |= sentTag[i] ^ calcTag[i];

                //if message doesn't authenticate return null
                if (compare != 0)
                    return null;

                using (var aes = new AesManaged
                {
                    KeySize = KeyBitSize,
                    BlockSize = BlockBitSize,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {
                    //Grab IV from message
                    var iv = new byte[ivLength];
                    Array.Copy(encryptedString, nonSecretPayloadLength, iv, 0, iv.Length);

                    using (var decrypter = aes.CreateDecryptor(cryptKey, iv))
                    using (var plainTextStream = new MemoryStream())
                    {
                        using (
                            var decrypterStream = new CryptoStream(plainTextStream, decrypter, CryptoStreamMode.Write))
                        using (var binaryWriter = new BinaryWriter(decrypterStream))
                        {
                            //Decrypt Cipher Text from Message
                            binaryWriter.Write(
                                encryptedString,
                                nonSecretPayloadLength + iv.Length,
                                encryptedString.Length - nonSecretPayloadLength - iv.Length - sentTag.Length
                                );
                        }
                        //Return Plain Text
                        return plainTextStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        ///     Simple Encryption (AES) then Authentication (HMAC) of a UTF8 message
        ///     using Keys derived from a Password (PBKDF2)
        /// </summary>
        /// <param name="encryptString">The secret message.</param>
        /// <param name="password">The password.</param>
        /// <param name="nonSecretPayload">The non secret payload.</param>
        /// <returns>Encrypted Message</returns>
        /// <exception cref="System.ArgumentException">Must have a password of minimum length;password</exception>
        /// <remarks>
        ///     Significantly less secure than using random binary keys.
        ///     Adds additional non secret payload for key generation parameters.
        /// </remarks>
        public static byte[] SimpleEncryptWithPassword(byte[] encryptString, string password,
            byte[] nonSecretPayload = null)
        {
            nonSecretPayload = nonSecretPayload ?? new byte[] {};

            //User Error Checks
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                throw new ArgumentException(
                    String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");

            if (encryptString == null || encryptString.Length == 0)
                throw new ArgumentException(@"String to encrypt is required!", "encryptString");

            var payload = new byte[((SaltBitSize/8)*2) + nonSecretPayload.Length];

            Array.Copy(nonSecretPayload, payload, nonSecretPayload.Length);
            var payloadIndex = nonSecretPayload.Length;

            byte[] cryptKey;
            byte[] authKey;
            //Use Random Salt to prevent pre-generated weak password attacks.
            using (var generator = new Rfc2898DeriveBytes(password, SaltBitSize/8, Iterations))
            {
                var salt = generator.Salt;

                //Generate Keys
                cryptKey = generator.GetBytes(KeyBitSize/8);

                //Create Non Secret Payload
                Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
                payloadIndex += salt.Length;
            }

            //Deriving separate key, might be less efficient than using HKDF, 
            //but now compatible with RNEncryptor which had a very similar wireformat and requires less code than HKDF.
            using (var generator = new Rfc2898DeriveBytes(password, SaltBitSize/8, Iterations))
            {
                var salt = generator.Salt;

                //Generate Keys
                authKey = generator.GetBytes(KeyBitSize/8);

                //Create Rest of Non Secret Payload
                Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
            }

            return SimpleEncrypt(encryptString, cryptKey, authKey, payload);
        }

        /// <summary>
        ///     Simple Authentication (HMAC) and then Descryption (AES) of a UTF8 Message
        ///     using keys derived from a password (PBKDF2).
        /// </summary>
        /// <param name="encryptedString">The encrypted message.</param>
        /// <param name="password">The password.</param>
        /// <param name="nonSecretPayloadLength">Length of the non secret payload.</param>
        /// <returns>Decrypted Message</returns>
        /// <exception cref="System.ArgumentException">Must have a password of minimum length;password</exception>
        /// <remarks>Significantly less secure than using random binary keys.</remarks>
        public static byte[] SimpleDecryptWithPassword(byte[] encryptedString, string password,
            int nonSecretPayloadLength = 0)
        {
            //User Error Checks
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                throw new ArgumentException(
                    String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");

            if (encryptedString == null || encryptedString.Length == 0)
                throw new ArgumentException(@"Encrypted string to decrypt is required!", "encryptedString");

            var cryptSalt = new byte[SaltBitSize/8];
            var authSalt = new byte[SaltBitSize/8];

            //Grab Salt from Non-Secret Payload
            Array.Copy(encryptedString, nonSecretPayloadLength, cryptSalt, 0, cryptSalt.Length);
            Array.Copy(encryptedString, nonSecretPayloadLength + cryptSalt.Length, authSalt, 0, authSalt.Length);

            byte[] cryptKey;
            byte[] authKey;

            //Generate crypt key
            using (var generator = new Rfc2898DeriveBytes(password, cryptSalt, Iterations))
            {
                cryptKey = generator.GetBytes(KeyBitSize/8);
            }
            //Generate auth key
            using (var generator = new Rfc2898DeriveBytes(password, authSalt, Iterations))
            {
                authKey = generator.GetBytes(KeyBitSize/8);
            }

            return SimpleDecrypt(encryptedString, cryptKey, authKey,
                cryptSalt.Length + authSalt.Length + nonSecretPayloadLength);
        }

        #endregion
    }
}