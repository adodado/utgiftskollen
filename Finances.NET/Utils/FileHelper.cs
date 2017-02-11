#region

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Finances.NET.Core.Accounts;
using Finances.NET.Core.Currencies;
using Finances.NET.Core.Operations;
using Finances.NET.Utils.Cryptography;
using Ookii.Dialogs;

#endregion

namespace Finances.NET.Utils
{
    /// <summary>
    /// A file helper.
    /// </summary>
    public class FileHelper
    {
        #region Fields

        /// <summary>
        ///     The _accounts
        /// </summary>
        private readonly AccountsRepository _accounts;

        /// <summary>
        /// The string resource manager
        /// </summary>
        private static readonly StringResources StringResourceManager=new StringResources();

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="accounts">The accounts.</param>
        public FileHelper(AccountsRepository accounts)
        {
            _accounts = accounts;
        }

        #endregion

        #region SaveXMLFile

        /// <summary>
        ///     Saves the account
        /// </summary>
        /// <param name="accounts">The accounts.</param>
        /// <param name="password">The password.</param>
        public void Save(AccountsRepository accounts, string password = "")
        {
            if (_accounts.FilePath == "")
                return;

            if (!_accounts.Encrypted)
            {
                ToXml(accounts, _accounts.FilePath);
                MessageBox.Show(StringResourceManager.GetString("ACCOUNTS_SAVED"),
                    StringResourceManager.GetString("SAVE"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            ToEncryptedXml(accounts, _accounts.FilePath, password);
            MessageBox.Show(StringResourceManager.GetString("ENCRYPTED_ACCOUNTS_SAVED"),
                StringResourceManager.GetString("SAVE"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        ///     Changes the filename and save the account
        /// </summary>
        /// <param name="accounts">The accounts.</param>
        /// <param name="file">The new filename</param>
        public void SaveAs(AccountsRepository accounts, string file, string password = "")
        {
            _accounts.FilePath = file;

            if (password == "")
                Save(accounts);
            else
                Save(accounts, password);
        }

        /// <summary>
        ///     Saves the given account to an XML file
        /// </summary>
        /// <param name="accountsRepository">Accounts to save</param>
        /// <param name="filepath">File name</param>
        /// <param name="autosave">Automatically save the file, default=true</param>
        /// <returns>The generated XDocument if autosave is set to false</returns>
        private static void ToXml(AccountsRepository accountsRepository, string filepath = "", bool autosave = true)
        {
            var doc = new XDocument(new XElement("AccountRepository"));
            foreach (var acc in accountsRepository.Accounts)
            {
                var xmlElement = new XElement("Account",
                    new XElement("Name", acc.Name),
                    new XElement("Created", acc.CreationDate.ToString("dd/MM/yyyy")),
                    new XElement("Currency", acc.Currency.ShortName),
                    new XElement("Operations",
                        acc.Operations.Select(x => new XElement("Op",
                            new XAttribute("ID", x.Id),
                            new XAttribute("Date", x.Date.ToString("dd/MM/yyyy")),
                            new XAttribute("Commentary", x.Commentary),
                            new XAttribute("Credit", x.Credit.ToString(CultureInfo.InvariantCulture)),
                            new XAttribute("Debit", x.Debit.ToString(CultureInfo.InvariantCulture)),
                            new XAttribute("Type", x.Type),
                            new XAttribute("Budget", x.Budget),
                            new XAttribute("Monthly", x.Monthly.ToString())))),
                    new XElement("Budgets",
                        acc.Budgets.Select(y => new XElement("B", y))),
                    new XElement("ScheduledTransactions",
                        acc.ScheduledTransactions.Select(x => new XElement("ScheduledTransaction",
                            new XAttribute("ID", x.Id),
                            new XAttribute("Date", x.Date.ToString("dd/MM/yyyy")),
                            new XAttribute("Commentary", x.Commentary),
                            new XAttribute("Credit", x.Credit.ToString(CultureInfo.InvariantCulture)),
                            new XAttribute("Debit", x.Debit.ToString(CultureInfo.InvariantCulture)),
                            new XAttribute("Type", x.Type),
                            new XAttribute("Budget", x.Budget)))));
                var xElement = doc.Element("AccountRepository");

                if (xElement != null)
                    xElement.Add(xmlElement);
            }

            if (autosave)
                doc.Save(filepath);
        }

        /// <summary>
        ///     Saves encrypted data to XML file.
        /// </summary>
        /// <param name="accountsRepository">The accounts repository.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="password">The password.</param>
        /// <param name="autosave">if set to <c>true</c> [autosave].</param>
        private static void ToEncryptedXml(AccountsRepository accountsRepository, string filepath, string password,
            bool autosave = true)
        {
            var doc = new XDocument(new XElement("AccountRepository"));

            foreach (var acc in accountsRepository.Accounts)
            {
                var xmlElement = new XElement("Account",
                    new XElement("Name", Encryption.SimpleEncryptWithPassword(acc.Name, password)),
                    new XElement("Created",
                        Encryption.SimpleEncryptWithPassword(acc.CreationDate.ToString("dd/MM/yyyy"), password)),
                    new XElement("Currency", Encryption.SimpleEncryptWithPassword(acc.Currency.ShortName, password)),
                    new XElement("Operations",
                        acc.Operations.Select(x => new XElement("Op",
                            new XAttribute("ID", Encryption.SimpleEncryptWithPassword(x.Id, password)),
                            new XAttribute("Date",
                                Encryption.SimpleEncryptWithPassword(x.Date.ToString("dd/MM/yyyy"), password)),
                            new XAttribute("Commentary", Encryption.SimpleEncryptWithPassword(x.Commentary, password)),
                            new XAttribute("Credit",
                                Encryption.SimpleEncryptWithPassword(x.Credit.ToString(CultureInfo.InvariantCulture),
                                    password)),
                            new XAttribute("Debit",
                                Encryption.SimpleEncryptWithPassword(x.Debit.ToString(CultureInfo.InvariantCulture),
                                    password)),
                            new XAttribute("Type", Encryption.SimpleEncryptWithPassword(x.Type, password)),
                            new XAttribute("Budget", Encryption.SimpleEncryptWithPassword(x.Budget, password)),
                            new XAttribute("Monthly",
                                Encryption.SimpleEncryptWithPassword(x.Monthly.ToString(), password))))),
                    new XElement("Budgets",
                        acc.Budgets.Select(y => new XElement("B", Encryption.SimpleEncryptWithPassword(y,password))),
                    new XElement("ScheduledTransactions",
                        acc.ScheduledTransactions.Select(x => new XElement("ScheduledTransaction",
                            new XAttribute("ID", Encryption.SimpleEncryptWithPassword(x.Id,password)),
                            new XAttribute("Date", Encryption.SimpleEncryptWithPassword(x.Date.ToString("dd/MM/yyyy"),password)),
                            new XAttribute("Commentary", Encryption.SimpleEncryptWithPassword(x.Commentary,password)),
                            new XAttribute("Credit", Encryption.SimpleEncryptWithPassword(x.Credit.ToString(CultureInfo.InvariantCulture),password)),
                            new XAttribute("Debit", Encryption.SimpleEncryptWithPassword(x.Debit.ToString(CultureInfo.InvariantCulture),password)),
                            new XAttribute("Type", Encryption.SimpleEncryptWithPassword(x.Type,password)),
                            new XAttribute("Budget", Encryption.SimpleEncryptWithPassword(x.Budget,password)))))));
                var xElement = doc.Element("AccountRepository");

                if (xElement != null)
                    xElement.Add(xmlElement);
            }

            if (autosave)
                doc.Save(filepath);
        }

        #endregion

        #region ReadXMLFile

        /// <summary>
        ///     Loads account from file
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <returns>The account from <paramref name="filepath" /></returns>
        public static AccountsRepository FromFile(string filepath)
        {
            switch (Path.GetExtension(filepath))
            {
                case ".cna":
                    return LoadAlt(filepath);
                case ".cne":
                {
                    var ax = new InputDialog
                    {
                        UsePasswordMasking = true,
                        MainInstruction = StringResourceManager.GetString("ENTER_ACCOUNT_PASSWORD")
                    };
                    if (ax.ShowDialog() == DialogResult.OK)
                    {
                        return LoadAlt(filepath, true, ax.Input);
                    }
                }
                    break;
            }
            return null;
        }

        /// <summary>
        ///     Gets the account from the XML file
        /// </summary>
        /// <param name="filePath">XML filepath</param>
        /// <param name="encryptedFile">if set to <c>true</c> [encrypted file].</param>
        /// <param name="password">The password.</param>
        /// <returns>AccountsRepository.</returns>
        private static AccountsRepository FromXml(string filePath, bool encryptedFile = false, string password = "")
        {
            if (!encryptedFile)
            {
                var xml = File.ReadAllText(filePath);
                return FromXmlCode(xml, filePath);
            }
            else
            {
                var xml = File.ReadAllText(filePath);
                return FromEncryptedXml(xml, filePath, password);
            }
        }

        /// <summary>
        ///     Loads the account from account file
        /// </summary>
        /// <param name="filePath">Account file</param>
        /// <param name="encryptedFile">True if file is encrypted</param>
        /// <param name="password">Password for decryption of file</param>
        /// <returns>Account stored in given file</returns>
        private static AccountsRepository LoadAlt(string filePath, bool encryptedFile = false, string password = "")
        {
            try
            {
                return FromXml(filePath, encryptedFile, password);
            }
            catch (Exception)
            {
                MessageBox.Show(StringResourceManager.GetString("FILE_LOAD_ERROR"));
                return null;
            }
        }

        /// <summary>
        ///     Gets the accounts from XML code
        /// </summary>
        /// <param name="xml">XML code</param>
        /// <param name="filepath">Filepath</param>
        /// <returns>The accounts from XML code</returns>
        private static AccountsRepository FromXmlCode(string xml, string filepath)
        {
            try
            {
                var encodedString = Encoding.UTF8.GetBytes(xml);

                var ms = new MemoryStream(encodedString);
                ms.Flush();
                ms.Position = 0;

                var accountsRepository = new AccountsRepository(filepath);
                var d = XDocument.Load(ms);
                foreach (var c in d.Element("AccountRepository").Elements().Where(a => a.Name != "Password"))
                {
                    var account = new Account(DateTime.ParseExact(c.Element("Created").Value, "dd/MM/yyyy", null));
                    account.Name = c.Element("Name").Value;
                    var currency = Currency.All.First(x => x.ShortName == c.Element("Currency").Value);
                    account.ChangeCurrency(currency, false);

                    foreach (var op in from XElement a in c.Element("Operations").Nodes()
                        select new Operation(a.Attribute("ID").Value)
                        {
                            Date = DateTime.ParseExact(a.Attribute("Date").Value, "dd/MM/yyyy", null),
                            Commentary = a.Attribute("Commentary").Value,
                            Credit = decimal.Parse(a.Attribute("Credit").Value),
                            Debit = decimal.Parse(a.Attribute("Debit").Value),
                            Type = a.Attribute("Type").Value,
                            Budget = a.Attribute("Budget").Value,
                            Monthly = bool.Parse(a.Attribute("Monthly").Value)
                        })
                    {
                        account.Operations.Add(op);
                    }

                    var xElement = c.Element("ScheduledTransactions");
                    if (xElement != null)
                        foreach (var sched in from XElement a in xElement.Nodes()
                            select new Operation(a.Attribute("ID").Value)
                            {
                                Date = DateTime.ParseExact(a.Attribute("Date").Value, "dd/MM/yyyy", null),
                                Commentary = a.Attribute("Commentary").Value,
                                Credit = decimal.Parse(a.Attribute("Credit").Value),
                                Debit = decimal.Parse(a.Attribute("Debit").Value),
                                Type = a.Attribute("Type").Value,
                                Budget = a.Attribute("Budget").Value
                            })
                        {
                            sched.Monthly = true;
                            account.ScheduledTransactions.Add(sched);
                        }

                    account.Budgets.Clear();
                    foreach (var budgetElement in c.Element("Budgets").Nodes().Cast<XElement>())
                    {
                        account.Budgets.Add(budgetElement.Value);
                    }
                    accountsRepository.Accounts.Add(account);
                }

                return accountsRepository;
            }
            catch (Exception ex)
            {
                //TODO: Logging!!!
            }

            return null;
        }

        /// <summary>
        ///     Decrypts the encrypted data from XML file.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="password">The password.</param>
        /// <returns>AccountsRepository.</returns>
        private static AccountsRepository FromEncryptedXml(string xml, string filepath, string password)
        {
            try
            {
                var encodedString = Encoding.UTF8.GetBytes(xml);

                var ms = new MemoryStream(encodedString);
                ms.Flush();
                ms.Position = 0;

                var accountsRepository = new AccountsRepository(filepath);
                var d = XDocument.Load(ms);
                foreach (var c in d.Element("AccountRepository").Elements())
                {
                    var account =
                        new Account(
                            DateTime.ParseExact(
                                Encryption.SimpleDecryptWithPassword(c.Element("Created").Value, password), "dd/MM/yyyy",
                                null));
                    account.Name = Encryption.SimpleDecryptWithPassword(c.Element("Name").Value, password);
                    var currency =
                        Currency.All.First(
                            x =>
                                x.ShortName ==
                                Encryption.SimpleDecryptWithPassword(c.Element("Currency").Value, password));
                    account.ChangeCurrency(currency, false);

                    foreach (var op in from XElement a in c.Element("Operations").Nodes()
                        select new Operation(Encryption.SimpleDecryptWithPassword(a.Attribute("ID").Value, password))
                        {
                            Date =
                                DateTime.ParseExact(
                                    Encryption.SimpleDecryptWithPassword(a.Attribute("Date").Value, password),
                                    "dd/MM/yyyy", null),
                            Commentary = Encryption.SimpleDecryptWithPassword(a.Attribute("Commentary").Value, password),
                            Credit =
                                decimal.Parse(Encryption.SimpleDecryptWithPassword(a.Attribute("Credit").Value, password)),
                            Debit =
                                decimal.Parse(Encryption.SimpleDecryptWithPassword(a.Attribute("Debit").Value, password)),
                            Type = Encryption.SimpleDecryptWithPassword(a.Attribute("Type").Value, password),
                            Budget = Encryption.SimpleDecryptWithPassword(a.Attribute("Budget").Value, password),
                            Monthly =
                                bool.Parse(Encryption.SimpleDecryptWithPassword(a.Attribute("Monthly").Value, password))
                        })
                    {
                        account.Operations.Add(op);
                    }

                    var xElement = c.Element("ScheduledTransactions");
                    if (xElement != null)
                        foreach (var sched in from XElement a in xElement.Nodes()
                                              select new Operation(Encryption.SimpleDecryptWithPassword(a.Attribute("ID").Value, password))
                                              {
                                                  Date =
                                                      DateTime.ParseExact(
                                                          Encryption.SimpleDecryptWithPassword(a.Attribute("Date").Value, password),
                                                          "dd/MM/yyyy", null),
                                                  Commentary = Encryption.SimpleDecryptWithPassword(a.Attribute("Commentary").Value, password),
                                                  Credit =
                                                      decimal.Parse(Encryption.SimpleDecryptWithPassword(a.Attribute("Credit").Value, password)),
                                                  Debit =
                                                      decimal.Parse(Encryption.SimpleDecryptWithPassword(a.Attribute("Debit").Value, password)),
                                                  Type = Encryption.SimpleDecryptWithPassword(a.Attribute("Type").Value, password),
                                                  Budget = Encryption.SimpleDecryptWithPassword(a.Attribute("Budget").Value, password)
                                              })
                        {
                            sched.Monthly = true;
                            account.ScheduledTransactions.Add(sched);
                        }

                    account.Budgets.Clear();
                    var element = c.Element("Budgets");
                    if (element != null)
                        foreach (var budgetElement in element.Nodes().Cast<XElement>())
                        {
                            account.Budgets.Add(Encryption.SimpleDecryptWithPassword(budgetElement.Value, password));
                        }
                    accountsRepository.Accounts.Add(account);
                }
                accountsRepository.Encrypted = true;
                return accountsRepository;
            }
            catch (Exception ex)
            {
                var error = ex;
                //TODO: Logging!!!
            }

            return null;
        }

        #endregion
    }
}