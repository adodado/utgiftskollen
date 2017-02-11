#region

using System;
using System.Collections.Generic;
using System.Linq;
using Finances.NET.Core.Currencies;
using Finances.NET.Core.Operations;

#endregion

namespace Finances.NET.Core.Accounts
{
    /// <summary>
    ///     The Account class
    /// </summary>
    public class Account
    {
        /// <summary>
        ///     The _crdate
        /// </summary>
        private readonly DateTime _crdate;

        /// <summary>
        ///     The _ops
        /// </summary>
        private readonly List<Operation> _ops = new List<Operation>();

        /// <summary>
        ///     The _budgets
        /// </summary>
        private List<string> _budgets = new List<string>();

        /// <summary>
        /// The _scheduled operations
        /// </summary>
        private List<Operation> _scheduledTransactions=new List<Operation>(); 
       
        /// <summary>
        ///     The _currency
        /// </summary>
        private CurrencyObject _currency;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public Account()
        {
            _crdate = DateTime.Now;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="cd">Creation date</param>
        public Account(DateTime cd)
        {
            _crdate = cd;
        }

        /// <summary>
        ///     The categories of operations
        /// </summary>
        /// <value>The budgets.</value>
        public List<string> Budgets
        {
            get
            {
                _budgets.Sort(String.CompareOrdinal);
                return _budgets;
            }
            set
            {
                _budgets = value;
                _budgets.Sort(String.CompareOrdinal);
            }
        }

        /// <summary>
        ///     The account's creation date
        /// </summary>
        /// <value>The creation date.</value>
        public DateTime CreationDate
        {
            get { return _crdate; }
        }

        /// <summary>
        ///     The currency of the account
        /// </summary>
        /// <value>The currency.</value>
        public CurrencyObject Currency
        {
            get { return _currency; }
        }

        /// <summary>
        ///     The name of the account
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     The operations on the account
        /// </summary>
        /// <value>The operations.</value>
        public List<Operation> Operations
        {
            get { return _ops; }
        }

        /// <summary>
        /// Gets the scheduled operations.
        /// </summary>
        /// <value>The scheduled operations.</value>
        public List<Operation> ScheduledTransactions
        {
            get { return _scheduledTransactions; }
            set { _scheduledTransactions = value; }
        }

        /// <summary>
        ///     Changes the account's currency to the given one
        /// </summary>
        /// <param name="d">The given currency</param>
        /// <param name="convert">Convert all the operations to the given currency</param>
        public void ChangeCurrency(CurrencyObject d, bool convert = true)
        {
            if (!convert)
            {
                _currency = d;
            }
            else
            {
                Enumerable.All(_ops, x =>
                {
                    x.Credit = _currency.ToCurrency(d, (double) x.Credit);
                    x.Debit = _currency.ToCurrency(d, (double) x.Debit);
                    return true;
                });

                _currency = d;
            }
        }
    }
}