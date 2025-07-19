using System.Drawing;

namespace Inventory.PopupForm
{
    partial class FirmPopAuthentication
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
            this.Icon = new Icon("wizard.ico");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmPopAuthentication));
            this.gbCON = new DevExpress.XtraEditors.GroupControl();
            this.txtPSS = new DevExpress.XtraEditors.TextEdit();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbHide = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUSR = new DevExpress.XtraEditors.TextEdit();
            this.lblLOG = new System.Windows.Forms.Label();
            this.bntSVA = new DevExpress.XtraEditors.SimpleButton();
            this.bntCAN = new DevExpress.XtraEditors.SimpleButton();
            this.logWET = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).BeginInit();
            this.gbCON.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSR.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCON
            // 
            this.gbCON.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gbCON.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gbCON.Appearance.Options.UseBackColor = true;
            this.gbCON.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gbCON.Controls.Add(this.txtPSS);
            this.gbCON.Controls.Add(this.pictureBox1);
            this.gbCON.Controls.Add(this.pbHide);
            this.gbCON.Controls.Add(this.lblUsername);
            this.gbCON.Controls.Add(this.lblPassword);
            this.gbCON.Controls.Add(this.txtUSR);
            this.gbCON.Controls.Add(this.lblLOG);
            this.gbCON.Controls.Add(this.bntSVA);
            this.gbCON.Controls.Add(this.bntCAN);
            this.gbCON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCON.Location = new System.Drawing.Point(0, 0);
            this.gbCON.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gbCON.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gbCON.Name = "gbCON";
            this.gbCON.Size = new System.Drawing.Size(582, 254);
            this.gbCON.TabIndex = 7;
            this.gbCON.Text = "LOGIN AUTHENTICATION";
            // 
            // txtPSS
            // 
            this.txtPSS.EditValue = "";
            this.txtPSS.Location = new System.Drawing.Point(200, 157);
            this.txtPSS.Name = "txtPSS";
            this.txtPSS.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPSS.Properties.Appearance.Options.UseFont = true;
            this.txtPSS.Properties.PasswordChar = '*';
            this.txtPSS.Properties.UseSystemPasswordChar = true;
            this.txtPSS.Size = new System.Drawing.Size(316, 32);
            this.txtPSS.TabIndex = 2;
            this.txtPSS.ToolTip = "User Password";
            this.txtPSS.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtPSS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPASS_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(156, 154);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 33);
            this.pictureBox1.TabIndex = 254;
            this.pictureBox1.TabStop = false;
            // 
            // pbHide
            // 
            this.pbHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbHide.Image = ((System.Drawing.Image)(resources.GetObject("pbHide.Image")));
            this.pbHide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbHide.Location = new System.Drawing.Point(156, 118);
            this.pbHide.Name = "pbHide";
            this.pbHide.Size = new System.Drawing.Size(38, 34);
            this.pbHide.TabIndex = 253;
            this.pbHide.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(44, 121);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(106, 25);
            this.lblUsername.TabIndex = 252;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(44, 156);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(102, 25);
            this.lblPassword.TabIndex = 251;
            this.lblPassword.Text = "Password:";
            // 
            // txtUSR
            // 
            this.txtUSR.EditValue = "Admin";
            this.txtUSR.Enabled = false;
            this.txtUSR.Location = new System.Drawing.Point(200, 119);
            this.txtUSR.Name = "txtUSR";
            this.txtUSR.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSR.Properties.Appearance.Options.UseFont = true;
            this.txtUSR.Size = new System.Drawing.Size(316, 32);
            this.txtUSR.TabIndex = 1;
            this.txtUSR.ToolTip = "Administrator Username";
            this.txtUSR.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtUSR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUSR_KeyDown);
            // 
            // lblLOG
            // 
            this.lblLOG.AutoSize = true;
            this.lblLOG.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLOG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblLOG.Location = new System.Drawing.Point(167, 44);
            this.lblLOG.Name = "lblLOG";
            this.lblLOG.Size = new System.Drawing.Size(358, 47);
            this.lblLOG.TabIndex = 249;
            this.lblLOG.Text = "SET SERVER CONFIG";
            // 
            // bntSVA
            // 
            this.bntSVA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSVA.ImageOptions.Image")));
            this.bntSVA.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntSVA.Location = new System.Drawing.Point(200, 206);
            this.bntSVA.Name = "bntSVA";
            this.bntSVA.Size = new System.Drawing.Size(157, 37);
            this.bntSVA.TabIndex = 3;
            this.bntSVA.ToolTip = "User Manual";
            this.bntSVA.Click += new System.EventHandler(this.bntSVA_Click);
            // 
            // bntCAN
            // 
            this.bntCAN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntCAN.ImageOptions.Image")));
            this.bntCAN.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntCAN.Location = new System.Drawing.Point(359, 206);
            this.bntCAN.Name = "bntCAN";
            this.bntCAN.Size = new System.Drawing.Size(157, 37);
            this.bntCAN.TabIndex = 4;
            this.bntCAN.ToolTip = "Service Manual";
            this.bntCAN.Click += new System.EventHandler(this.bntCAN_Click);
            // 
            // logWET
            // 
            this.logWET.ClosingDelay = 500;
            // 
            // FirmPopAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 254);
            this.Controls.Add(this.gbCON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirmPopAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentication";
            this.Load += new System.EventHandler(this.FirmPopAuthentication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).EndInit();
            this.gbCON.ResumeLayout(false);
            this.gbCON.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSR.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbCON;
        private DevExpress.XtraEditors.TextEdit txtPSS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbHide;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private DevExpress.XtraEditors.TextEdit txtUSR;
        private System.Windows.Forms.Label lblLOG;
        private DevExpress.XtraEditors.SimpleButton bntSVA;
        private DevExpress.XtraEditors.SimpleButton bntCAN;
        private DevExpress.XtraSplashScreen.SplashScreenManager logWET;
    }
}