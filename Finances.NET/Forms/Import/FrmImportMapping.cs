#region

using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Finances.NET.Core.Operations;
using DataTable = System.Data.DataTable;

#endregion

namespace Finances.NET.Forms.Import
{
    /// <summary>
    /// Class FrmImportMapping.
    /// </summary>
    public partial class FrmImportMapping : Form
    {
        /// <summary>
        /// Gets or sets the import data.
        /// </summary>
        /// <value>The import data.</value>
        public DataTable ImportData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmImportMapping" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public FrmImportMapping(DataTable data)
        {
            InitializeComponent();
            ImportData = data;
            SetupDataGrid();
        }

        /// <summary>
        /// Setups the data grid.
        /// </summary>
        private void SetupDataGrid()
        {
            var columns = ImportData.Columns.Count;

            dataGridColumnMapping.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridColumnMapping.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridColumnMapping.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            for (var i = 0; i < columns; i++)
            {
                var importcombo = new DataGridViewComboBoxCell();
                var propcombo = new DataGridViewComboBoxCell();
                var importColumnsList = (from object col in ImportData.Columns select col.ToString()).ToList();
                var objectProperty = typeof (Operation).GetProperties().Select(prop => prop.Name).ToList();
                var newrow = new DataGridViewRow {MinimumHeight = 26};

                importcombo.DataSource = importColumnsList;
                importcombo.Value = importColumnsList[i];
                propcombo.DataSource = objectProperty;
                objectProperty.Add("UNKNOWN");

                var matches = objectProperty.FirstOrDefault().Where(stringCheck => stringCheck.ToString(CultureInfo.InvariantCulture)==importcombo.Value.ToString());
                
                propcombo.Value = matches.Count()!=0 ? importcombo.Value : "UNKNOWN";
                newrow.Cells.Add(importcombo);
                newrow.Cells.Add(propcombo);
                dataGridColumnMapping.Rows.Add(newrow);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnImport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnImport_Click(object sender, System.EventArgs e)
        {
            var rows = dataGridColumnMapping.Rows.Count;

            for (var i = 0; i < rows; i++)
            {
                var colString = dataGridColumnMapping.Rows[i].Cells[0].Value;
                var newColString = dataGridColumnMapping.Rows[i].Cells[1].Value;
             
                foreach (var item in ImportData.Columns.Cast<object>().Where(item => colString.ToString() == item.ToString()))
                {
                    ImportData.Columns[i].ColumnName = newColString.ToString();
                }
            }
        }
    }
}