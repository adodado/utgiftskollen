#region

using System;
using System.Windows.Forms;
using Finances.NET.Core.Accounts;
using Finances.NET.Core.Operations;
using Finances.NET.Utils;

#endregion

namespace Finances.NET.Forms.Operations
{
    /// <summary>
    ///     Class FrmOperation.
    /// </summary>
    public partial class FrmOperation : Form
    {
        /// <summary>
        /// The string resource manager
        /// </summary>
        private static readonly StringResources StringResourceManager = new StringResources();

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmOperation" /> class.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="edit">if set to <c>true</c> [edit].</param>
        /// <param name="op">The op.</param>
        public FrmOperation(Account account, bool edit = false, Operation op = null)
        {
            InitializeComponent();

            account.Budgets.ForEach(x => cbxBudget.Items.Add(x));
            cbxBudget.SelectedIndex = 0;
            cbxType.SelectedIndex = 0;

            if (edit)
                Text = StringResourceManager.GetString("EDIT_TRANSACTION");

            if (op == null) return;

            cbxType.SelectedItem = op.Type;
            mupCredit.Value = op.Credit;
            mupDebit.Value = op.Debit;
            cbxBudget.SelectedItem = op.Budget;
            mcDate.SelectionStart = op.Date;
            mcDate.SelectionEnd = op.Date;
            txtComm.Text = op.Commentary;
            chkMonthly.Checked = op.Monthly;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Handles the Enter event of the mupCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void mupCredit_Enter(object sender, EventArgs e)
        {
            mupCredit.Text = "";
        }

        /// <summary>
        ///     Handles the KeyUp event of the mupCredit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void mupCredit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                mupCredit.Text = mupCredit.Value + " " + mupCredit.Currency;
            }
        }

        /// <summary>
        ///     Handles the Enter event of the mupDebit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void mupDebit_Enter(object sender, EventArgs e)
        {
            mupDebit.Text = "";
        }

        /// <summary>
        ///     Handles the KeyUp event of the mupDebit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void mupDebit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                mupDebit.Text = mupDebit.Value + " " + mupDebit.Currency;
            }
        }

        #endregion Methods
    }
}