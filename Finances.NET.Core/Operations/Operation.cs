#region

using System;

#endregion

namespace Finances.NET.Core.Operations
{
    /// <summary>
    ///     Class Operation.
    /// </summary>
    [Serializable]
    public class Operation
    {

        #region Constructors

        /// <summary>
        ///     Simple constructor
        /// </summary>
        public Operation()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">The GUID</param>
        public Operation(string id)
        {
            Id = id;
        }

        #endregion

        #region Public properties

        /// <summary>
        ///     GUID of operation
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        ///     Date of operation
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Commentary
        /// </summary>
        /// <value>The commentary.</value>
        public string Commentary { get; set; }

        /// <summary>
        ///     Credit
        /// </summary>
        /// <value>The credit.</value>
        public decimal Credit { get; set; }

        /// <summary>
        ///     Debit
        /// </summary>
        /// <value>The debit.</value>
        public decimal Debit { get; set; }

        /// <summary>
        ///     Type
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        ///     Category
        /// </summary>
        /// <value>The budget.</value>
        public string Budget { get; set; }

        /// <summary>
        ///     Monthly
        /// </summary>
        /// <value><c>true</c> if monthly; otherwise, <c>false</c>.</value>
        public bool Monthly { get; set; }

        #endregion
    }
}