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
            this.lblDeliveredQty = new System.Windows.Forms.Label();
            this.txtDeliveredQty = new System.Windows.Forms.TextBox();
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
            this.label25 = new System.Windows.Forms.Label();
            this.dkpDelUpdate = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbDelDeliveryStatus = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDelRemarks = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDelReceiptNo = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDelTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDelDeliveryQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDelCostPerItem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDelStatus = new System.Windows.Forms.ComboBox();
            this.cmbDelProductName = new System.Windows.Forms.ComboBox();
            this.cmbDelBranch = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dkpDelDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDelLastCost = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDelQty = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDelDeliveryNo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDelBarcode = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDelDeliveryID = new System.Windows.Forms.TextBox();
            this.ImageProduct = new System.Windows.Forms.PictureBox();
            this.groupDelivery = new DevExpress.XtraEditors.GroupControl();
            this.gridCtrlProducts = new DevExpress.XtraGrid.GridControl();
            this.gridProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraSales = new DevExpress.XtraTab.XtraTabPage();
            this.groupSalesDetails = new DevExpress.XtraEditors.GroupControl();
            this.cmbSalesStatus = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSalesDiscount = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtSalesCustomer = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtSalesQty = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtSalesNet = new System.Windows.Forms.TextBox();
            this.cmbSalesProductName = new System.Windows.Forms.ComboBox();
            this.cmbSalesBranch = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.dkpSalesDate = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.txtSalesGross = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtSalesPrice = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtSalesInvoice = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtSalesBarcode = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.ImageSales = new System.Windows.Forms.PictureBox();
            this.groupSales = new DevExpress.XtraEditors.GroupControl();
            this.gridCtrlSales = new DevExpress.XtraGrid.GridControl();
            this.gridSales = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            this.xtraSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesDetails)).BeginInit();
            this.groupSalesDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).BeginInit();
            this.groupSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
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
            this.pnlRightOptions.Location = new System.Drawing.Point(1743, 1);
            this.pnlRightOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRightOptions.Name = "pnlRightOptions";
            this.pnlRightOptions.Size = new System.Drawing.Size(103, 942);
            this.pnlRightOptions.TabIndex = 78;
            // 
            // pcRight
            // 
            this.pcRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pcRight.Image = ((System.Drawing.Image)(resources.GetObject("pcRight.Image")));
            this.pcRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcRight.Location = new System.Drawing.Point(4, 79);
            this.pcRight.Margin = new System.Windows.Forms.Padding(4);
            this.pcRight.Name = "pcRight";
            this.pcRight.Size = new System.Drawing.Size(47, 42);
            this.pcRight.TabIndex = 20;
            this.pcRight.TabStop = false;
            // 
            // pnlRightMain
            // 
            this.pnlRightMain.Controls.Add(this.pbExit);
            this.pnlRightMain.Controls.Add(this.pbHome);
            this.pnlRightMain.Controls.Add(this.pbLogout);
            this.pnlRightMain.Location = new System.Drawing.Point(4, 121);
            this.pnlRightMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(93, 651);
            this.pnlRightMain.TabIndex = 1;
            // 
            // pbExit
            // 
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbExit.Location = new System.Drawing.Point(-1, 551);
            this.pbExit.Margin = new System.Windows.Forms.Padding(4);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(93, 94);
            this.pbExit.TabIndex = 5;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbHome
            // 
            this.pbHome.Image = ((System.Drawing.Image)(resources.GetObject("pbHome.Image")));
            this.pbHome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbHome.Location = new System.Drawing.Point(-3, 331);
            this.pbHome.Margin = new System.Windows.Forms.Padding(4);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(101, 94);
            this.pbHome.TabIndex = 4;
            this.pbHome.TabStop = false;
            this.pbHome.Click += new System.EventHandler(this.pbHome_Click);
            // 
            // pbLogout
            // 
            this.pbLogout.Image = ((System.Drawing.Image)(resources.GetObject("pbLogout.Image")));
            this.pbLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbLogout.Location = new System.Drawing.Point(-4, 80);
            this.pbLogout.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogout.Name = "pbLogout";
            this.pbLogout.Size = new System.Drawing.Size(101, 94);
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
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1735, 940);
            this.pnlMain.TabIndex = 227;
            // 
            // pcLOG
            // 
            this.pcLOG.BackColor = System.Drawing.Color.Gray;
            this.pcLOG.Image = ((System.Drawing.Image)(resources.GetObject("pcLOG.Image")));
            this.pcLOG.Location = new System.Drawing.Point(53, 4);
            this.pcLOG.Margin = new System.Windows.Forms.Padding(4);
            this.pcLOG.Name = "pcLOG";
            this.pcLOG.Size = new System.Drawing.Size(108, 128);
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
            this.bntHome.Location = new System.Drawing.Point(124, 590);
            this.bntHome.Margin = new System.Windows.Forms.Padding(4);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(121, 128);
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
            this.lblMainTitle.Location = new System.Drawing.Point(4, 140);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(229, 60);
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
            this.bntDelete.Location = new System.Drawing.Point(1, 590);
            this.bntDelete.Margin = new System.Windows.Forms.Padding(4);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(121, 128);
            this.bntDelete.TabIndex = 126;
            this.bntDelete.Text = "DELETE";
            this.bntDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntDelete.UseVisualStyleBackColor = false;
            this.bntDelete.Click += new System.EventHandler(this.bntDEL_Click);
            // 
            // xtraInventory
            // 
            this.xtraInventory.Location = new System.Drawing.Point(248, 4);
            this.xtraInventory.Margin = new System.Windows.Forms.Padding(4);
            this.xtraInventory.Name = "xtraInventory";
            this.xtraInventory.SelectedTabPage = this.xtraIntake;
            this.xtraInventory.Size = new System.Drawing.Size(1481, 933);
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
            this.xtraIntake.Margin = new System.Windows.Forms.Padding(4);
            this.xtraIntake.Name = "xtraIntake";
            this.xtraIntake.Size = new System.Drawing.Size(1479, 903);
            this.xtraIntake.Text = "Inventory Intake";
            // 
            // groupIntakeDetails
            // 
            this.groupIntakeDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupIntakeDetails.Appearance.Options.UseBackColor = true;
            this.groupIntakeDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupIntakeDetails.Controls.Add(this.lblDeliveredQty);
            this.groupIntakeDetails.Controls.Add(this.txtDeliveredQty);
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
            this.groupIntakeDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupIntakeDetails.Name = "groupIntakeDetails";
            this.groupIntakeDetails.Size = new System.Drawing.Size(1479, 903);
            this.groupIntakeDetails.TabIndex = 173;
            // 
            // lblDeliveredQty
            // 
            this.lblDeliveredQty.AutoSize = true;
            this.lblDeliveredQty.BackColor = System.Drawing.Color.Transparent;
            this.lblDeliveredQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveredQty.ForeColor = System.Drawing.Color.White;
            this.lblDeliveredQty.Location = new System.Drawing.Point(17, 181);
            this.lblDeliveredQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeliveredQty.Name = "lblDeliveredQty";
            this.lblDeliveredQty.Size = new System.Drawing.Size(126, 23);
            this.lblDeliveredQty.TabIndex = 232;
            this.lblDeliveredQty.Text = "Delivered Qty:";
            // 
            // txtDeliveredQty
            // 
            this.txtDeliveredQty.BackColor = System.Drawing.Color.DimGray;
            this.txtDeliveredQty.Enabled = false;
            this.txtDeliveredQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveredQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtDeliveredQty.Location = new System.Drawing.Point(181, 173);
            this.txtDeliveredQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeliveredQty.Name = "txtDeliveredQty";
            this.txtDeliveredQty.Size = new System.Drawing.Size(357, 34);
            this.txtDeliveredQty.TabIndex = 231;
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
            this.gBAL.Location = new System.Drawing.Point(740, 27);
            this.gBAL.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gBAL.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gBAL.Margin = new System.Windows.Forms.Padding(4);
            this.gBAL.Name = "gBAL";
            this.gBAL.Size = new System.Drawing.Size(359, 161);
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
            this.lblSign.Location = new System.Drawing.Point(8, 37);
            this.lblSign.Margin = new System.Windows.Forms.Padding(4);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(27, 60);
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
            this.lblPrice.Location = new System.Drawing.Point(45, 37);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(112, 60);
            this.lblPrice.TabIndex = 101;
            this.lblPrice.Text = "00.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(576, 238);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 23);
            this.label9.TabIndex = 229;
            this.label9.Text = "Product Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtBarcode.Location = new System.Drawing.Point(740, 230);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(357, 34);
            this.txtBarcode.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 326);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 23);
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
            this.cmbProductStatus.Location = new System.Drawing.Point(180, 319);
            this.cmbProductStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProductStatus.Name = "cmbProductStatus";
            this.cmbProductStatus.Size = new System.Drawing.Size(357, 36);
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
            this.cmbProductName.Location = new System.Drawing.Point(180, 99);
            this.cmbProductName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(357, 36);
            this.cmbProductName.TabIndex = 112;
            this.cmbProductName.SelectedIndexChanged += new System.EventHandler(this.CmbProductName_SelectedIndexChanged);
            this.cmbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductName_KeyDown);
            // 
            // imgPreview
            // 
            this.imgPreview.BackColor = System.Drawing.Color.Gray;
            this.imgPreview.Location = new System.Drawing.Point(1113, 26);
            this.imgPreview.Margin = new System.Windows.Forms.Padding(4);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(360, 330);
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
            this.cmbBranchName.Location = new System.Drawing.Point(180, 245);
            this.cmbBranchName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBranchName.Name = "cmbBranchName";
            this.cmbBranchName.Size = new System.Drawing.Size(357, 36);
            this.cmbBranchName.TabIndex = 116;
            this.cmbBranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranchName_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(17, 253);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 23);
            this.label13.TabIndex = 214;
            this.label13.Text = "Branch Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(576, 198);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 23);
            this.label12.TabIndex = 212;
            this.label12.Text = "Inventory Date:";
            // 
            // dkpInventoryDate
            // 
            this.dkpInventoryDate.CustomFormat = "dd-MM-yyyy";
            this.dkpInventoryDate.Enabled = false;
            this.dkpInventoryDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpInventoryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpInventoryDate.Location = new System.Drawing.Point(740, 191);
            this.dkpInventoryDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpInventoryDate.Name = "dkpInventoryDate";
            this.dkpInventoryDate.Size = new System.Drawing.Size(357, 34);
            this.dkpInventoryDate.TabIndex = 120;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(17, 291);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 23);
            this.label8.TabIndex = 206;
            this.label8.Text = "Last Cost:";
            // 
            // txtLastCost
            // 
            this.txtLastCost.BackColor = System.Drawing.Color.DimGray;
            this.txtLastCost.Enabled = false;
            this.txtLastCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastCost.ForeColor = System.Drawing.Color.Maroon;
            this.txtLastCost.Location = new System.Drawing.Point(181, 283);
            this.txtLastCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastCost.Name = "txtLastCost";
            this.txtLastCost.Size = new System.Drawing.Size(357, 34);
            this.txtLastCost.TabIndex = 117;
            this.txtLastCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLastCost_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 23);
            this.label6.TabIndex = 184;
            this.label6.Text = "QTY Stock:";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.DimGray;
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtQty.Location = new System.Drawing.Point(181, 209);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(357, 34);
            this.txtQty.TabIndex = 115;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 23);
            this.label5.TabIndex = 182;
            this.label5.Text = "Product Name:";
            // 
            // txtDeliveryNumber
            // 
            this.txtDeliveryNumber.BackColor = System.Drawing.Color.DimGray;
            this.txtDeliveryNumber.Enabled = false;
            this.txtDeliveryNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryNumber.ForeColor = System.Drawing.Color.Maroon;
            this.txtDeliveryNumber.Location = new System.Drawing.Point(181, 137);
            this.txtDeliveryNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeliveryNumber.Name = "txtDeliveryNumber";
            this.txtDeliveryNumber.Size = new System.Drawing.Size(357, 34);
            this.txtDeliveryNumber.TabIndex = 113;
            this.txtDeliveryNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeliveryNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 176;
            this.label2.Text = "Delivery No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 174;
            this.label1.Text = "Inventory Code:";
            // 
            // txtInventoryCode
            // 
            this.txtInventoryCode.BackColor = System.Drawing.Color.DimGray;
            this.txtInventoryCode.Enabled = false;
            this.txtInventoryCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryCode.ForeColor = System.Drawing.Color.Maroon;
            this.txtInventoryCode.Location = new System.Drawing.Point(181, 63);
            this.txtInventoryCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventoryCode.Name = "txtInventoryCode";
            this.txtInventoryCode.Size = new System.Drawing.Size(357, 34);
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
            this.groupIntake.Location = new System.Drawing.Point(-1, 363);
            this.groupIntake.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupIntake.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupIntake.Margin = new System.Windows.Forms.Padding(4);
            this.groupIntake.Name = "groupIntake";
            this.groupIntake.Size = new System.Drawing.Size(1477, 542);
            this.groupIntake.TabIndex = 172;
            this.groupIntake.Text = "List of Stocks";
            // 
            // gCON
            // 
            this.gCON.Cursor = System.Windows.Forms.Cursors.Default;
            this.gCON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCON.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gCON.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gCON.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gCON.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gCON.Location = new System.Drawing.Point(3, 21);
            this.gCON.MainView = this.gridInventory;
            this.gCON.Margin = new System.Windows.Forms.Padding(4);
            this.gCON.Name = "gCON";
            this.gCON.Size = new System.Drawing.Size(1471, 518);
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
            this.gridInventory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridInventory.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridInventory.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridInventory.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridInventory.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridInventory.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridInventory.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridInventory.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.gridInventory.DetailHeight = 431;
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
            this.gridView2.DetailHeight = 431;
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
            this.gridView3.DetailHeight = 431;
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
            this.grdHIS.DetailHeight = 431;
            this.grdHIS.GridControl = this.gCON;
            this.grdHIS.Name = "grdHIS";
            // 
            // txtPRI
            // 
            this.txtPRI.BackColor = System.Drawing.Color.DimGray;
            this.txtPRI.Enabled = false;
            this.txtPRI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRI.ForeColor = System.Drawing.Color.Maroon;
            this.txtPRI.Location = new System.Drawing.Point(-11, 26);
            this.txtPRI.Margin = new System.Windows.Forms.Padding(4);
            this.txtPRI.Multiline = true;
            this.txtPRI.Name = "txtPRI";
            this.txtPRI.Size = new System.Drawing.Size(12, 11);
            this.txtPRI.TabIndex = 99;
            this.txtPRI.Visible = false;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.White;
            this.lblBarcode.Location = new System.Drawing.Point(17, 34);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(113, 23);
            this.lblBarcode.TabIndex = 142;
            this.lblBarcode.Text = "Inventory Id:";
            // 
            // txtInventoryId
            // 
            this.txtInventoryId.BackColor = System.Drawing.Color.DimGray;
            this.txtInventoryId.Enabled = false;
            this.txtInventoryId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryId.ForeColor = System.Drawing.Color.Maroon;
            this.txtInventoryId.Location = new System.Drawing.Point(181, 27);
            this.txtInventoryId.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventoryId.Name = "txtInventoryId";
            this.txtInventoryId.Size = new System.Drawing.Size(357, 34);
            this.txtInventoryId.TabIndex = 110;
            // 
            // xtraDelivery
            // 
            this.xtraDelivery.Controls.Add(this.groupDeliveryDetails);
            this.xtraDelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraDelivery.ImageOptions.Image")));
            this.xtraDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.xtraDelivery.Name = "xtraDelivery";
            this.xtraDelivery.Size = new System.Drawing.Size(1479, 903);
            this.xtraDelivery.Text = "Delivery Received";
            // 
            // groupDeliveryDetails
            // 
            this.groupDeliveryDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupDeliveryDetails.Appearance.Options.UseBackColor = true;
            this.groupDeliveryDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupDeliveryDetails.Controls.Add(this.label25);
            this.groupDeliveryDetails.Controls.Add(this.dkpDelUpdate);
            this.groupDeliveryDetails.Controls.Add(this.label24);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelDeliveryStatus);
            this.groupDeliveryDetails.Controls.Add(this.label23);
            this.groupDeliveryDetails.Controls.Add(this.txtDelRemarks);
            this.groupDeliveryDetails.Controls.Add(this.label22);
            this.groupDeliveryDetails.Controls.Add(this.txtDelReceiptNo);
            this.groupDeliveryDetails.Controls.Add(this.label21);
            this.groupDeliveryDetails.Controls.Add(this.txtDelTotal);
            this.groupDeliveryDetails.Controls.Add(this.label3);
            this.groupDeliveryDetails.Controls.Add(this.txtDelDeliveryQty);
            this.groupDeliveryDetails.Controls.Add(this.label7);
            this.groupDeliveryDetails.Controls.Add(this.txtDelCostPerItem);
            this.groupDeliveryDetails.Controls.Add(this.label10);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelStatus);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelProductName);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelBranch);
            this.groupDeliveryDetails.Controls.Add(this.label11);
            this.groupDeliveryDetails.Controls.Add(this.label14);
            this.groupDeliveryDetails.Controls.Add(this.dkpDelDeliveryDate);
            this.groupDeliveryDetails.Controls.Add(this.label15);
            this.groupDeliveryDetails.Controls.Add(this.txtDelLastCost);
            this.groupDeliveryDetails.Controls.Add(this.label16);
            this.groupDeliveryDetails.Controls.Add(this.txtDelQty);
            this.groupDeliveryDetails.Controls.Add(this.label17);
            this.groupDeliveryDetails.Controls.Add(this.txtDelDeliveryNo);
            this.groupDeliveryDetails.Controls.Add(this.label18);
            this.groupDeliveryDetails.Controls.Add(this.label19);
            this.groupDeliveryDetails.Controls.Add(this.txtDelBarcode);
            this.groupDeliveryDetails.Controls.Add(this.label20);
            this.groupDeliveryDetails.Controls.Add(this.txtDelDeliveryID);
            this.groupDeliveryDetails.Controls.Add(this.ImageProduct);
            this.groupDeliveryDetails.Controls.Add(this.groupDelivery);
            this.groupDeliveryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDeliveryDetails.Location = new System.Drawing.Point(0, 0);
            this.groupDeliveryDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupDeliveryDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupDeliveryDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupDeliveryDetails.Name = "groupDeliveryDetails";
            this.groupDeliveryDetails.Size = new System.Drawing.Size(1479, 903);
            this.groupDeliveryDetails.TabIndex = 175;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(568, 256);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(117, 23);
            this.label25.TabIndex = 264;
            this.label25.Text = "Update Date:";
            // 
            // dkpDelUpdate
            // 
            this.dkpDelUpdate.CustomFormat = "dd-MM-yyyy";
            this.dkpDelUpdate.Enabled = false;
            this.dkpDelUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDelUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDelUpdate.Location = new System.Drawing.Point(732, 249);
            this.dkpDelUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpDelUpdate.Name = "dkpDelUpdate";
            this.dkpDelUpdate.Size = new System.Drawing.Size(357, 34);
            this.dkpDelUpdate.TabIndex = 263;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(568, 182);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(137, 23);
            this.label24.TabIndex = 262;
            this.label24.Text = "Delivery Status:";
            // 
            // cmbDelDeliveryStatus
            // 
            this.cmbDelDeliveryStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDelDeliveryStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDelDeliveryStatus.BackColor = System.Drawing.Color.DimGray;
            this.cmbDelDeliveryStatus.Enabled = false;
            this.cmbDelDeliveryStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelDeliveryStatus.ForeColor = System.Drawing.Color.Maroon;
            this.cmbDelDeliveryStatus.FormattingEnabled = true;
            this.cmbDelDeliveryStatus.Location = new System.Drawing.Point(731, 175);
            this.cmbDelDeliveryStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelDeliveryStatus.Name = "cmbDelDeliveryStatus";
            this.cmbDelDeliveryStatus.Size = new System.Drawing.Size(357, 36);
            this.cmbDelDeliveryStatus.TabIndex = 261;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(568, 147);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 23);
            this.label23.TabIndex = 260;
            this.label23.Text = "Remarks:";
            // 
            // txtDelRemarks
            // 
            this.txtDelRemarks.BackColor = System.Drawing.Color.DimGray;
            this.txtDelRemarks.Enabled = false;
            this.txtDelRemarks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelRemarks.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelRemarks.Location = new System.Drawing.Point(732, 139);
            this.txtDelRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelRemarks.Name = "txtDelRemarks";
            this.txtDelRemarks.Size = new System.Drawing.Size(357, 34);
            this.txtDelRemarks.TabIndex = 259;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(568, 111);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 23);
            this.label22.TabIndex = 258;
            this.label22.Text = "Receipt No:";
            // 
            // txtDelReceiptNo
            // 
            this.txtDelReceiptNo.BackColor = System.Drawing.Color.DimGray;
            this.txtDelReceiptNo.Enabled = false;
            this.txtDelReceiptNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelReceiptNo.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelReceiptNo.Location = new System.Drawing.Point(732, 103);
            this.txtDelReceiptNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelReceiptNo.Name = "txtDelReceiptNo";
            this.txtDelReceiptNo.Size = new System.Drawing.Size(357, 34);
            this.txtDelReceiptNo.TabIndex = 257;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(568, 37);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 23);
            this.label21.TabIndex = 256;
            this.label21.Text = "Total Value:";
            // 
            // txtDelTotal
            // 
            this.txtDelTotal.BackColor = System.Drawing.Color.DimGray;
            this.txtDelTotal.Enabled = false;
            this.txtDelTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelTotal.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelTotal.Location = new System.Drawing.Point(732, 29);
            this.txtDelTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelTotal.Name = "txtDelTotal";
            this.txtDelTotal.Size = new System.Drawing.Size(357, 34);
            this.txtDelTotal.TabIndex = 255;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 23);
            this.label3.TabIndex = 254;
            this.label3.Text = "Delivered Qty:";
            // 
            // txtDelDeliveryQty
            // 
            this.txtDelDeliveryQty.BackColor = System.Drawing.Color.DimGray;
            this.txtDelDeliveryQty.Enabled = false;
            this.txtDelDeliveryQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelDeliveryQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelDeliveryQty.Location = new System.Drawing.Point(181, 175);
            this.txtDelDeliveryQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelDeliveryQty.Name = "txtDelDeliveryQty";
            this.txtDelDeliveryQty.Size = new System.Drawing.Size(357, 34);
            this.txtDelDeliveryQty.TabIndex = 253;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 329);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 23);
            this.label7.TabIndex = 252;
            this.label7.Text = "Cost Per Item:";
            // 
            // txtDelCostPerItem
            // 
            this.txtDelCostPerItem.BackColor = System.Drawing.Color.DimGray;
            this.txtDelCostPerItem.Enabled = false;
            this.txtDelCostPerItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelCostPerItem.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelCostPerItem.Location = new System.Drawing.Point(181, 321);
            this.txtDelCostPerItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelCostPerItem.Name = "txtDelCostPerItem";
            this.txtDelCostPerItem.Size = new System.Drawing.Size(357, 34);
            this.txtDelCostPerItem.TabIndex = 241;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(569, 72);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 23);
            this.label10.TabIndex = 251;
            this.label10.Text = "Product Status:";
            // 
            // cmbDelStatus
            // 
            this.cmbDelStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDelStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDelStatus.BackColor = System.Drawing.Color.DimGray;
            this.cmbDelStatus.Enabled = false;
            this.cmbDelStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelStatus.ForeColor = System.Drawing.Color.Maroon;
            this.cmbDelStatus.FormattingEnabled = true;
            this.cmbDelStatus.Location = new System.Drawing.Point(732, 65);
            this.cmbDelStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelStatus.Name = "cmbDelStatus";
            this.cmbDelStatus.Size = new System.Drawing.Size(357, 36);
            this.cmbDelStatus.TabIndex = 240;
            // 
            // cmbDelProductName
            // 
            this.cmbDelProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDelProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDelProductName.BackColor = System.Drawing.Color.DimGray;
            this.cmbDelProductName.Enabled = false;
            this.cmbDelProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelProductName.ForeColor = System.Drawing.Color.Maroon;
            this.cmbDelProductName.FormattingEnabled = true;
            this.cmbDelProductName.Location = new System.Drawing.Point(180, 101);
            this.cmbDelProductName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelProductName.Name = "cmbDelProductName";
            this.cmbDelProductName.Size = new System.Drawing.Size(357, 36);
            this.cmbDelProductName.TabIndex = 235;
            // 
            // cmbDelBranch
            // 
            this.cmbDelBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDelBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDelBranch.BackColor = System.Drawing.Color.DimGray;
            this.cmbDelBranch.Enabled = false;
            this.cmbDelBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelBranch.ForeColor = System.Drawing.Color.Maroon;
            this.cmbDelBranch.FormattingEnabled = true;
            this.cmbDelBranch.Location = new System.Drawing.Point(180, 247);
            this.cmbDelBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelBranch.Name = "cmbDelBranch";
            this.cmbDelBranch.Size = new System.Drawing.Size(357, 36);
            this.cmbDelBranch.TabIndex = 238;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(17, 255);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 23);
            this.label11.TabIndex = 250;
            this.label11.Text = "Branch Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(568, 220);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 23);
            this.label14.TabIndex = 249;
            this.label14.Text = "Delivery Date:";
            // 
            // dkpDelDeliveryDate
            // 
            this.dkpDelDeliveryDate.CustomFormat = "dd-MM-yyyy";
            this.dkpDelDeliveryDate.Enabled = false;
            this.dkpDelDeliveryDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDelDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDelDeliveryDate.Location = new System.Drawing.Point(732, 213);
            this.dkpDelDeliveryDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpDelDeliveryDate.Name = "dkpDelDeliveryDate";
            this.dkpDelDeliveryDate.Size = new System.Drawing.Size(357, 34);
            this.dkpDelDeliveryDate.TabIndex = 242;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(17, 293);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 23);
            this.label15.TabIndex = 248;
            this.label15.Text = "Last Cost:";
            // 
            // txtDelLastCost
            // 
            this.txtDelLastCost.BackColor = System.Drawing.Color.DimGray;
            this.txtDelLastCost.Enabled = false;
            this.txtDelLastCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelLastCost.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelLastCost.Location = new System.Drawing.Point(181, 285);
            this.txtDelLastCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelLastCost.Name = "txtDelLastCost";
            this.txtDelLastCost.Size = new System.Drawing.Size(357, 34);
            this.txtDelLastCost.TabIndex = 239;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(17, 219);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 23);
            this.label16.TabIndex = 247;
            this.label16.Text = "QTY Stock:";
            // 
            // txtDelQty
            // 
            this.txtDelQty.BackColor = System.Drawing.Color.DimGray;
            this.txtDelQty.Enabled = false;
            this.txtDelQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelQty.Location = new System.Drawing.Point(181, 211);
            this.txtDelQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelQty.Name = "txtDelQty";
            this.txtDelQty.Size = new System.Drawing.Size(357, 34);
            this.txtDelQty.TabIndex = 237;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(17, 107);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 23);
            this.label17.TabIndex = 246;
            this.label17.Text = "Product Name:";
            // 
            // txtDelDeliveryNo
            // 
            this.txtDelDeliveryNo.BackColor = System.Drawing.Color.DimGray;
            this.txtDelDeliveryNo.Enabled = false;
            this.txtDelDeliveryNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelDeliveryNo.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelDeliveryNo.Location = new System.Drawing.Point(181, 139);
            this.txtDelDeliveryNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelDeliveryNo.Name = "txtDelDeliveryNo";
            this.txtDelDeliveryNo.Size = new System.Drawing.Size(357, 34);
            this.txtDelDeliveryNo.TabIndex = 236;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(17, 146);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 23);
            this.label18.TabIndex = 245;
            this.label18.Text = "Delivery No:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(17, 72);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 23);
            this.label19.TabIndex = 244;
            this.label19.Text = "Barcode:";
            // 
            // txtDelBarcode
            // 
            this.txtDelBarcode.BackColor = System.Drawing.Color.DimGray;
            this.txtDelBarcode.Enabled = false;
            this.txtDelBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelBarcode.Location = new System.Drawing.Point(181, 65);
            this.txtDelBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelBarcode.Name = "txtDelBarcode";
            this.txtDelBarcode.Size = new System.Drawing.Size(357, 34);
            this.txtDelBarcode.TabIndex = 234;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(17, 36);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 23);
            this.label20.TabIndex = 243;
            this.label20.Text = "Delivery Id:";
            // 
            // txtDelDeliveryID
            // 
            this.txtDelDeliveryID.BackColor = System.Drawing.Color.DimGray;
            this.txtDelDeliveryID.Enabled = false;
            this.txtDelDeliveryID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelDeliveryID.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelDeliveryID.Location = new System.Drawing.Point(181, 29);
            this.txtDelDeliveryID.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelDeliveryID.Name = "txtDelDeliveryID";
            this.txtDelDeliveryID.Size = new System.Drawing.Size(357, 34);
            this.txtDelDeliveryID.TabIndex = 233;
            // 
            // ImageProduct
            // 
            this.ImageProduct.BackColor = System.Drawing.Color.Gray;
            this.ImageProduct.Location = new System.Drawing.Point(1112, 27);
            this.ImageProduct.Margin = new System.Windows.Forms.Padding(4);
            this.ImageProduct.Name = "ImageProduct";
            this.ImageProduct.Size = new System.Drawing.Size(360, 330);
            this.ImageProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageProduct.TabIndex = 224;
            this.ImageProduct.TabStop = false;
            // 
            // groupDelivery
            // 
            this.groupDelivery.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupDelivery.Appearance.Options.UseBackColor = true;
            this.groupDelivery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupDelivery.Controls.Add(this.gridCtrlProducts);
            this.groupDelivery.Location = new System.Drawing.Point(1, 363);
            this.groupDelivery.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupDelivery.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.groupDelivery.Name = "groupDelivery";
            this.groupDelivery.Size = new System.Drawing.Size(1479, 537);
            this.groupDelivery.TabIndex = 174;
            this.groupDelivery.Text = "List of Delivery Received";
            // 
            // gridCtrlProducts
            // 
            this.gridCtrlProducts.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCtrlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtrlProducts.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridCtrlProducts.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridCtrlProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridCtrlProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridCtrlProducts.Location = new System.Drawing.Point(3, 21);
            this.gridCtrlProducts.MainView = this.gridProducts;
            this.gridCtrlProducts.Margin = new System.Windows.Forms.Padding(4);
            this.gridCtrlProducts.Name = "gridCtrlProducts";
            this.gridCtrlProducts.Size = new System.Drawing.Size(1473, 513);
            this.gridCtrlProducts.TabIndex = 103;
            this.gridCtrlProducts.TabStop = false;
            this.gridCtrlProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProducts,
            this.gridView5,
            this.gridView6,
            this.gridView7});
            // 
            // gridProducts
            // 
            this.gridProducts.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridProducts.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridProducts.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridProducts.Appearance.Empty.Options.UseBackColor = true;
            this.gridProducts.Appearance.Empty.Options.UseBorderColor = true;
            this.gridProducts.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridProducts.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridProducts.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridProducts.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProducts.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridProducts.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridProducts.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridProducts.Appearance.FocusedRow.Options.UseFont = true;
            this.gridProducts.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridProducts.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridProducts.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProducts.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridProducts.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridProducts.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridProducts.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridProducts.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridProducts.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridProducts.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProducts.Appearance.Row.Options.UseBackColor = true;
            this.gridProducts.Appearance.Row.Options.UseBorderColor = true;
            this.gridProducts.Appearance.Row.Options.UseFont = true;
            this.gridProducts.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProducts.Appearance.ViewCaption.Options.UseFont = true;
            this.gridProducts.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridProducts.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProducts.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridProducts.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridProducts.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridProducts.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridProducts.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridProducts.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridProducts.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProducts.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridProducts.AppearancePrint.Row.Options.UseFont = true;
            this.gridProducts.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridProducts.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridProducts.DetailHeight = 431;
            this.gridProducts.GridControl = this.gridCtrlProducts;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridProducts.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridProducts.OptionsBehavior.Editable = false;
            this.gridProducts.OptionsCustomization.AllowRowSizing = true;
            this.gridProducts.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridProducts.OptionsSelection.MultiSelect = true;
            this.gridProducts.OptionsView.EnableAppearanceEvenRow = true;
            this.gridProducts.OptionsView.RowAutoHeight = true;
            this.gridProducts.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridProducts.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridProducts_RowClick);
            this.gridProducts.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridProducts_FocusedRowChanged);
            this.gridProducts.LostFocus += new System.EventHandler(this.GridProducts_LostFocus);
            // 
            // gridView5
            // 
            this.gridView5.DetailHeight = 431;
            this.gridView5.GridControl = this.gridCtrlProducts;
            this.gridView5.Name = "gridView5";
            // 
            // gridView6
            // 
            this.gridView6.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView6.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridView6.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gridView6.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Green;
            this.gridView6.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView6.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView6.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView6.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView6.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView6.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView6.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridView6.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView6.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView6.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView6.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView6.Appearance.Row.Options.UseFont = true;
            this.gridView6.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridView6.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView6.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView6.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView6.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView6.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridView6.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView6.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView6.AppearancePrint.Row.Options.UseFont = true;
            this.gridView6.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridView6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView6.DetailHeight = 431;
            this.gridView6.GridControl = this.gridCtrlProducts;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView6.OptionsBehavior.Editable = false;
            this.gridView6.OptionsBehavior.ReadOnly = true;
            this.gridView6.OptionsCustomization.AllowRowSizing = true;
            this.gridView6.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView6.OptionsSelection.MultiSelect = true;
            this.gridView6.OptionsView.ColumnAutoWidth = false;
            // 
            // gridView7
            // 
            this.gridView7.DetailHeight = 431;
            this.gridView7.GridControl = this.gridCtrlProducts;
            this.gridView7.Name = "gridView7";
            // 
            // xtraSales
            // 
            this.xtraSales.Controls.Add(this.groupSalesDetails);
            this.xtraSales.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraSales.ImageOptions.Image")));
            this.xtraSales.Margin = new System.Windows.Forms.Padding(4);
            this.xtraSales.Name = "xtraSales";
            this.xtraSales.Size = new System.Drawing.Size(1479, 903);
            this.xtraSales.Text = "Transaction History";
            // 
            // groupSalesDetails
            // 
            this.groupSalesDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupSalesDetails.Appearance.Options.UseBackColor = true;
            this.groupSalesDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupSalesDetails.Controls.Add(this.cmbSalesStatus);
            this.groupSalesDetails.Controls.Add(this.label38);
            this.groupSalesDetails.Controls.Add(this.label26);
            this.groupSalesDetails.Controls.Add(this.txtSalesDiscount);
            this.groupSalesDetails.Controls.Add(this.label27);
            this.groupSalesDetails.Controls.Add(this.txtSalesCustomer);
            this.groupSalesDetails.Controls.Add(this.label28);
            this.groupSalesDetails.Controls.Add(this.txtSalesQty);
            this.groupSalesDetails.Controls.Add(this.label29);
            this.groupSalesDetails.Controls.Add(this.txtSalesNet);
            this.groupSalesDetails.Controls.Add(this.cmbSalesProductName);
            this.groupSalesDetails.Controls.Add(this.cmbSalesBranch);
            this.groupSalesDetails.Controls.Add(this.label30);
            this.groupSalesDetails.Controls.Add(this.label31);
            this.groupSalesDetails.Controls.Add(this.dkpSalesDate);
            this.groupSalesDetails.Controls.Add(this.label32);
            this.groupSalesDetails.Controls.Add(this.txtSalesGross);
            this.groupSalesDetails.Controls.Add(this.label33);
            this.groupSalesDetails.Controls.Add(this.txtSalesPrice);
            this.groupSalesDetails.Controls.Add(this.label34);
            this.groupSalesDetails.Controls.Add(this.txtSalesInvoice);
            this.groupSalesDetails.Controls.Add(this.label35);
            this.groupSalesDetails.Controls.Add(this.label36);
            this.groupSalesDetails.Controls.Add(this.txtSalesBarcode);
            this.groupSalesDetails.Controls.Add(this.label37);
            this.groupSalesDetails.Controls.Add(this.txtSalesId);
            this.groupSalesDetails.Controls.Add(this.ImageSales);
            this.groupSalesDetails.Controls.Add(this.groupSales);
            this.groupSalesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSalesDetails.Location = new System.Drawing.Point(0, 0);
            this.groupSalesDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSalesDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSalesDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupSalesDetails.Name = "groupSalesDetails";
            this.groupSalesDetails.Size = new System.Drawing.Size(1479, 903);
            this.groupSalesDetails.TabIndex = 176;
            // 
            // cmbSalesStatus
            // 
            this.cmbSalesStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesStatus.BackColor = System.Drawing.Color.DimGray;
            this.cmbSalesStatus.Enabled = false;
            this.cmbSalesStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalesStatus.ForeColor = System.Drawing.Color.Maroon;
            this.cmbSalesStatus.FormattingEnabled = true;
            this.cmbSalesStatus.Location = new System.Drawing.Point(729, 100);
            this.cmbSalesStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSalesStatus.Name = "cmbSalesStatus";
            this.cmbSalesStatus.Size = new System.Drawing.Size(357, 36);
            this.cmbSalesStatus.TabIndex = 285;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(566, 108);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 23);
            this.label38.TabIndex = 286;
            this.label38.Text = "Status:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(14, 255);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(85, 23);
            this.label26.TabIndex = 284;
            this.label26.Text = "Discount:";
            // 
            // txtSalesDiscount
            // 
            this.txtSalesDiscount.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesDiscount.Enabled = false;
            this.txtSalesDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesDiscount.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesDiscount.Location = new System.Drawing.Point(178, 247);
            this.txtSalesDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesDiscount.Name = "txtSalesDiscount";
            this.txtSalesDiscount.Size = new System.Drawing.Size(357, 34);
            this.txtSalesDiscount.TabIndex = 283;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(565, 36);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(93, 23);
            this.label27.TabIndex = 282;
            this.label27.Text = "Customer:";
            // 
            // txtSalesCustomer
            // 
            this.txtSalesCustomer.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesCustomer.Enabled = false;
            this.txtSalesCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesCustomer.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesCustomer.Location = new System.Drawing.Point(729, 28);
            this.txtSalesCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesCustomer.Name = "txtSalesCustomer";
            this.txtSalesCustomer.Size = new System.Drawing.Size(357, 34);
            this.txtSalesCustomer.TabIndex = 281;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(14, 182);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(85, 23);
            this.label28.TabIndex = 280;
            this.label28.Text = "Quantity:";
            // 
            // txtSalesQty
            // 
            this.txtSalesQty.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesQty.Enabled = false;
            this.txtSalesQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesQty.Location = new System.Drawing.Point(178, 174);
            this.txtSalesQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesQty.Name = "txtSalesQty";
            this.txtSalesQty.Size = new System.Drawing.Size(357, 34);
            this.txtSalesQty.TabIndex = 279;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(14, 328);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 23);
            this.label29.TabIndex = 278;
            this.label29.Text = "Net:";
            // 
            // txtSalesNet
            // 
            this.txtSalesNet.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesNet.Enabled = false;
            this.txtSalesNet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesNet.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesNet.Location = new System.Drawing.Point(178, 320);
            this.txtSalesNet.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesNet.Name = "txtSalesNet";
            this.txtSalesNet.Size = new System.Drawing.Size(357, 34);
            this.txtSalesNet.TabIndex = 268;
            // 
            // cmbSalesProductName
            // 
            this.cmbSalesProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesProductName.BackColor = System.Drawing.Color.DimGray;
            this.cmbSalesProductName.Enabled = false;
            this.cmbSalesProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalesProductName.ForeColor = System.Drawing.Color.Maroon;
            this.cmbSalesProductName.FormattingEnabled = true;
            this.cmbSalesProductName.Location = new System.Drawing.Point(177, 136);
            this.cmbSalesProductName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSalesProductName.Name = "cmbSalesProductName";
            this.cmbSalesProductName.Size = new System.Drawing.Size(357, 36);
            this.cmbSalesProductName.TabIndex = 263;
            // 
            // cmbSalesBranch
            // 
            this.cmbSalesBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesBranch.BackColor = System.Drawing.Color.DimGray;
            this.cmbSalesBranch.Enabled = false;
            this.cmbSalesBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalesBranch.ForeColor = System.Drawing.Color.Maroon;
            this.cmbSalesBranch.FormattingEnabled = true;
            this.cmbSalesBranch.Location = new System.Drawing.Point(729, 63);
            this.cmbSalesBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSalesBranch.Name = "cmbSalesBranch";
            this.cmbSalesBranch.Size = new System.Drawing.Size(357, 36);
            this.cmbSalesBranch.TabIndex = 266;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(566, 71);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(122, 23);
            this.label30.TabIndex = 277;
            this.label30.Text = "Branch Name:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(565, 144);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(98, 23);
            this.label31.TabIndex = 276;
            this.label31.Text = "Sales Date:";
            // 
            // dkpSalesDate
            // 
            this.dkpSalesDate.CustomFormat = "dd-MM-yyyy";
            this.dkpSalesDate.Enabled = false;
            this.dkpSalesDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpSalesDate.Location = new System.Drawing.Point(729, 137);
            this.dkpSalesDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpSalesDate.Name = "dkpSalesDate";
            this.dkpSalesDate.Size = new System.Drawing.Size(357, 34);
            this.dkpSalesDate.TabIndex = 269;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(14, 292);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(58, 23);
            this.label32.TabIndex = 275;
            this.label32.Text = "Gross:";
            // 
            // txtSalesGross
            // 
            this.txtSalesGross.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesGross.Enabled = false;
            this.txtSalesGross.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesGross.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesGross.Location = new System.Drawing.Point(178, 284);
            this.txtSalesGross.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesGross.Name = "txtSalesGross";
            this.txtSalesGross.Size = new System.Drawing.Size(357, 34);
            this.txtSalesGross.TabIndex = 267;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(14, 218);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(54, 23);
            this.label33.TabIndex = 274;
            this.label33.Text = "Price:";
            // 
            // txtSalesPrice
            // 
            this.txtSalesPrice.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesPrice.Enabled = false;
            this.txtSalesPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesPrice.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesPrice.Location = new System.Drawing.Point(178, 210);
            this.txtSalesPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesPrice.Name = "txtSalesPrice";
            this.txtSalesPrice.Size = new System.Drawing.Size(357, 34);
            this.txtSalesPrice.TabIndex = 265;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(14, 141);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(130, 23);
            this.label34.TabIndex = 273;
            this.label34.Text = "Product Name:";
            // 
            // txtSalesInvoice
            // 
            this.txtSalesInvoice.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesInvoice.Enabled = false;
            this.txtSalesInvoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesInvoice.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesInvoice.Location = new System.Drawing.Point(178, 64);
            this.txtSalesInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesInvoice.Name = "txtSalesInvoice";
            this.txtSalesInvoice.Size = new System.Drawing.Size(357, 34);
            this.txtSalesInvoice.TabIndex = 264;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(14, 71);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(71, 23);
            this.label35.TabIndex = 272;
            this.label35.Text = "Invoice:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(14, 106);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 23);
            this.label36.TabIndex = 271;
            this.label36.Text = "Barcode:";
            // 
            // txtSalesBarcode
            // 
            this.txtSalesBarcode.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesBarcode.Enabled = false;
            this.txtSalesBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesBarcode.Location = new System.Drawing.Point(178, 100);
            this.txtSalesBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesBarcode.Name = "txtSalesBarcode";
            this.txtSalesBarcode.Size = new System.Drawing.Size(357, 34);
            this.txtSalesBarcode.TabIndex = 262;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(14, 35);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(76, 23);
            this.label37.TabIndex = 270;
            this.label37.Text = "Sales Id:";
            // 
            // txtSalesId
            // 
            this.txtSalesId.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesId.Enabled = false;
            this.txtSalesId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesId.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesId.Location = new System.Drawing.Point(178, 28);
            this.txtSalesId.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(357, 34);
            this.txtSalesId.TabIndex = 261;
            // 
            // ImageSales
            // 
            this.ImageSales.BackColor = System.Drawing.Color.Gray;
            this.ImageSales.Location = new System.Drawing.Point(1113, 28);
            this.ImageSales.Margin = new System.Windows.Forms.Padding(4);
            this.ImageSales.Name = "ImageSales";
            this.ImageSales.Size = new System.Drawing.Size(360, 330);
            this.ImageSales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageSales.TabIndex = 225;
            this.ImageSales.TabStop = false;
            // 
            // groupSales
            // 
            this.groupSales.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupSales.Appearance.Options.UseBackColor = true;
            this.groupSales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupSales.Controls.Add(this.gridCtrlSales);
            this.groupSales.Location = new System.Drawing.Point(3, 363);
            this.groupSales.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSales.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSales.Margin = new System.Windows.Forms.Padding(4);
            this.groupSales.Name = "groupSales";
            this.groupSales.Size = new System.Drawing.Size(1475, 533);
            this.groupSales.TabIndex = 175;
            this.groupSales.Text = "List of Transaction History";
            // 
            // gridCtrlSales
            // 
            this.gridCtrlSales.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCtrlSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtrlSales.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridCtrlSales.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridCtrlSales.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridCtrlSales.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridCtrlSales.Location = new System.Drawing.Point(3, 21);
            this.gridCtrlSales.MainView = this.gridSales;
            this.gridCtrlSales.Margin = new System.Windows.Forms.Padding(4);
            this.gridCtrlSales.Name = "gridCtrlSales";
            this.gridCtrlSales.Size = new System.Drawing.Size(1469, 509);
            this.gridCtrlSales.TabIndex = 104;
            this.gridCtrlSales.TabStop = false;
            this.gridCtrlSales.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSales,
            this.gridView8,
            this.gridView9,
            this.gridView10});
            // 
            // gridSales
            // 
            this.gridSales.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridSales.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridSales.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridSales.Appearance.Empty.Options.UseBackColor = true;
            this.gridSales.Appearance.Empty.Options.UseBorderColor = true;
            this.gridSales.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridSales.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridSales.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridSales.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSales.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridSales.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridSales.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridSales.Appearance.FocusedRow.Options.UseFont = true;
            this.gridSales.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridSales.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridSales.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSales.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridSales.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridSales.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridSales.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridSales.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridSales.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridSales.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridSales.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSales.Appearance.Row.Options.UseBackColor = true;
            this.gridSales.Appearance.Row.Options.UseBorderColor = true;
            this.gridSales.Appearance.Row.Options.UseFont = true;
            this.gridSales.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSales.Appearance.ViewCaption.Options.UseFont = true;
            this.gridSales.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridSales.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSales.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridSales.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridSales.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridSales.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridSales.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridSales.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridSales.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSales.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridSales.AppearancePrint.Row.Options.UseFont = true;
            this.gridSales.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridSales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridSales.DetailHeight = 431;
            this.gridSales.GridControl = this.gridCtrlSales;
            this.gridSales.Name = "gridSales";
            this.gridSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridSales.OptionsBehavior.Editable = false;
            this.gridSales.OptionsCustomization.AllowRowSizing = true;
            this.gridSales.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridSales.OptionsSelection.MultiSelect = true;
            this.gridSales.OptionsView.EnableAppearanceEvenRow = true;
            this.gridSales.OptionsView.RowAutoHeight = true;
            this.gridSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridSales.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridSales_RowClick);
            this.gridSales.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridSales_FocusedRowChanged);
            this.gridSales.LostFocus += new System.EventHandler(this.GridSales_LostFocus);
            // 
            // gridView8
            // 
            this.gridView8.DetailHeight = 431;
            this.gridView8.GridControl = this.gridCtrlSales;
            this.gridView8.Name = "gridView8";
            // 
            // gridView9
            // 
            this.gridView9.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView9.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridView9.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gridView9.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Green;
            this.gridView9.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView9.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView9.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView9.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView9.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView9.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView9.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridView9.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView9.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView9.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView9.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView9.Appearance.Row.Options.UseFont = true;
            this.gridView9.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridView9.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView9.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView9.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView9.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView9.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridView9.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView9.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView9.AppearancePrint.Row.Options.UseFont = true;
            this.gridView9.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridView9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView9.DetailHeight = 431;
            this.gridView9.GridControl = this.gridCtrlSales;
            this.gridView9.Name = "gridView9";
            this.gridView9.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView9.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView9.OptionsBehavior.Editable = false;
            this.gridView9.OptionsBehavior.ReadOnly = true;
            this.gridView9.OptionsCustomization.AllowRowSizing = true;
            this.gridView9.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView9.OptionsSelection.MultiSelect = true;
            this.gridView9.OptionsView.ColumnAutoWidth = false;
            // 
            // gridView10
            // 
            this.gridView10.DetailHeight = 431;
            this.gridView10.GridControl = this.gridCtrlSales;
            this.gridView10.Name = "gridView10";
            // 
            // bntClear
            // 
            this.bntClear.BackColor = System.Drawing.Color.Firebrick;
            this.bntClear.Enabled = false;
            this.bntClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntClear.ForeColor = System.Drawing.Color.White;
            this.bntClear.Image = ((System.Drawing.Image)(resources.GetObject("bntClear.Image")));
            this.bntClear.Location = new System.Drawing.Point(1, 460);
            this.bntClear.Margin = new System.Windows.Forms.Padding(4);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(121, 128);
            this.bntClear.TabIndex = 124;
            this.bntClear.Text = "CLEAR";
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
            this.bntAdd.Location = new System.Drawing.Point(1, 202);
            this.bntAdd.Margin = new System.Windows.Forms.Padding(4);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(121, 128);
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
            this.bntCancel.Location = new System.Drawing.Point(124, 460);
            this.bntCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(121, 128);
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
            this.bntUpdate.Location = new System.Drawing.Point(124, 202);
            this.bntUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.Size = new System.Drawing.Size(121, 128);
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
            this.bntSave.Location = new System.Drawing.Point(1, 331);
            this.bntSave.Margin = new System.Windows.Forms.Padding(4);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(244, 128);
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
            this.pnlOptions.Location = new System.Drawing.Point(4, 950);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1731, 91);
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
            this.pnlOptionsMain.Location = new System.Drawing.Point(25, 5);
            this.pnlOptionsMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptionsMain.Name = "pnlOptionsMain";
            this.pnlOptionsMain.Size = new System.Drawing.Size(1191, 82);
            this.pnlOptionsMain.TabIndex = 21;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox17.Image")));
            this.pictureBox17.Location = new System.Drawing.Point(1075, 4);
            this.pictureBox17.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(101, 79);
            this.pictureBox17.TabIndex = 59;
            this.pictureBox17.TabStop = false;
            // 
            // pcSettings
            // 
            this.pcSettings.BackColor = System.Drawing.Color.Transparent;
            this.pcSettings.Image = ((System.Drawing.Image)(resources.GetObject("pcSettings.Image")));
            this.pcSettings.Location = new System.Drawing.Point(952, 4);
            this.pcSettings.Margin = new System.Windows.Forms.Padding(4);
            this.pcSettings.Name = "pcSettings";
            this.pcSettings.Size = new System.Drawing.Size(101, 75);
            this.pcSettings.TabIndex = 58;
            this.pcSettings.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(321, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 79);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pcSchedule
            // 
            this.pcSchedule.BackColor = System.Drawing.Color.Transparent;
            this.pcSchedule.Image = ((System.Drawing.Image)(resources.GetObject("pcSchedule.Image")));
            this.pcSchedule.Location = new System.Drawing.Point(821, 4);
            this.pcSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.pcSchedule.Name = "pcSchedule";
            this.pcSchedule.Size = new System.Drawing.Size(101, 79);
            this.pcSchedule.TabIndex = 17;
            this.pcSchedule.TabStop = false;
            // 
            // pcBL
            // 
            this.pcBL.BackColor = System.Drawing.Color.Transparent;
            this.pcBL.Image = ((System.Drawing.Image)(resources.GetObject("pcBL.Image")));
            this.pcBL.Location = new System.Drawing.Point(697, 2);
            this.pcBL.Margin = new System.Windows.Forms.Padding(4);
            this.pcBL.Name = "pcBL";
            this.pcBL.Size = new System.Drawing.Size(101, 79);
            this.pcBL.TabIndex = 16;
            this.pcBL.TabStop = false;
            // 
            // pcList
            // 
            this.pcList.BackColor = System.Drawing.Color.Transparent;
            this.pcList.Image = ((System.Drawing.Image)(resources.GetObject("pcList.Image")));
            this.pcList.Location = new System.Drawing.Point(571, 1);
            this.pcList.Margin = new System.Windows.Forms.Padding(4);
            this.pcList.Name = "pcList";
            this.pcList.Size = new System.Drawing.Size(101, 79);
            this.pcList.TabIndex = 15;
            this.pcList.TabStop = false;
            // 
            // pcUser
            // 
            this.pcUser.BackColor = System.Drawing.Color.Transparent;
            this.pcUser.Image = ((System.Drawing.Image)(resources.GetObject("pcUser.Image")));
            this.pcUser.Location = new System.Drawing.Point(192, 2);
            this.pcUser.Margin = new System.Windows.Forms.Padding(4);
            this.pcUser.Name = "pcUser";
            this.pcUser.Size = new System.Drawing.Size(101, 79);
            this.pcUser.TabIndex = 14;
            this.pcUser.TabStop = false;
            // 
            // pcAdd
            // 
            this.pcAdd.BackColor = System.Drawing.Color.Transparent;
            this.pcAdd.Image = ((System.Drawing.Image)(resources.GetObject("pcAdd.Image")));
            this.pcAdd.Location = new System.Drawing.Point(49, 2);
            this.pcAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pcAdd.Name = "pcAdd";
            this.pcAdd.Size = new System.Drawing.Size(101, 79);
            this.pcAdd.TabIndex = 13;
            this.pcAdd.TabStop = false;
            // 
            // pcChangePassword
            // 
            this.pcChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.pcChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("pcChangePassword.Image")));
            this.pcChangePassword.Location = new System.Drawing.Point(445, 2);
            this.pcChangePassword.Margin = new System.Windows.Forms.Padding(4);
            this.pcChangePassword.Name = "pcChangePassword";
            this.pcChangePassword.Size = new System.Drawing.Size(101, 79);
            this.pcChangePassword.TabIndex = 9;
            this.pcChangePassword.TabStop = false;
            // 
            // pbHide
            // 
            this.pbHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbHide.Image = ((System.Drawing.Image)(resources.GetObject("pbHide.Image")));
            this.pbHide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbHide.Location = new System.Drawing.Point(1539, 4);
            this.pbHide.Margin = new System.Windows.Forms.Padding(4);
            this.pbHide.Name = "pbHide";
            this.pbHide.Size = new System.Drawing.Size(51, 42);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlRightOptions);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.groupDeliveryDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).EndInit();
            this.groupDelivery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            this.xtraSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesDetails)).EndInit();
            this.groupSalesDetails.ResumeLayout(false);
            this.groupSalesDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).EndInit();
            this.groupSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblSign;
        private DevExpress.XtraEditors.GroupControl groupDeliveryDetails;
        private System.Windows.Forms.PictureBox ImageProduct;
        private DevExpress.XtraEditors.GroupControl groupSalesDetails;
        private System.Windows.Forms.PictureBox ImageSales;
        private DevExpress.XtraGrid.GridControl gridCtrlProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.GridControl gridCtrlSales;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSales;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private System.Windows.Forms.Label lblDeliveredQty;
        private System.Windows.Forms.TextBox txtDeliveredQty;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dkpDelUpdate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbDelDeliveryStatus;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtDelRemarks;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtDelReceiptNo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDelTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDelDeliveryQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDelCostPerItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDelStatus;
        private System.Windows.Forms.ComboBox cmbDelProductName;
        private System.Windows.Forms.ComboBox cmbDelBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dkpDelDeliveryDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDelLastCost;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDelQty;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDelDeliveryNo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDelBarcode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDelDeliveryID;
        private System.Windows.Forms.ComboBox cmbSalesStatus;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSalesDiscount;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtSalesCustomer;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtSalesQty;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtSalesNet;
        private System.Windows.Forms.ComboBox cmbSalesProductName;
        private System.Windows.Forms.ComboBox cmbSalesBranch;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker dkpSalesDate;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtSalesGross;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtSalesInvoice;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtSalesBarcode;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtSalesId;
    }
}