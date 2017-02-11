#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Finances.NET.Core.Accounts;
using Finances.NET.Core.Currencies;
using Finances.NET.Core.Operations;
using Finances.NET.Forms;
using Finances.NET.Forms.Import;
using Finances.NET.Forms.Operations;
using Finances.NET.Forms.Options;
using Finances.NET.PluginContract;
using Finances.NET.Properties;
using Finances.NET.Utils;
using Finances.NET.Utils.Excel;
using Finances.NET.Utils.Renderer;
using Ookii.Dialogs;

#endregion

namespace Finances.NET
{
    /// <summary>
    ///     Class MainWindow.
    /// </summary>
    public partial class MainWindow : Form
    {
        #region Fields

        /// <summary>
        ///     The win1252 cp
        /// </summary>
        private const int Win1252Cp = 1252;

        /// <summary>
        ///     The stringresources manager class
        /// </summary>
        private readonly StringResources _stringResourcesManager;

        /// <summary>
        ///     The account repository
        /// </summary>
        public AccountsRepository AccountRepository = null;

        /// <summary>
        ///     The current account
        /// </summary>
        public Account CurrentAccount = null;

        /// <summary>
        ///     The current balance
        /// </summary>
        public decimal CurrentBalance = 0;

        /// <summary>
        ///     The current file
        /// </summary>
        public string CurrentFile = string.Empty;

        /// <summary>
        ///     The LVW column sorter
        /// </summary>
        public ListViewColumnSorter LvwColumnSorter = new ListViewColumnSorter();

        /// <summary>
        ///     The _current file name
        /// </summary>
        private string _currentFileName;

        /// <summary>
        ///     The win1252 cp
        /// </summary>
        private string _password = string.Empty;

        #endregion Fields

        #region Properties

        /// <summary>
        ///     Gets options for controlling the create.
        /// </summary>
        /// <value>
        ///     A <see cref="T:System.Windows.Forms.CreateParams" /> that contains the required creation
        ///     parameters when the handle to the control is created.
        /// </value>
        /// <returns>
        ///     A <see cref="T:System.Windows.Forms.CreateParams" /> that contains the required creation parameters when the
        ///     handle to the control is created.
        /// </returns>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        /// <summary>
        ///     Gets the dfd.
        /// </summary>
        /// <value>The dfd.</value>
        private string dfd
        {
            get { return Currency.All.First(x => x.ShortName == Settings.Default.DefaultCurrency).Symbol; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public MainWindow()
        {
            _stringResourcesManager = new StringResources();

            InitializeComponent();
            InitRenderers();
            SetWindowTheme(lvOps.Handle, "Explorer", null);
            ClearStuff();

            lvOps.DrawItem += lvOps_DrawItem;
            lvOps.ListViewItemSorter = LvwColumnSorter;
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="file">The file.</param>
        public MainWindow(string file)
        {
            InitializeComponent();
            InitRenderers();
            SetWindowTheme(lvOps.Handle, "Explorer", null);
            _stringResourcesManager = new StringResources();

            ClearStuff();
            SetupPlugins();

            lvOps.DrawItem += lvOps_DrawItem;
            lvOps.ListViewItemSorter = LvwColumnSorter;
            CurrentFile = file;
        }

        /// <summary>
        ///     Setups the plugins.
        /// </summary>
        private void SetupPlugins()
        {
            var pluginsDropDown = btnGraph.DropDown;
            var reportsDropDown = new ToolStripMenuItem
            {
                Name = "Reports",
                Text = _stringResourcesManager.GetString("REPORTS_PLUGINS"),
                Enabled = false
            };
            var chartsDropDown = new ToolStripMenuItem
            {
                Name = "Charts",
                Text = _stringResourcesManager.GetString("CHARTS_PLUGINS"),
                Enabled = false
            };
            var functionsDropDown = new ToolStripMenuItem
            {
                Name = "Functions",
                Text = _stringResourcesManager.GetString("FUNCTIONS_PLUGINS"),
                Enabled = false
            };
            var othersDropDown = new ToolStripMenuItem
            {
                Name = "Other",
                Text = _stringResourcesManager.GetString("OTHER_PLUGINS"),
                Enabled = false
            };

            pluginsDropDown.Items.Clear();
            pluginsDropDown.AutoSize = true;

            foreach (var item in Program.Plugins)
            {
                switch (item.Value.Type)
                {
                    case PluginType.Chart:
                    {
                        chartsDropDown.Enabled = true;
                        var name =
                            item.Value.Name.FirstOrDefault(a => a.Key == Settings.Default.Lang.ToString()).Value;
                        var b = new ToolStripButton {Text = name, Name = item.Key.ToString()};
                        b.Click += btnChart_Click;
                        b.Width = 120;
                        chartsDropDown.DropDownItems.Add(b);
                    }
                        break;
                    case PluginType.Report:
                    {
                        reportsDropDown.Enabled = true;
                        var name =
                            item.Value.Name.FirstOrDefault(a => a.Key == Settings.Default.Lang.ToString()).Value;
                        var b = new ToolStripButton {Text = name, Name = item.Key.ToString()};
                        b.Click += btnChart_Click;
                        b.Width = 120;
                        reportsDropDown.DropDownItems.Add(b);
                    }
                        break;
                    case PluginType.Function:
                    {
                        functionsDropDown.Enabled = true;
                        var name =
                            item.Value.Name.FirstOrDefault(a => a.Key == Settings.Default.Lang.ToString()).Value;
                        var b = new ToolStripButton {Text = name, Name = item.Key.ToString()};
                        b.Click += btnChart_Click;
                        b.Width = 120;
                        functionsDropDown.DropDownItems.Add(b);
                    }
                        break;
                    case PluginType.Other:
                    {
                        othersDropDown.Enabled = true;
                        var name =
                            item.Value.Name.FirstOrDefault(a => a.Key == Settings.Default.Lang.ToString()).Value;
                        var b = new ToolStripButton {Text = name, Name = item.Key.ToString()};
                        b.Click += btnChart_Click;
                        b.Width = 120;
                        othersDropDown.DropDownItems.Add(b);
                    }
                        break;
                }
                pluginsDropDown.Items.Add(chartsDropDown);
                pluginsDropDown.Items.Add(reportsDropDown);
                pluginsDropDown.Items.Add(functionsDropDown);
                pluginsDropDown.Items.Add(othersDropDown);
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///     The Accounts repository.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        private void AccountRepositoryInfo(AccountsRepository accountRepository)
        {
            foreach (var account in accountRepository.Accounts)
            {
                cbxAccounts.Items.Add(account);
            }

            if (cbxAccounts.ComboBox != null)
            {
                cbxAccounts.ComboBox.DisplayMember = "Name";
                cbxAccounts.ComboBox.SelectedIndex = 0;
            }
            CurrentAccount = accountRepository.Accounts.FirstOrDefault();
            LoadOps();
        }

        /// <summary>
        ///     Event handler. Called by toolStripButton3 for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void AddOperationToAccount_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CurrentAccount);

            if (ae.ShowDialog() != DialogResult.OK) return;
            var op = new Operation
            {
                Type = ae.cbxType.SelectedItem.ToString(),
                Credit = ae.mupCredit.Value,
                Debit = ae.mupDebit.Value,
                Budget = ae.cbxBudget.SelectedItem.ToString(),
                Date = ae.mcDate.SelectionStart,
                Commentary = ae.txtComm.Text,
                Monthly = ae.chkMonthly.Checked
            };
            CurrentAccount.Operations.Add(op);

            if (op.Monthly)
            {
                op.Date.AddMonths(1);
                CurrentAccount.ScheduledTransactions.Add(op);
            }

            LoadOps();
        }

        /// <summary>
        ///     Event handler. Called by btnDelOp for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void btnDelOp_Click(object sender, EventArgs e)
        {
            CurrentAccount.Operations.RemoveAll(x => x.Id == lvOps.SelectedItems[0].Text);
            LoadOps();
        }

        /// <summary>
        ///     Event handler. Called by btnDuplOp for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void btnDuplOp_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CurrentAccount, true,
                CurrentAccount.Operations.First(x => x.Id == lvOps.SelectedItems[0].Text));
            if (ae.ShowDialog() != DialogResult.OK) return;

            var op = new Operation
            {
                Type = ae.cbxType.SelectedItem.ToString(),
                Credit = ae.mupCredit.Value,
                Debit = ae.mupDebit.Value,
                Budget = ae.cbxBudget.SelectedItem.ToString(),
                Date = ae.mcDate.SelectionStart,
                Commentary = ae.txtComm.Text
            };

            CurrentAccount.Operations.Add(op);
            LoadOps();
        }

        /// <summary>
        ///     Event handler. Called by btnImportExcel for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            if (ImportExcelFileDialog.ShowDialog() != DialogResult.OK) return;

            var importFile = ImportExcelFileDialog.FileName;
            var data = ExcelHelper.ReadExcelFile(importFile);
            var dialog = new FrmImportMapping(data);

            if (dialog.ShowDialog() != DialogResult.OK) return;

            var importData = dialog.ImportData;
            CurrentAccount.Operations.Clear();
            CurrentAccount.Operations.AddRange(ExcelHelper.DataTableToList(importData));
        }

        /// <summary>
        ///     Handles the Click event of the btnChart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnChart_Click(object sender, EventArgs e)
        {
            var b = sender as ToolStripButton;

            if (b == null) return;

            var key = new Guid(b.Name.ToString(CultureInfo.InvariantCulture));

            if (!Program.Plugins.ContainsKey(key)) return;

            var plugin = Program.Plugins[key];
            plugin.Execute(CurrentAccount, Settings.Default.Lang.ToString());
        }

        /// <summary>
        ///     Event handler. Called by btnOpen for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //TODO: Go over dataload methods and cleanup/refactor everything
            ClearStuff();

            if (AccountsOpenFileDialog.ShowDialog() != DialogResult.OK) return;
            _currentFileName = AccountsOpenFileDialog.FileName;

            AnimatedProgressControl.Loading = true;
            AnimatedProgressControl.Visible = true;
            ReadDataFromFileBackgroundWorker.RunWorkerAsync();

            SetupPlugins();
            var scheduler = new TransactionScheduler();
            scheduler.ProcessTransactions(CurrentAccount);
        }

        /// <summary>
        ///     Event handler. Called by btnOpt_Click for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void btnOpt_Click(object sender, EventArgs e)
        {
            var settings = new FrmOptions();

            if (settings.ShowDialog() == DialogResult.OK)
            {
                _stringResourcesManager.SwitchLanguage();
            }

            if (CurrentAccount == null) ClearStuff();
        }

        /// <summary>
        ///     Event handler. Called by btnSave for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO:Go over and cleanup/refactor datasave methods
            switch (Path.GetExtension(CurrentFile))
            {
                case ".cna":
                {
                    SaveDataToFileBackgroundWorker.RunWorkerAsync();
                    break;
                }
                case ".cne":
                {
                    var ax = new InputDialog
                    {
                        UsePasswordMasking = true,
                        MainInstruction = _stringResourcesManager.GetString("ENTER_ACCOUNT_PASSWORD")
                    };

                    if (ax.ShowDialog() == DialogResult.OK)
                    {
                        _password = ax.Input;
                        AccountRepository.Encrypted = true;
                        AnimatedProgressControl.Loading = true;
                        AnimatedProgressControl.Visible = true;
                        AnimatedProgressControl.StatusText = "";
                        SaveDataToFileBackgroundWorker.RunWorkerAsync();
                    }
                    break;
                }
            }
        }

        /// <summary>
        ///     Handles the SelectedIndexChanged event of the cbxAccounts control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cbxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentAccount = (Account) cbxAccounts.SelectedItem;
            LoadOps();
            LoadBalanceString();
        }

        /// <summary>
        ///     Clears and resets everything.
        /// </summary>
        public void ClearStuff()
        {
            if (CurrentAccount != null)
            {
                CurrentAccount = null;
                CurrentFile = "";
                CurrentBalance = 0;
            }

            btnEditAcc.Visible = false;
            toolStripSeparator1.Visible = false;
            btnImportExcel.Visible = false;
            btnAddOp.Visible = false;
            btnEditOp.Visible = false;
            btnDuplOp.Visible = false;
            btnDelOp.Visible = false;
            btnFilterOp.Visible = false;
            btnSave.Visible = false;
            btnGraph.Visible = false;
            lvOps.Items.Clear();
            Controls.Clear();
            InitializeComponent();
            InitRenderers();
            cbxAccounts.Items.Clear();
            lblAccountName.Text = _stringResourcesManager.GetString("NO_ACCOUNT_LOADED");
            lblBalance.Text = _stringResourcesManager.GetString("BALANCE") + @" 0,00 " + dfd;
            lblBalanceAt.Text = _stringResourcesManager.GetString("BALANCE_AT") + @" 0,00 " + dfd;
            lblTotalCredit.Text = @"0,00 " + dfd;
            lblTotalDeb.Text = @"0,00 " + dfd;
        }

        /// <summary>
        ///     Handles the Click event of the DeleteAccountToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DeleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountRepository.Accounts.Remove(CurrentAccount);
            cbxAccounts.Items.Remove(cbxAccounts.SelectedItem);

            if (cbxAccounts.Items.Count != 0)
                cbxAccounts.SelectedIndex = 0;

            if (AccountRepository.Accounts.Count != 0)
            {
                CurrentAccount = AccountRepository.Accounts.FirstOrDefault();
                SetupAccount();
            }

            else
                ClearStuff();

            MessageBox.Show(_stringResourcesManager.GetString("ACCOUNT_DELETED"),
                _stringResourcesManager.GetString("DELETE"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        ///     Event handler. Called by btnEditOp for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void EditOperation_Click(object sender, EventArgs e)
        {
            Operation monthlyOp = null;
            var monthly = CurrentAccount.Operations.First(x => x.Id == lvOps.SelectedItems[0].Text).Monthly;

            if (monthly)
            {
                monthlyOp = CurrentAccount.Operations.First(x => x.Id == lvOps.SelectedItems[0].Text);
            }

            var ae = new FrmOperation(CurrentAccount, true,
                CurrentAccount.Operations.First(x => x.Id == lvOps.SelectedItems[0].Text));

            if (ae.ShowDialog() != DialogResult.OK) return;

            var op = new Operation
            {
                Type = ae.cbxType.SelectedItem.ToString(),
                Credit = ae.mupCredit.Value,
                Debit = ae.mupDebit.Value,
                Budget = ae.cbxBudget.SelectedItem.ToString(),
                Date = ae.mcDate.SelectionStart,
                Commentary = ae.txtComm.Text,
                Monthly = ae.chkMonthly.Checked
            };

            var a =
                CurrentAccount.Operations.IndexOf(
                    CurrentAccount.Operations.First(x => x.Id == lvOps.SelectedItems[0].Text));
            CurrentAccount.Operations.RemoveAll(x => x.Id == lvOps.SelectedItems[0].Text);
            CurrentAccount.Operations.Insert(a, op);
            LoadOps();

            if (CurrentAccount.ScheduledTransactions == null)
                CurrentAccount.ScheduledTransactions = new List<Operation>();

            if (monthly)
            {
                if (op.Monthly) return;
                if (monthlyOp != null)
                    CurrentAccount.ScheduledTransactions.Remove(monthlyOp);
            }
            else
            {
                if (!op.Monthly) return;
                op.Date = op.Date.AddMonths(1);
                CurrentAccount.ScheduledTransactions.Add(op);
            }
        }

        /// <summary>
        ///     Event handler. Called by ExportToCSVToolStripMenuItem for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void ExportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CSVSaveFileDialog.ShowDialog() != DialogResult.OK) return;

            if (File.Exists(CSVSaveFileDialog.FileName))
                File.Delete(CSVSaveFileDialog.FileName);

            using (var wr = new StreamWriter(CSVSaveFileDialog.FileName, false, Encoding.GetEncoding(Win1252Cp)))
            {
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        wr.WriteLine("Date;Type;Budget;Comment;Credit;Debit");
                        break;
                    case "de-DE":
                        wr.WriteLine("Date;Type;Budget;Kommentar;Kredit;Debit");
                        break;
                    default: //case "sv-SE":
                        wr.WriteLine("Date;Type;Budget;Kommentar;Kredit;Debit");
                        break;
                }


                foreach (var op in CurrentAccount.Operations)
                {
                    var s = "";
                    s += op.Date.ToString("dd/MM/yyyy");
                    s += ";";
                    s += op.Type;
                    s += ";";
                    s += op.Budget;
                    s += ";";
                    s += op.Commentary;
                    s += ";";
                    s += op.Credit + " " + CurrentAccount.Currency.Symbol;
                    s += ";";
                    s += op.Debit + " " + CurrentAccount.Currency.Symbol;
                    wr.WriteLine(s);
                }
                wr.Close();
            }

            Process.Start(CSVSaveFileDialog.FileName);
        }

        /// <summary>
        ///     Event handler. Called by ExportToExcelToolStripMenuItem. Exports the Accountsinformation to excel.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void ExportToExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (XLSSaveFileDialog.ShowDialog() != DialogResult.OK) return;

            if (File.Exists(XLSSaveFileDialog.FileName))
                File.Delete(XLSSaveFileDialog.FileName);

            ExcelHelper.CreateSpreadsheetWorkbook(XLSSaveFileDialog.FileName, CurrentAccount.Operations);

            //TODO: Messagebox save complete

            Process.Start(XLSSaveFileDialog.FileName);
        }

        /// <summary>
        ///     Initializes the renderer.
        /// </summary>
        public void InitRenderers()
        {
            var rend = new Renderer
            {
                Colors =
                {
                    gripOffset = 1,
                    gripSquare = 2,
                    gripSize = 3,
                    gripMove = 4,
                    gripLines = 3,
                    checkInset = 1,
                    marginInset = 2,
                    separatorInset = 31,
                    cutToolItemMenu = 1f,
                    cutContextMenu = 0f,
                    cutMenuItemBack = 1.3f,
                    contextCheckTickThickness = 1.6f,
                    imageMargin = Color.Transparent,
                    insideTop1 = Color.FromArgb(80, 80, 80),
                    insideTop2 = Color.FromArgb(80, 80, 80),
                    insideBottom1 = Color.FromArgb(80, 80, 80),
                    insideBottom2 = Color.FromArgb(80, 80, 80),
                    fillTop1 = Color.FromArgb(75, 75, 75),
                    fillTop2 = Color.FromArgb(75, 75, 75),
                    fillBottom1 = Color.FromArgb(75, 75, 75),
                    fillBottom2 = Color.FromArgb(75, 75, 75),
                    borderColor1 = Color.FromArgb(20, 20, 20),
                    borderColor2 = Color.FromArgb(20, 20, 20),
                    disabledInsideTop1 = Color.FromArgb(160, 160, 160),
                    disabledInsideTop2 = Color.FromArgb(160, 160, 160),
                    disabledInsideBottom1 = Color.FromArgb(160, 160, 160),
                    disabledInsideBottom2 = Color.FromArgb(160, 160, 160),
                    disabledFillTop1 = Color.FromArgb(160, 160, 160),
                    disabledFillTop2 = Color.FromArgb(160, 160, 160),
                    disabledFillBottom1 = Color.FromArgb(160, 160, 160),
                    disabledFillBottom2 = Color.FromArgb(160, 160, 160),
                    disabledBorderColor1 = Color.FromArgb(130, 130, 130),
                    disabledBorderColor2 = Color.FromArgb(130, 130, 130),
                    textDisabled = Color.FromArgb(160, 160, 160),
                    textMenuStripItem = Color.LightGray,
                    textStatusStripItem = Color.LightGray,
                    textContextMenuItem = Color.LightGray,
                    textSelected = Color.LightGray,
                    arrowDisabled = Color.WhiteSmoke,
                    arrowLight = Color.WhiteSmoke,
                    arrowDark = Color.WhiteSmoke,
                    arrowSelected = Color.WhiteSmoke,
                    separatorMenuLight = Color.FromArgb(50, 50, 50),
                    separatorMenuDark = Color.FromArgb(50, 50, 50),
                    contextMenuBack = Color.FromArgb(50, 50, 50),
                    contextCheckBorder = Color.Transparent,
                    contextCheckBorderSelected = Color.Transparent,
                    contextCheckTick = Color.WhiteSmoke,
                    contextCheckTickSelected = Color.WhiteSmoke,
                    statusStripBorderDark = Color.FromArgb(50, 50, 50),
                    statusStripBorderLight = Color.FromArgb(50, 50, 50),
                    gripDark = Color.FromArgb(0, 0, 0),
                    gripLight = Color.FromArgb(0, 0, 0),
                    foreColor = Color.LightGray
                }
            };


            toolStrip.Renderer = rend.GetRenderer();
        }

        /// <summary>
        ///     Loads balance string.
        /// </summary>
        public void LoadBalanceString()
        {
            if (lvOps.SelectedItems.Count == 0)
            {
                lblBalanceAt.Text = _stringResourcesManager.GetString("BALANCE_AT");
                lblBalanceAt.Text += DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine +
                                     CurrentBalance.ToString("0.00") +
                                     @" " +
                                     CurrentAccount.Currency.Symbol;
            }
            else
            {
                var d = CurrentAccount.Operations.First(x2 => x2.Id == lvOps.SelectedItems[0].Text).Date;
                decimal totalc = 0;
                CurrentAccount.Operations.FindAll(
                    x =>
                        CurrentAccount.Operations.IndexOf(x) <=
                        CurrentAccount.Operations.IndexOf(
                            CurrentAccount.Operations.First(x2 => x2.Id == lvOps.SelectedItems[0].Text)))
                    .ForEach(x1 => totalc += x1.Credit);
                decimal totald = 0;
                CurrentAccount.Operations.FindAll(
                    x =>
                        CurrentAccount.Operations.IndexOf(x) <=
                        CurrentAccount.Operations.IndexOf(
                            CurrentAccount.Operations.First(x2 => x2.Id == lvOps.SelectedItems[0].Text)))
                    .ForEach(x1 => totald += x1.Debit);

                lblBalanceAt.Text = _stringResourcesManager.GetString("BALANCE_AT");
                lblBalanceAt.Text += d.ToString("dd/MM/yyyy") + Environment.NewLine + (totalc - totald).ToString("0.00") +
                                     @" " +
                                     CurrentAccount.Currency.Symbol;
            }
        }

        /// <summary>
        ///     Loads the account operations (transactions).
        /// </summary>
        public void LoadOps()
        {
            if (CurrentAccount == null)
                return;

            lvOps.BeginUpdate();
            lvOps.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvOps.Items.Clear();

            foreach (var op in CurrentAccount.Operations)
            {
                var it = new ListViewItem {Text = op.Id, Name = op.Id};
                it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                it.SubItems.Add(op.Type);
                it.SubItems.Add(op.Budget);
                it.SubItems.Add(op.Commentary);
                it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                lvOps.Items.Add(it);
            }

            lvOps.EndUpdate();

            decimal totalc = 0;
            CurrentAccount.Operations.ForEach(x1 => totalc += x1.Credit);
            lblTotalCredit.Text = totalc.ToString("0.00") + @" " + CurrentAccount.Currency.Symbol;

            decimal totald = 0;
            CurrentAccount.Operations.ForEach(x1 => totald += x1.Debit);
            lblTotalDeb.Text = totald.ToString("0.00") + @" " + CurrentAccount.Currency.Symbol;
            lblBalance.Text = _stringResourcesManager.GetString("BALANCE");
            lblBalance.Text += (totalc - totald).ToString("0.00") + @" " + CurrentAccount.Currency.Symbol;

            CurrentBalance = totalc - totald;
        }

        /// <summary>
        ///     Event handler. Called by lvOps for column click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Column click event information.</param>
        private void lvOps_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvOps.BeginUpdate();

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == LvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (LvwColumnSorter.Order == SortOrder.Ascending)
                {
                    LvwColumnSorter.Order = SortOrder.Descending;
                    lvOps.Sorting = SortOrder.Descending;
                }
                else
                {
                    LvwColumnSorter.Order = SortOrder.Ascending;
                    lvOps.Sorting = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                LvwColumnSorter.SortColumn = e.Column;
                LvwColumnSorter.Order = SortOrder.Ascending;
                lvOps.Sorting = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvOps.Sort();
            lvOps.EndUpdate();
        }

        /// <summary>
        ///     Event handler. Called by lvOps for draw item events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Draw list view item event information.</param>
        private void lvOps_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Item.ForeColor = SystemColors.HighlightText;
                e.Item.BackColor = SystemColors.Highlight;
            }
            else
            {
                e.Item.ForeColor = lvOps.ForeColor;
                e.Item.BackColor = lvOps.BackColor;
            }
        }

        /// <summary>
        ///     Event handler. Called by lvOps for selected index changed events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void lvOps_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditOp.Enabled = lvOps.SelectedItems.Count != 0;
            btnDuplOp.Enabled = lvOps.SelectedItems.Count != 0;
            btnDelOp.Enabled = lvOps.SelectedItems.Count != 0;

            LoadBalanceString();
        }

        /// <summary>
        ///     Event handler. Called by MainWindow for load events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            ClearStuff();
        }

        /// <summary>
        ///     Event handler. Called by MainWindow for shown events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void MainWindow_Shown(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the <see cref="E:DoWorkDataLoadFromFile" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs" /> instance containing the event data.</param>
        private void OnDoWorkDataLoadFromFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (Path.GetExtension(_currentFileName))
                {
                    case ".cna":
                        ReadDataFromFileBackgroundWorker.ReportProgress(-1,
                            _stringResourcesManager.GetString("LOADING_ACCOUNTS_FILE") + Environment.NewLine +
                            _currentFileName);
                        _password = string.Empty;
                        break;
                    case ".cne":
                        ReadDataFromFileBackgroundWorker.ReportProgress(-1,
                            _stringResourcesManager.GetString("DECRYPTING_ACCOUNTS_FILE") + Environment.NewLine +
                            _currentFileName);
                        break;
                }

                AccountRepository = FileHelper.FromFile(_currentFileName);
                ReadDataFromFileBackgroundWorker.ReportProgress(33,
                    _stringResourcesManager.GetString("ACCOUNTS_DATA_LOAD_FINISHED"));
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(
                        delegate
                        {
                            ReadDataFromFileBackgroundWorker.ReportProgress(66,
                                _stringResourcesManager.GetString("INITIALIZING_ACCOUNTS"));
                            AccountRepositoryInfo(AccountRepository);
                            CurrentFile = _currentFileName;
                            ReadDataFromFileBackgroundWorker.ReportProgress(90,
                                _stringResourcesManager.GetString("FINALIZING_ACCOUNT_SETUP"));
                            SetupAccount();
                        }));
                }
            }
            catch
            {
                ClearStuff();
                //TODO:Error messagebox
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:DoWorkSaveDataToFile" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs" /> instance containing the event data.</param>
        private void OnDoWorkSaveDataToFile(object sender, DoWorkEventArgs e)
        {
            if (CurrentFile != null && string.IsNullOrEmpty(_password))
            {
                SaveDataToFileBackgroundWorker.ReportProgress(-1,
                    _stringResourcesManager.GetString("SAVING_DATA_XML_FILE") + Environment.NewLine + CurrentFile);
                AccountRepository.FileHelper.SaveAs(AccountRepository, CurrentFile);
            }
            else if (CurrentFile != null && !string.IsNullOrEmpty(_password))
            {
                SaveDataToFileBackgroundWorker.ReportProgress(-1,
                    _stringResourcesManager.GetString("ENCRYPTING_DATA_XML_FILE") + Environment.NewLine + CurrentFile);
                AccountRepository.Encrypted = true;
                AccountRepository.FileHelper.SaveAs(AccountRepository, CurrentFile, _password);
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:ProgressChangedDataLoadFromFile" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs" /> instance containing the event data.</param>
        private void OnProgressChangedDataLoadFromFile(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
            {
                AnimatedProgressControl.StatusText = (String) e.UserState;
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:ProgressChangedSaveDataToFile" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs" /> instance containing the event data.</param>
        private void OnProgressChangedSaveDataToFile(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
            {
                AnimatedProgressControl.StatusText = (String) e.UserState;
            }
        }

        /// <summary>
        ///     Handles the <see cref="E:RunWorkerCompletedDataLoadFromFile" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs" /> instance containing the event data.</param>
        private void OnRunWorkerCompletedDataLoadFromFile(object sender, RunWorkerCompletedEventArgs e)
        {
            // hide animation
            AnimatedProgressControl.Visible = false;
        }

        /// <summary>
        ///     Handles the <see cref="E:RunWorkerCompletedSaveDataToFile" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs" /> instance containing the event data.</param>
        private void OnRunWorkerCompletedSaveDataToFile(object sender, RunWorkerCompletedEventArgs e)
        {
            // hide animation
            AnimatedProgressControl.Visible = false;
        }

        /// <summary>
        ///     Event handler. Called by cryptéToolStripMenuItem for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void SaveAsEncryptedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:Go over and cleanup/refactor datasave methods Also test encryption properly, maybe write unit tests?

            AccountsSaveFileDialog.Filter = _stringResourcesManager.GetString("ENCRYPTED_ACCOUNTS_FILE");

            if (AccountsSaveFileDialog.ShowDialog() != DialogResult.OK) return;

            var ax = new InputDialog
            {
                UsePasswordMasking = true,
                MainInstruction = _stringResourcesManager.GetString("ENTER_ACCOUNT_PASSWORD")
            };

            if (ax.ShowDialog() != DialogResult.OK) return;

            _password = ax.Input;
            AnimatedProgressControl.Loading = true;
            AnimatedProgressControl.Visible = true;
            AnimatedProgressControl.StatusText = "";
            AccountRepository.Encrypted = true;
            CurrentFile = AccountsSaveFileDialog.FileName;
            SaveDataToFileBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        ///     Event handler. Called by SaveAsToolStripMenuItem for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private
            void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:Go over and cleanup/refactor datasave methods
            CurrentFile = null;
            AccountsSaveFileDialog.Filter = _stringResourcesManager.GetString("ACCOUNTS_FILE");

            if (AccountsSaveFileDialog.ShowDialog() != DialogResult.OK) return;

            AnimatedProgressControl.Loading = true;
            AnimatedProgressControl.Visible = true;
            AnimatedProgressControl.StatusText = "";
            CurrentFile = AccountsSaveFileDialog.FileName;
            SaveDataToFileBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        ///     Setups the account.
        /// </summary>
        public void SetupAccount()
        {
            if (CurrentAccount == null)
                return;

            btnEditAcc.Visible = true;
            toolStripSeparator1.Visible = true;
            btnImportExcel.Visible = true;
            btnAddOp.Visible = true;
            btnEditOp.Visible = true;
            btnDuplOp.Visible = true;
            btnDelOp.Visible = true;
            btnFilterOp.Visible = true;
            btnSave.Visible = true;

            btnGraph.Visible = true;

            LoadOps();

            LoadBalanceString();

            lblAccountName.Text = CurrentFile;
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

        /// <summary>
        ///     Event handler. Called by toolStrip for paint events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Paint event information.</param>
        private void toolStrip_Paint(object sender, PaintEventArgs e)
        {
            var clr = Color.FromArgb(45, 45, 48);
            var a = toolStrip.Width;
            e.Graphics.DrawLine(new Pen(clr), a, 0, a, toolStrip.Height);
        }

        /// <summary>
        ///     Event handler. Called by toolStripButton1 for click events.
        /// </summary>
        /// <param name="sender">Source of the event.</param>
        /// <param name="e">Event information.</param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (AccountRepository == null)
            {
                if (CurrentAccount != null)
                    ClearStuff();

                var dialog = new FrmCreateAccount(setPassword: true);

                if (dialog.ShowDialog() != DialogResult.OK) return;

                AccountRepository = new AccountsRepository(CurrentFile);

                var account = new Account
                {
                    Name = dialog.txtName.Text,
                    Budgets = dialog.lbxBudgets.Items.Cast<string>().ToList()
                };

                account.ChangeCurrency(
                    Currency.All.First(x => x.Name == (string) (dialog.cbxCurrency.SelectedItem)));

                AccountRepository.Accounts.Add(account);
                cbxAccounts.Items.Add(account);

                if (cbxAccounts.ComboBox != null)
                {
                    cbxAccounts.ComboBox.DisplayMember = "Name";
                    cbxAccounts.ComboBox.SelectedIndex = cbxAccounts.Items.Count - 1;
                }

                CurrentAccount = account;
                SetupAccount();
            }
            else
            {
                var dialog = new FrmCreateAccount();

                if (dialog.ShowDialog() != DialogResult.OK) return;

                var account = new Account
                {
                    Name = dialog.txtName.Text,
                    Budgets = dialog.lbxBudgets.Items.Cast<string>().ToList()
                };

                account.ChangeCurrency(
                    Currency.All.First(x => x.Name == (string) (dialog.cbxCurrency.SelectedItem)));
                AccountRepository.Accounts.Add(account);
                cbxAccounts.Items.Add(account);

                if (cbxAccounts.ComboBox != null)
                {
                    cbxAccounts.ComboBox.DisplayMember = "Name";
                    cbxAccounts.ComboBox.SelectedIndex = cbxAccounts.Items.Count - 1;
                }

                CurrentAccount = account;
                LoadOps();
            }
        }

        #endregion Methods

        /// <summary>
        ///     Handles the Click event of the EditAccountToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void EditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ae = new FrmCreateAccount(CurrentAccount);

            if (ae.ShowDialog() != DialogResult.OK) return;

            CurrentAccount.Name = ae.txtName.Text;
            CurrentAccount.ChangeCurrency(Currency.All.First(x => x.Name == ae.cbxCurrency.SelectedItem.ToString()));

            SetupAccount();
        }

        /// <summary>
        /// Handles the Click event of the ScheduledTransactionsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ScheduledTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ae = new FrmScheduledOperations(CurrentAccount);

            if (ae.ShowDialog() != DialogResult.OK) return;
            CurrentAccount.ScheduledTransactions = ae.ScheduledOperations;
        }

        /// <summary>
        /// Handles the Click event of the filterTransactionsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void filterTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FrmOpFilter();

            if (dialog.ShowDialog() != DialogResult.OK) return;
            var filter = dialog.ResultFilter;

            lvOps.Items.Clear();
            foreach (var op in CurrentAccount.Operations)
            {
                switch (filter.Type)
                {
                    case OpFilterType.Date:
                        switch (filter.Order)
                        {
                            case OpFilterOrder.Equal:
                                if (op.Date == (DateTime)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                            case OpFilterOrder.Inf:
                                if (op.Date < (DateTime)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                            case OpFilterOrder.Sup:
                                if (op.Date > (DateTime)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                        }
                        break;
                    case OpFilterType.Credit:
                        switch (filter.Order)
                        {
                            case OpFilterOrder.Equal:
                                if (op.Credit == (decimal)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                            case OpFilterOrder.Inf:
                                if (op.Credit < (decimal)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                            case OpFilterOrder.Sup:
                                if (op.Credit > (decimal)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                        }
                        break;
                    case OpFilterType.Debit:
                        switch (filter.Order)
                        {
                            case OpFilterOrder.Equal:
                                if (op.Debit == (decimal)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                            case OpFilterOrder.Inf:
                                if (op.Debit < (decimal)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                            case OpFilterOrder.Sup:
                                if (op.Debit > (decimal)filter.Value)
                                {
                                    var it = new ListViewItem { Text = op.Id, Name = op.Id };
                                    it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                                    it.SubItems.Add(op.Type);
                                    it.SubItems.Add(op.Budget);
                                    it.SubItems.Add(op.Commentary);
                                    it.SubItems.Add(op.Credit + " " + CurrentAccount.Currency.Symbol);
                                    it.SubItems.Add(op.Debit + " " + CurrentAccount.Currency.Symbol);

                                    lvOps.Items.Add(it);
                                }
                                break;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the showAllTransactionsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showAllTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadOps();
        }
    }
}