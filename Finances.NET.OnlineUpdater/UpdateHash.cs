using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Finances.NET.OnlineUpdater
{
    internal static class UpdateHash
    {
        internal enum HashType
        {
            Md5,
            Sha1,
            Sha512
        }

        #region Methods of UpdateHash

        /// <summary>
        /// Bytes the hash to string hash.
        /// </summary>
        /// <param name="hashBytes">The hash bytes.</param>
        /// <returns>System.String.</returns>
        private static string ByteHashToStringHash(byte[] hashBytes)
        {
            var builder = new StringBuilder(hashBytes.Length * 2);

            foreach (var hashByte in hashBytes)
            {
                builder.Append(hashByte.ToString("X2").ToLower());
            }
            return builder.ToString();
        }

        /// <summary>
        /// Hashes the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="algoHashType">Type of the algo hash.</param>
        /// <returns>System.String.</returns>
        internal static string HashFile(string filePath, HashType algoHashType)
        {
            switch (algoHashType)
            {
                case HashType.Md5:
                    {
                        return ByteHashToStringHash(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                    }
                case HashType.Sha1:
                    {
                        return ByteHashToStringHash(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                    }
                case HashType.Sha512:
                    {
                        return ByteHashToStringHash(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                    }
            }
            return string.Empty;
        }

        #endregion
    }
}
