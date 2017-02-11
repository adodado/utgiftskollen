using Finances.NET.Utils.Components;

namespace Finances.NET.Forms.Operations
{
    partial class FrmOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperation));
            this.mcDate = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxBudget = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.mupDebit = new Finances.NET.Utils.Components.MoneyUpDown();
            this.mupCredit = new Finances.NET.Utils.Components.MoneyUpDown();
            this.chkMonthly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.mupDebit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupCredit)).BeginInit();
            this.SuspendLayout();
            // 
            // mcDate
            // 
            resources.ApplyResources(this.mcDate, "mcDate");
            this.mcDate.MaxSelectionCount = 1;
            this.mcDate.Name = "mcDate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            resources.GetString("cbxType.Items"),
            resources.GetString("cbxType.Items1"),
            resources.GetString("cbxType.Items2"),
            resources.GetString("cbxType.Items3"),
            resources.GetString("cbxType.Items4")});
            resources.ApplyResources(this.cbxType, "cbxType");
            this.cbxType.Name = "cbxType";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cbxBudget
            // 
            this.cbxBudget.FormattingEnabled = true;
            resources.ApplyResources(this.cbxBudget, "cbxBudget");
            this.cbxBudget.Name = "cbxBudget";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtComm
            // 
            resources.ApplyResources(this.txtComm, "txtComm");
            this.txtComm.Name = "txtComm";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // mupDebit
            // 
            this.mupDebit.Currency = "kr";
            this.mupDebit.DecimalPlaces = 2;
            resources.ApplyResources(this.mupDebit, "mupDebit");
            this.mupDebit.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupDebit.Name = "mupDebit";
            this.mupDebit.Enter += new System.EventHandler(this.mupDebit_Enter);
            this.mupDebit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mupDebit_KeyUp);
            // 
            // mupCredit
            // 
            this.mupCredit.Currency = "kr";
            this.mupCredit.DecimalPlaces = 2;
            resources.ApplyResources(this.mupCredit, "mupCredit");
            this.mupCredit.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupCredit.Name = "mupCredit";
            this.mupCredit.Enter += new System.EventHandler(this.mupCredit_Enter);
            this.mupCredit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mupCredit_KeyUp);
            // 
            // chkMonthly
            // 
            resources.ApplyResources(this.chkMonthly, "chkMonthly");
            this.chkMonthly.Name = "chkMonthly";
            this.chkMonthly.UseVisualStyleBackColor = true;
            // 
            // FrmOperation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.chkMonthly);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtComm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxBudget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mupDebit);
            this.Controls.Add(this.mupCredit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mcDate);
            this.Name = "FrmOperation";
            ((System.ComponentModel.ISupportInitialize)(this.mupDebit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupCredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.MonthCalendar mcDate;

        public System.Windows.Forms.ComboBox cbxType;
        public MoneyUpDown mupCredit;
        public MoneyUpDown mupDebit;
        public System.Windows.Forms.ComboBox cbxBudget;
        public System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.CheckBox chkMonthly;

    }
}