namespace Inventory.MainForm
{
    partial class FrmInventory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlRightOptions = new System.Windows.Forms.Panel();
            this.pcRight = new System.Windows.Forms.PictureBox();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.pbLogout = new System.Windows.Forms.PictureBox();
            this.posWET = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.RightOptions = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pcLOG = new System.Windows.Forms.PictureBox();
            this.bntHome = new System.Windows.Forms.Button();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.bntDelete = new System.Windows.Forms.Button();
            this.xtraInventory = new DevExpress.XtraTab.XtraTabControl();
            this.xtraIntake = new DevExpress.XtraTab.XtraTabPage();
            this.groupIntakeDetails = new DevExpress.XtraEditors.GroupControl();
            this.gBAL = new DevExpress.XtraEditors.GroupControl();
            this.lblSign = new DevExpress.XtraEditors.LabelControl();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProductStatus = new System.Windows.Forms.ComboBox();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.cmbBranchName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dkpInventoryDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLastCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeliveryNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInventoryCode = new System.Windows.Forms.TextBox();
            this.groupIntake = new DevExpress.XtraEditors.GroupControl();
            this.gCON = new DevExpress.XtraGrid.GridControl();
            this.gridInventory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdHIS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtPRI = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtInventoryId = new System.Windows.Forms.TextBox();
            this.xtraDelivery = new DevExpress.XtraTab.XtraTabPage();
            this.groupDeliveryDetails = new DevExpress.XtraEditors.GroupControl();
            this.ImageProduct = new System.Windows.Forms.PictureBox();
            this.groupDelivery = new DevExpress.XtraEditors.GroupControl();
            this.gridProducts = new System.Windows.Forms.DataGridView();
            this.xtraSales = new DevExpress.XtraTab.XtraTabPage();
            this.groupSalesDetails = new DevExpress.XtraEditors.GroupControl();
            this.ImageSales = new System.Windows.Forms.PictureBox();
            this.groupSales = new DevExpress.XtraEditors.GroupControl();
            this.gridSales = new System.Windows.Forms.DataGridView();
            this.bntClear = new System.Windows.Forms.Button();
            this.bntAdd = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            this.bntUpdate = new System.Windows.Forms.Button();
            this.bntSave = new System.Windows.Forms.Button();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlOptionsMain = new System.Windows.Forms.Panel();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pcSettings = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pcSchedule = new System.Windows.Forms.PictureBox();
            this.pcBL = new System.Windows.Forms.PictureBox();
            this.pcList = new System.Windows.Forms.PictureBox();
            this.pcUser = new System.Windows.Forms.PictureBox();
            this.pcAdd = new System.Windows.Forms.PictureBox();
            this.pcChangePassword = new System.Windows.Forms.PictureBox();
            this.pbHide = new System.Windows.Forms.PictureBox();
            this.Options = new System.Windows.Forms.Timer(this.components);
            this.pnlRightOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcRight)).BeginInit();
            this.pnlRightMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLOG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraInventory)).BeginInit();
            this.xtraInventory.SuspendLayout();
            this.xtraIntake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupIntakeDetails)).BeginInit();
            this.groupIntakeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBAL)).BeginInit();
            this.gBAL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupIntake)).BeginInit();
            this.groupIntake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHIS)).BeginInit();
            this.xtraDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupDeliveryDetails)).BeginInit();
            this.groupDeliveryDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).BeginInit();
            this.groupDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            this.xtraSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesDetails)).BeginInit();
            this.groupSalesDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).BeginInit();
            this.groupSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.pnlOptionsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChangePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRightOptions
            // 
            this.pnlRightOptions.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlRightOptions.Controls.Add(this.pcRight);
            this.pnlRightOptions.Controls.Add(this.pnlRightMain);
            this.pnlRightOptions.Location = new System.Drawing.Point(1307, 1);
            this.pnlRightOptions.Name = "pnlRightOptions";
            this.pnlRightOptions.Size = new System.Drawing.Size(77, 765);
            this.pnlRightOptions.TabIndex = 78;
            // 
            // pcRight
            // 
            this.pcRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pcRight.Image = ((System.Drawing.Image)(resources.GetObject("pcRight.Image")));
            this.pcRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcRight.Location = new System.Drawing.Point(3, 64);
            this.pcRight.Name = "pcRight";
            this.pcRight.Size = new System.Drawing.Size(35, 34);
            this.pcRight.TabIndex = 20;
            this.pcRight.TabStop = false;
            // 
            // pnlRightMain
            // 
            this.pnlRightMain.Controls.Add(this.pbExit);
            this.pnlRightMain.Controls.Add(this.pbHome);
            this.pnlRightMain.Controls.Add(this.pbLogout);
            this.pnlRightMain.Location = new System.Drawing.Point(3, 98);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(70, 529);
            this.pnlRightMain.TabIndex = 1;
            // 
            // pbExit
            // 
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbExit.Location = new System.Drawing.Point(-1, 448);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(70, 76);
            this.pbExit.TabIndex = 5;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbHome
            // 
            this.pbHome.Image = ((System.Drawing.Image)(resources.GetObject("pbHome.Image")));
            this.pbHome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbHome.Location = new System.Drawing.Point(-2, 269);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(76, 76);
            this.pbHome.TabIndex = 4;
            this.pbHome.TabStop = false;
            this.pbHome.Click += new System.EventHandler(this.pbHome_Click);
            // 
            // pbLogout
            // 
            this.pbLogout.Image = ((System.Drawing.Image)(resources.GetObject("pbLogout.Image")));
            this.pbLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbLogout.Location = new System.Drawing.Point(-3, 65);
            this.pbLogout.Name = "pbLogout";
            this.pbLogout.Size = new System.Drawing.Size(76, 76);
            this.pbLogout.TabIndex = 3;
            this.pbLogout.TabStop = false;
            this.pbLogout.Click += new System.EventHandler(this.pbLogout_Click);
            // 
            // posWET
            // 
            this.posWET.ClosingDelay = 500;
            // 
            // RightOptions
            // 
            this.RightOptions.Interval = 1;
            this.RightOptions.Tick += new System.EventHandler(this.RightOptions_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pcLOG);
            this.pnlMain.Controls.Add(this.bntHome);
            this.pnlMain.Controls.Add(this.lblMainTitle);
            this.pnlMain.Controls.Add(this.bntDelete);
            this.pnlMain.Controls.Add(this.xtraInventory);
            this.pnlMain.Controls.Add(this.bntClear);
            this.pnlMain.Controls.Add(this.bntAdd);
            this.pnlMain.Controls.Add(this.bntCancel);
            this.pnlMain.Controls.Add(this.bntUpdate);
            this.pnlMain.Controls.Add(this.bntSave);
            this.pnlMain.Location = new System.Drawing.Point(0, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1301, 764);
            this.pnlMain.TabIndex = 227;
            // 
            // pcLOG
            // 
            this.pcLOG.BackColor = System.Drawing.Color.Gray;
            this.pcLOG.Image = ((System.Drawing.Image)(resources.GetObject("pcLOG.Image")));
            this.pcLOG.Location = new System.Drawing.Point(40, 3);
            this.pcLOG.Name = "pcLOG";
            this.pcLOG.Size = new System.Drawing.Size(81, 104);
            this.pcLOG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcLOG.TabIndex = 236;
            this.pcLOG.TabStop = false;
            // 
            // bntHome
            // 
            this.bntHome.BackColor = System.Drawing.Color.ForestGreen;
            this.bntHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntHome.ForeColor = System.Drawing.Color.White;
            this.bntHome.Image = ((System.Drawing.Image)(resources.GetObject("bntHome.Image")));
            this.bntHome.Location = new System.Drawing.Point(93, 479);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(91, 104);
            this.bntHome.TabIndex = 127;
            this.bntHome.Text = "HOME";
            this.bntHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntHome.UseVisualStyleBackColor = false;
            this.bntHome.Click += new System.EventHandler(this.bntHOM_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(3, 114);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(180, 47);
            this.lblMainTitle.TabIndex = 227;
            this.lblMainTitle.Text = "Inventory";
            // 
            // bntDelete
            // 
            this.bntDelete.BackColor = System.Drawing.Color.DarkOrange;
            this.bntDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntDelete.ForeColor = System.Drawing.Color.White;
            this.bntDelete.Image = ((System.Drawing.Image)(resources.GetObject("bntDelete.Image")));
            this.bntDelete.Location = new System.Drawing.Point(1, 479);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(91, 104);
            this.bntDelete.TabIndex = 126;
            this.bntDelete.Text = "DELETE";
            this.bntDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntDelete.UseVisualStyleBackColor = false;
            this.bntDelete.Click += new System.EventHandler(this.bntDEL_Click);
            // 
            // xtraInventory
            // 
            this.xtraInventory.Location = new System.Drawing.Point(186, 3);
            this.xtraInventory.Name = "xtraInventory";
            this.xtraInventory.SelectedTabPage = this.xtraIntake;
            this.xtraInventory.Size = new System.Drawing.Size(1111, 758);
            this.xtraInventory.TabIndex = 228;
            this.xtraInventory.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraIntake,
            this.xtraDelivery,
            this.xtraSales});
            // 
            // xtraIntake
            // 
            this.xtraIntake.Appearance.PageClient.BackColor = System.Drawing.Color.Black;
            this.xtraIntake.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraIntake.Controls.Add(this.groupIntakeDetails);
            this.xtraIntake.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraIntake.ImageOptions.Image")));
            this.xtraIntake.Name = "xtraIntake";
            this.xtraIntake.Size = new System.Drawing.Size(1109, 730);
            this.xtraIntake.Text = "Inventory Intake";
            // 
            // groupIntakeDetails
            // 
            this.groupIntakeDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupIntakeDetails.Appearance.Options.UseBackColor = true;
            this.groupIntakeDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupIntakeDetails.Controls.Add(this.gBAL);
            this.groupIntakeDetails.Controls.Add(this.label9);
            this.groupIntakeDetails.Controls.Add(this.txtBarcode);
            this.groupIntakeDetails.Controls.Add(this.label4);
            this.groupIntakeDetails.Controls.Add(this.cmbProductStatus);
            this.groupIntakeDetails.Controls.Add(this.cmbProductName);
            this.groupIntakeDetails.Controls.Add(this.imgPreview);
            this.groupIntakeDetails.Controls.Add(this.cmbBranchName);
            this.groupIntakeDetails.Controls.Add(this.label13);
            this.groupIntakeDetails.Controls.Add(this.label12);
            this.groupIntakeDetails.Controls.Add(this.dkpInventoryDate);
            this.groupIntakeDetails.Controls.Add(this.label8);
            this.groupIntakeDetails.Controls.Add(this.txtLastCost);
            this.groupIntakeDetails.Controls.Add(this.label6);
            this.groupIntakeDetails.Controls.Add(this.txtQty);
            this.groupIntakeDetails.Controls.Add(this.label5);
            this.groupIntakeDetails.Controls.Add(this.txtDeliveryNumber);
            this.groupIntakeDetails.Controls.Add(this.label2);
            this.groupIntakeDetails.Controls.Add(this.label1);
            this.groupIntakeDetails.Controls.Add(this.txtInventoryCode);
            this.groupIntakeDetails.Controls.Add(this.groupIntake);
            this.groupIntakeDetails.Controls.Add(this.lblBarcode);
            this.groupIntakeDetails.Controls.Add(this.txtInventoryId);
            this.groupIntakeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupIntakeDetails.Location = new System.Drawing.Point(0, 0);
            this.groupIntakeDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupIntakeDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupIntakeDetails.Name = "groupIntakeDetails";
            this.groupIntakeDetails.Size = new System.Drawing.Size(1109, 730);
            this.groupIntakeDetails.TabIndex = 173;
            // 
            // gBAL
            // 
            this.gBAL.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gBAL.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.gBAL.Appearance.BorderColor = System.Drawing.Color.White;
            this.gBAL.Appearance.Options.UseBackColor = true;
            this.gBAL.Appearance.Options.UseBorderColor = true;
            this.gBAL.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gBAL.CaptionLocation = DevExpress.Utils.Locations.Bottom;
            this.gBAL.Controls.Add(this.lblSign);
            this.gBAL.Controls.Add(this.lblPrice);
            this.gBAL.Location = new System.Drawing.Point(555, 22);
            this.gBAL.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gBAL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gBAL.Name = "gBAL";
            this.gBAL.Size = new System.Drawing.Size(269, 131);
            this.gBAL.TabIndex = 230;
            this.gBAL.Text = "ITEM PRICE";
            // 
            // lblSign
            // 
            this.lblSign.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSign.Appearance.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSign.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblSign.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblSign.Appearance.Options.UseBorderColor = true;
            this.lblSign.Appearance.Options.UseFont = true;
            this.lblSign.Appearance.Options.UseForeColor = true;
            this.lblSign.Location = new System.Drawing.Point(6, 30);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(22, 47);
            this.lblSign.TabIndex = 102;
            this.lblSign.Text = "P";
            // 
            // lblPrice
            // 
            this.lblPrice.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPrice.Appearance.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblPrice.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblPrice.Appearance.Options.UseBorderColor = true;
            this.lblPrice.Appearance.Options.UseFont = true;
            this.lblPrice.Appearance.Options.UseForeColor = true;
            this.lblPrice.Location = new System.Drawing.Point(34, 30);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(89, 47);
            this.lblPrice.TabIndex = 101;
            this.lblPrice.Text = "00.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(13, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 17);
            this.label9.TabIndex = 229;
            this.label9.Text = "Product Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtBarcode.Location = new System.Drawing.Point(136, 262);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(269, 29);
            this.txtBarcode.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 225;
            this.label4.Text = "Product Status:";
            // 
            // cmbProductStatus
            // 
            this.cmbProductStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductStatus.BackColor = System.Drawing.Color.DimGray;
            this.cmbProductStatus.Enabled = false;
            this.cmbProductStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductStatus.ForeColor = System.Drawing.Color.Maroon;
            this.cmbProductStatus.FormattingEnabled = true;
            this.cmbProductStatus.Location = new System.Drawing.Point(136, 232);
            this.cmbProductStatus.Name = "cmbProductStatus";
            this.cmbProductStatus.Size = new System.Drawing.Size(269, 29);
            this.cmbProductStatus.TabIndex = 118;
            this.cmbProductStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductStatus_KeyDown);
            // 
            // cmbProductName
            // 
            this.cmbProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductName.BackColor = System.Drawing.Color.DimGray;
            this.cmbProductName.Enabled = false;
            this.cmbProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductName.ForeColor = System.Drawing.Color.Maroon;
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(135, 82);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(269, 29);
            this.cmbProductName.TabIndex = 112;
            this.cmbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductName_KeyDown);
            // 
            // imgPreview
            // 
            this.imgPreview.BackColor = System.Drawing.Color.Gray;
            this.imgPreview.Location = new System.Drawing.Point(835, 21);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(270, 268);
            this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPreview.TabIndex = 223;
            this.imgPreview.TabStop = false;
            // 
            // cmbBranchName
            // 
            this.cmbBranchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBranchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranchName.BackColor = System.Drawing.Color.DimGray;
            this.cmbBranchName.Enabled = false;
            this.cmbBranchName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranchName.ForeColor = System.Drawing.Color.Maroon;
            this.cmbBranchName.FormattingEnabled = true;
            this.cmbBranchName.Location = new System.Drawing.Point(135, 172);
            this.cmbBranchName.Name = "cmbBranchName";
            this.cmbBranchName.Size = new System.Drawing.Size(269, 29);
            this.cmbBranchName.TabIndex = 116;
            this.cmbBranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranchName_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(13, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 214;
            this.label13.Text = "Branch Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(432, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 17);
            this.label12.TabIndex = 212;
            this.label12.Text = "Inventory Date:";
            // 
            // dkpInventoryDate
            // 
            this.dkpInventoryDate.CustomFormat = "dd-MM-yyyy";
            this.dkpInventoryDate.Enabled = false;
            this.dkpInventoryDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpInventoryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpInventoryDate.Location = new System.Drawing.Point(555, 155);
            this.dkpInventoryDate.Name = "dkpInventoryDate";
            this.dkpInventoryDate.Size = new System.Drawing.Size(269, 29);
            this.dkpInventoryDate.TabIndex = 120;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(13, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 206;
            this.label8.Text = "Last Cost:";
            // 
            // txtLastCost
            // 
            this.txtLastCost.BackColor = System.Drawing.Color.DimGray;
            this.txtLastCost.Enabled = false;
            this.txtLastCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastCost.ForeColor = System.Drawing.Color.Maroon;
            this.txtLastCost.Location = new System.Drawing.Point(136, 202);
            this.txtLastCost.Name = "txtLastCost";
            this.txtLastCost.Size = new System.Drawing.Size(269, 29);
            this.txtLastCost.TabIndex = 117;
            this.txtLastCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLastCost_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 184;
            this.label6.Text = "QTY Stock:";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.DimGray;
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtQty.Location = new System.Drawing.Point(136, 142);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(269, 29);
            this.txtQty.TabIndex = 115;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 182;
            this.label5.Text = "Product Name:";
            // 
            // txtDeliveryNumber
            // 
            this.txtDeliveryNumber.BackColor = System.Drawing.Color.DimGray;
            this.txtDeliveryNumber.Enabled = false;
            this.txtDeliveryNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryNumber.ForeColor = System.Drawing.Color.Maroon;
            this.txtDeliveryNumber.Location = new System.Drawing.Point(136, 112);
            this.txtDeliveryNumber.Name = "txtDeliveryNumber";
            this.txtDeliveryNumber.Size = new System.Drawing.Size(269, 29);
            this.txtDeliveryNumber.TabIndex = 113;
            this.txtDeliveryNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 176;
            this.label2.Text = "Delivery No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 174;
            this.label1.Text = "Inventory Code:";
            // 
            // txtInventoryCode
            // 
            this.txtInventoryCode.BackColor = System.Drawing.Color.DimGray;
            this.txtInventoryCode.Enabled = false;
            this.txtInventoryCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryCode.ForeColor = System.Drawing.Color.Maroon;
            this.txtInventoryCode.Location = new System.Drawing.Point(136, 52);
            this.txtInventoryCode.Name = "txtInventoryCode";
            this.txtInventoryCode.Size = new System.Drawing.Size(269, 29);
            this.txtInventoryCode.TabIndex = 111;
            this.txtInventoryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInventoryCode_KeyDown);
            // 
            // groupIntake
            // 
            this.groupIntake.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupIntake.Appearance.Options.UseBackColor = true;
            this.groupIntake.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupIntake.Controls.Add(this.gCON);
            this.groupIntake.Controls.Add(this.txtPRI);
            this.groupIntake.Location = new System.Drawing.Point(-1, 295);
            this.groupIntake.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupIntake.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupIntake.Name = "groupIntake";
            this.groupIntake.Size = new System.Drawing.Size(1108, 440);
            this.groupIntake.TabIndex = 172;
            this.groupIntake.Text = "List of Stock Received";
            // 
            // gCON
            // 
            this.gCON.Cursor = System.Windows.Forms.Cursors.Default;
            this.gCON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCON.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gCON.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gCON.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gCON.Location = new System.Drawing.Point(3, 18);
            this.gCON.MainView = this.gridInventory;
            this.gCON.Name = "gCON";
            this.gCON.Size = new System.Drawing.Size(1102, 419);
            this.gCON.TabIndex = 102;
            this.gCON.TabStop = false;
            this.gCON.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInventory,
            this.gridView2,
            this.gridView3,
            this.grdHIS});
            // 
            // gridInventory
            // 
            this.gridInventory.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridInventory.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridInventory.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridInventory.Appearance.Empty.Options.UseBackColor = true;
            this.gridInventory.Appearance.Empty.Options.UseBorderColor = true;
            this.gridInventory.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridInventory.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridInventory.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridInventory.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridInventory.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridInventory.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridInventory.Appearance.FocusedRow.Options.UseFont = true;
            this.gridInventory.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridInventory.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridInventory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridInventory.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridInventory.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridInventory.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridInventory.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridInventory.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridInventory.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridInventory.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.Appearance.Row.Options.UseBackColor = true;
            this.gridInventory.Appearance.Row.Options.UseBorderColor = true;
            this.gridInventory.Appearance.Row.Options.UseFont = true;
            this.gridInventory.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.Appearance.ViewCaption.Options.UseFont = true;
            this.gridInventory.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridInventory.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridInventory.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridInventory.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridInventory.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridInventory.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridInventory.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridInventory.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridInventory.AppearancePrint.Row.Options.UseFont = true;
            this.gridInventory.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridInventory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridInventory.GridControl = this.gCON;
            this.gridInventory.Name = "gridInventory";
            this.gridInventory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridInventory.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridInventory.OptionsBehavior.Editable = false;
            this.gridInventory.OptionsCustomization.AllowRowSizing = true;
            this.gridInventory.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridInventory.OptionsSelection.MultiSelect = true;
            this.gridInventory.OptionsView.EnableAppearanceEvenRow = true;
            this.gridInventory.OptionsView.RowAutoHeight = true;
            this.gridInventory.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridInventory.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridInventory_RowClick);
            this.gridInventory.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridInventory_FocusedRowChanged);
            this.gridInventory.LostFocus += new System.EventHandler(this.gridInventory_LostFocus);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gCON;
            this.gridView2.Name = "gridView2";
            // 
            // gridView3
            // 
            this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView3.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gridView3.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Green;
            this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView3.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridView3.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView3.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridView3.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView3.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView3.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView3.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView3.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridView3.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView3.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView3.AppearancePrint.Row.Options.UseFont = true;
            this.gridView3.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridView3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView3.GridControl = this.gCON;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsCustomization.AllowRowSizing = true;
            this.gridView3.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView3.OptionsSelection.MultiSelect = true;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            // 
            // grdHIS
            // 
            this.grdHIS.GridControl = this.gCON;
            this.grdHIS.Name = "grdHIS";
            // 
            // txtPRI
            // 
            this.txtPRI.BackColor = System.Drawing.Color.DimGray;
            this.txtPRI.Enabled = false;
            this.txtPRI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRI.ForeColor = System.Drawing.Color.Maroon;
            this.txtPRI.Location = new System.Drawing.Point(-8, 21);
            this.txtPRI.Multiline = true;
            this.txtPRI.Name = "txtPRI";
            this.txtPRI.Size = new System.Drawing.Size(10, 10);
            this.txtPRI.TabIndex = 99;
            this.txtPRI.Visible = false;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.White;
            this.lblBarcode.Location = new System.Drawing.Point(13, 28);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(88, 17);
            this.lblBarcode.TabIndex = 142;
            this.lblBarcode.Text = "Inventory Id:";
            // 
            // txtInventoryId
            // 
            this.txtInventoryId.BackColor = System.Drawing.Color.DimGray;
            this.txtInventoryId.Enabled = false;
            this.txtInventoryId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryId.ForeColor = System.Drawing.Color.Maroon;
            this.txtInventoryId.Location = new System.Drawing.Point(136, 22);
            this.txtInventoryId.Name = "txtInventoryId";
            this.txtInventoryId.Size = new System.Drawing.Size(269, 29);
            this.txtInventoryId.TabIndex = 110;
            // 
            // xtraDelivery
            // 
            this.xtraDelivery.Controls.Add(this.groupDeliveryDetails);
            this.xtraDelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraDelivery.ImageOptions.Image")));
            this.xtraDelivery.Name = "xtraDelivery";
            this.xtraDelivery.Size = new System.Drawing.Size(1109, 730);
            this.xtraDelivery.Text = "Delivery Received";
            // 
            // groupDeliveryDetails
            // 
            this.groupDeliveryDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupDeliveryDetails.Appearance.Options.UseBackColor = true;
            this.groupDeliveryDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupDeliveryDetails.Controls.Add(this.ImageProduct);
            this.groupDeliveryDetails.Controls.Add(this.groupDelivery);
            this.groupDeliveryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDeliveryDetails.Location = new System.Drawing.Point(0, 0);
            this.groupDeliveryDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupDeliveryDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupDeliveryDetails.Name = "groupDeliveryDetails";
            this.groupDeliveryDetails.Size = new System.Drawing.Size(1109, 730);
            this.groupDeliveryDetails.TabIndex = 175;
            // 
            // ImageProduct
            // 
            this.ImageProduct.BackColor = System.Drawing.Color.Gray;
            this.ImageProduct.Location = new System.Drawing.Point(834, 22);
            this.ImageProduct.Name = "ImageProduct";
            this.ImageProduct.Size = new System.Drawing.Size(270, 268);
            this.ImageProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageProduct.TabIndex = 224;
            this.ImageProduct.TabStop = false;
            // 
            // groupDelivery
            // 
            this.groupDelivery.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupDelivery.Appearance.Options.UseBackColor = true;
            this.groupDelivery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupDelivery.Controls.Add(this.gridProducts);
            this.groupDelivery.Location = new System.Drawing.Point(1, 295);
            this.groupDelivery.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupDelivery.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupDelivery.Name = "groupDelivery";
            this.groupDelivery.Size = new System.Drawing.Size(1109, 436);
            this.groupDelivery.TabIndex = 174;
            this.groupDelivery.Text = "List of Stock Received";
            // 
            // gridProducts
            // 
            this.gridProducts.AllowUserToAddRows = false;
            this.gridProducts.BackgroundColor = System.Drawing.Color.White;
            this.gridProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProducts.ColumnHeadersHeight = 30;
            this.gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProducts.EnableHeadersVisualStyles = false;
            this.gridProducts.Location = new System.Drawing.Point(3, 18);
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.RowHeadersVisible = false;
            this.gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProducts.Size = new System.Drawing.Size(1103, 415);
            this.gridProducts.TabIndex = 110;
            this.gridProducts.SelectionChanged += new System.EventHandler(this.gridProducts_SelectionChanged);
            // 
            // xtraSales
            // 
            this.xtraSales.Controls.Add(this.groupSalesDetails);
            this.xtraSales.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraSales.ImageOptions.Image")));
            this.xtraSales.Name = "xtraSales";
            this.xtraSales.Size = new System.Drawing.Size(1109, 730);
            this.xtraSales.Text = "Transaction History";
            // 
            // groupSalesDetails
            // 
            this.groupSalesDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupSalesDetails.Appearance.Options.UseBackColor = true;
            this.groupSalesDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupSalesDetails.Controls.Add(this.ImageSales);
            this.groupSalesDetails.Controls.Add(this.groupSales);
            this.groupSalesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSalesDetails.Location = new System.Drawing.Point(0, 0);
            this.groupSalesDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSalesDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSalesDetails.Name = "groupSalesDetails";
            this.groupSalesDetails.Size = new System.Drawing.Size(1109, 730);
            this.groupSalesDetails.TabIndex = 176;
            // 
            // ImageSales
            // 
            this.ImageSales.BackColor = System.Drawing.Color.Gray;
            this.ImageSales.Location = new System.Drawing.Point(835, 23);
            this.ImageSales.Name = "ImageSales";
            this.ImageSales.Size = new System.Drawing.Size(270, 268);
            this.ImageSales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageSales.TabIndex = 225;
            this.ImageSales.TabStop = false;
            // 
            // groupSales
            // 
            this.groupSales.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupSales.Appearance.Options.UseBackColor = true;
            this.groupSales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupSales.Controls.Add(this.gridSales);
            this.groupSales.Location = new System.Drawing.Point(2, 295);
            this.groupSales.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSales.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSales.Name = "groupSales";
            this.groupSales.Size = new System.Drawing.Size(1106, 433);
            this.groupSales.TabIndex = 175;
            this.groupSales.Text = "List of Transaction History";
            // 
            // gridSales
            // 
            this.gridSales.AllowUserToAddRows = false;
            this.gridSales.BackgroundColor = System.Drawing.Color.White;
            this.gridSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSales.ColumnHeadersHeight = 30;
            this.gridSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSales.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridSales.EnableHeadersVisualStyles = false;
            this.gridSales.Location = new System.Drawing.Point(3, 18);
            this.gridSales.Name = "gridSales";
            this.gridSales.RowHeadersVisible = false;
            this.gridSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSales.Size = new System.Drawing.Size(1100, 412);
            this.gridSales.TabIndex = 111;
            this.gridSales.SelectionChanged += new System.EventHandler(this.gridSales_SelectionChanged);
            // 
            // bntClear
            // 
            this.bntClear.BackColor = System.Drawing.Color.Firebrick;
            this.bntClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntClear.ForeColor = System.Drawing.Color.White;
            this.bntClear.Image = ((System.Drawing.Image)(resources.GetObject("bntClear.Image")));
            this.bntClear.Location = new System.Drawing.Point(1, 374);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(91, 104);
            this.bntClear.TabIndex = 124;
            this.bntClear.Text = "BRANCH";
            this.bntClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntClear.UseVisualStyleBackColor = false;
            this.bntClear.Click += new System.EventHandler(this.bntCLR_Click);
            // 
            // bntAdd
            // 
            this.bntAdd.BackColor = System.Drawing.Color.Red;
            this.bntAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAdd.ForeColor = System.Drawing.Color.White;
            this.bntAdd.Image = ((System.Drawing.Image)(resources.GetObject("bntAdd.Image")));
            this.bntAdd.Location = new System.Drawing.Point(1, 164);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(91, 104);
            this.bntAdd.TabIndex = 121;
            this.bntAdd.Text = "ACCEPT";
            this.bntAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntAdd.UseVisualStyleBackColor = false;
            this.bntAdd.Click += new System.EventHandler(this.bntADD_Click);
            // 
            // bntCancel
            // 
            this.bntCancel.BackColor = System.Drawing.Color.DimGray;
            this.bntCancel.Enabled = false;
            this.bntCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCancel.ForeColor = System.Drawing.Color.White;
            this.bntCancel.Image = ((System.Drawing.Image)(resources.GetObject("bntCancel.Image")));
            this.bntCancel.Location = new System.Drawing.Point(93, 374);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(91, 104);
            this.bntCancel.TabIndex = 125;
            this.bntCancel.Text = "CANCEL";
            this.bntCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntCancel.UseVisualStyleBackColor = false;
            this.bntCancel.Click += new System.EventHandler(this.bntCAN_Click);
            // 
            // bntUpdate
            // 
            this.bntUpdate.BackColor = System.Drawing.Color.Blue;
            this.bntUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntUpdate.ForeColor = System.Drawing.Color.White;
            this.bntUpdate.Image = ((System.Drawing.Image)(resources.GetObject("bntUpdate.Image")));
            this.bntUpdate.Location = new System.Drawing.Point(93, 164);
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.Size = new System.Drawing.Size(91, 104);
            this.bntUpdate.TabIndex = 122;
            this.bntUpdate.Text = "EDIT";
            this.bntUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntUpdate.UseVisualStyleBackColor = false;
            this.bntUpdate.Click += new System.EventHandler(this.bntUPD_Click);
            // 
            // bntSave
            // 
            this.bntSave.BackColor = System.Drawing.Color.Fuchsia;
            this.bntSave.Enabled = false;
            this.bntSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSave.ForeColor = System.Drawing.Color.White;
            this.bntSave.Image = ((System.Drawing.Image)(resources.GetObject("bntSave.Image")));
            this.bntSave.Location = new System.Drawing.Point(1, 269);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(183, 104);
            this.bntSave.TabIndex = 123;
            this.bntSave.Text = "SAVE";
            this.bntSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntSave.UseVisualStyleBackColor = false;
            this.bntSave.Click += new System.EventHandler(this.bntSAV_Click);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlOptions.Controls.Add(this.pnlOptionsMain);
            this.pnlOptions.Controls.Add(this.pbHide);
            this.pnlOptions.ForeColor = System.Drawing.Color.Black;
            this.pnlOptions.Location = new System.Drawing.Point(3, 772);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1298, 74);
            this.pnlOptions.TabIndex = 228;
            // 
            // pnlOptionsMain
            // 
            this.pnlOptionsMain.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlOptionsMain.Controls.Add(this.pictureBox17);
            this.pnlOptionsMain.Controls.Add(this.pcSettings);
            this.pnlOptionsMain.Controls.Add(this.pictureBox1);
            this.pnlOptionsMain.Controls.Add(this.pcSchedule);
            this.pnlOptionsMain.Controls.Add(this.pcBL);
            this.pnlOptionsMain.Controls.Add(this.pcList);
            this.pnlOptionsMain.Controls.Add(this.pcUser);
            this.pnlOptionsMain.Controls.Add(this.pcAdd);
            this.pnlOptionsMain.Controls.Add(this.pcChangePassword);
            this.pnlOptionsMain.Location = new System.Drawing.Point(19, 4);
            this.pnlOptionsMain.Name = "pnlOptionsMain";
            this.pnlOptionsMain.Size = new System.Drawing.Size(893, 67);
            this.pnlOptionsMain.TabIndex = 21;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox17.Image")));
            this.pictureBox17.Location = new System.Drawing.Point(806, 3);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(76, 64);
            this.pictureBox17.TabIndex = 59;
            this.pictureBox17.TabStop = false;
            // 
            // pcSettings
            // 
            this.pcSettings.BackColor = System.Drawing.Color.Transparent;
            this.pcSettings.Image = ((System.Drawing.Image)(resources.GetObject("pcSettings.Image")));
            this.pcSettings.Location = new System.Drawing.Point(714, 3);
            this.pcSettings.Name = "pcSettings";
            this.pcSettings.Size = new System.Drawing.Size(76, 61);
            this.pcSettings.TabIndex = 58;
            this.pcSettings.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(241, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 64);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pcSchedule
            // 
            this.pcSchedule.BackColor = System.Drawing.Color.Transparent;
            this.pcSchedule.Image = ((System.Drawing.Image)(resources.GetObject("pcSchedule.Image")));
            this.pcSchedule.Location = new System.Drawing.Point(616, 3);
            this.pcSchedule.Name = "pcSchedule";
            this.pcSchedule.Size = new System.Drawing.Size(76, 64);
            this.pcSchedule.TabIndex = 17;
            this.pcSchedule.TabStop = false;
            // 
            // pcBL
            // 
            this.pcBL.BackColor = System.Drawing.Color.Transparent;
            this.pcBL.Image = ((System.Drawing.Image)(resources.GetObject("pcBL.Image")));
            this.pcBL.Location = new System.Drawing.Point(523, 2);
            this.pcBL.Name = "pcBL";
            this.pcBL.Size = new System.Drawing.Size(76, 64);
            this.pcBL.TabIndex = 16;
            this.pcBL.TabStop = false;
            // 
            // pcList
            // 
            this.pcList.BackColor = System.Drawing.Color.Transparent;
            this.pcList.Image = ((System.Drawing.Image)(resources.GetObject("pcList.Image")));
            this.pcList.Location = new System.Drawing.Point(428, 1);
            this.pcList.Name = "pcList";
            this.pcList.Size = new System.Drawing.Size(76, 64);
            this.pcList.TabIndex = 15;
            this.pcList.TabStop = false;
            // 
            // pcUser
            // 
            this.pcUser.BackColor = System.Drawing.Color.Transparent;
            this.pcUser.Image = ((System.Drawing.Image)(resources.GetObject("pcUser.Image")));
            this.pcUser.Location = new System.Drawing.Point(144, 2);
            this.pcUser.Name = "pcUser";
            this.pcUser.Size = new System.Drawing.Size(76, 64);
            this.pcUser.TabIndex = 14;
            this.pcUser.TabStop = false;
            // 
            // pcAdd
            // 
            this.pcAdd.BackColor = System.Drawing.Color.Transparent;
            this.pcAdd.Image = ((System.Drawing.Image)(resources.GetObject("pcAdd.Image")));
            this.pcAdd.Location = new System.Drawing.Point(37, 2);
            this.pcAdd.Name = "pcAdd";
            this.pcAdd.Size = new System.Drawing.Size(76, 64);
            this.pcAdd.TabIndex = 13;
            this.pcAdd.TabStop = false;
            // 
            // pcChangePassword
            // 
            this.pcChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.pcChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("pcChangePassword.Image")));
            this.pcChangePassword.Location = new System.Drawing.Point(334, 2);
            this.pcChangePassword.Name = "pcChangePassword";
            this.pcChangePassword.Size = new System.Drawing.Size(76, 64);
            this.pcChangePassword.TabIndex = 9;
            this.pcChangePassword.TabStop = false;
            // 
            // pbHide
            // 
            this.pbHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbHide.Image = ((System.Drawing.Image)(resources.GetObject("pbHide.Image")));
            this.pbHide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbHide.Location = new System.Drawing.Point(1154, 3);
            this.pbHide.Name = "pbHide";
            this.pbHide.Size = new System.Drawing.Size(38, 34);
            this.pbHide.TabIndex = 14;
            this.pbHide.TabStop = false;
            // 
            // Options
            // 
            this.Options.Interval = 1;
            this.Options.Tick += new System.EventHandler(this.Options_Tick);
            // 
            // FrmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlRightOptions);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInventory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInventory_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmInventory_MouseMove);
            this.pnlRightOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcRight)).EndInit();
            this.pnlRightMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLOG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraInventory)).EndInit();
            this.xtraInventory.ResumeLayout(false);
            this.xtraIntake.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupIntakeDetails)).EndInit();
            this.groupIntakeDetails.ResumeLayout(false);
            this.groupIntakeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBAL)).EndInit();
            this.gBAL.ResumeLayout(false);
            this.gBAL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupIntake)).EndInit();
            this.groupIntake.ResumeLayout(false);
            this.groupIntake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHIS)).EndInit();
            this.xtraDelivery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupDeliveryDetails)).EndInit();
            this.groupDeliveryDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).EndInit();
            this.groupDelivery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            this.xtraSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesDetails)).EndInit();
            this.groupSalesDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).EndInit();
            this.groupSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptionsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChangePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRightOptions;
        private System.Windows.Forms.PictureBox pcRight;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.PictureBox pbLogout;
        private DevExpress.XtraSplashScreen.SplashScreenManager posWET;
        private System.Windows.Forms.Timer RightOptions;
        private System.Windows.Forms.Panel pnlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.PictureBox pcLOG;
        private System.Windows.Forms.Button bntHome;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Button bntDelete;
        private DevExpress.XtraTab.XtraTabControl xtraInventory;
        private DevExpress.XtraTab.XtraTabPage xtraIntake;
        private DevExpress.XtraEditors.GroupControl groupIntakeDetails;
        private DevExpress.XtraEditors.GroupControl gBAL;
        private DevExpress.XtraEditors.LabelControl lblPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProductStatus;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.PictureBox imgPreview;
        private System.Windows.Forms.ComboBox cmbBranchName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dkpInventoryDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLastCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeliveryNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInventoryCode;
        private DevExpress.XtraEditors.GroupControl groupIntake;
        private DevExpress.XtraGrid.GridControl gCON;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView grdHIS;
        private System.Windows.Forms.TextBox txtPRI;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtInventoryId;
        private DevExpress.XtraTab.XtraTabPage xtraDelivery;
        private DevExpress.XtraEditors.GroupControl groupDelivery;
        private DevExpress.XtraTab.XtraTabPage xtraSales;
        private DevExpress.XtraEditors.GroupControl groupSales;
        private System.Windows.Forms.Button bntClear;
        private System.Windows.Forms.Button bntAdd;
        private System.Windows.Forms.Button bntCancel;
        private System.Windows.Forms.Button bntUpdate;
        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlOptionsMain;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pcSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pcSchedule;
        private System.Windows.Forms.PictureBox pcBL;
        private System.Windows.Forms.PictureBox pcList;
        private System.Windows.Forms.PictureBox pcUser;
        private System.Windows.Forms.PictureBox pcAdd;
        private System.Windows.Forms.PictureBox pcChangePassword;
        private System.Windows.Forms.PictureBox pbHide;
        private System.Windows.Forms.Timer Options;
        private System.Windows.Forms.DataGridView gridSales;
        private DevExpress.XtraEditors.LabelControl lblSign;
        private DevExpress.XtraEditors.GroupControl groupDeliveryDetails;
        private System.Windows.Forms.PictureBox ImageProduct;
        private DevExpress.XtraEditors.GroupControl groupSalesDetails;
        private System.Windows.Forms.PictureBox ImageSales;
    }
}