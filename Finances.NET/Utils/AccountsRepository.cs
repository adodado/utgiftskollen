#region

using System.Collections.Generic;
using Finances.NET.Core.Accounts;

#endregion

namespace Finances.NET.Utils
{
    /// <summary>
    ///     The Accounts repository
    /// </summary>
    public class AccountsRepository
    {
        #region Fields

        /// <summary>
        ///     The _file helper
        /// </summary>
        private readonly FileHelper _fileHelper;

        /// <summary>
        ///     The filepath
        /// </summary>
        private string _filepath = "";

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public AccountsRepository(string filePath)
        {
            Accounts = new List<Account>();
            _fileHelper = new FileHelper(this);
            _filepath = filePath;
        }

        #endregion

        #region Public properties

        /// <summary>
        ///     Gets the file helper.
        /// </summary>
        /// <value>The file helper.</value>
        public FileHelper FileHelper
        {
            get { return _fileHelper; }
        }

        /// <summary>
        ///     Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public List<Account> Accounts { get; set; }

        /// <summary>
        ///     The encryption state of the account
        /// </summary>
        /// <value><c>true</c> if encrypted; otherwise, <c>false</c>.</value>
        public bool Encrypted { get; set; }

        /// <summary>
        ///     The filepath of the account
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        #endregion
    }
}