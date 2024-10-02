namespace Inventory.PopupForm
{
    partial class FrmPopAddExpenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopAddExpenses));
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.groupLauncher = new DevExpress.XtraEditors.GroupControl();
            this.cmbRelatedEntity = new System.Windows.Forms.ComboBox();
            this.cmbExpensesType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dkpDelivery = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bntExit = new DevExpress.XtraEditors.SimpleButton();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupImage = new DevExpress.XtraEditors.GroupControl();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.bntAccept = new DevExpress.XtraEditors.SimpleButton();
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
            this.groupLauncher.Controls.Add(this.cmbRelatedEntity);
            this.groupLauncher.Controls.Add(this.cmbExpensesType);
            this.groupLauncher.Controls.Add(this.label10);
            this.groupLauncher.Controls.Add(this.dkpDelivery);
            this.groupLauncher.Controls.Add(this.pictureBox1);
            this.groupLauncher.Controls.Add(this.bntExit);
            this.groupLauncher.Controls.Add(this.lblMainTitle);
            this.groupLauncher.Controls.Add(this.txtDescription);
            this.groupLauncher.Controls.Add(this.label6);
            this.groupLauncher.Controls.Add(this.label2);
            this.groupLauncher.Controls.Add(this.txtAmount);
            this.groupLauncher.Controls.Add(this.label3);
            this.groupLauncher.Controls.Add(this.label7);
            this.groupLauncher.Controls.Add(this.groupImage);
            this.groupLauncher.Controls.Add(this.bntAccept);
            this.groupLauncher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLauncher.Location = new System.Drawing.Point(0, 0);
            this.groupLauncher.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupLauncher.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupLauncher.Name = "groupLauncher";
            this.groupLauncher.Size = new System.Drawing.Size(931, 475);
            this.groupLauncher.TabIndex = 6;
            this.groupLauncher.Text = "Stock Expenses From Inventory";
            // 
            // cmbRelatedEntity
            // 
            this.cmbRelatedEntity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRelatedEntity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRelatedEntity.BackColor = System.Drawing.Color.White;
            this.cmbRelatedEntity.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbRelatedEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbRelatedEntity.FormattingEnabled = true;
            this.cmbRelatedEntity.Location = new System.Drawing.Point(522, 98);
            this.cmbRelatedEntity.Name = "cmbRelatedEntity";
            this.cmbRelatedEntity.Size = new System.Drawing.Size(397, 36);
            this.cmbRelatedEntity.TabIndex = 282;
            // 
            // cmbExpensesType
            // 
            this.cmbExpensesType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbExpensesType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbExpensesType.BackColor = System.Drawing.Color.White;
            this.cmbExpensesType.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbExpensesType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbExpensesType.FormattingEnabled = true;
            this.cmbExpensesType.Location = new System.Drawing.Point(522, 27);
            this.cmbExpensesType.Name = "cmbExpensesType";
            this.cmbExpensesType.Size = new System.Drawing.Size(397, 36);
            this.cmbExpensesType.TabIndex = 281;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(387, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 21);
            this.label10.TabIndex = 273;
            this.label10.Text = "Date:";
            // 
            // dkpDelivery
            // 
            this.dkpDelivery.CustomFormat = "dd-MM-yyyy";
            this.dkpDelivery.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.dkpDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDelivery.Location = new System.Drawing.Point(523, 169);
            this.dkpDelivery.Name = "dkpDelivery";
            this.dkpDelivery.Size = new System.Drawing.Size(396, 34);
            this.dkpDelivery.TabIndex = 13;
            this.dkpDelivery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpDelivery_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(711, 226);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 241);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 271;
            this.pictureBox1.TabStop = false;
            // 
            // bntExit
            // 
            this.bntExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntExit.ImageOptions.Image")));
            this.bntExit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntExit.Location = new System.Drawing.Point(2, 411);
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
            this.lblMainTitle.Location = new System.Drawing.Point(439, 323);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(186, 51);
            this.lblMainTitle.TabIndex = 270;
            this.lblMainTitle.Text = "Expenses";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(523, 136);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(396, 32);
            this.txtDescription.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(387, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 21);
            this.label6.TabIndex = 264;
            this.label6.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(387, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 258;
            this.label2.Text = "Related Entity:";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(523, 65);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(396, 32);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmountPaid_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmountPaid_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(387, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 256;
            this.label3.Text = "Amount:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(387, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 21);
            this.label7.TabIndex = 251;
            this.label7.Text = "Expenses Type:";
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
            this.groupImage.Size = new System.Drawing.Size(372, 328);
            this.groupImage.TabIndex = 250;
            // 
            // imgPreview
            // 
            this.imgPreview.BackColor = System.Drawing.Color.White;
            this.imgPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPreview.Location = new System.Drawing.Point(3, 18);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(366, 307);
            this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPreview.TabIndex = 244;
            this.imgPreview.TabStop = false;
            // 
            // bntAccept
            // 
            this.bntAccept.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAccept.Appearance.Options.UseFont = true;
            this.bntAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntAccept.ImageOptions.Image")));
            this.bntAccept.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntAccept.Location = new System.Drawing.Point(2, 348);
            this.bntAccept.Name = "bntAccept";
            this.bntAccept.Size = new System.Drawing.Size(371, 62);
            this.bntAccept.TabIndex = 14;
            this.bntAccept.ToolTip = "Accept Delivery";
            this.bntAccept.Click += new System.EventHandler(this.bntAccept_Click);
            // 
            // FrmPopAddExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 475);
            this.Controls.Add(this.groupLauncher);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPopAddExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPopAccept";
            this.Load += new System.EventHandler(this.FrmPopAddExpenses_Load);
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
        private DevExpress.XtraEditors.SimpleButton bntAccept;
        private DevExpress.XtraEditors.GroupControl groupImage;
        private System.Windows.Forms.PictureBox imgPreview;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton bntExit;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dkpDelivery;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private System.Windows.Forms.ComboBox cmbExpensesType;
        private System.Windows.Forms.ComboBox cmbRelatedEntity;
    }
}