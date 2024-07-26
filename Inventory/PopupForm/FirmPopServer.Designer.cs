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
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.txtPSS = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUSR = new DevExpress.XtraEditors.TextEdit();
            this.txtDAT = new DevExpress.XtraEditors.TextEdit();
            this.txtNAM = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bntSVA = new DevExpress.XtraEditors.SimpleButton();
            this.bntCAN = new DevExpress.XtraEditors.SimpleButton();
            this.regWET = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.WaitForm1), true, true);
            this.bntCLR = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).BeginInit();
            this.gbCON.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDAT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNAM.Properties)).BeginInit();
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
            this.gbCON.Controls.Add(this.txtPSS);
            this.gbCON.Controls.Add(this.label4);
            this.gbCON.Controls.Add(this.txtUSR);
            this.gbCON.Controls.Add(this.txtDAT);
            this.gbCON.Controls.Add(this.txtNAM);
            this.gbCON.Controls.Add(this.label3);
            this.gbCON.Controls.Add(this.label1);
            this.gbCON.Controls.Add(this.label2);
            this.gbCON.Controls.Add(this.bntSVA);
            this.gbCON.Controls.Add(this.bntCAN);
            this.gbCON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCON.Location = new System.Drawing.Point(0, 0);
            this.gbCON.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gbCON.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gbCON.Name = "gbCON";
            this.gbCON.Size = new System.Drawing.Size(582, 299);
            this.gbCON.TabIndex = 8;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(136, 34);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(393, 47);
            this.lblMainTitle.TabIndex = 216;
            this.lblMainTitle.Text = "SET SERVER SETTINGS";
            // 
            // txtPSS
            // 
            this.txtPSS.EditValue = "";
            this.txtPSS.Location = new System.Drawing.Point(126, 197);
            this.txtPSS.Name = "txtPSS";
            this.txtPSS.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPSS.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtPSS.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            this.txtPSS.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtPSS.Properties.Appearance.Options.UseBackColor = true;
            this.txtPSS.Properties.Appearance.Options.UseBorderColor = true;
            this.txtPSS.Properties.Appearance.Options.UseFont = true;
            this.txtPSS.Properties.PasswordChar = '*';
            this.txtPSS.Properties.UseSystemPasswordChar = true;
            this.txtPSS.Size = new System.Drawing.Size(426, 28);
            this.txtPSS.TabIndex = 4;
            this.txtPSS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPSS_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(4, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 185;
            this.label4.Text = "Password:";
            // 
            // txtUSR
            // 
            this.txtUSR.EditValue = "";
            this.txtUSR.Location = new System.Drawing.Point(126, 163);
            this.txtUSR.Name = "txtUSR";
            this.txtUSR.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUSR.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtUSR.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtUSR.Properties.Appearance.Options.UseBackColor = true;
            this.txtUSR.Properties.Appearance.Options.UseFont = true;
            this.txtUSR.Size = new System.Drawing.Size(426, 28);
            this.txtUSR.TabIndex = 3;
            this.txtUSR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUSR_KeyDown);
            // 
            // txtDAT
            // 
            this.txtDAT.Location = new System.Drawing.Point(126, 129);
            this.txtDAT.Name = "txtDAT";
            this.txtDAT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDAT.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtDAT.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtDAT.Properties.Appearance.Options.UseBackColor = true;
            this.txtDAT.Properties.Appearance.Options.UseFont = true;
            this.txtDAT.Size = new System.Drawing.Size(426, 28);
            this.txtDAT.TabIndex = 2;
            this.txtDAT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDAT_KeyDown);
            // 
            // txtNAM
            // 
            this.txtNAM.EditValue = "PC-NAME\\DB";
            this.txtNAM.Location = new System.Drawing.Point(123, 95);
            this.txtNAM.Name = "txtNAM";
            this.txtNAM.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNAM.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtNAM.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtNAM.Properties.Appearance.Options.UseBackColor = true;
            this.txtNAM.Properties.Appearance.Options.UseFont = true;
            this.txtNAM.Size = new System.Drawing.Size(429, 28);
            this.txtNAM.TabIndex = 1;
            this.txtNAM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNAM_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(4, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 21);
            this.label3.TabIndex = 181;
            this.label3.Text = "Server Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(4, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 179;
            this.label1.Text = "UserName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(4, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 177;
            this.label2.Text = "Database:";
            // 
            // bntSVA
            // 
            this.bntSVA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSVA.ImageOptions.Image")));
            this.bntSVA.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntSVA.Location = new System.Drawing.Point(126, 240);
            this.bntSVA.Name = "bntSVA";
            this.bntSVA.Size = new System.Drawing.Size(138, 37);
            this.bntSVA.TabIndex = 4;
            this.bntSVA.Text = "REG";
            this.bntSVA.ToolTip = "User Manual";
            this.bntSVA.Click += new System.EventHandler(this.bntSVA_Click);
            // 
            // bntCAN
            // 
            this.bntCAN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntCAN.ImageOptions.Image")));
            this.bntCAN.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntCAN.Location = new System.Drawing.Point(414, 240);
            this.bntCAN.Name = "bntCAN";
            this.bntCAN.Size = new System.Drawing.Size(138, 37);
            this.bntCAN.TabIndex = 5;
            this.bntCAN.ToolTip = "Service Manual";
            this.bntCAN.Click += new System.EventHandler(this.bntCAN_Click);
            // 
            // regWET
            // 
            this.regWET.ClosingDelay = 500;
            // 
            // bntCLR
            // 
            this.bntCLR.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.bntCLR.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntCLR.Location = new System.Drawing.Point(270, 240);
            this.bntCLR.Name = "bntCLR";
            this.bntCLR.Size = new System.Drawing.Size(138, 37);
            this.bntCLR.TabIndex = 217;
            this.bntCLR.ToolTip = "Service Manual";
            this.bntCLR.Click += new System.EventHandler(this.bntCLR_Click);
            // 
            // FirmPopServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 299);
            this.Controls.Add(this.gbCON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirmPopServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmPopServer";
            this.Load += new System.EventHandler(this.FirmPopServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).EndInit();
            this.gbCON.ResumeLayout(false);
            this.gbCON.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDAT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNAM.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbCON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton bntSVA;
        private DevExpress.XtraEditors.SimpleButton bntCAN;
        private DevExpress.XtraEditors.TextEdit txtNAM;
        private DevExpress.XtraEditors.TextEdit txtDAT;
        private DevExpress.XtraEditors.TextEdit txtPSS;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtUSR;
        private System.Windows.Forms.Label lblMainTitle;
        private DevExpress.XtraSplashScreen.SplashScreenManager regWET;
        private DevExpress.XtraEditors.SimpleButton bntCLR;
    }
}