#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Finances.NET.Core.Accounts;
using Finances.NET.Core.Operations;
using Finances.NET.Utils;

#endregion

namespace Finances.NET.Forms.Operations
{
    public partial class FrmScheduledOperations : Form
    {
        /// <summary>
        ///     The string resource manager
        /// </summary>
        private static readonly StringResources StringResourceManager = new StringResources();

        /// <summary>
        ///     The _account
        /// </summary>
        private readonly Account _account;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmScheduledOperations" /> class.
        /// </summary>
        /// <param name="account">The account.</param>
        public FrmScheduledOperations(Account account)
        {
            InitializeComponent();
            _account = account;
            ScheduledOperations = _account.ScheduledTransactions;
            SetupGridView();
            SetWindowTheme(scheduledOperationsList.Handle, "Explorer", null);

            scheduledOperationsList.DrawItem += scheduledOperationsList_DrawItem;
        }

        /// <summary>
        ///     Gets or sets the scheduled operations.
        /// </summary>
        /// <value>The scheduled operations.</value>
        public List<Operation> ScheduledOperations { get; set; }

        /// <summary>
        ///     Sets the window theme.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pszSubAppName">Name of the PSZ sub application.</param>
        /// <param name="pszSubIdList">The PSZ sub identifier list.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        /// <summary>
        ///     Handles the DrawItem event of the scheduledOperationsList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DrawListViewItemEventArgs" /> instance containing the event data.</param>
        private void scheduledOperationsList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Item.ForeColor = SystemColors.HighlightText;
                e.Item.BackColor = SystemColors.Highlight;
            }
            else
            {
                e.Item.ForeColor = scheduledOperationsList.ForeColor;
                e.Item.BackColor = scheduledOperationsList.BackColor;
            }
        }

        /// <summary>
        ///     Setups the grid view.
        /// </summary>
        private void SetupGridView()
        {
            scheduledOperationsList.BeginUpdate();
            scheduledOperationsList.Items.Clear();

            foreach (var op in ScheduledOperations)
            {
                var it = new ListViewItem {Text = op.Id, Name = op.Id};
                it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                it.SubItems.Add(op.Budget);
                it.SubItems.Add(op.Commentary);
                it.SubItems.Add(op.Credit + " " + _account.Currency.Symbol);
                it.SubItems.Add(op.Debit + " " + _account.Currency.Symbol);
                scheduledOperationsList.Items.Add(it);
            }

            scheduledOperationsList.EndUpdate();
        }

        /// <summary>
        ///     Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Handles the Click event of the btnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            var operationToRemove =
                _account.ScheduledTransactions.First(x => x.Id == scheduledOperationsList.SelectedItems[0].Text);
            ScheduledOperations.Remove(operationToRemove);
            SetupGridView();
            MessageBox.Show(StringResourceManager.GetString("SCHEDULED_OPERATION_REMOVED"));
        }
    }
}