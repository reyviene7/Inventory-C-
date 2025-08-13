using System.Drawing;

namespace Inventory.PopupForm
{
    partial class FrmPopAccept
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopAccept));
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.groupLauncher = new DevExpress.XtraEditors.GroupControl();
            this.label12 = new System.Windows.Forms.Label();
            this.txtItemQty = new System.Windows.Forms.TextBox();
            this.txtInventoryCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dkpDelivery = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bntExit = new DevExpress.XtraEditors.SimpleButton();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbItemStatus = new System.Windows.Forms.ComboBox();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeliveryCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupImage = new DevExpress.XtraEditors.GroupControl();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.cmbBranchName = new System.Windows.Forms.ComboBox();
            this.bntAccept = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeliveryQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupLauncher)).BeginInit();
            this.groupLauncher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImage)).BeginInit();
            this.groupImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupLauncher
            // 
            this.groupLauncher.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupLauncher.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupLauncher.Appearance.Options.UseBackColor = true;
            this.groupLauncher.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupLauncher.Controls.Add(this.txtDeliveryQty);
            this.groupLauncher.Controls.Add(this.label5);
            this.groupLauncher.Controls.Add(this.txtProductName);
            this.groupLauncher.Controls.Add(this.label4);
            this.groupLauncher.Controls.Add(this.label12);
            this.groupLauncher.Controls.Add(this.txtItemQty);
            this.groupLauncher.Controls.Add(this.txtInventoryCode);
            this.groupLauncher.Controls.Add(this.label11);
            this.groupLauncher.Controls.Add(this.label10);
            this.groupLauncher.Controls.Add(this.dkpDelivery);
            this.groupLauncher.Controls.Add(this.pictureBox1);
            this.groupLauncher.Controls.Add(this.bntExit);
            this.groupLauncher.Controls.Add(this.lblMainTitle);
            this.groupLauncher.Controls.Add(this.label8);
            this.groupLauncher.Controls.Add(this.cmbItemStatus);
            this.groupLauncher.Controls.Add(this.txtCostPrice);
            this.groupLauncher.Controls.Add(this.label2);
            this.groupLauncher.Controls.Add(this.txtLastCost);
            this.groupLauncher.Controls.Add(this.label3);
            this.groupLauncher.Controls.Add(this.label1);
            this.groupLauncher.Controls.Add(this.txtDeliveryCode);
            this.groupLauncher.Controls.Add(this.lblName);
            this.groupLauncher.Controls.Add(this.txtBarcode);
            this.groupLauncher.Controls.Add(this.label7);
            this.groupLauncher.Controls.Add(this.groupImage);
            this.groupLauncher.Controls.Add(this.cmbBranchName);
            this.groupLauncher.Controls.Add(this.bntAccept);
            this.groupLauncher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLauncher.Location = new System.Drawing.Point(0, 0);
            this.groupLauncher.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupLauncher.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupLauncher.Name = "groupLauncher";
            this.groupLauncher.Size = new System.Drawing.Size(931, 582);
            this.groupLauncher.TabIndex = 6;
            this.groupLauncher.Text = "Accepting Delivery";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(386, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 28);
            this.label12.TabIndex = 277;
            this.label12.Text = "Branch:";
            // 
            // txtItemQty
            // 
            this.txtItemQty.BackColor = System.Drawing.Color.Yellow;
            this.txtItemQty.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtItemQty.Location = new System.Drawing.Point(523, 90);
            this.txtItemQty.Name = "txtItemQty";
            this.txtItemQty.Size = new System.Drawing.Size(396, 38);
            this.txtItemQty.TabIndex = 3;
            this.txtItemQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemQty_KeyDown);
            this.txtItemQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemQty_KeyPress);
            // 
            // txtInventoryCode
            // 
            this.txtInventoryCode.Enabled = false;
            this.txtInventoryCode.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtInventoryCode.Location = new System.Drawing.Point(523, 162);
            this.txtInventoryCode.Name = "txtInventoryCode";
            this.txtInventoryCode.Size = new System.Drawing.Size(396, 38);
            this.txtInventoryCode.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(387, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 28);
            this.label11.TabIndex = 275;
            this.label11.Text = "Inventory Code:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(386, 389);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 28);
            this.label10.TabIndex = 273;
            this.label10.Text = "Accepted Date:";
            // 
            // dkpDelivery
            // 
            this.dkpDelivery.CustomFormat = "dd-MM-yyyy";
            this.dkpDelivery.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.dkpDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDelivery.Location = new System.Drawing.Point(522, 381);
            this.dkpDelivery.Name = "dkpDelivery";
            this.dkpDelivery.Size = new System.Drawing.Size(223, 41);
            this.dkpDelivery.TabIndex = 13;
            this.dkpDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpDelivery_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(751, 347);
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
            this.bntExit.TabIndex = 16;
            this.bntExit.ToolTip = "Close Item Delivery";
            this.bntExit.Click += new System.EventHandler(this.bntExit_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(441, 486);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(373, 62);
            this.lblMainTitle.TabIndex = 270;
            this.lblMainTitle.Text = "Accept Delivery";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(386, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 28);
            this.label8.TabIndex = 267;
            this.label8.Text = "Item Status:";
            // 
            // cmbItemStatus
            // 
            this.cmbItemStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemStatus.BackColor = System.Drawing.Color.White;
            this.cmbItemStatus.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbItemStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbItemStatus.FormattingEnabled = true;
            this.cmbItemStatus.Location = new System.Drawing.Point(522, 340);
            this.cmbItemStatus.Name = "cmbItemStatus";
            this.cmbItemStatus.Size = new System.Drawing.Size(223, 43);
            this.cmbItemStatus.TabIndex = 11;
            this.cmbItemStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemStatus_KeyDown);
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Enabled = false;
            this.txtCostPrice.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtCostPrice.Location = new System.Drawing.Point(523, 234);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(396, 38);
            this.txtCostPrice.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(387, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 28);
            this.label2.TabIndex = 258;
            this.label2.Text = "Cost Price:";
            // 
            // txtLastCost
            // 
            this.txtLastCost.Enabled = false;
            this.txtLastCost.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtLastCost.Location = new System.Drawing.Point(523, 269);
            this.txtLastCost.Name = "txtLastCost";
            this.txtLastCost.Size = new System.Drawing.Size(396, 38);
            this.txtLastCost.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(387, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 28);
            this.label3.TabIndex = 256;
            this.label3.Text = "Last Cost:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(387, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 28);
            this.label1.TabIndex = 255;
            this.label1.Text = "Item Quantity:";
            // 
            // txtDeliveryCode
            // 
            this.txtDeliveryCode.Enabled = false;
            this.txtDeliveryCode.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtDeliveryCode.Location = new System.Drawing.Point(523, 199);
            this.txtDeliveryCode.Name = "txtDeliveryCode";
            this.txtDeliveryCode.Size = new System.Drawing.Size(396, 38);
            this.txtDeliveryCode.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(387, 204);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(150, 28);
            this.lblName.TabIndex = 253;
            this.lblName.Text = "Delivery Code:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtBarcode.Location = new System.Drawing.Point(523, 22);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(396, 38);
            this.txtBarcode.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(387, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 28);
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
            this.groupImage.Controls.Add(this.imgPreview);
            this.groupImage.Location = new System.Drawing.Point(2, 19);
            this.groupImage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupImage.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupImage.Name = "groupImage";
            this.groupImage.Size = new System.Drawing.Size(372, 433);
            this.groupImage.TabIndex = 250;
            // 
            // imgPreview
            // 
            this.imgPreview.BackColor = System.Drawing.Color.White;
            this.imgPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPreview.Location = new System.Drawing.Point(3, 21);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(366, 409);
            this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPreview.TabIndex = 244;
            this.imgPreview.TabStop = false;
            // 
            // cmbBranchName
            // 
            this.cmbBranchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBranchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranchName.BackColor = System.Drawing.Color.White;
            this.cmbBranchName.Enabled = false;
            this.cmbBranchName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbBranchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbBranchName.FormattingEnabled = true;
            this.cmbBranchName.Location = new System.Drawing.Point(522, 303);
            this.cmbBranchName.Name = "cmbBranchName";
            this.cmbBranchName.Size = new System.Drawing.Size(397, 43);
            this.cmbBranchName.TabIndex = 10;
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
            this.bntAccept.TabIndex = 14;
            this.bntAccept.ToolTip = "Accept Delivery";
            this.bntAccept.Click += new System.EventHandler(this.bntAccept_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtProductName.Location = new System.Drawing.Point(523, 55);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(396, 38);
            this.txtProductName.TabIndex = 278;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(387, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 28);
            this.label4.TabIndex = 279;
            this.label4.Text = "Product Name:";
            // 
            // txtDeliveryQty
            // 
            this.txtDeliveryQty.Enabled = false;
            this.txtDeliveryQty.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtDeliveryQty.Location = new System.Drawing.Point(523, 124);
            this.txtDeliveryQty.Name = "txtDeliveryQty";
            this.txtDeliveryQty.Size = new System.Drawing.Size(396, 38);
            this.txtDeliveryQty.TabIndex = 280;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(387, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 28);
            this.label5.TabIndex = 281;
            this.label5.Text = "Delivery Qty:";
            // 
            // FrmPopAccept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 582);
            this.Controls.Add(this.groupLauncher);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPopAccept";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Accept";
            this.Load += new System.EventHandler(this.FrmPopAccept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupLauncher)).EndInit();
            this.groupLauncher.ResumeLayout(false);
            this.groupLauncher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupImage)).EndInit();
            this.groupImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupLauncher;
        private System.Windows.Forms.ComboBox cmbBranchName;
        private DevExpress.XtraEditors.SimpleButton bntAccept;
        private DevExpress.XtraEditors.GroupControl groupImage;
        private System.Windows.Forms.PictureBox imgPreview;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbItemStatus;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeliveryCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBarcode;
        private DevExpress.XtraEditors.SimpleButton bntExit;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dkpDelivery;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private System.Windows.Forms.TextBox txtInventoryCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtItemQty;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeliveryQty;
        private System.Windows.Forms.Label label5;
    }
}