using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finances.NET.Core.Accounts;
using Finances.NET.Core.Operations;
using Microsoft.Reporting.WinForms;

namespace Finances.NET.TransactionsReport.Plugin
{
    /// <summary>
    /// Class FrmTransactionsReport.
    /// </summary>
    public partial class FrmTransactionsReport : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmTransactionsReport"/> class.
        /// </summary>
        /// <param name="account">The account.</param>
        public FrmTransactionsReport(Account account)
        {
            InitializeComponent();
            CreateRaport(account);
        }

        /// <summary>
        /// Creates the raport.
        /// </summary>
        /// <param name="account">The account.</param>
        private void CreateRaport(Account account)
        {
            var data = CreateDataSet(account.Operations);
            data.DataSetName = "OperationsDataset";
            var datasource = new
                ReportDataSource("OperationsDataset",
                    data.Tables[0]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasource);
        }

        /// <summary>
        /// Handles the Load event of the FrmTransactionsReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmTransactionsReport_Load(object sender, EventArgs e)
        {

            reportViewer1.RefreshReport();
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// Creates the data set.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns>System.Data.DataSet.</returns>
        public System.Data.DataSet CreateDataSet<T>(List<T> list)
        {
            //list is nothing or has nothing, return nothing (or add exception handling)
            if (list == null || list.Count == 0) { return null; }

            //get the type of the first obj in the list
            var obj = list[0].GetType();

            //now grab all properties
            var properties = obj.GetProperties();

            //make sure the obj has properties, return nothing (or add exception handling)
            if (properties.Length == 0) { return null; }

            //it does so create the dataset and table
            var dataSet = new System.Data.DataSet();
            var dataTable = new DataTable();

            //now build the columns from the properties
            var columns = new DataColumn[properties.Length];
            for (var i = 0; i < properties.Length; i++)
            {
                columns[i] = new DataColumn(properties[i].Name, properties[i].PropertyType);
            }

            //add columns to table
            dataTable.Columns.AddRange(columns);

            //now add the list values to the table
            foreach (var item in list)
            {
                //create a new row from table
                var dataRow = dataTable.NewRow();

                //now we have to iterate thru each property of the item and retrieve it's value for the corresponding row's cell
                var itemProperties = item.GetType().GetProperties();

                for (var i = 0; i < itemProperties.Length; i++)
                {
                    dataRow[i] = itemProperties[i].GetValue(item, null);
                }

                //now add the populated row to the table
                dataTable.Rows.Add(dataRow);
            }

            //add table to dataset
            dataSet.Tables.Add(dataTable);

            //return dataset
            return dataSet;
        }

    }
}
