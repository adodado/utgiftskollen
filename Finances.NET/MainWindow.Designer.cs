using System.Windows.Forms;
using Finances.NET.Utils.Components;
using Finances.NET.Utils.UserControls;

namespace Finances.NET
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Generated codd

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblAccountName = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalCredit = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalDeb = new System.Windows.Forms.ToolStripStatusLabel();
            this.AccountsOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AccountsSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CSVSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.XLSSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ODSSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblBalanceAt = new System.Windows.Forms.Label();
            this.ReadDataFromFileBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SaveDataToFileBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ImportExcelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AnimatedProgressControl = new Finances.NET.Utils.UserControls.AnimatedProgressControl();
            this.lvOps = new Finances.NET.Utils.Components.DoubleBufferListView();
            this.clmnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnBudget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnComm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnCred = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDeb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip = new Finances.NET.Utils.Components.NoBorderToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripSplitButton();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsEncryptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.cbxAccounts = new System.Windows.Forms.ToolStripComboBox();
            this.btnEditAcc = new System.Windows.Forms.ToolStripSplitButton();
            this.DeleteAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduledTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImportExcel = new System.Windows.Forms.ToolStripButton();
            this.btnAddOp = new System.Windows.Forms.ToolStripButton();
            this.btnEditOp = new System.Windows.Forms.ToolStripButton();
            this.btnDuplOp = new System.Windows.Forms.ToolStripButton();
            this.btnDelOp = new System.Windows.Forms.ToolStripButton();
            this.btnFilterOp = new System.Windows.Forms.ToolStripDropDownButton();
            this.filterTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpt = new System.Windows.Forms.ToolStripButton();
            this.btnGraph = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAccountName,
            this.spacer,
            this.lblTotalCredit,
            this.lblTotalDeb});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // lblAccountName
            // 
            this.lblAccountName.ForeColor = System.Drawing.Color.LightGray;
            this.lblAccountName.Name = "lblAccountName";
            resources.ApplyResources(this.lblAccountName, "lblAccountName");
            // 
            // spacer
            // 
            this.spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.spacer.ForeColor = System.Drawing.Color.LightGray;
            this.spacer.Name = "spacer";
            resources.ApplyResources(this.spacer, "spacer");
            this.spacer.Spring = true;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            resources.ApplyResources(this.lblTotalCredit, "lblTotalCredit");
            // 
            // lblTotalDeb
            // 
            this.lblTotalDeb.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDeb.Name = "lblTotalDeb";
            this.lblTotalDeb.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            resources.ApplyResources(this.lblTotalDeb, "lblTotalDeb");
            // 
            // AccountsOpenFileDialog
            // 
            this.AccountsOpenFileDialog.DefaultExt = "cna";
            resources.ApplyResources(this.AccountsOpenFileDialog, "AccountsOpenFileDialog");
            // 
            // AccountsSaveFileDialog
            // 
            resources.ApplyResources(this.AccountsSaveFileDialog, "AccountsSaveFileDialog");
            // 
            // CSVSaveFileDialog
            // 
            this.CSVSaveFileDialog.DefaultExt = "csv";
            resources.ApplyResources(this.CSVSaveFileDialog, "CSVSaveFileDialog");
            // 
            // XLSSaveFileDialog
            // 
            this.XLSSaveFileDialog.DefaultExt = "xls";
            resources.ApplyResources(this.XLSSaveFileDialog, "XLSSaveFileDialog");
            // 
            // ODSSaveFileDialog
            // 
            this.ODSSaveFileDialog.DefaultExt = "ods";
            resources.ApplyResources(this.ODSSaveFileDialog, "ODSSaveFileDialog");
            // 
            // lblBalance
            // 
            resources.ApplyResources(this.lblBalance, "lblBalance");
            this.lblBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblBalance.Name = "lblBalance";
            // 
            // lblBalanceAt
            // 
            resources.ApplyResources(this.lblBalanceAt, "lblBalanceAt");
            this.lblBalanceAt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblBalanceAt.Name = "lblBalanceAt";
            // 
            // ReadDataFromFileBackgroundWorker
            // 
            this.ReadDataFromFileBackgroundWorker.WorkerReportsProgress = true;
            this.ReadDataFromFileBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWorkDataLoadFromFile);
            this.ReadDataFromFileBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChangedDataLoadFromFile);
            this.ReadDataFromFileBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnRunWorkerCompletedDataLoadFromFile);
            // 
            // SaveDataToFileBackgroundWorker
            // 
            this.SaveDataToFileBackgroundWorker.WorkerReportsProgress = true;
            this.SaveDataToFileBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWorkSaveDataToFile);
            this.SaveDataToFileBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChangedSaveDataToFile);
            this.SaveDataToFileBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnRunWorkerCompletedSaveDataToFile);
            // 
            // ImportExcelFileDialog
            // 
            resources.ApplyResources(this.ImportExcelFileDialog, "ImportExcelFileDialog");
            // 
            // AnimatedProgressControl
            // 
            resources.ApplyResources(this.AnimatedProgressControl, "AnimatedProgressControl");
            this.AnimatedProgressControl.BackColor = System.Drawing.Color.Transparent;
            this.AnimatedProgressControl.Cancel = false;
            this.AnimatedProgressControl.Error = false;
            this.AnimatedProgressControl.ForeColor = System.Drawing.Color.Black;
            this.AnimatedProgressControl.Information = false;
            this.AnimatedProgressControl.Loading = false;
            this.AnimatedProgressControl.Name = "AnimatedProgressControl";
            this.AnimatedProgressControl.StatusText = "";
            // 
            // lvOps
            // 
            this.lvOps.AllowColumnReorder = true;
            this.lvOps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnID,
            this.clmnDate,
            this.clmnType,
            this.clmnBudget,
            this.clmnComm,
            this.clmnCred,
            this.clmnDeb});
            resources.ApplyResources(this.lvOps, "lvOps");
            this.lvOps.FullRowSelect = true;
            this.lvOps.Name = "lvOps";
            this.lvOps.UseCompatibleStateImageBehavior = false;
            this.lvOps.View = System.Windows.Forms.View.Details;
            this.lvOps.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOps_ColumnClick);
            this.lvOps.SelectedIndexChanged += new System.EventHandler(this.lvOps_SelectedIndexChanged);
            // 
            // clmnID
            // 
            resources.ApplyResources(this.clmnID, "clmnID");
            // 
            // clmnDate
            // 
            resources.ApplyResources(this.clmnDate, "clmnDate");
            // 
            // clmnType
            // 
            resources.ApplyResources(this.clmnType, "clmnType");
            // 
            // clmnBudget
            // 
            resources.ApplyResources(this.clmnBudget, "clmnBudget");
            // 
            // clmnComm
            // 
            resources.ApplyResources(this.clmnComm, "clmnComm");
            // 
            // clmnCred
            // 
            resources.ApplyResources(this.clmnCred, "clmnCred");
            // 
            // clmnDeb
            // 
            resources.ApplyResources(this.clmnDeb, "clmnDeb");
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnNew,
            this.cbxAccounts,
            this.btnEditAcc,
            this.toolStripSeparator1,
            this.btnImportExcel,
            this.btnAddOp,
            this.btnEditOp,
            this.btnDuplOp,
            this.btnDelOp,
            this.btnFilterOp,
            this.btnOpt,
            this.btnGraph});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStrip_Paint);
            // 
            // btnOpen
            // 
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Image = global::Finances.NET.Properties.Resources.document_import;
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DropDownButtonWidth = 15;
            this.btnSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsToolStripMenuItem,
            this.SaveAsEncryptedToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem});
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Finances.NET.Properties.Resources.save;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.ButtonClick += new System.EventHandler(this.btnSave_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.save_as;
            resources.ApplyResources(this.SaveAsToolStripMenuItem, "SaveAsToolStripMenuItem");
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // SaveAsEncryptedToolStripMenuItem
            // 
            this.SaveAsEncryptedToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.document_protect;
            resources.ApplyResources(this.SaveAsEncryptedToolStripMenuItem, "SaveAsEncryptedToolStripMenuItem");
            this.SaveAsEncryptedToolStripMenuItem.Name = "SaveAsEncryptedToolStripMenuItem";
            this.SaveAsEncryptedToolStripMenuItem.Click += new System.EventHandler(this.SaveAsEncryptedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToCSVToolStripMenuItem,
            this.ExportToExcelToolStripMenuItem});
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            // 
            // ExportToCSVToolStripMenuItem
            // 
            this.ExportToCSVToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.csv;
            resources.ApplyResources(this.ExportToCSVToolStripMenuItem, "ExportToCSVToolStripMenuItem");
            this.ExportToCSVToolStripMenuItem.Name = "ExportToCSVToolStripMenuItem";
            this.ExportToCSVToolStripMenuItem.Click += new System.EventHandler(this.ExportToCSVToolStripMenuItem_Click);
            // 
            // ExportToExcelToolStripMenuItem
            // 
            this.ExportToExcelToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.icon_xlsx;
            resources.ApplyResources(this.ExportToExcelToolStripMenuItem, "ExportToExcelToolStripMenuItem");
            this.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem";
            this.ExportToExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItem_Click_1);
            // 
            // btnNew
            // 
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = global::Finances.NET.Properties.Resources.document_plus;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // cbxAccounts
            // 
            resources.ApplyResources(this.cbxAccounts, "cbxAccounts");
            this.cbxAccounts.DropDownWidth = 200;
            this.cbxAccounts.Items.AddRange(new object[] {
            resources.GetString("cbxAccounts.Items"),
            resources.GetString("cbxAccounts.Items1")});
            this.cbxAccounts.Name = "cbxAccounts";
            this.cbxAccounts.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cbxAccounts.SelectedIndexChanged += new System.EventHandler(this.cbxAccounts_SelectedIndexChanged);
            // 
            // btnEditAcc
            // 
            this.btnEditAcc.DropDownButtonWidth = 15;
            this.btnEditAcc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteAccountToolStripMenuItem,
            this.EditAccountToolStripMenuItem,
            this.ScheduledTransactionsToolStripMenuItem});
            this.btnEditAcc.Image = global::Finances.NET.Properties.Resources.document_prepare;
            resources.ApplyResources(this.btnEditAcc, "btnEditAcc");
            this.btnEditAcc.Name = "btnEditAcc";
            // 
            // DeleteAccountToolStripMenuItem
            // 
            this.DeleteAccountToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.page_delete;
            this.DeleteAccountToolStripMenuItem.Name = "DeleteAccountToolStripMenuItem";
            resources.ApplyResources(this.DeleteAccountToolStripMenuItem, "DeleteAccountToolStripMenuItem");
            this.DeleteAccountToolStripMenuItem.Click += new System.EventHandler(this.DeleteAccountToolStripMenuItem_Click);
            // 
            // EditAccountToolStripMenuItem
            // 
            this.EditAccountToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.page_edit;
            this.EditAccountToolStripMenuItem.Name = "EditAccountToolStripMenuItem";
            resources.ApplyResources(this.EditAccountToolStripMenuItem, "EditAccountToolStripMenuItem");
            this.EditAccountToolStripMenuItem.Click += new System.EventHandler(this.EditAccountToolStripMenuItem_Click);
            // 
            // ScheduledTransactionsToolStripMenuItem
            // 
            this.ScheduledTransactionsToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.Document_scheduled_tasks_icon;
            this.ScheduledTransactionsToolStripMenuItem.Name = "ScheduledTransactionsToolStripMenuItem";
            resources.ApplyResources(this.ScheduledTransactionsToolStripMenuItem, "ScheduledTransactionsToolStripMenuItem");
            this.ScheduledTransactionsToolStripMenuItem.Click += new System.EventHandler(this.ScheduledTransactionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Image = global::Finances.NET.Properties.Resources.ExcelOfficeIcon;
            resources.ApplyResources(this.btnImportExcel, "btnImportExcel");
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnAddOp
            // 
            this.btnAddOp.Image = global::Finances.NET.Properties.Resources.page_add;
            resources.ApplyResources(this.btnAddOp, "btnAddOp");
            this.btnAddOp.Name = "btnAddOp";
            this.btnAddOp.Click += new System.EventHandler(this.AddOperationToAccount_Click);
            // 
            // btnEditOp
            // 
            resources.ApplyResources(this.btnEditOp, "btnEditOp");
            this.btnEditOp.Image = global::Finances.NET.Properties.Resources.page_edit;
            this.btnEditOp.Name = "btnEditOp";
            this.btnEditOp.Click += new System.EventHandler(this.EditOperation_Click);
            // 
            // btnDuplOp
            // 
            resources.ApplyResources(this.btnDuplOp, "btnDuplOp");
            this.btnDuplOp.Image = global::Finances.NET.Properties.Resources.page_copy;
            this.btnDuplOp.Name = "btnDuplOp";
            this.btnDuplOp.Click += new System.EventHandler(this.btnDuplOp_Click);
            // 
            // btnDelOp
            // 
            resources.ApplyResources(this.btnDelOp, "btnDelOp");
            this.btnDelOp.Image = global::Finances.NET.Properties.Resources.page_delete;
            this.btnDelOp.Name = "btnDelOp";
            this.btnDelOp.Click += new System.EventHandler(this.btnDelOp_Click);
            // 
            // btnFilterOp
            // 
            this.btnFilterOp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterTransactionsToolStripMenuItem,
            this.showAllTransactionsToolStripMenuItem});
            this.btnFilterOp.Image = global::Finances.NET.Properties.Resources.page_find;
            resources.ApplyResources(this.btnFilterOp, "btnFilterOp");
            this.btnFilterOp.Name = "btnFilterOp";
            // 
            // filterTransactionsToolStripMenuItem
            // 
            this.filterTransactionsToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.actions_document_file_doc_magnifying_search_zoom_magnify_loupe_magnifier_find_paper_look;
            this.filterTransactionsToolStripMenuItem.Name = "filterTransactionsToolStripMenuItem";
            resources.ApplyResources(this.filterTransactionsToolStripMenuItem, "filterTransactionsToolStripMenuItem");
            this.filterTransactionsToolStripMenuItem.Click += new System.EventHandler(this.filterTransactionsToolStripMenuItem_Click);
            // 
            // showAllTransactionsToolStripMenuItem
            // 
            this.showAllTransactionsToolStripMenuItem.Image = global::Finances.NET.Properties.Resources.Error;
            this.showAllTransactionsToolStripMenuItem.Name = "showAllTransactionsToolStripMenuItem";
            resources.ApplyResources(this.showAllTransactionsToolStripMenuItem, "showAllTransactionsToolStripMenuItem");
            this.showAllTransactionsToolStripMenuItem.Click += new System.EventHandler(this.showAllTransactionsToolStripMenuItem_Click);
            // 
            // btnOpt
            // 
            this.btnOpt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOpt.Image = global::Finances.NET.Properties.Resources.application_form_edit;
            resources.ApplyResources(this.btnOpt, "btnOpt");
            this.btnOpt.Name = "btnOpt";
            this.btnOpt.Click += new System.EventHandler(this.btnOpt_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.AutoToolTip = false;
            this.btnGraph.Image = global::Finances.NET.Properties.Resources.diagnostic_chart1;
            resources.ApplyResources(this.btnGraph, "btnGraph");
            this.btnGraph.Name = "btnGraph";
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.AnimatedProgressControl);
            this.Controls.Add(this.lblBalanceAt);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lvOps);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalCredit;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalDeb;
        private System.Windows.Forms.ToolStripStatusLabel spacer;
        private System.Windows.Forms.OpenFileDialog AccountsOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog AccountsSaveFileDialog;
        private System.Windows.Forms.SaveFileDialog CSVSaveFileDialog;
        private System.Windows.Forms.SaveFileDialog XLSSaveFileDialog;
        private System.Windows.Forms.SaveFileDialog ODSSaveFileDialog;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSplitButton btnSave;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsEncryptedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton btnEditAcc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddOp;
        private System.Windows.Forms.ToolStripButton btnEditOp;
        private System.Windows.Forms.ToolStripButton btnDuplOp;
        private System.Windows.Forms.ToolStripButton btnDelOp;
        private System.Windows.Forms.ToolStripButton btnOpt;
        private NoBorderToolStrip toolStrip;
        private System.Windows.Forms.ColumnHeader clmnID;
        private System.Windows.Forms.ColumnHeader clmnDate;
        private System.Windows.Forms.ColumnHeader clmnType;
        private System.Windows.Forms.ColumnHeader clmnBudget;
        private System.Windows.Forms.ColumnHeader clmnComm;
        private System.Windows.Forms.ColumnHeader clmnCred;
        private System.Windows.Forms.ColumnHeader clmnDeb;
        private DoubleBufferListView lvOps;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.ToolStripDropDownButton btnGraph;
        private System.Windows.Forms.Label lblBalanceAt;
        private System.Windows.Forms.ToolStripButton btnImportExcel;
        private System.Windows.Forms.ToolStripStatusLabel lblAccountName;
        private System.Windows.Forms.ToolStripComboBox cbxAccounts;
        private System.Windows.Forms.ToolStripButton btnNew;
        private AnimatedProgressControl AnimatedProgressControl;
        private System.ComponentModel.BackgroundWorker ReadDataFromFileBackgroundWorker;
        private ToolStripMenuItem DeleteAccountToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker SaveDataToFileBackgroundWorker;
        private OpenFileDialog ImportExcelFileDialog;
        private ToolStripMenuItem EditAccountToolStripMenuItem;
        private ToolStripMenuItem ScheduledTransactionsToolStripMenuItem;
        private ToolStripDropDownButton btnFilterOp;
        private ToolStripMenuItem filterTransactionsToolStripMenuItem;
        private ToolStripMenuItem showAllTransactionsToolStripMenuItem;
    }
}

