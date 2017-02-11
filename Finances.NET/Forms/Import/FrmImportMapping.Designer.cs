namespace Finances.NET.Forms.Import
{
    partial class FrmImportMapping
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportMapping));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridColumnMapping = new System.Windows.Forms.DataGridView();
            this.ImportFileColumns = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OperationPropertyColumns = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridColumnMapping
            // 
            resources.ApplyResources(this.dataGridColumnMapping, "dataGridColumnMapping");
            this.dataGridColumnMapping.AllowUserToAddRows = false;
            this.dataGridColumnMapping.AllowUserToDeleteRows = false;
            this.dataGridColumnMapping.BackgroundColor = System.Drawing.Color.White;
            this.dataGridColumnMapping.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridColumnMapping.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridColumnMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridColumnMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImportFileColumns,
            this.OperationPropertyColumns});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridColumnMapping.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridColumnMapping.Name = "dataGridColumnMapping";
            this.dataGridColumnMapping.RowHeadersVisible = false;
            this.dataGridColumnMapping.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.dataGridColumnMapping.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridColumnMapping.RowTemplate.Height = 30;
            // 
            // ImportFileColumns
            // 
            resources.ApplyResources(this.ImportFileColumns, "ImportFileColumns");
            this.ImportFileColumns.Name = "ImportFileColumns";
            // 
            // OperationPropertyColumns
            // 
            resources.ApplyResources(this.OperationPropertyColumns, "OperationPropertyColumns");
            this.OperationPropertyColumns.Name = "OperationPropertyColumns";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblInformation
            // 
            resources.ApplyResources(this.lblInformation, "lblInformation");
            this.lblInformation.Name = "lblInformation";
            // 
            // FrmImportMapping
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dataGridColumnMapping);
            this.Name = "FrmImportMapping";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridColumnMapping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridColumnMapping;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.DataGridViewComboBoxColumn ImportFileColumns;
        private System.Windows.Forms.DataGridViewComboBoxColumn OperationPropertyColumns;
    }
}