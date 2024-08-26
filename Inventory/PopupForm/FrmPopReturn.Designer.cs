namespace Inventory.PopupForm
{
    partial class FrmPopReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopReturn));
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.groupLauncher = new DevExpress.XtraEditors.GroupControl();
            this.label10 = new System.Windows.Forms.Label();
            this.dkpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bntExit = new DevExpress.XtraEditors.SimpleButton();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbReturnDestination = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbReturnItemStatus = new System.Windows.Forms.ComboBox();
            this.txtInventoryQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReturnRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReturnQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReturnItem = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtReturnBarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupImage = new DevExpress.XtraEditors.GroupControl();
            this.ImageReturnPreview = new System.Windows.Forms.PictureBox();
            this.cmbReturnBranch = new System.Windows.Forms.ComboBox();
            this.bntAccept = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupLauncher)).BeginInit();
            this.groupLauncher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImage)).BeginInit();
            this.groupImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageReturnPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupLauncher
            // 
            this.groupLauncher.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupLauncher.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupLauncher.Appearance.Options.UseBackColor = true;
            this.groupLauncher.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupLauncher.Controls.Add(this.label10);
            this.groupLauncher.Controls.Add(this.dkpReturnDate);
            this.groupLauncher.Controls.Add(this.pictureBox1);
            this.groupLauncher.Controls.Add(this.bntExit);
            this.groupLauncher.Controls.Add(this.lblMainTitle);
            this.groupLauncher.Controls.Add(this.label9);
            this.groupLauncher.Controls.Add(this.cmbReturnDestination);
            this.groupLauncher.Controls.Add(this.label8);
            this.groupLauncher.Controls.Add(this.cmbReturnItemStatus);
            this.groupLauncher.Controls.Add(this.txtInventoryQuantity);
            this.groupLauncher.Controls.Add(this.label6);
            this.groupLauncher.Controls.Add(this.txtReturnRemarks);
            this.groupLauncher.Controls.Add(this.label4);
            this.groupLauncher.Controls.Add(this.txtReturnQuantity);
            this.groupLauncher.Controls.Add(this.label5);
            this.groupLauncher.Controls.Add(this.label1);
            this.groupLauncher.Controls.Add(this.txtReturnItem);
            this.groupLauncher.Controls.Add(this.lblName);
            this.groupLauncher.Controls.Add(this.txtReturnBarcode);
            this.groupLauncher.Controls.Add(this.label7);
            this.groupLauncher.Controls.Add(this.groupImage);
            this.groupLauncher.Controls.Add(this.cmbReturnBranch);
            this.groupLauncher.Controls.Add(this.bntAccept);
            this.groupLauncher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLauncher.Location = new System.Drawing.Point(0, 0);
            this.groupLauncher.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupLauncher.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupLauncher.Name = "groupLauncher";
            this.groupLauncher.Size = new System.Drawing.Size(931, 582);
            this.groupLauncher.TabIndex = 6;
            this.groupLauncher.Text = "Stock Delivery From Warehouse";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(386, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 21);
            this.label10.TabIndex = 273;
            this.label10.Text = "Delivery Date:";
            // 
            // dkpReturnDate
            // 
            this.dkpReturnDate.CustomFormat = "dd-MM-yyyy";
            this.dkpReturnDate.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.dkpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpReturnDate.Location = new System.Drawing.Point(523, 298);
            this.dkpReturnDate.Name = "dkpReturnDate";
            this.dkpReturnDate.Size = new System.Drawing.Size(223, 34);
            this.dkpReturnDate.TabIndex = 11;
            this.dkpReturnDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpDelivery_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(746, 347);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 271;
            this.pictureBox1.TabStop = false;
            // 
            // bntExit
            // 
            this.bntExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntExit.ImageOptions.Image")));
            this.bntExit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntExit.Location = new System.Drawing.Point(3, 516);
            this.bntExit.Name = "bntExit";
            this.bntExit.Size = new System.Drawing.Size(371, 62);
            this.bntExit.TabIndex = 14;
            this.bntExit.ToolTip = "Close Item Delivery";
            this.bntExit.Click += new System.EventHandler(this.bntExit_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(444, 452);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(236, 51);
            this.lblMainTitle.TabIndex = 270;
            this.lblMainTitle.Text = "Return Item";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(384, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 21);
            this.label9.TabIndex = 269;
            this.label9.Text = "Destination:";
            // 
            // cmbReturnDestination
            // 
            this.cmbReturnDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReturnDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReturnDestination.BackColor = System.Drawing.Color.White;
            this.cmbReturnDestination.Enabled = false;
            this.cmbReturnDestination.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbReturnDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbReturnDestination.FormattingEnabled = true;
            this.cmbReturnDestination.Location = new System.Drawing.Point(523, 125);
            this.cmbReturnDestination.Name = "cmbReturnDestination";
            this.cmbReturnDestination.Size = new System.Drawing.Size(396, 36);
            this.cmbReturnDestination.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(386, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 21);
            this.label8.TabIndex = 267;
            this.label8.Text = "Item Status:";
            // 
            // cmbReturnItemStatus
            // 
            this.cmbReturnItemStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReturnItemStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReturnItemStatus.BackColor = System.Drawing.Color.White;
            this.cmbReturnItemStatus.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbReturnItemStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbReturnItemStatus.FormattingEnabled = true;
            this.cmbReturnItemStatus.Location = new System.Drawing.Point(523, 228);
            this.cmbReturnItemStatus.Name = "cmbReturnItemStatus";
            this.cmbReturnItemStatus.Size = new System.Drawing.Size(396, 36);
            this.cmbReturnItemStatus.TabIndex = 8;
            this.cmbReturnItemStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemStatus_KeyDown);
            // 
            // txtInventoryQuantity
            // 
            this.txtInventoryQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventoryQuantity.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtInventoryQuantity.Location = new System.Drawing.Point(523, 162);
            this.txtInventoryQuantity.Name = "txtInventoryQuantity";
            this.txtInventoryQuantity.Size = new System.Drawing.Size(396, 32);
            this.txtInventoryQuantity.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(385, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 21);
            this.label6.TabIndex = 264;
            this.label6.Text = "Item Quantity:";
            // 
            // txtReturnRemarks
            // 
            this.txtReturnRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnRemarks.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtReturnRemarks.Location = new System.Drawing.Point(523, 265);
            this.txtReturnRemarks.Name = "txtReturnRemarks";
            this.txtReturnRemarks.Size = new System.Drawing.Size(396, 32);
            this.txtReturnRemarks.TabIndex = 7;
            this.txtReturnRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReturnRemarks_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(387, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 21);
            this.label4.TabIndex = 262;
            this.label4.Text = "Remarks:";
            // 
            // txtReturnQuantity
            // 
            this.txtReturnQuantity.BackColor = System.Drawing.Color.Yellow;
            this.txtReturnQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnQuantity.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtReturnQuantity.Location = new System.Drawing.Point(523, 195);
            this.txtReturnQuantity.Name = "txtReturnQuantity";
            this.txtReturnQuantity.Size = new System.Drawing.Size(396, 32);
            this.txtReturnQuantity.TabIndex = 6;
            this.txtReturnQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReturnQuantity_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(385, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 21);
            this.label5.TabIndex = 260;
            this.label5.Text = "Return Quantity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(385, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 255;
            this.label1.Text = "Branch:";
            // 
            // txtReturnItem
            // 
            this.txtReturnItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnItem.Enabled = false;
            this.txtReturnItem.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtReturnItem.Location = new System.Drawing.Point(523, 55);
            this.txtReturnItem.Name = "txtReturnItem";
            this.txtReturnItem.Size = new System.Drawing.Size(396, 32);
            this.txtReturnItem.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(385, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 21);
            this.lblName.TabIndex = 253;
            this.lblName.Text = "Item Name:";
            // 
            // txtReturnBarcode
            // 
            this.txtReturnBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnBarcode.Enabled = false;
            this.txtReturnBarcode.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtReturnBarcode.Location = new System.Drawing.Point(523, 22);
            this.txtReturnBarcode.Name = "txtReturnBarcode";
            this.txtReturnBarcode.Size = new System.Drawing.Size(396, 32);
            this.txtReturnBarcode.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(385, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 21);
            this.label7.TabIndex = 251;
            this.label7.Text = "Barcode:";
            // 
            // groupImage
            // 
            this.groupImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupImage.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupImage.Appearance.Options.UseBackColor = true;
            this.groupImage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupImage.Controls.Add(this.ImageReturnPreview);
            this.groupImage.Location = new System.Drawing.Point(2, 19);
            this.groupImage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupImage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupImage.Name = "groupImage";
            this.groupImage.Size = new System.Drawing.Size(372, 433);
            this.groupImage.TabIndex = 250;
            // 
            // ImageReturnPreview
            // 
            this.ImageReturnPreview.BackColor = System.Drawing.Color.White;
            this.ImageReturnPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageReturnPreview.Location = new System.Drawing.Point(3, 18);
            this.ImageReturnPreview.Name = "ImageReturnPreview";
            this.ImageReturnPreview.Size = new System.Drawing.Size(366, 412);
            this.ImageReturnPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageReturnPreview.TabIndex = 244;
            this.ImageReturnPreview.TabStop = false;
            // 
            // cmbReturnBranch
            // 
            this.cmbReturnBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReturnBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReturnBranch.BackColor = System.Drawing.Color.White;
            this.cmbReturnBranch.Enabled = false;
            this.cmbReturnBranch.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbReturnBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbReturnBranch.FormattingEnabled = true;
            this.cmbReturnBranch.Location = new System.Drawing.Point(523, 88);
            this.cmbReturnBranch.Name = "cmbReturnBranch";
            this.cmbReturnBranch.Size = new System.Drawing.Size(396, 36);
            this.cmbReturnBranch.TabIndex = 3;
            // 
            // bntAccept
            // 
            this.bntAccept.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAccept.Appearance.Options.UseFont = true;
            this.bntAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntAccept.ImageOptions.Image")));
            this.bntAccept.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntAccept.Location = new System.Drawing.Point(3, 453);
            this.bntAccept.Name = "bntAccept";
            this.bntAccept.Size = new System.Drawing.Size(371, 62);
            this.bntAccept.TabIndex = 12;
            this.bntAccept.ToolTip = "Accept Return";
            this.bntAccept.Click += new System.EventHandler(this.bntAccept_Click);
            // 
            // FrmPopReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 582);
            this.Controls.Add(this.groupLauncher);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPopReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPopLauncher";
            this.Load += new System.EventHandler(this.FrmPopLauncher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupLauncher)).EndInit();
            this.groupLauncher.ResumeLayout(false);
            this.groupLauncher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImage)).EndInit();
            this.groupImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageReturnPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupLauncher;
        private System.Windows.Forms.ComboBox cmbReturnBranch;
        private DevExpress.XtraEditors.SimpleButton bntAccept;
        private DevExpress.XtraEditors.GroupControl groupImage;
        private System.Windows.Forms.PictureBox ImageReturnPreview;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbReturnDestination;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbReturnItemStatus;
        private System.Windows.Forms.TextBox txtInventoryQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReturnRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReturnQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReturnItem;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtReturnBarcode;
        private DevExpress.XtraEditors.SimpleButton bntExit;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dkpReturnDate;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
    }
}