using System;
using System.Windows.Forms;
using Finances.NET.OnlineUpdater.Interfaces;

namespace Finances.NET.OnlineUpdater.Forms
{
    public partial class FrmUpdateInformation : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmUpdateInformation" /> class.
        /// </summary>
        /// <param name="applicationUpdatable">The application updatable.</param>
        /// <param name="updateInformationXml">The update information XML.</param>
        public FrmUpdateInformation(IFinancesNetUpdatable applicationUpdatable, UpdateXml updateInformationXml)
        {
            InitializeComponent();
            if (applicationUpdatable.ApplicationIcon != null)
                Icon = applicationUpdatable.ApplicationIcon;
            Text = applicationUpdatable.AplicationName;
            lblVersion.Text = string.Format("Current version {0}\nUpdate version {1}",applicationUpdatable.ApplicationAssembly.GetName().Version,updateInformationXml.Version);
            richDescription.Text = updateInformationXml.Description;
        }

        /// <summary>
        /// Handles the Click event of the btnBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the KeyDown event of the richDescription control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void richDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C))
                e.SuppressKeyPress = true;
        }
    }
}
