#region

using System.Windows.Forms;

#endregion

namespace Finances.NET.Utils.Components
{
    /// <summary>
    ///     Class MoneyUpDown.
    /// </summary>
    public class MoneyUpDown : NumericUpDown
    {
        #region Fields

        /// <summary>
        ///     The _currency
        /// </summary>
        private string _currency = "kr";

        #endregion Fields

        #region Properties

        /// <summary>
        ///     Gets or sets the currency.
        /// </summary>
        /// <value>The devise.</value>
        public string Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                UpdateEditText();
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MoneyUpDown" /> class.
        /// </summary>
        public MoneyUpDown()
        {
            Maximum = 999999999999;
            DecimalPlaces = 2;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Displays the current value of the spin box (also known as an up-down control) in the appropriate format.
        /// </summary>
        protected override void UpdateEditText()
        {
            Text = Value + " " + Currency;
        }

        #endregion Methods
    }
}