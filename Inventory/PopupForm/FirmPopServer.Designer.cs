namespace Inventory.PopupForm
{
    partial class FirmPopServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmPopServer));
            this.gbCON = new DevExpress.XtraEditors.GroupControl();
            this.bntCLR = new DevExpress.XtraEditors.SimpleButton();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.txtThirdKey = new DevExpress.XtraEditors.TextEdit();
            this.txtSecondKey = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstKey = new DevExpress.XtraEditors.TextEdit();
            this.txtComputerName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bntSVA = new DevExpress.XtraEditors.SimpleButton();
            this.bntCAN = new DevExpress.XtraEditors.SimpleButton();
            this.regWET = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).BeginInit();
            this.gbCON.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThirdKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecondKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComputerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCON
            // 
            this.gbCON.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gbCON.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gbCON.Appearance.Options.UseBackColor = true;
            this.gbCON.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gbCON.Controls.Add(this.bntCLR);
            this.gbCON.Controls.Add(this.lblMainTitle);
            this.gbCON.Controls.Add(this.txtThirdKey);
            this.gbCON.Controls.Add(this.txtSecondKey);
            this.gbCON.Controls.Add(this.txtFirstKey);
            this.gbCON.Controls.Add(this.txtComputerName);
            this.gbCON.Controls.Add(this.label3);
            this.gbCON.Controls.Add(this.label2);
            this.gbCON.Controls.Add(this.bntSVA);
            this.gbCON.Controls.Add(this.bntCAN);
            this.gbCON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCON.Location = new System.Drawing.Point(0, 0);
            this.gbCON.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gbCON.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gbCON.Name = "gbCON";
            this.gbCON.Size = new System.Drawing.Size(742, 308);
            this.gbCON.TabIndex = 8;
            // 
            // bntCLR
            // 
            this.bntCLR.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntCLR.ImageOptions.Image")));
            this.bntCLR.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntCLR.Location = new System.Drawing.Point(357, 224);
            this.bntCLR.Name = "bntCLR";
            this.bntCLR.Size = new System.Drawing.Size(169, 44);
            this.bntCLR.TabIndex = 6;
            this.bntCLR.ToolTip = "Service Manual";
            this.bntCLR.Click += new System.EventHandler(this.bntCLR_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(213, 31);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(452, 47);
            this.lblMainTitle.TabIndex = 216;
            this.lblMainTitle.Text = "SET AUTHORIZATION KEY";
            // 
            // txtThirdKey
            // 
            this.txtThirdKey.EditValue = "";
            this.txtThirdKey.Location = new System.Drawing.Point(532, 159);
            this.txtThirdKey.Name = "txtThirdKey";
            this.txtThirdKey.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtThirdKey.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtThirdKey.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            this.txtThirdKey.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtThirdKey.Properties.Appearance.Options.UseBackColor = true;
            this.txtThirdKey.Properties.Appearance.Options.UseBorderColor = true;
            this.txtThirdKey.Properties.Appearance.Options.UseFont = true;
            this.txtThirdKey.Size = new System.Drawing.Size(169, 44);
            this.txtThirdKey.TabIndex = 4;
            this.txtThirdKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPSS_KeyDown);
            // 
            // txtSecondKey
            // 
            this.txtSecondKey.EditValue = "";
            this.txtSecondKey.Location = new System.Drawing.Point(357, 161);
            this.txtSecondKey.Name = "txtSecondKey";
            this.txtSecondKey.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSecondKey.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtSecondKey.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.txtSecondKey.Properties.Appearance.Options.UseBackColor = true;
            this.txtSecondKey.Properties.Appearance.Options.UseFont = true;
            this.txtSecondKey.Size = new System.Drawing.Size(169, 44);
            this.txtSecondKey.TabIndex = 2;
            this.txtSecondKey.TextChanged += new System.EventHandler(this.txtSecondKey_TextChanged);
            this.txtSecondKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUSR_KeyDown);
            // 
            // txtFirstKey
            // 
            this.txtFirstKey.EditValue = "";
            this.txtFirstKey.Location = new System.Drawing.Point(182, 161);
            this.txtFirstKey.Name = "txtFirstKey";
            this.txtFirstKey.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFirstKey.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtFirstKey.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstKey.Properties.Appearance.Options.UseBackColor = true;
            this.txtFirstKey.Properties.Appearance.Options.UseFont = true;
            this.txtFirstKey.Size = new System.Drawing.Size(169, 44);
            this.txtFirstKey.TabIndex = 3;
            this.txtFirstKey.TextChanged += new System.EventHandler(this.txtFirstKey_TextChanged);
            this.txtFirstKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDAT_KeyDown);
            // 
            // txtComputerName
            // 
            this.txtComputerName.EditValue = "";
            this.txtComputerName.Enabled = false;
            this.txtComputerName.Location = new System.Drawing.Point(182, 109);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtComputerName.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtComputerName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.txtComputerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtComputerName.Properties.Appearance.Options.UseFont = true;
            this.txtComputerName.Size = new System.Drawing.Size(519, 46);
            this.txtComputerName.TabIndex = 1;
            this.txtComputerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNAM_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(15, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 41);
            this.label3.TabIndex = 181;
            this.label3.Text = "PC NAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(15, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 37);
            this.label2.TabIndex = 177;
            this.label2.Text = "PRIME KEY:";
            // 
            // bntSVA
            // 
            this.bntSVA.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.bntSVA.Appearance.Options.UseFont = true;
            this.bntSVA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSVA.ImageOptions.Image")));
            this.bntSVA.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntSVA.Location = new System.Drawing.Point(182, 224);
            this.bntSVA.Name = "bntSVA";
            this.bntSVA.Size = new System.Drawing.Size(169, 44);
            this.bntSVA.TabIndex = 5;
            this.bntSVA.Text = "REG";
            this.bntSVA.ToolTip = "User Manual";
            this.bntSVA.Click += new System.EventHandler(this.bntSVA_Click);
            // 
            // bntCAN
            // 
            this.bntCAN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntCAN.ImageOptions.Image")));
            this.bntCAN.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntCAN.Location = new System.Drawing.Point(532, 224);
            this.bntCAN.Name = "bntCAN";
            this.bntCAN.Size = new System.Drawing.Size(169, 44);
            this.bntCAN.TabIndex = 7;
            this.bntCAN.ToolTip = "Service Manual";
            this.bntCAN.Click += new System.EventHandler(this.bntCAN_Click);
            // 
            // regWET
            // 
            this.regWET.ClosingDelay = 500;
            // 
            // FirmPopServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 308);
            this.Controls.Add(this.gbCON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirmPopServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmPopServer";
            this.Load += new System.EventHandler(this.FirmPopServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).EndInit();
            this.gbCON.ResumeLayout(false);
            this.gbCON.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThirdKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecondKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComputerName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbCON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton bntSVA;
        private DevExpress.XtraEditors.SimpleButton bntCAN;
        private DevExpress.XtraEditors.TextEdit txtComputerName;
        private DevExpress.XtraEditors.TextEdit txtFirstKey;
        private DevExpress.XtraEditors.TextEdit txtThirdKey;
        private DevExpress.XtraEditors.TextEdit txtSecondKey;
        private System.Windows.Forms.Label lblMainTitle;
        private DevExpress.XtraSplashScreen.SplashScreenManager regWET;
        private DevExpress.XtraEditors.SimpleButton bntCLR;
    }
}