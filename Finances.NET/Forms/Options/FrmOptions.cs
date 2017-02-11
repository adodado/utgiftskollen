#region

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Finances.NET.Properties;
using Finances.NET.Core.Currencies;

#endregion

namespace Finances.NET.Forms.Options
{
    /// <summary>
    ///     Class FrmOptions.
    /// </summary>
    public partial class FrmOptions : Form
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmOptions" /> class.
        /// </summary>
        public FrmOptions()
        {
            InitializeComponent();

            Currency.All.ForEach(x => cbxDftCrc.Items.Add(x.Name));
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            var cultureName = cbxLng.SelectedItem.ToString().Split('(')[1].Replace(")", "");

            Settings.Default.DefaultCurrency =
                Currency.All.First(x => x.Name == cbxDftCrc.SelectedItem.ToString()).ShortName;
            Settings.Default.Lang = (CultureInfo) new CultureInfoConverter().ConvertFromString(cultureName);
            Settings.Default.Iterations = Convert.ToInt32(cbxIterations.SelectedItem.ToString());
            Settings.Default.KeyBitSize = Convert.ToInt32(cbxKeySize.SelectedItem.ToString());
            Settings.Default.MinPasswordLength = Convert.ToInt32(cbxMinPasswordLength.SelectedItem.ToString());
            Settings.Default.Save();
        }

        /// <summary>
        ///     Handles the Load event of the FrmOptions control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmOptions_Load(object sender, EventArgs e)
        {
            cbxDftCrc.SelectedItem = ((CurrencyObject) (Settings.Default.DefaultCurrency)).Name;

            if (Settings.Default.Lang.Name == "sv-SE") cbxLng.SelectedIndex = 0;
            if (Settings.Default.Lang.Name == "en-US") cbxLng.SelectedIndex = 1;
            if (Settings.Default.Lang.Name == "de-DE") cbxLng.SelectedIndex = 2;

            cbxKeySize.SelectedIndex = cbxKeySize.FindString(Settings.Default.KeyBitSize.ToString());
            cbxMinPasswordLength.SelectedIndex =
                cbxMinPasswordLength.FindString(Settings.Default.MinPasswordLength.ToString());
            cbxIterations.SelectedIndex = cbxIterations.FindString(Settings.Default.Iterations.ToString());
        }

        /// <summary>
        ///     Sets the window theme.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="pszSubAppName">Name of the PSZ sub application.</param>
        /// <param name="pszSubIdList">The PSZ sub identifier list.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        #endregion Methods
    }
}