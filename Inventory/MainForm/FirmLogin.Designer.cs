namespace Inventory.MainForm
{
    partial class FirmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmLogin));
            this.intWET = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgClock = new CalendarClock.CalendarClock();
            this.lblLicense = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgEmployees = new System.Windows.Forms.PictureBox();
            this.bntONL = new System.Windows.Forms.Button();
            this.bntLCL = new System.Windows.Forms.Button();
            this.bntConf = new System.Windows.Forms.Button();
            this.bntExit = new System.Windows.Forms.Button();
            this.bntAdmin = new System.Windows.Forms.Button();
            this.bntUser = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgEmployees)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // intWET
            // 
            this.intWET.ClosingDelay = 500;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(52)))), ((int)(((byte)(119)))));
            this.lblSubTitle.Location = new System.Drawing.Point(741, 199);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(384, 35);
            this.lblSubTitle.TabIndex = 98;
            this.lblSubTitle.Text = "Inventory Management System";
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(52)))), ((int)(((byte)(119)))));
            this.lblMainTitle.Location = new System.Drawing.Point(599, 63);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(661, 106);
            this.lblMainTitle.TabIndex = 96;
            this.lblMainTitle.Text = "The Wizards Inc.";
            this.lblMainTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 841);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 23);
            this.label1.TabIndex = 95;
            this.label1.Text = "© 2025 All rights reserved";
            // 
            // DgClock
            // 
            this.DgClock.BackColor = System.Drawing.Color.LightSteelBlue;
            this.DgClock.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgClock.ForeColor = System.Drawing.Color.Red;
            this.DgClock.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.DgClock.Location = new System.Drawing.Point(5, 199);
            this.DgClock.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.DgClock.Name = "DgClock";
            this.DgClock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DgClock.Size = new System.Drawing.Size(363, 309);
            this.DgClock.TabIndex = 87;
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicense.ForeColor = System.Drawing.Color.Black;
            this.lblLicense.Location = new System.Drawing.Point(15, 809);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(306, 20);
            this.lblLicense.TabIndex = 94;
            this.lblLicense.Text = "295A10691CD571763D3340413A6F17A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(85, 784);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 93;
            this.label2.Text = "Product License:";
            // 
            // imgEmployees
            // 
            this.imgEmployees.BackColor = System.Drawing.Color.White;
            this.imgEmployees.Image = ((System.Drawing.Image)(resources.GetObject("imgEmployees.Image")));
            this.imgEmployees.Location = new System.Drawing.Point(804, 289);
            this.imgEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.imgEmployees.Name = "imgEmployees";
            this.imgEmployees.Size = new System.Drawing.Size(272, 321);
            this.imgEmployees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgEmployees.TabIndex = 92;
            this.imgEmployees.TabStop = false;
            // 
            // bntONL
            // 
            this.bntONL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bntONL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bntONL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bntONL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntONL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bntONL.ForeColor = System.Drawing.Color.White;
            this.bntONL.Image = ((System.Drawing.Image)(resources.GetObject("bntONL.Image")));
            this.bntONL.Location = new System.Drawing.Point(187, 511);
            this.bntONL.Margin = new System.Windows.Forms.Padding(4);
            this.bntONL.Name = "bntONL";
            this.bntONL.Size = new System.Drawing.Size(181, 134);
            this.bntONL.TabIndex = 89;
            this.bntONL.Text = "SET SERVER";
            this.bntONL.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntONL.UseVisualStyleBackColor = false;
            this.bntONL.Click += new System.EventHandler(this.bntONL_Click);
            // 
            // bntLCL
            // 
            this.bntLCL.BackColor = System.Drawing.Color.Black;
            this.bntLCL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bntLCL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bntLCL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntLCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.bntLCL.ForeColor = System.Drawing.Color.White;
            this.bntLCL.Image = ((System.Drawing.Image)(resources.GetObject("bntLCL.Image")));
            this.bntLCL.Location = new System.Drawing.Point(5, 511);
            this.bntLCL.Margin = new System.Windows.Forms.Padding(4);
            this.bntLCL.Name = "bntLCL";
            this.bntLCL.Size = new System.Drawing.Size(180, 134);
            this.bntLCL.TabIndex = 88;
            this.bntLCL.Text = "GUESS";
            this.bntLCL.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntLCL.UseVisualStyleBackColor = false;
            this.bntLCL.Click += new System.EventHandler(this.bntLCL_Click);
            // 
            // bntConf
            // 
            this.bntConf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bntConf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bntConf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bntConf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntConf.ForeColor = System.Drawing.Color.White;
            this.bntConf.Image = ((System.Drawing.Image)(resources.GetObject("bntConf.Image")));
            this.bntConf.Location = new System.Drawing.Point(5, 646);
            this.bntConf.Margin = new System.Windows.Forms.Padding(4);
            this.bntConf.Name = "bntConf";
            this.bntConf.Size = new System.Drawing.Size(180, 134);
            this.bntConf.TabIndex = 90;
            this.bntConf.Text = "ABOUT";
            this.bntConf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntConf.UseVisualStyleBackColor = false;
            // 
            // bntExit
            // 
            this.bntExit.BackColor = System.Drawing.Color.Indigo;
            this.bntExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bntExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bntExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntExit.ForeColor = System.Drawing.Color.White;
            this.bntExit.Image = ((System.Drawing.Image)(resources.GetObject("bntExit.Image")));
            this.bntExit.Location = new System.Drawing.Point(187, 646);
            this.bntExit.Margin = new System.Windows.Forms.Padding(4);
            this.bntExit.Name = "bntExit";
            this.bntExit.Size = new System.Drawing.Size(181, 134);
            this.bntExit.TabIndex = 91;
            this.bntExit.Text = "EXIT";
            this.bntExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntExit.UseVisualStyleBackColor = false;
            this.bntExit.Click += new System.EventHandler(this.bntExit_Click);
            // 
            // bntAdmin
            // 
            this.bntAdmin.BackColor = System.Drawing.Color.LightSeaGreen;
            this.bntAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bntAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bntAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAdmin.ForeColor = System.Drawing.Color.White;
            this.bntAdmin.Image = ((System.Drawing.Image)(resources.GetObject("bntAdmin.Image")));
            this.bntAdmin.Location = new System.Drawing.Point(187, 63);
            this.bntAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.bntAdmin.Name = "bntAdmin";
            this.bntAdmin.Size = new System.Drawing.Size(181, 134);
            this.bntAdmin.TabIndex = 86;
            this.bntAdmin.Text = "ADMIN";
            this.bntAdmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntAdmin.UseVisualStyleBackColor = false;
            this.bntAdmin.Click += new System.EventHandler(this.bntAdmin_Click);
            // 
            // bntUser
            // 
            this.bntUser.BackColor = System.Drawing.Color.Red;
            this.bntUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.bntUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bntUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntUser.ForeColor = System.Drawing.Color.White;
            this.bntUser.Image = ((System.Drawing.Image)(resources.GetObject("bntUser.Image")));
            this.bntUser.Location = new System.Drawing.Point(5, 63);
            this.bntUser.Margin = new System.Windows.Forms.Padding(4);
            this.bntUser.Name = "bntUser";
            this.bntUser.Size = new System.Drawing.Size(180, 134);
            this.bntUser.TabIndex = 85;
            this.bntUser.Text = "USER";
            this.bntUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntUser.UseVisualStyleBackColor = false;
            this.bntUser.Click += new System.EventHandler(this.bntUser_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.imgEmployees);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.lblMainTitle);
            this.pnlMain.Controls.Add(this.bntONL);
            this.pnlMain.Controls.Add(this.lblSubTitle);
            this.pnlMain.Controls.Add(this.bntLCL);
            this.pnlMain.Controls.Add(this.bntUser);
            this.pnlMain.Controls.Add(this.DgClock);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.bntConf);
            this.pnlMain.Controls.Add(this.lblLicense);
            this.pnlMain.Controls.Add(this.bntExit);
            this.pnlMain.Controls.Add(this.bntAdmin);
            this.pnlMain.Location = new System.Drawing.Point(1, -2);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1805, 905);
            this.pnlMain.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(52)))), ((int)(((byte)(119)))));
            this.label3.Location = new System.Drawing.Point(680, 667);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(493, 35);
            this.label3.TabIndex = 99;
            this.label3.Text = "Enchanting Efficiency in Every Stock Check";
            // 
            // FirmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1805, 902);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FirmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
    "                     ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FirmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgEmployees)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgEmployees;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntONL;
        private System.Windows.Forms.Button bntLCL;
        private CalendarClock.CalendarClock DgClock;
        private System.Windows.Forms.Button bntConf;
        private System.Windows.Forms.Button bntExit;
        private System.Windows.Forms.Button bntAdmin;
        private System.Windows.Forms.Button bntUser;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraSplashScreen.SplashScreenManager intWET;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label3;
    }
}