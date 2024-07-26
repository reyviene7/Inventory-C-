namespace Inventory.PopupForm
{
    partial class FirmPopReturnEmpty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmPopReturnEmpty));
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSAT = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dkpDET = new System.Windows.Forms.DateTimePicker();
            this.lblHiredate = new System.Windows.Forms.Label();
            this.dkpDEL = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQTY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtORG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRET = new System.Windows.Forms.TextBox();
            this.cmbBRA = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.bntSVA = new DevExpress.XtraEditors.SimpleButton();
            this.bntCAN = new DevExpress.XtraEditors.SimpleButton();
            this.gbCON = new DevExpress.XtraEditors.GroupControl();
            this.cmbNAM = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtINV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMAR = new System.Windows.Forms.TextBox();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.retWET = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).BeginInit();
            this.gbCON.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 241;
            this.label9.Text = "Product Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(442, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 235;
            this.label6.Text = "Product Status:";
            // 
            // cmbSAT
            // 
            this.cmbSAT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSAT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSAT.BackColor = System.Drawing.Color.White;
            this.cmbSAT.Enabled = false;
            this.cmbSAT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSAT.ForeColor = System.Drawing.Color.Maroon;
            this.cmbSAT.FormattingEnabled = true;
            this.cmbSAT.Location = new System.Drawing.Point(565, 254);
            this.cmbSAT.Name = "cmbSAT";
            this.cmbSAT.Size = new System.Drawing.Size(269, 29);
            this.cmbSAT.TabIndex = 10;
            this.cmbSAT.Text = "Return";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(442, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 17);
            this.label12.TabIndex = 233;
            this.label12.Text = "Input Date:";
            // 
            // dkpDET
            // 
            this.dkpDET.CustomFormat = "MM-dd-yyyy";
            this.dkpDET.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDET.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDET.Location = new System.Drawing.Point(565, 223);
            this.dkpDET.Name = "dkpDET";
            this.dkpDET.Size = new System.Drawing.Size(269, 29);
            this.dkpDET.TabIndex = 9;
            this.dkpDET.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpDET_KeyDown);
            // 
            // lblHiredate
            // 
            this.lblHiredate.AutoSize = true;
            this.lblHiredate.BackColor = System.Drawing.Color.Transparent;
            this.lblHiredate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiredate.ForeColor = System.Drawing.Color.White;
            this.lblHiredate.Location = new System.Drawing.Point(442, 198);
            this.lblHiredate.Name = "lblHiredate";
            this.lblHiredate.Size = new System.Drawing.Size(97, 17);
            this.lblHiredate.TabIndex = 231;
            this.lblHiredate.Text = "Delivery Date:";
            // 
            // dkpDEL
            // 
            this.dkpDEL.CustomFormat = "MM-dd-yyyy";
            this.dkpDEL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDEL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDEL.Location = new System.Drawing.Point(565, 192);
            this.dkpDEL.Name = "dkpDEL";
            this.dkpDEL.Size = new System.Drawing.Size(269, 29);
            this.dkpDEL.TabIndex = 8;
            this.dkpDEL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpDEL_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 222;
            this.label4.Text = "Qty Deliver:";
            // 
            // txtQTY
            // 
            this.txtQTY.BackColor = System.Drawing.Color.White;
            this.txtQTY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQTY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQTY.ForeColor = System.Drawing.Color.Maroon;
            this.txtQTY.Location = new System.Drawing.Point(129, 251);
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(269, 29);
            this.txtQTY.TabIndex = 5;
            this.txtQTY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQTY_KeyDown);
            this.txtQTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQTY_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 220;
            this.label3.Text = "Branch Origin:";
            // 
            // txtORG
            // 
            this.txtORG.BackColor = System.Drawing.Color.White;
            this.txtORG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtORG.Enabled = false;
            this.txtORG.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtORG.ForeColor = System.Drawing.Color.Maroon;
            this.txtORG.Location = new System.Drawing.Point(129, 281);
            this.txtORG.Name = "txtORG";
            this.txtORG.Size = new System.Drawing.Size(269, 29);
            this.txtORG.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 218;
            this.label2.Text = "Return No:";
            // 
            // txtRET
            // 
            this.txtRET.BackColor = System.Drawing.Color.White;
            this.txtRET.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRET.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRET.ForeColor = System.Drawing.Color.Maroon;
            this.txtRET.Location = new System.Drawing.Point(129, 221);
            this.txtRET.Name = "txtRET";
            this.txtRET.Size = new System.Drawing.Size(269, 29);
            this.txtRET.TabIndex = 4;
            this.txtRET.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRET_KeyDown);
            this.txtRET.Leave += new System.EventHandler(this.txtRET_Leave);
            // 
            // cmbBRA
            // 
            this.cmbBRA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBRA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBRA.BackColor = System.Drawing.Color.White;
            this.cmbBRA.Enabled = false;
            this.cmbBRA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBRA.ForeColor = System.Drawing.Color.Maroon;
            this.cmbBRA.FormattingEnabled = true;
            this.cmbBRA.Location = new System.Drawing.Point(565, 161);
            this.cmbBRA.Name = "cmbBRA";
            this.cmbBRA.Size = new System.Drawing.Size(269, 29);
            this.cmbBRA.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(443, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 17);
            this.label13.TabIndex = 216;
            this.label13.Text = "Delivery Branch:";
            // 
            // txtPID
            // 
            this.txtPID.BackColor = System.Drawing.Color.White;
            this.txtPID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPID.Enabled = false;
            this.txtPID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPID.ForeColor = System.Drawing.Color.Maroon;
            this.txtPID.Location = new System.Drawing.Point(129, 161);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(269, 29);
            this.txtPID.TabIndex = 2;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.White;
            this.lblBarcode.Location = new System.Drawing.Point(7, 166);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(76, 17);
            this.lblBarcode.TabIndex = 177;
            this.lblBarcode.Text = "Product Id:";
            // 
            // bntSVA
            // 
            this.bntSVA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSVA.ImageOptions.Image")));
            this.bntSVA.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntSVA.Location = new System.Drawing.Point(305, 357);
            this.bntSVA.Name = "bntSVA";
            this.bntSVA.Size = new System.Drawing.Size(157, 37);
            this.bntSVA.TabIndex = 4;
            this.bntSVA.ToolTip = "User Manual";
            this.bntSVA.Click += new System.EventHandler(this.bntSVA_Click);
            // 
            // bntCAN
            // 
            this.bntCAN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntCAN.ImageOptions.Image")));
            this.bntCAN.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntCAN.Location = new System.Drawing.Point(464, 357);
            this.bntCAN.Name = "bntCAN";
            this.bntCAN.Size = new System.Drawing.Size(157, 37);
            this.bntCAN.TabIndex = 5;
            this.bntCAN.ToolTip = "Service Manual";
            this.bntCAN.Click += new System.EventHandler(this.bntCAN_Click);
            // 
            // gbCON
            // 
            this.gbCON.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gbCON.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.gbCON.Appearance.Options.UseBackColor = true;
            this.gbCON.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gbCON.Controls.Add(this.cmbNAM);
            this.gbCON.Controls.Add(this.label5);
            this.gbCON.Controls.Add(this.txtINV);
            this.gbCON.Controls.Add(this.label1);
            this.gbCON.Controls.Add(this.txtMAR);
            this.gbCON.Controls.Add(this.label9);
            this.gbCON.Controls.Add(this.label6);
            this.gbCON.Controls.Add(this.cmbSAT);
            this.gbCON.Controls.Add(this.label12);
            this.gbCON.Controls.Add(this.dkpDET);
            this.gbCON.Controls.Add(this.lblHiredate);
            this.gbCON.Controls.Add(this.dkpDEL);
            this.gbCON.Controls.Add(this.label4);
            this.gbCON.Controls.Add(this.txtQTY);
            this.gbCON.Controls.Add(this.label3);
            this.gbCON.Controls.Add(this.txtORG);
            this.gbCON.Controls.Add(this.label2);
            this.gbCON.Controls.Add(this.txtRET);
            this.gbCON.Controls.Add(this.cmbBRA);
            this.gbCON.Controls.Add(this.label13);
            this.gbCON.Controls.Add(this.txtPID);
            this.gbCON.Controls.Add(this.lblBarcode);
            this.gbCON.Controls.Add(this.bntSVA);
            this.gbCON.Controls.Add(this.bntCAN);
            this.gbCON.Controls.Add(this.lblMainTitle);
            this.gbCON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCON.Location = new System.Drawing.Point(0, 0);
            this.gbCON.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gbCON.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gbCON.Name = "gbCON";
            this.gbCON.Size = new System.Drawing.Size(844, 406);
            this.gbCON.TabIndex = 5;
            // 
            // cmbNAM
            // 
            this.cmbNAM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNAM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNAM.BackColor = System.Drawing.Color.White;
            this.cmbNAM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNAM.ForeColor = System.Drawing.Color.Maroon;
            this.cmbNAM.FormattingEnabled = true;
            this.cmbNAM.Location = new System.Drawing.Point(129, 129);
            this.cmbNAM.Name = "cmbNAM";
            this.cmbNAM.Size = new System.Drawing.Size(705, 29);
            this.cmbNAM.TabIndex = 1;
            this.cmbNAM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNAM_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 245;
            this.label5.Text = "Inventory Id:";
            // 
            // txtINV
            // 
            this.txtINV.BackColor = System.Drawing.Color.White;
            this.txtINV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtINV.Enabled = false;
            this.txtINV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtINV.ForeColor = System.Drawing.Color.Maroon;
            this.txtINV.Location = new System.Drawing.Point(129, 191);
            this.txtINV.Name = "txtINV";
            this.txtINV.Size = new System.Drawing.Size(269, 29);
            this.txtINV.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(442, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 243;
            this.label1.Text = "Remarks:";
            // 
            // txtMAR
            // 
            this.txtMAR.BackColor = System.Drawing.Color.White;
            this.txtMAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMAR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAR.ForeColor = System.Drawing.Color.Maroon;
            this.txtMAR.Location = new System.Drawing.Point(564, 285);
            this.txtMAR.Name = "txtMAR";
            this.txtMAR.Size = new System.Drawing.Size(269, 29);
            this.txtMAR.TabIndex = 11;
            this.txtMAR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMAR_KeyDown);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblMainTitle.Location = new System.Drawing.Point(165, 54);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(573, 47);
            this.lblMainTitle.TabIndex = 100;
            this.lblMainTitle.Text = "RETURN EMPTY TO WAREHOUSE";
            // 
            // retWET
            // 
            this.retWET.ClosingDelay = 500;
            // 
            // FirmPopReturnEmpty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 406);
            this.Controls.Add(this.gbCON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirmPopReturnEmpty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmPopReturnEmpty";
            this.Load += new System.EventHandler(this.FirmPopReturnEmpty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).EndInit();
            this.gbCON.ResumeLayout(false);
            this.gbCON.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSAT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dkpDET;
        private System.Windows.Forms.Label lblHiredate;
        private System.Windows.Forms.DateTimePicker dkpDEL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQTY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtORG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRET;
        private System.Windows.Forms.ComboBox cmbBRA;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.Label lblBarcode;
        private DevExpress.XtraEditors.SimpleButton bntSVA;
        private DevExpress.XtraEditors.SimpleButton bntCAN;
        private DevExpress.XtraEditors.GroupControl gbCON;
        private System.Windows.Forms.Label lblMainTitle;
        private DevExpress.XtraSplashScreen.SplashScreenManager retWET;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtINV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMAR;
        private System.Windows.Forms.ComboBox cmbNAM;
    }
}