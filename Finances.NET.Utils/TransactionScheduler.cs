using System;
using System.Collections.Generic;
using System.Linq;
using Finances.NET.Core.Accounts;
using Finances.NET.Core.Operations;

namespace Finances.NET.Utils
{
    public class TransactionScheduler
    {
        /// <summary>
        /// The _date time
        /// </summary>
        private DateTime _dateTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionScheduler"/> class.
        /// </summary>
        public TransactionScheduler()
        {
            _dateTime=DateTime.Now;
        }

        /// <summary>
        /// Checks for scheduled transactions.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>List{ScheduledTransaction}.</returns>
        private List<Operation> CheckForScheduledTransactions(Account account)
        {
            var scheduledTransactions = new List<Operation>();
            if (account.ScheduledTransactions.Count != 0)
            {
                scheduledTransactions.AddRange(account.ScheduledTransactions.Where(item => item.Date <= _dateTime));
                return scheduledTransactions.Count != 0 ? scheduledTransactions : null;
            }
            return null;
        }

        /// <summary>
        /// Processes the transactions.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>Account.</returns>
        public Account ProcessTransactions(Account account)
        {
            if (account != null)
            {
                foreach (var item in account.ScheduledTransactions.ToList().Where(item => item.Date <= _dateTime))
                {
                    account.ScheduledTransactions.Remove(item);
                    item.Date = _dateTime;
                    item.Id = Guid.NewGuid().ToString();
                    account.Operations.Add(item);
                    item.Date.AddMonths(1);
                    account.ScheduledTransactions.Add(item);
                }
                return account;
            }
            return null;
        }

        /// <summary>
        /// Schedules the transaction.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="operation">The operation.</param>
        /// <returns>List{ScheduledTransaction}.</returns>
        public List<Operation> ScheduleTransaction(Account account, Operation operation)
        {
            var scheduledTransactions = account.ScheduledTransactions;
            scheduledTransactions.Add(operation);
            return scheduledTransactions;
        }
    }
}
