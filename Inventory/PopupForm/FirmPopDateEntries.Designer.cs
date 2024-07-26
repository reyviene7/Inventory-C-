namespace Inventory.PopupForm
{
    partial class FirmPopDateEntries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmPopDateEntries));
            this.gbCON = new DevExpress.XtraEditors.GroupControl();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dkpEND = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dkpSTR = new System.Windows.Forms.DateTimePicker();
            this.bntSVA = new DevExpress.XtraEditors.SimpleButton();
            this.bntCAN = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).BeginInit();
            this.gbCON.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCON
            // 
            this.gbCON.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gbCON.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gbCON.Appearance.Options.UseBackColor = true;
            this.gbCON.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gbCON.Controls.Add(this.lblMainTitle);
            this.gbCON.Controls.Add(this.label1);
            this.gbCON.Controls.Add(this.dkpEND);
            this.gbCON.Controls.Add(this.label2);
            this.gbCON.Controls.Add(this.dkpSTR);
            this.gbCON.Controls.Add(this.bntSVA);
            this.gbCON.Controls.Add(this.bntCAN);
            this.gbCON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCON.Location = new System.Drawing.Point(0, 0);
            this.gbCON.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gbCON.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gbCON.Name = "gbCON";
            this.gbCON.Size = new System.Drawing.Size(457, 201);
            this.gbCON.TabIndex = 6;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(42, 23);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(367, 47);
            this.lblMainTitle.TabIndex = 180;
            this.lblMainTitle.Text = "Periodic View Report";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(34, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 179;
            this.label1.Text = "End Date:";
            // 
            // dkpEND
            // 
            this.dkpEND.CustomFormat = "MM-dd-yyyy";
            this.dkpEND.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpEND.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpEND.Location = new System.Drawing.Point(139, 109);
            this.dkpEND.Name = "dkpEND";
            this.dkpEND.Size = new System.Drawing.Size(232, 33);
            this.dkpEND.TabIndex = 2;
            this.dkpEND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpEND_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(34, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 177;
            this.label2.Text = "Start Date:";
            // 
            // dkpSTR
            // 
            this.dkpSTR.CustomFormat = "MM-dd-yyyy";
            this.dkpSTR.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpSTR.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpSTR.Location = new System.Drawing.Point(139, 74);
            this.dkpSTR.Name = "dkpSTR";
            this.dkpSTR.Size = new System.Drawing.Size(232, 33);
            this.dkpSTR.TabIndex = 1;
            this.dkpSTR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpSTR_KeyDown);
            // 
            // bntSVA
            // 
            this.bntSVA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSVA.ImageOptions.Image")));
            this.bntSVA.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntSVA.Location = new System.Drawing.Point(68, 152);
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
            this.bntCAN.Location = new System.Drawing.Point(231, 152);
            this.bntCAN.Name = "bntCAN";
            this.bntCAN.Size = new System.Drawing.Size(157, 37);
            this.bntCAN.TabIndex = 4;
            this.bntCAN.ToolTip = "Service Manual";
            this.bntCAN.Click += new System.EventHandler(this.bntCAN_Click);
            // 
            // FirmPopDateEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 201);
            this.Controls.Add(this.gbCON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirmPopDateEntries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmPopShowReport";
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).EndInit();
            this.gbCON.ResumeLayout(false);
            this.gbCON.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbCON;
        private DevExpress.XtraEditors.SimpleButton bntSVA;
        private DevExpress.XtraEditors.SimpleButton bntCAN;
        private System.Windows.Forms.DateTimePicker dkpSTR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dkpEND;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMainTitle;
    }
}