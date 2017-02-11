namespace Finances.NET.Forms.Options
{
    partial class FrmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxDftCrc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLng = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxMinPasswordLength = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxIterations = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxKeySize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vsbMain = new System.Windows.Forms.VScrollBar();
            this.panel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Name = "panel1";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbxDftCrc
            // 
            resources.ApplyResources(this.cbxDftCrc, "cbxDftCrc");
            this.cbxDftCrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDftCrc.FormattingEnabled = true;
            this.cbxDftCrc.Name = "cbxDftCrc";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbxLng
            // 
            resources.ApplyResources(this.cbxLng, "cbxLng");
            this.cbxLng.FormattingEnabled = true;
            this.cbxLng.Items.AddRange(new object[] {
            resources.GetString("cbxLng.Items"),
            resources.GetString("cbxLng.Items1"),
            resources.GetString("cbxLng.Items2")});
            this.cbxLng.Name = "cbxLng";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.cbxMinPasswordLength);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.cbxIterations);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.cbxKeySize);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.cbxDftCrc);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.cbxLng);
            this.pnlMain.Name = "pnlMain";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cbxMinPasswordLength
            // 
            resources.ApplyResources(this.cbxMinPasswordLength, "cbxMinPasswordLength");
            this.cbxMinPasswordLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMinPasswordLength.FormattingEnabled = true;
            this.cbxMinPasswordLength.Items.AddRange(new object[] {
            resources.GetString("cbxMinPasswordLength.Items"),
            resources.GetString("cbxMinPasswordLength.Items1"),
            resources.GetString("cbxMinPasswordLength.Items2"),
            resources.GetString("cbxMinPasswordLength.Items3"),
            resources.GetString("cbxMinPasswordLength.Items4")});
            this.cbxMinPasswordLength.Name = "cbxMinPasswordLength";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cbxIterations
            // 
            resources.ApplyResources(this.cbxIterations, "cbxIterations");
            this.cbxIterations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIterations.FormattingEnabled = true;
            this.cbxIterations.Items.AddRange(new object[] {
            resources.GetString("cbxIterations.Items"),
            resources.GetString("cbxIterations.Items1"),
            resources.GetString("cbxIterations.Items2"),
            resources.GetString("cbxIterations.Items3")});
            this.cbxIterations.Name = "cbxIterations";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Name = "label5";
            // 
            // cbxKeySize
            // 
            resources.ApplyResources(this.cbxKeySize, "cbxKeySize");
            this.cbxKeySize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKeySize.FormattingEnabled = true;
            this.cbxKeySize.Items.AddRange(new object[] {
            resources.GetString("cbxKeySize.Items"),
            resources.GetString("cbxKeySize.Items1"),
            resources.GetString("cbxKeySize.Items2")});
            this.cbxKeySize.Name = "cbxKeySize";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // vsbMain
            // 
            resources.ApplyResources(this.vsbMain, "vsbMain");
            this.vsbMain.Name = "vsbMain";
            // 
            // FrmOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.vsbMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmOptions";
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.panel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxDftCrc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.VScrollBar vsbMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxKeySize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxIterations;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxMinPasswordLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;

    }
}