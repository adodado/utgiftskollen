#region

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Finances.NET.Core.Accounts;
using Finances.NET.Core.Currencies;

#endregion

namespace Finances.NET.Forms
{
    /// <summary>
    ///     Class FrmCreateAccount.
    /// </summary>
    public partial class FrmCreateAccount : Form
    {
        /// <summary>
        /// The _edit account
        /// </summary>
        private Account _editAccount;

        /// <summary>
        ///     The removing field
        /// </summary>
        private bool _removing;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmCreateAccount" /> class.
        /// </summary>
        /// <param name="editCompt">The edit compt.</param>
        /// <param name="setPassword">if set to <c>true</c> [set password].</param>
        public FrmCreateAccount(Account editCompt = null, bool setPassword = false)
        {
            InitializeComponent();
            Currency.All.ForEach(x => cbxCurrency.Items.Add(x.Name));

            if (editCompt != null)
            {
                _editAccount = editCompt;
                txtName.Text = editCompt.Name;

                lbxBudgets.Items.Clear();

                editCompt.Budgets.ForEach(x => lbxBudgets.Items.Add(x));
                if (editCompt.Currency == null)
                    cbxCurrency.SelectedItem = "";
                else
                    cbxCurrency.SelectedItem = editCompt.Currency.Name;
            }

            SetWindowTheme(lbxBudgets.Handle, "Explorer", null);
        }

        /// <summary>
        ///     Sets the window theme.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pszSubAppName">Name of the PSZ sub application.</param>
        /// <param name="pszSubIdList">The PSZ sub identifier list.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("uxtheme.dll")]
        public static extern int SetWindowTheme([In] IntPtr hwnd,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszSubAppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszSubIdList);

        /// <summary>
        ///     Handles the SelectedIndexChanged event of the listBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0)
            {
                btnAdd.Enabled = true;

                if (!_removing)
                    txtItemName.Text = "";
                btnRemB.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnRemB.Enabled = true;

                if (!_removing)
                    txtItemName.Text = lbxBudgets.SelectedItem.ToString();
            }
        }

        /// <summary>
        ///     Handles the Load event of the FrmCreateAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmCreateAccount_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the Click event of the btnRemB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRemB_Click(object sender, EventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0)
                return;

            _editAccount.Budgets.Remove(lbxBudgets.SelectedItem.ToString());
            lbxBudgets.Items.Remove(lbxBudgets.SelectedItem);

            if (lbxBudgets.SelectedItems.Count == 1)
                btnRemB.Enabled = false;
        }

        /// <summary>
        ///     Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!lbxBudgets.Items.Contains(txtItemName.Text))
            {
                _editAccount.Budgets.Add(txtItemName.Text);
                lbxBudgets.Items.Add(txtItemName.Text);
            }
            txtItemName.Text = "";
        }


        /// <summary>
        ///     Handles the TextChanged event of the txtItemName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0) return;

            if (txtItemName.Text == lbxBudgets.SelectedItem.ToString()) return;
            var index = lbxBudgets.SelectedIndex;
            var s = txtItemName.Text;
            _removing = true;

            lbxBudgets.Items.RemoveAt(index);
            lbxBudgets.Items.Insert(index, txtItemName.Text);

            _removing = false;

            lbxBudgets.SetSelected(lbxBudgets.Items.IndexOf(s), true);
        }

        /// <summary>
        ///     Handles the FormClosing event of the FrmCreateAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        private void FrmCreateAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            if (cbxCurrency.SelectedItem != null) return;
            e.Cancel = true;
            errorProvider.SetError(cbxCurrency, "!");
        }

        /// <summary>
        ///     Handles the SelectedIndexChanged event of the cbxCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cbxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(cbxCurrency, null);
        }
    }
}