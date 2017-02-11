namespace Finances.NET.Forms
{
    partial class FrmCreateAccount
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateAccount));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbxBudgets = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCurrency = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.errorProvider.SetError(this.txtName, resources.GetString("txtName.Error"));
            this.errorProvider.SetIconAlignment(this.txtName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtName.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtName, ((int)(resources.GetObject("txtName.IconPadding"))));
            this.txtName.Name = "txtName";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.btnCancel, resources.GetString("btnCancel.Error"));
            this.errorProvider.SetIconAlignment(this.btnCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnCancel, ((int)(resources.GetObject("btnCancel.IconPadding"))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbxBudgets
            // 
            resources.ApplyResources(this.lbxBudgets, "lbxBudgets");
            this.errorProvider.SetError(this.lbxBudgets, resources.GetString("lbxBudgets.Error"));
            this.lbxBudgets.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.lbxBudgets, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lbxBudgets.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lbxBudgets, ((int)(resources.GetObject("lbxBudgets.IconPadding"))));
            this.lbxBudgets.Items.AddRange(new object[] {
            resources.GetString("lbxBudgets.Items"),
            resources.GetString("lbxBudgets.Items1"),
            resources.GetString("lbxBudgets.Items2"),
            resources.GetString("lbxBudgets.Items3"),
            resources.GetString("lbxBudgets.Items4"),
            resources.GetString("lbxBudgets.Items5")});
            this.lbxBudgets.Name = "lbxBudgets";
            this.lbxBudgets.Sorted = true;
            this.lbxBudgets.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.errorProvider.SetError(this.btnOK, resources.GetString("btnOK.Error"));
            this.errorProvider.SetIconAlignment(this.btnOK, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnOK.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnOK, ((int)(resources.GetObject("btnOK.IconPadding"))));
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            resources.ApplyResources(this.txtItemName, "txtItemName");
            this.errorProvider.SetError(this.txtItemName, resources.GetString("txtItemName.Error"));
            this.errorProvider.SetIconAlignment(this.txtItemName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtItemName.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtItemName, ((int)(resources.GetObject("txtItemName.IconPadding"))));
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.errorProvider.SetError(this.label4, resources.GetString("label4.Error"));
            this.errorProvider.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding"))));
            this.label4.Name = "label4";
            // 
            // cbxCurrency
            // 
            resources.ApplyResources(this.cbxCurrency, "cbxCurrency");
            this.errorProvider.SetError(this.cbxCurrency, resources.GetString("cbxCurrency.Error"));
            this.cbxCurrency.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cbxCurrency, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbxCurrency.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cbxCurrency, ((int)(resources.GetObject("cbxCurrency.IconPadding"))));
            this.cbxCurrency.Name = "cbxCurrency";
            this.cbxCurrency.SelectedIndexChanged += new System.EventHandler(this.cbxCurrency_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.errorProvider.SetError(this.label5, resources.GetString("label5.Error"));
            this.errorProvider.SetIconAlignment(this.label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label5, ((int)(resources.GetObject("label5.IconPadding"))));
            this.label5.Name = "label5";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.errorProvider.SetError(this.btnAdd, resources.GetString("btnAdd.Error"));
            this.errorProvider.SetIconAlignment(this.btnAdd, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnAdd.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnAdd, ((int)(resources.GetObject("btnAdd.IconPadding"))));
            this.btnAdd.Image = global::Finances.NET.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemB
            // 
            resources.ApplyResources(this.btnRemB, "btnRemB");
            this.errorProvider.SetError(this.btnRemB, resources.GetString("btnRemB.Error"));
            this.errorProvider.SetIconAlignment(this.btnRemB, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnRemB.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnRemB, ((int)(resources.GetObject("btnRemB.IconPadding"))));
            this.btnRemB.Image = global::Finances.NET.Properties.Resources.delete;
            this.btnRemB.Name = "btnRemB";
            this.btnRemB.UseVisualStyleBackColor = true;
            this.btnRemB.Click += new System.EventHandler(this.btnRemB_Click);
            // 
            // FrmCreateAccount
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxCurrency);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemB);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbxBudgets);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateAccount";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCreateAccount_FormClosing);
            this.Load += new System.EventHandler(this.FrmCreateAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.ListBox lbxBudgets;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRemB;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbxCurrency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}