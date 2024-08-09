namespace Inventory.PopupForm
{
    partial class FirmPopWarehouses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmPopWarehouses));
            this.cmbWarehouses = new System.Windows.Forms.ComboBox();
            this.gbCON = new DevExpress.XtraEditors.GroupControl();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.bntSVA = new DevExpress.XtraEditors.SimpleButton();
            this.bntCAN = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).BeginInit();
            this.gbCON.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbWarehouses
            // 
            this.cmbWarehouses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbWarehouses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWarehouses.BackColor = System.Drawing.Color.White;
            this.cmbWarehouses.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbWarehouses.FormattingEnabled = true;
            this.cmbWarehouses.Location = new System.Drawing.Point(13, 88);
            this.cmbWarehouses.Name = "cmbWarehouses";
            this.cmbWarehouses.Size = new System.Drawing.Size(433, 40);
            this.cmbWarehouses.TabIndex = 1;
            // 
            // gbCON
            // 
            this.gbCON.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gbCON.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gbCON.Appearance.Options.UseBackColor = true;
            this.gbCON.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gbCON.Controls.Add(this.cmbWarehouses);
            this.gbCON.Controls.Add(this.lblMainTitle);
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
            this.lblMainTitle.Location = new System.Drawing.Point(90, 27);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(281, 47);
            this.lblMainTitle.TabIndex = 249;
            this.lblMainTitle.Text = "Branch Delivery";
            // 
            // bntSVA
            // 
            this.bntSVA.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSVA.ImageOptions.Image")));
            this.bntSVA.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntSVA.Location = new System.Drawing.Point(69, 152);
            this.bntSVA.Name = "bntSVA";
            this.bntSVA.Size = new System.Drawing.Size(157, 37);
            this.bntSVA.TabIndex = 2;
            this.bntSVA.ToolTip = "User Manual";
            this.bntSVA.Click += new System.EventHandler(this.bntSAVE_Click);
            // 
            // bntCAN
            // 
            this.bntCAN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntCAN.ImageOptions.Image")));
            this.bntCAN.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntCAN.Location = new System.Drawing.Point(232, 152);
            this.bntCAN.Name = "bntCAN";
            this.bntCAN.Size = new System.Drawing.Size(157, 37);
            this.bntCAN.TabIndex = 3;
            this.bntCAN.ToolTip = "Service Manual";
            // 
            // FirmPopWarehouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 201);
            this.Controls.Add(this.gbCON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirmPopWarehouses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmPopWarehouses";
            this.Load += new System.EventHandler(this.FirmPopWarehouses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).EndInit();
            this.gbCON.ResumeLayout(false);
            this.gbCON.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWarehouses;
        private DevExpress.XtraEditors.GroupControl gbCON;
        private System.Windows.Forms.Label lblMainTitle;
        private DevExpress.XtraEditors.SimpleButton bntSVA;
        private DevExpress.XtraEditors.SimpleButton bntCAN;
    }
}