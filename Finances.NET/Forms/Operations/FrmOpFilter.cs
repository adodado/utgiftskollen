#region

using System;
using System.Windows.Forms;

#endregion

namespace Finances.NET.Forms.Operations
{
    public partial class FrmOpFilter : Form
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmOpFilter" /> class.
        /// </summary>
        public FrmOpFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Gets the result filter.
        /// </summary>
        /// <value>The result filter.</value>
        public OpFilter ResultFilter { get; set; }

        /// <summary>
        ///     Handles the Load event of the FrmOpFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmOpFilter_Load(object sender, EventArgs e)
        {
            cbxFCmn.SelectedIndex = 0;
            cbxFType.SelectedIndex = 0;
        }

        /// <summary>
        ///     Handles the SelectedIndexChanged event of the cbxFCmn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cbxFCmn_SelectedIndexChanged(object sender, EventArgs e)
        {
            coolTabControl1.SelectTab(cbxFCmn.SelectedIndex);
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            ResultFilter = new OpFilter
            {
                Type = (OpFilterType)cbxFCmn.SelectedIndex+1,
                Order = (OpFilterOrder)cbxFType.SelectedIndex+1,
                Value =
                    cbxFCmn.SelectedIndex == 0
                        ? mupC.Value
                        : (cbxFCmn.SelectedIndex == 1 ? mupDb.Value : (object)dtpM.Value)
            };
        }
    }

    /// <summary>
    ///     Struct OpFilter
    /// </summary>
    public struct OpFilter
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public OpFilterType Type { get; set; }

        /// <summary>
        ///     Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public OpFilterOrder Order { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }
    }

    /// <summary>
    ///     Enum OpFilterType
    /// </summary>
    public enum OpFilterType
    {
        /// <summary>
        ///     The credit
        /// </summary>
        Credit = 1,

        /// <summary>
        ///     The debit
        /// </summary>
        Debit = 2,

        /// <summary>
        ///     The date
        /// </summary>
        Date = 3
    }

    /// <summary>
    ///     Enum OpFilterOrder
    /// </summary>
    public enum OpFilterOrder
    {
        /// <summary>
        ///     The inf
        /// </summary>
        Inf = 1,

        /// <summary>
        ///     The equal
        /// </summary>
        Equal = 2,

        /// <summary>
        ///     The sup
        /// </summary>
        Sup = 3
    }
}