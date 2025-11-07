using System.Drawing;

namespace Inventory.MainForm
{
    partial class FirmWarehouseInvetory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmWarehouseInvetory));
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.pnlRightOptions = new System.Windows.Forms.Panel();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.pbLogout = new System.Windows.Forms.PictureBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlOptionsMain = new System.Windows.Forms.Panel();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pcSettings = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pcSchedule = new System.Windows.Forms.PictureBox();
            this.pcBL = new System.Windows.Forms.PictureBox();
            this.pcList = new System.Windows.Forms.PictureBox();
            this.pcUser = new System.Windows.Forms.PictureBox();
            this.pcAdd = new System.Windows.Forms.PictureBox();
            this.pcChangePassword = new System.Windows.Forms.PictureBox();
            this.pbHide = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bntAdd = new System.Windows.Forms.Button();
            this.xInventory = new DevExpress.XtraTab.XtraTabControl();
            this.xtraInventory = new DevExpress.XtraTab.XtraTabPage();
            this.groupInventoryDetail = new DevExpress.XtraEditors.GroupControl();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dpkLastUpdated = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dpkCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dpkExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCostPerUnit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.imgInventory = new System.Windows.Forms.PictureBox();
            this.cmbItemLocation = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dkpLastOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.lblHiredate = new System.Windows.Forms.Label();
            this.dkpLastStockedDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLastCostPerUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.txtQuantityStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWarehouseSKU = new System.Windows.Forms.TextBox();
            this.groupInventory = new DevExpress.XtraEditors.GroupControl();
            this.gridController = new DevExpress.XtraGrid.GridControl();
            this.gridInventory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdHIS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtInventoryId = new System.Windows.Forms.TextBox();
            this.xtraDelivery = new DevExpress.XtraTab.XtraTabPage();
            this.groupDeliveryDetails = new DevExpress.XtraEditors.GroupControl();
            this.label29 = new System.Windows.Forms.Label();
            this.dkpDelUpdate = new System.Windows.Forms.DateTimePicker();
            this.txtDelProductName = new System.Windows.Forms.TextBox();
            this.cmbDelWarehouseCode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDelDeliveryStatus = new System.Windows.Forms.ComboBox();
            this.txtDelRemarks = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDelRemainQty = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDelQty = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDelItemPrice = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDelProduct = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbDelProductStatus = new System.Windows.Forms.ComboBox();
            this.cmbDelBranch = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.dkpDelDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtDelReceipt = new System.Windows.Forms.TextBox();
            this.txtDelLastCost = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtDelWarehouseCode = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtDelWarehouseId = new System.Windows.Forms.TextBox();
            this.imgDelivery = new System.Windows.Forms.PictureBox();
            this.groupDelivery = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDelivery = new DevExpress.XtraGrid.GridControl();
            this.gridDelivery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.xtraReturn = new DevExpress.XtraTab.XtraTabPage();
            this.groupReturnDetails = new DevExpress.XtraEditors.GroupControl();
            this.label40 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtReturnedStatus = new System.Windows.Forms.TextBox();
            this.txtReturnedProduct = new System.Windows.Forms.TextBox();
            this.cmbReturnedWarehouse = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtReturnedRemarks = new System.Windows.Forms.TextBox();
            this.cmbReturnedBranch = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtReturnedQty = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.dkpReturedDate = new System.Windows.Forms.DateTimePicker();
            this.label52 = new System.Windows.Forms.Label();
            this.txtReturnedDelivery = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txtReturnedCode = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.txtReturnedId = new System.Windows.Forms.TextBox();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.groupReturn = new DevExpress.XtraEditors.GroupControl();
            this.gridControlReturn = new DevExpress.XtraGrid.GridControl();
            this.gridReturn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.xtraSales = new DevExpress.XtraTab.XtraTabPage();
            this.groupSalesDetails = new DevExpress.XtraEditors.GroupControl();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.dkpSalesDate = new System.Windows.Forms.DateTimePicker();
            this.txtSalesBarcode = new System.Windows.Forms.TextBox();
            this.txtNetSales = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtGrossSales = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtSalesQty = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtSalesInvoice = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtSalesDiscount = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.txtSalesPrice = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.imgSales = new System.Windows.Forms.PictureBox();
            this.groupSales = new DevExpress.XtraEditors.GroupControl();
            this.gridControlSales = new DevExpress.XtraGrid.GridControl();
            this.gridSales = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView14 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bntClear = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            this.bntSave = new System.Windows.Forms.Button();
            this.bntUpdate = new System.Windows.Forms.Button();
            this.bntHome = new System.Windows.Forms.Button();
            this.bntDelete = new System.Windows.Forms.Button();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.RightOptions = new System.Windows.Forms.Timer(this.components);
            this.Options = new System.Windows.Forms.Timer(this.components);
            this.pnlRightOptions.SuspendLayout();
            this.pnlRightMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.pnlOptionsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChangePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xInventory)).BeginInit();
            this.xInventory.SuspendLayout();
            this.xtraInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupInventoryDetail)).BeginInit();
            this.groupInventoryDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInventory)).BeginInit();
            this.groupInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHIS)).BeginInit();
            this.xtraDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupDeliveryDetails)).BeginInit();
            this.groupDeliveryDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).BeginInit();
            this.groupDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            this.xtraReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupReturnDetails)).BeginInit();
            this.groupReturnDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupReturn)).BeginInit();
            this.groupReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            this.xtraSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesDetails)).BeginInit();
            this.groupSalesDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).BeginInit();
            this.groupSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRightOptions
            // 
            this.pnlRightOptions.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlRightOptions.Controls.Add(this.pnlRightMain);
            this.pnlRightOptions.Location = new System.Drawing.Point(1804, 1);
            this.pnlRightOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRightOptions.Name = "pnlRightOptions";
            this.pnlRightOptions.Size = new System.Drawing.Size(103, 942);
            this.pnlRightOptions.TabIndex = 100;
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
            this.pbExit.Location = new System.Drawing.Point(0, 551);
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
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlOptions.Controls.Add(this.pnlOptionsMain);
            this.pnlOptions.Controls.Add(this.pbHide);
            this.pnlOptions.ForeColor = System.Drawing.Color.Black;
            this.pnlOptions.Location = new System.Drawing.Point(-3, 945);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1909, 91);
            this.pnlOptions.TabIndex = 129;
            // 
            // pnlOptionsMain
            // 
            this.pnlOptionsMain.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlOptionsMain.Controls.Add(this.pictureBox17);
            this.pnlOptionsMain.Controls.Add(this.pcSettings);
            this.pnlOptionsMain.Controls.Add(this.pictureBox2);
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(321, 1);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 79);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
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
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.bntAdd);
            this.pnlMain.Controls.Add(this.xInventory);
            this.pnlMain.Controls.Add(this.bntClear);
            this.pnlMain.Controls.Add(this.bntCancel);
            this.pnlMain.Controls.Add(this.bntSave);
            this.pnlMain.Controls.Add(this.bntUpdate);
            this.pnlMain.Controls.Add(this.bntHome);
            this.pnlMain.Controls.Add(this.bntDelete);
            this.pnlMain.Controls.Add(this.lblMainTitle);
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1735, 940);
            this.pnlMain.TabIndex = 228;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 138;
            this.pictureBox1.TabStop = false;
            // 
            // bntAdd
            // 
            this.bntAdd.BackColor = System.Drawing.Color.Red;
            this.bntAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAdd.ForeColor = System.Drawing.Color.White;
            this.bntAdd.Image = ((System.Drawing.Image)(resources.GetObject("bntAdd.Image")));
            this.bntAdd.Location = new System.Drawing.Point(5, 267);
            this.bntAdd.Margin = new System.Windows.Forms.Padding(4);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(121, 128);
            this.bntAdd.TabIndex = 130;
            this.bntAdd.Text = "ADD";
            this.bntAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntAdd.UseVisualStyleBackColor = false;
            this.bntAdd.Click += new System.EventHandler(this.bntAdd_Click);
            // 
            // xInventory
            // 
            this.xInventory.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.xInventory.Appearance.Options.UseBackColor = true;
            this.xInventory.Location = new System.Drawing.Point(252, 22);
            this.xInventory.Margin = new System.Windows.Forms.Padding(4);
            this.xInventory.Name = "xInventory";
            this.xInventory.SelectedTabPage = this.xtraInventory;
            this.xInventory.Size = new System.Drawing.Size(1477, 914);
            this.xInventory.TabIndex = 137;
            this.xInventory.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraInventory,
            this.xtraDelivery,
            this.xtraReturn,
            this.xtraSales});
            this.xInventory.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xInventory_SelectedPageChanged);
            // 
            // xtraInventory
            // 
            this.xtraInventory.Appearance.PageClient.BackColor = System.Drawing.Color.Black;
            this.xtraInventory.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraInventory.Controls.Add(this.groupInventoryDetail);
            this.xtraInventory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraInventory.ImageOptions.Image")));
            this.xtraInventory.Margin = new System.Windows.Forms.Padding(4);
            this.xtraInventory.Name = "xtraInventory";
            this.xtraInventory.Size = new System.Drawing.Size(1475, 884);
            this.xtraInventory.Text = "Warehouse Inventory";
            // 
            // groupInventoryDetail
            // 
            this.groupInventoryDetail.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupInventoryDetail.Appearance.Options.UseBackColor = true;
            this.groupInventoryDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupInventoryDetail.Controls.Add(this.label7);
            this.groupInventoryDetail.Controls.Add(this.txtBarcode);
            this.groupInventoryDetail.Controls.Add(this.cmbStatus);
            this.groupInventoryDetail.Controls.Add(this.label17);
            this.groupInventoryDetail.Controls.Add(this.dpkLastUpdated);
            this.groupInventoryDetail.Controls.Add(this.label18);
            this.groupInventoryDetail.Controls.Add(this.dpkCreatedDate);
            this.groupInventoryDetail.Controls.Add(this.label16);
            this.groupInventoryDetail.Controls.Add(this.dpkExpirationDate);
            this.groupInventoryDetail.Controls.Add(this.cmbSupplier);
            this.groupInventoryDetail.Controls.Add(this.label15);
            this.groupInventoryDetail.Controls.Add(this.txtCostPerUnit);
            this.groupInventoryDetail.Controls.Add(this.label9);
            this.groupInventoryDetail.Controls.Add(this.label4);
            this.groupInventoryDetail.Controls.Add(this.cmbUser);
            this.groupInventoryDetail.Controls.Add(this.cmbProductName);
            this.groupInventoryDetail.Controls.Add(this.imgInventory);
            this.groupInventoryDetail.Controls.Add(this.cmbItemLocation);
            this.groupInventoryDetail.Controls.Add(this.label13);
            this.groupInventoryDetail.Controls.Add(this.label12);
            this.groupInventoryDetail.Controls.Add(this.dkpLastOrderDate);
            this.groupInventoryDetail.Controls.Add(this.label11);
            this.groupInventoryDetail.Controls.Add(this.txtTotalValue);
            this.groupInventoryDetail.Controls.Add(this.lblHiredate);
            this.groupInventoryDetail.Controls.Add(this.dkpLastStockedDate);
            this.groupInventoryDetail.Controls.Add(this.label8);
            this.groupInventoryDetail.Controls.Add(this.txtLastCostPerUnit);
            this.groupInventoryDetail.Controls.Add(this.label3);
            this.groupInventoryDetail.Controls.Add(this.label6);
            this.groupInventoryDetail.Controls.Add(this.label5);
            this.groupInventoryDetail.Controls.Add(this.txtReorderLevel);
            this.groupInventoryDetail.Controls.Add(this.txtQuantityStock);
            this.groupInventoryDetail.Controls.Add(this.label2);
            this.groupInventoryDetail.Controls.Add(this.label1);
            this.groupInventoryDetail.Controls.Add(this.txtWarehouseSKU);
            this.groupInventoryDetail.Controls.Add(this.groupInventory);
            this.groupInventoryDetail.Controls.Add(this.lblBarcode);
            this.groupInventoryDetail.Controls.Add(this.txtInventoryId);
            this.groupInventoryDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInventoryDetail.Location = new System.Drawing.Point(0, 0);
            this.groupInventoryDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupInventoryDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupInventoryDetail.Margin = new System.Windows.Forms.Padding(4);
            this.groupInventoryDetail.Name = "groupInventoryDetail";
            this.groupInventoryDetail.Size = new System.Drawing.Size(1475, 884);
            this.groupInventoryDetail.TabIndex = 173;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 244;
            this.label7.Text = "Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.DimGray;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtBarcode.Location = new System.Drawing.Point(160, 63);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(379, 34);
            this.txtBarcode.TabIndex = 243;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.BackColor = System.Drawing.Color.DimGray;
            this.cmbStatus.Enabled = false;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.ForeColor = System.Drawing.Color.Maroon;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(739, 323);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(329, 36);
            this.cmbStatus.TabIndex = 18;
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(568, 220);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 23);
            this.label17.TabIndex = 242;
            this.label17.Text = "Updated Date:";
            // 
            // dpkLastUpdated
            // 
            this.dpkLastUpdated.CustomFormat = "dd-MM-yyyy";
            this.dpkLastUpdated.Enabled = false;
            this.dpkLastUpdated.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpkLastUpdated.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpkLastUpdated.Location = new System.Drawing.Point(739, 213);
            this.dpkLastUpdated.Margin = new System.Windows.Forms.Padding(4);
            this.dpkLastUpdated.Name = "dpkLastUpdated";
            this.dpkLastUpdated.Size = new System.Drawing.Size(329, 34);
            this.dpkLastUpdated.TabIndex = 15;
            this.dpkLastUpdated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpkLastUpdated_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(568, 182);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 23);
            this.label18.TabIndex = 240;
            this.label18.Text = "Created Date:";
            // 
            // dpkCreatedDate
            // 
            this.dpkCreatedDate.CustomFormat = "dd-MM-yyyy";
            this.dpkCreatedDate.Enabled = false;
            this.dpkCreatedDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpkCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpkCreatedDate.Location = new System.Drawing.Point(739, 176);
            this.dpkCreatedDate.Margin = new System.Windows.Forms.Padding(4);
            this.dpkCreatedDate.Name = "dpkCreatedDate";
            this.dpkCreatedDate.Size = new System.Drawing.Size(329, 34);
            this.dpkCreatedDate.TabIndex = 14;
            this.dpkCreatedDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpkCreatedDate_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(568, 145);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 23);
            this.label16.TabIndex = 238;
            this.label16.Text = "Expiration Date:";
            // 
            // dpkExpirationDate
            // 
            this.dpkExpirationDate.CustomFormat = "dd-MM-yyyy";
            this.dpkExpirationDate.Enabled = false;
            this.dpkExpirationDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpkExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpkExpirationDate.Location = new System.Drawing.Point(739, 139);
            this.dpkExpirationDate.Margin = new System.Windows.Forms.Padding(4);
            this.dpkExpirationDate.Name = "dpkExpirationDate";
            this.dpkExpirationDate.Size = new System.Drawing.Size(329, 34);
            this.dpkExpirationDate.TabIndex = 13;
            this.dpkExpirationDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpkExpirationDate_KeyDown);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplier.BackColor = System.Drawing.Color.DimGray;
            this.cmbSupplier.Enabled = false;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.ForeColor = System.Drawing.Color.Maroon;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(159, 248);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(380, 36);
            this.cmbSupplier.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(7, 256);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 23);
            this.label15.TabIndex = 236;
            this.label15.Text = "Supplier:";
            // 
            // txtCostPerUnit
            // 
            this.txtCostPerUnit.BackColor = System.Drawing.Color.DimGray;
            this.txtCostPerUnit.Enabled = false;
            this.txtCostPerUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostPerUnit.ForeColor = System.Drawing.Color.Maroon;
            this.txtCostPerUnit.Location = new System.Drawing.Point(160, 285);
            this.txtCostPerUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtCostPerUnit.Name = "txtCostPerUnit";
            this.txtCostPerUnit.Size = new System.Drawing.Size(379, 34);
            this.txtCostPerUnit.TabIndex = 7;
            this.txtCostPerUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostPerUnit_KeyDown);
            this.txtCostPerUnit.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCostPerUnit_PreviewKeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(568, 257);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 23);
            this.label9.TabIndex = 229;
            this.label9.Text = "Operator:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(568, 330);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 225;
            this.label4.Text = "Status:";
            // 
            // cmbUser
            // 
            this.cmbUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUser.BackColor = System.Drawing.Color.DimGray;
            this.cmbUser.Enabled = false;
            this.cmbUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUser.ForeColor = System.Drawing.Color.Maroon;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(739, 249);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(329, 36);
            this.cmbUser.TabIndex = 16;
            this.cmbUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUser_KeyDown);
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
            this.cmbProductName.Location = new System.Drawing.Point(159, 137);
            this.cmbProductName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(380, 36);
            this.cmbProductName.TabIndex = 3;
            this.cmbProductName.SelectedIndexChanged += new System.EventHandler(this.cmbProductName_SelectedIndexChanged);
            this.cmbProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductName_KeyDown);
            // 
            // imgInventory
            // 
            this.imgInventory.BackColor = System.Drawing.Color.Gray;
            this.imgInventory.Location = new System.Drawing.Point(1092, 23);
            this.imgInventory.Margin = new System.Windows.Forms.Padding(4);
            this.imgInventory.Name = "imgInventory";
            this.imgInventory.Size = new System.Drawing.Size(380, 338);
            this.imgInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgInventory.TabIndex = 223;
            this.imgInventory.TabStop = false;
            // 
            // cmbItemLocation
            // 
            this.cmbItemLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemLocation.BackColor = System.Drawing.Color.DimGray;
            this.cmbItemLocation.Enabled = false;
            this.cmbItemLocation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemLocation.ForeColor = System.Drawing.Color.Maroon;
            this.cmbItemLocation.FormattingEnabled = true;
            this.cmbItemLocation.Location = new System.Drawing.Point(739, 286);
            this.cmbItemLocation.Margin = new System.Windows.Forms.Padding(4);
            this.cmbItemLocation.Name = "cmbItemLocation";
            this.cmbItemLocation.Size = new System.Drawing.Size(329, 36);
            this.cmbItemLocation.TabIndex = 17;
            this.cmbItemLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemLocation_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(7, 292);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 23);
            this.label13.TabIndex = 214;
            this.label13.Text = "Cost Per Unit:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(568, 108);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 23);
            this.label12.TabIndex = 212;
            this.label12.Text = "Last Ordered Date:";
            // 
            // dkpLastOrderDate
            // 
            this.dkpLastOrderDate.CustomFormat = "dd-MM-yyyy";
            this.dkpLastOrderDate.Enabled = false;
            this.dkpLastOrderDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpLastOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpLastOrderDate.Location = new System.Drawing.Point(739, 102);
            this.dkpLastOrderDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpLastOrderDate.Name = "dkpLastOrderDate";
            this.dkpLastOrderDate.Size = new System.Drawing.Size(329, 34);
            this.dkpLastOrderDate.TabIndex = 12;
            this.dkpLastOrderDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpLastOrderDate_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(568, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 23);
            this.label11.TabIndex = 210;
            this.label11.Text = "Total Value:";
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.BackColor = System.Drawing.Color.DimGray;
            this.txtTotalValue.Enabled = false;
            this.txtTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalValue.ForeColor = System.Drawing.Color.Maroon;
            this.txtTotalValue.Location = new System.Drawing.Point(739, 28);
            this.txtTotalValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Size = new System.Drawing.Size(329, 34);
            this.txtTotalValue.TabIndex = 9;
            // 
            // lblHiredate
            // 
            this.lblHiredate.AutoSize = true;
            this.lblHiredate.BackColor = System.Drawing.Color.Transparent;
            this.lblHiredate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiredate.ForeColor = System.Drawing.Color.White;
            this.lblHiredate.Location = new System.Drawing.Point(568, 71);
            this.lblHiredate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHiredate.Name = "lblHiredate";
            this.lblHiredate.Size = new System.Drawing.Size(160, 23);
            this.lblHiredate.TabIndex = 208;
            this.lblHiredate.Text = "Last Stocked Date:";
            // 
            // dkpLastStockedDate
            // 
            this.dkpLastStockedDate.CustomFormat = "dd-MM-yyyy";
            this.dkpLastStockedDate.Enabled = false;
            this.dkpLastStockedDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpLastStockedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpLastStockedDate.Location = new System.Drawing.Point(739, 65);
            this.dkpLastStockedDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpLastStockedDate.Name = "dkpLastStockedDate";
            this.dkpLastStockedDate.Size = new System.Drawing.Size(329, 34);
            this.dkpLastStockedDate.TabIndex = 11;
            this.dkpLastStockedDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpLastStockedDate_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 329);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 23);
            this.label8.TabIndex = 206;
            this.label8.Text = "Last Cost/Unit:";
            // 
            // txtLastCostPerUnit
            // 
            this.txtLastCostPerUnit.BackColor = System.Drawing.Color.DimGray;
            this.txtLastCostPerUnit.Enabled = false;
            this.txtLastCostPerUnit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastCostPerUnit.ForeColor = System.Drawing.Color.Maroon;
            this.txtLastCostPerUnit.Location = new System.Drawing.Point(160, 322);
            this.txtLastCostPerUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastCostPerUnit.Name = "txtLastCostPerUnit";
            this.txtLastCostPerUnit.Size = new System.Drawing.Size(379, 34);
            this.txtLastCostPerUnit.TabIndex = 8;
            this.txtLastCostPerUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLastCostPerUnit_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 23);
            this.label3.TabIndex = 200;
            this.label3.Text = "Reorder-Level:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(568, 293);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 23);
            this.label6.TabIndex = 184;
            this.label6.Text = "Item Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 23);
            this.label5.TabIndex = 182;
            this.label5.Text = "Product Name:";
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.BackColor = System.Drawing.Color.DimGray;
            this.txtReorderLevel.Enabled = false;
            this.txtReorderLevel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReorderLevel.ForeColor = System.Drawing.Color.Maroon;
            this.txtReorderLevel.Location = new System.Drawing.Point(160, 212);
            this.txtReorderLevel.Margin = new System.Windows.Forms.Padding(4);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(379, 34);
            this.txtReorderLevel.TabIndex = 5;
            this.txtReorderLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReorderLevel_KeyDown);
            // 
            // txtQuantityStock
            // 
            this.txtQuantityStock.BackColor = System.Drawing.Color.DimGray;
            this.txtQuantityStock.Enabled = false;
            this.txtQuantityStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityStock.ForeColor = System.Drawing.Color.Maroon;
            this.txtQuantityStock.Location = new System.Drawing.Point(160, 175);
            this.txtQuantityStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantityStock.Name = "txtQuantityStock";
            this.txtQuantityStock.Size = new System.Drawing.Size(379, 34);
            this.txtQuantityStock.TabIndex = 4;
            this.txtQuantityStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantityStock_KeyDown);
            this.txtQuantityStock.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtQuantityStock_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 176;
            this.label2.Text = "Qty Stock:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 174;
            this.label1.Text = "Warehouse SKU:";
            // 
            // txtWarehouseSKU
            // 
            this.txtWarehouseSKU.BackColor = System.Drawing.Color.DimGray;
            this.txtWarehouseSKU.Enabled = false;
            this.txtWarehouseSKU.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarehouseSKU.ForeColor = System.Drawing.Color.Maroon;
            this.txtWarehouseSKU.Location = new System.Drawing.Point(160, 100);
            this.txtWarehouseSKU.Margin = new System.Windows.Forms.Padding(4);
            this.txtWarehouseSKU.Name = "txtWarehouseSKU";
            this.txtWarehouseSKU.Size = new System.Drawing.Size(379, 34);
            this.txtWarehouseSKU.TabIndex = 2;
            this.txtWarehouseSKU.TextChanged += new System.EventHandler(this.txtWarehouseSKU_TextChanged);
            this.txtWarehouseSKU.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtWarehouseSKU_KeyDown);
            // 
            // groupInventory
            // 
            this.groupInventory.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupInventory.Appearance.Options.UseBackColor = true;
            this.groupInventory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupInventory.Controls.Add(this.gridController);
            this.groupInventory.Location = new System.Drawing.Point(-1, 363);
            this.groupInventory.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupInventory.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupInventory.Margin = new System.Windows.Forms.Padding(4);
            this.groupInventory.Name = "groupInventory";
            this.groupInventory.Size = new System.Drawing.Size(1477, 546);
            this.groupInventory.TabIndex = 172;
            this.groupInventory.Text = "Warehouse Inventory List";
            // 
            // gridController
            // 
            this.gridController.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridController.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridController.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridController.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridController.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridController.Location = new System.Drawing.Point(3, 21);
            this.gridController.MainView = this.gridInventory;
            this.gridController.Margin = new System.Windows.Forms.Padding(4);
            this.gridController.Name = "gridController";
            this.gridController.Size = new System.Drawing.Size(1471, 522);
            this.gridController.TabIndex = 26;
            this.gridController.TabStop = false;
            this.gridController.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gridInventory.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridInventory.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridInventory.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridInventory.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridInventory.Appearance.FocusedRow.Options.UseFont = true;
            this.gridInventory.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridInventory.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridInventory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridInventory.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
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
            this.gridInventory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridInventory.DetailHeight = 431;
            this.gridInventory.GridControl = this.gridController;
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
            this.gridInventory.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridInventory_RowClick);
            this.gridInventory.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridInventory_FocusedRowChanged);
            this.gridInventory.LostFocus += new System.EventHandler(this.GridInventory_LostFocus);
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 431;
            this.gridView2.GridControl = this.gridController;
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
            this.gridView3.GridControl = this.gridController;
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
            this.grdHIS.GridControl = this.gridController;
            this.grdHIS.Name = "grdHIS";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.White;
            this.lblBarcode.Location = new System.Drawing.Point(7, 33);
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
            this.txtInventoryId.Location = new System.Drawing.Point(160, 26);
            this.txtInventoryId.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventoryId.Name = "txtInventoryId";
            this.txtInventoryId.Size = new System.Drawing.Size(379, 34);
            this.txtInventoryId.TabIndex = 1;
            // 
            // xtraDelivery
            // 
            this.xtraDelivery.Controls.Add(this.groupDeliveryDetails);
            this.xtraDelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraDelivery.ImageOptions.Image")));
            this.xtraDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.xtraDelivery.Name = "xtraDelivery";
            this.xtraDelivery.Size = new System.Drawing.Size(1475, 884);
            this.xtraDelivery.Text = "Delivery History";
            // 
            // groupDeliveryDetails
            // 
            this.groupDeliveryDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupDeliveryDetails.Appearance.Options.UseBackColor = true;
            this.groupDeliveryDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupDeliveryDetails.Controls.Add(this.label29);
            this.groupDeliveryDetails.Controls.Add(this.dkpDelUpdate);
            this.groupDeliveryDetails.Controls.Add(this.txtDelProductName);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelWarehouseCode);
            this.groupDeliveryDetails.Controls.Add(this.label10);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelDeliveryStatus);
            this.groupDeliveryDetails.Controls.Add(this.txtDelRemarks);
            this.groupDeliveryDetails.Controls.Add(this.label14);
            this.groupDeliveryDetails.Controls.Add(this.txtDelRemainQty);
            this.groupDeliveryDetails.Controls.Add(this.label19);
            this.groupDeliveryDetails.Controls.Add(this.txtDelQty);
            this.groupDeliveryDetails.Controls.Add(this.label20);
            this.groupDeliveryDetails.Controls.Add(this.txtDelItemPrice);
            this.groupDeliveryDetails.Controls.Add(this.label21);
            this.groupDeliveryDetails.Controls.Add(this.txtDelProduct);
            this.groupDeliveryDetails.Controls.Add(this.label22);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelProductStatus);
            this.groupDeliveryDetails.Controls.Add(this.cmbDelBranch);
            this.groupDeliveryDetails.Controls.Add(this.label23);
            this.groupDeliveryDetails.Controls.Add(this.label24);
            this.groupDeliveryDetails.Controls.Add(this.label25);
            this.groupDeliveryDetails.Controls.Add(this.dkpDelDeliveryDate);
            this.groupDeliveryDetails.Controls.Add(this.label26);
            this.groupDeliveryDetails.Controls.Add(this.label27);
            this.groupDeliveryDetails.Controls.Add(this.label28);
            this.groupDeliveryDetails.Controls.Add(this.txtDelReceipt);
            this.groupDeliveryDetails.Controls.Add(this.txtDelLastCost);
            this.groupDeliveryDetails.Controls.Add(this.label30);
            this.groupDeliveryDetails.Controls.Add(this.label31);
            this.groupDeliveryDetails.Controls.Add(this.txtDelWarehouseCode);
            this.groupDeliveryDetails.Controls.Add(this.label32);
            this.groupDeliveryDetails.Controls.Add(this.txtDelWarehouseId);
            this.groupDeliveryDetails.Controls.Add(this.imgDelivery);
            this.groupDeliveryDetails.Controls.Add(this.groupDelivery);
            this.groupDeliveryDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDeliveryDetails.Location = new System.Drawing.Point(0, 0);
            this.groupDeliveryDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupDeliveryDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupDeliveryDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupDeliveryDetails.Name = "groupDeliveryDetails";
            this.groupDeliveryDetails.Size = new System.Drawing.Size(1475, 884);
            this.groupDeliveryDetails.TabIndex = 174;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(555, 297);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(113, 23);
            this.label29.TabIndex = 302;
            this.label29.Text = "Updated On:";
            // 
            // dkpDelUpdate
            // 
            this.dkpDelUpdate.CustomFormat = "dd-MM-yyyy";
            this.dkpDelUpdate.Enabled = false;
            this.dkpDelUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDelUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDelUpdate.Location = new System.Drawing.Point(725, 289);
            this.dkpDelUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpDelUpdate.Name = "dkpDelUpdate";
            this.dkpDelUpdate.Size = new System.Drawing.Size(357, 34);
            this.dkpDelUpdate.TabIndex = 301;
            // 
            // txtDelProductName
            // 
            this.txtDelProductName.BackColor = System.Drawing.Color.DimGray;
            this.txtDelProductName.Enabled = false;
            this.txtDelProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelProductName.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelProductName.Location = new System.Drawing.Point(171, 105);
            this.txtDelProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelProductName.Name = "txtDelProductName";
            this.txtDelProductName.Size = new System.Drawing.Size(357, 34);
            this.txtDelProductName.TabIndex = 273;
            // 
            // cmbDelWarehouseCode
            // 
            this.cmbDelWarehouseCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDelWarehouseCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDelWarehouseCode.BackColor = System.Drawing.Color.DimGray;
            this.cmbDelWarehouseCode.Enabled = false;
            this.cmbDelWarehouseCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelWarehouseCode.ForeColor = System.Drawing.Color.Maroon;
            this.cmbDelWarehouseCode.FormattingEnabled = true;
            this.cmbDelWarehouseCode.Location = new System.Drawing.Point(169, 178);
            this.cmbDelWarehouseCode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelWarehouseCode.Name = "cmbDelWarehouseCode";
            this.cmbDelWarehouseCode.Size = new System.Drawing.Size(359, 36);
            this.cmbDelWarehouseCode.TabIndex = 272;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(555, 186);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 23);
            this.label10.TabIndex = 300;
            this.label10.Text = "Delivery Status:";
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
            this.cmbDelDeliveryStatus.Location = new System.Drawing.Point(724, 178);
            this.cmbDelDeliveryStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelDeliveryStatus.Name = "cmbDelDeliveryStatus";
            this.cmbDelDeliveryStatus.Size = new System.Drawing.Size(358, 36);
            this.cmbDelDeliveryStatus.TabIndex = 278;
            // 
            // txtDelRemarks
            // 
            this.txtDelRemarks.BackColor = System.Drawing.Color.DimGray;
            this.txtDelRemarks.Enabled = false;
            this.txtDelRemarks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelRemarks.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelRemarks.Location = new System.Drawing.Point(725, 215);
            this.txtDelRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelRemarks.Name = "txtDelRemarks";
            this.txtDelRemarks.Size = new System.Drawing.Size(357, 34);
            this.txtDelRemarks.TabIndex = 279;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(556, 223);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 23);
            this.label14.TabIndex = 299;
            this.label14.Text = "Remarks:";
            // 
            // txtDelRemainQty
            // 
            this.txtDelRemainQty.BackColor = System.Drawing.Color.DimGray;
            this.txtDelRemainQty.Enabled = false;
            this.txtDelRemainQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelRemainQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelRemainQty.Location = new System.Drawing.Point(171, 289);
            this.txtDelRemainQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelRemainQty.Name = "txtDelRemainQty";
            this.txtDelRemainQty.Size = new System.Drawing.Size(357, 34);
            this.txtDelRemainQty.TabIndex = 292;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(555, 149);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(116, 23);
            this.label19.TabIndex = 298;
            this.label19.Text = "Delivery Qty:";
            // 
            // txtDelQty
            // 
            this.txtDelQty.BackColor = System.Drawing.Color.DimGray;
            this.txtDelQty.Enabled = false;
            this.txtDelQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelQty.Location = new System.Drawing.Point(725, 142);
            this.txtDelQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelQty.Name = "txtDelQty";
            this.txtDelQty.Size = new System.Drawing.Size(357, 34);
            this.txtDelQty.TabIndex = 276;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(7, 260);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 23);
            this.label20.TabIndex = 297;
            this.label20.Text = "Item Price:";
            // 
            // txtDelItemPrice
            // 
            this.txtDelItemPrice.BackColor = System.Drawing.Color.DimGray;
            this.txtDelItemPrice.Enabled = false;
            this.txtDelItemPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelItemPrice.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelItemPrice.Location = new System.Drawing.Point(171, 252);
            this.txtDelItemPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelItemPrice.Name = "txtDelItemPrice";
            this.txtDelItemPrice.Size = new System.Drawing.Size(357, 34);
            this.txtDelItemPrice.TabIndex = 275;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(5, 75);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(148, 23);
            this.label21.TabIndex = 296;
            this.label21.Text = "Product Barcode:";
            // 
            // txtDelProduct
            // 
            this.txtDelProduct.BackColor = System.Drawing.Color.DimGray;
            this.txtDelProduct.Enabled = false;
            this.txtDelProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelProduct.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelProduct.Location = new System.Drawing.Point(171, 68);
            this.txtDelProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelProduct.Name = "txtDelProduct";
            this.txtDelProduct.Size = new System.Drawing.Size(357, 34);
            this.txtDelProduct.TabIndex = 293;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(5, 149);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(133, 23);
            this.label22.TabIndex = 291;
            this.label22.Text = "Product Status:";
            // 
            // cmbDelProductStatus
            // 
            this.cmbDelProductStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDelProductStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDelProductStatus.BackColor = System.Drawing.Color.DimGray;
            this.cmbDelProductStatus.Enabled = false;
            this.cmbDelProductStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelProductStatus.ForeColor = System.Drawing.Color.Maroon;
            this.cmbDelProductStatus.FormattingEnabled = true;
            this.cmbDelProductStatus.Location = new System.Drawing.Point(169, 142);
            this.cmbDelProductStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelProductStatus.Name = "cmbDelProductStatus";
            this.cmbDelProductStatus.Size = new System.Drawing.Size(359, 36);
            this.cmbDelProductStatus.TabIndex = 295;
            // 
            // cmbDelBranch
            // 
            this.cmbDelBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDelBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDelBranch.BackColor = System.Drawing.Color.DimGray;
            this.cmbDelBranch.Enabled = false;
            this.cmbDelBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDelBranch.ForeColor = System.Drawing.Color.Black;
            this.cmbDelBranch.FormattingEnabled = true;
            this.cmbDelBranch.Location = new System.Drawing.Point(724, 31);
            this.cmbDelBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDelBranch.Name = "cmbDelBranch";
            this.cmbDelBranch.Size = new System.Drawing.Size(358, 36);
            this.cmbDelBranch.TabIndex = 294;
            this.cmbDelBranch.Text = "SELECT BRANCH";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(555, 36);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(107, 23);
            this.label23.TabIndex = 289;
            this.label23.Text = "Destination:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(5, 186);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(148, 23);
            this.label24.TabIndex = 288;
            this.label24.Text = "Warehouse Code:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(556, 260);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 23);
            this.label25.TabIndex = 287;
            this.label25.Text = "Delivery Date:";
            // 
            // dkpDelDeliveryDate
            // 
            this.dkpDelDeliveryDate.CustomFormat = "dd-MM-yyyy";
            this.dkpDelDeliveryDate.Enabled = false;
            this.dkpDelDeliveryDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDelDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDelDeliveryDate.Location = new System.Drawing.Point(725, 252);
            this.dkpDelDeliveryDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpDelDeliveryDate.Name = "dkpDelDeliveryDate";
            this.dkpDelDeliveryDate.Size = new System.Drawing.Size(357, 34);
            this.dkpDelDeliveryDate.TabIndex = 277;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(555, 112);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(147, 23);
            this.label26.TabIndex = 286;
            this.label26.Text = "Receipt Number:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(7, 297);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(135, 23);
            this.label27.TabIndex = 285;
            this.label27.Text = "Remaining Qty:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(5, 112);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(130, 23);
            this.label28.TabIndex = 284;
            this.label28.Text = "Product Name:";
            // 
            // txtDelReceipt
            // 
            this.txtDelReceipt.BackColor = System.Drawing.Color.DimGray;
            this.txtDelReceipt.Enabled = false;
            this.txtDelReceipt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelReceipt.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelReceipt.Location = new System.Drawing.Point(725, 105);
            this.txtDelReceipt.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelReceipt.Name = "txtDelReceipt";
            this.txtDelReceipt.Size = new System.Drawing.Size(357, 34);
            this.txtDelReceipt.TabIndex = 290;
            // 
            // txtDelLastCost
            // 
            this.txtDelLastCost.BackColor = System.Drawing.Color.DimGray;
            this.txtDelLastCost.Enabled = false;
            this.txtDelLastCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelLastCost.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelLastCost.Location = new System.Drawing.Point(171, 215);
            this.txtDelLastCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelLastCost.Name = "txtDelLastCost";
            this.txtDelLastCost.Size = new System.Drawing.Size(357, 34);
            this.txtDelLastCost.TabIndex = 274;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(7, 223);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(129, 23);
            this.label30.TabIndex = 283;
            this.label30.Text = "Last Item Cost:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(555, 75);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(128, 23);
            this.label31.TabIndex = 282;
            this.label31.Text = "Delivery Code:";
            // 
            // txtDelWarehouseCode
            // 
            this.txtDelWarehouseCode.BackColor = System.Drawing.Color.DimGray;
            this.txtDelWarehouseCode.Enabled = false;
            this.txtDelWarehouseCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelWarehouseCode.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelWarehouseCode.Location = new System.Drawing.Point(725, 68);
            this.txtDelWarehouseCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelWarehouseCode.Name = "txtDelWarehouseCode";
            this.txtDelWarehouseCode.Size = new System.Drawing.Size(357, 34);
            this.txtDelWarehouseCode.TabIndex = 271;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(5, 38);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(103, 23);
            this.label32.TabIndex = 281;
            this.label32.Text = "Delivery Id:";
            // 
            // txtDelWarehouseId
            // 
            this.txtDelWarehouseId.BackColor = System.Drawing.Color.DimGray;
            this.txtDelWarehouseId.Enabled = false;
            this.txtDelWarehouseId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelWarehouseId.ForeColor = System.Drawing.Color.Maroon;
            this.txtDelWarehouseId.Location = new System.Drawing.Point(171, 31);
            this.txtDelWarehouseId.Margin = new System.Windows.Forms.Padding(4);
            this.txtDelWarehouseId.Name = "txtDelWarehouseId";
            this.txtDelWarehouseId.Size = new System.Drawing.Size(357, 34);
            this.txtDelWarehouseId.TabIndex = 280;
            // 
            // imgDelivery
            // 
            this.imgDelivery.BackColor = System.Drawing.Color.Gray;
            this.imgDelivery.Location = new System.Drawing.Point(1092, 21);
            this.imgDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.imgDelivery.Name = "imgDelivery";
            this.imgDelivery.Size = new System.Drawing.Size(380, 314);
            this.imgDelivery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgDelivery.TabIndex = 224;
            this.imgDelivery.TabStop = false;
            // 
            // groupDelivery
            // 
            this.groupDelivery.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupDelivery.Appearance.Options.UseBackColor = true;
            this.groupDelivery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupDelivery.Controls.Add(this.gridControlDelivery);
            this.groupDelivery.Controls.Add(this.textBox1);
            this.groupDelivery.Location = new System.Drawing.Point(-3, 335);
            this.groupDelivery.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupDelivery.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.groupDelivery.Name = "groupDelivery";
            this.groupDelivery.Size = new System.Drawing.Size(1477, 546);
            this.groupDelivery.TabIndex = 173;
            this.groupDelivery.Text = "Warehouse Delivery List";
            // 
            // gridControlDelivery
            // 
            this.gridControlDelivery.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDelivery.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridControlDelivery.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControlDelivery.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlDelivery.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridControlDelivery.Location = new System.Drawing.Point(3, 21);
            this.gridControlDelivery.MainView = this.gridDelivery;
            this.gridControlDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlDelivery.Name = "gridControlDelivery";
            this.gridControlDelivery.Size = new System.Drawing.Size(1471, 522);
            this.gridControlDelivery.TabIndex = 26;
            this.gridControlDelivery.TabStop = false;
            this.gridControlDelivery.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDelivery,
            this.gridView4,
            this.gridView5,
            this.gridView6});
            // 
            // gridDelivery
            // 
            this.gridDelivery.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridDelivery.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridDelivery.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridDelivery.Appearance.Empty.Options.UseBackColor = true;
            this.gridDelivery.Appearance.Empty.Options.UseBorderColor = true;
            this.gridDelivery.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridDelivery.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridDelivery.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridDelivery.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridDelivery.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridDelivery.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridDelivery.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridDelivery.Appearance.FocusedRow.Options.UseFont = true;
            this.gridDelivery.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridDelivery.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridDelivery.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDelivery.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gridDelivery.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridDelivery.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridDelivery.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridDelivery.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridDelivery.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridDelivery.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridDelivery.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDelivery.Appearance.Row.Options.UseBackColor = true;
            this.gridDelivery.Appearance.Row.Options.UseBorderColor = true;
            this.gridDelivery.Appearance.Row.Options.UseFont = true;
            this.gridDelivery.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDelivery.Appearance.ViewCaption.Options.UseFont = true;
            this.gridDelivery.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridDelivery.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDelivery.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridDelivery.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridDelivery.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridDelivery.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridDelivery.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridDelivery.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDelivery.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDelivery.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridDelivery.AppearancePrint.Row.Options.UseFont = true;
            this.gridDelivery.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridDelivery.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridDelivery.DetailHeight = 431;
            this.gridDelivery.GridControl = this.gridControlDelivery;
            this.gridDelivery.Name = "gridDelivery";
            this.gridDelivery.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridDelivery.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridDelivery.OptionsBehavior.Editable = false;
            this.gridDelivery.OptionsCustomization.AllowRowSizing = true;
            this.gridDelivery.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridDelivery.OptionsSelection.MultiSelect = true;
            this.gridDelivery.OptionsView.EnableAppearanceEvenRow = true;
            this.gridDelivery.OptionsView.RowAutoHeight = true;
            this.gridDelivery.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridDelivery.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridDelivery_RowClick);
            this.gridDelivery.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridDelivery_FocusedRowChanged);
            this.gridDelivery.LostFocus += new System.EventHandler(this.GridDelivery_LostFocus);
            // 
            // gridView4
            // 
            this.gridView4.DetailHeight = 431;
            this.gridView4.GridControl = this.gridControlDelivery;
            this.gridView4.Name = "gridView4";
            // 
            // gridView5
            // 
            this.gridView5.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView5.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridView5.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gridView5.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Green;
            this.gridView5.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView5.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView5.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView5.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView5.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView5.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView5.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridView5.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView5.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView5.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView5.Appearance.Row.Options.UseFont = true;
            this.gridView5.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridView5.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView5.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView5.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView5.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView5.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridView5.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView5.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView5.AppearancePrint.Row.Options.UseFont = true;
            this.gridView5.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridView5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView5.DetailHeight = 431;
            this.gridView5.GridControl = this.gridControlDelivery;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsBehavior.ReadOnly = true;
            this.gridView5.OptionsCustomization.AllowRowSizing = true;
            this.gridView5.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView5.OptionsSelection.MultiSelect = true;
            this.gridView5.OptionsView.ColumnAutoWidth = false;
            // 
            // gridView6
            // 
            this.gridView6.DetailHeight = 431;
            this.gridView6.GridControl = this.gridControlDelivery;
            this.gridView6.Name = "gridView6";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(-11, 26);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(12, 11);
            this.textBox1.TabIndex = 99;
            this.textBox1.Visible = false;
            // 
            // xtraReturn
            // 
            this.xtraReturn.Controls.Add(this.groupReturnDetails);
            this.xtraReturn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraReturn.ImageOptions.Image")));
            this.xtraReturn.Margin = new System.Windows.Forms.Padding(4);
            this.xtraReturn.Name = "xtraReturn";
            this.xtraReturn.Size = new System.Drawing.Size(1475, 884);
            this.xtraReturn.Text = "Return History";
            // 
            // groupReturnDetails
            // 
            this.groupReturnDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupReturnDetails.Appearance.Options.UseBackColor = true;
            this.groupReturnDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupReturnDetails.Controls.Add(this.label40);
            this.groupReturnDetails.Controls.Add(this.dateTimePicker1);
            this.groupReturnDetails.Controls.Add(this.txtReturnedStatus);
            this.groupReturnDetails.Controls.Add(this.txtReturnedProduct);
            this.groupReturnDetails.Controls.Add(this.cmbReturnedWarehouse);
            this.groupReturnDetails.Controls.Add(this.label41);
            this.groupReturnDetails.Controls.Add(this.label42);
            this.groupReturnDetails.Controls.Add(this.txtReturnedRemarks);
            this.groupReturnDetails.Controls.Add(this.cmbReturnedBranch);
            this.groupReturnDetails.Controls.Add(this.label44);
            this.groupReturnDetails.Controls.Add(this.label49);
            this.groupReturnDetails.Controls.Add(this.txtReturnedQty);
            this.groupReturnDetails.Controls.Add(this.label50);
            this.groupReturnDetails.Controls.Add(this.label51);
            this.groupReturnDetails.Controls.Add(this.dkpReturedDate);
            this.groupReturnDetails.Controls.Add(this.label52);
            this.groupReturnDetails.Controls.Add(this.txtReturnedDelivery);
            this.groupReturnDetails.Controls.Add(this.label53);
            this.groupReturnDetails.Controls.Add(this.label54);
            this.groupReturnDetails.Controls.Add(this.txtReturnedCode);
            this.groupReturnDetails.Controls.Add(this.label55);
            this.groupReturnDetails.Controls.Add(this.txtReturnedId);
            this.groupReturnDetails.Controls.Add(this.imgReturn);
            this.groupReturnDetails.Controls.Add(this.groupReturn);
            this.groupReturnDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupReturnDetails.Location = new System.Drawing.Point(0, 0);
            this.groupReturnDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupReturnDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupReturnDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupReturnDetails.Name = "groupReturnDetails";
            this.groupReturnDetails.Size = new System.Drawing.Size(1475, 884);
            this.groupReturnDetails.TabIndex = 176;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.White;
            this.label40.Location = new System.Drawing.Point(563, 114);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(102, 23);
            this.label40.TabIndex = 290;
            this.label40.Text = "Update On:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(716, 105);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(357, 34);
            this.dateTimePicker1.TabIndex = 289;
            // 
            // txtReturnedStatus
            // 
            this.txtReturnedStatus.BackColor = System.Drawing.Color.DimGray;
            this.txtReturnedStatus.Enabled = false;
            this.txtReturnedStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedStatus.ForeColor = System.Drawing.Color.Maroon;
            this.txtReturnedStatus.Location = new System.Drawing.Point(168, 288);
            this.txtReturnedStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnedStatus.Name = "txtReturnedStatus";
            this.txtReturnedStatus.Size = new System.Drawing.Size(357, 34);
            this.txtReturnedStatus.TabIndex = 276;
            // 
            // txtReturnedProduct
            // 
            this.txtReturnedProduct.BackColor = System.Drawing.Color.DimGray;
            this.txtReturnedProduct.Enabled = false;
            this.txtReturnedProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedProduct.ForeColor = System.Drawing.Color.Maroon;
            this.txtReturnedProduct.Location = new System.Drawing.Point(168, 103);
            this.txtReturnedProduct.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnedProduct.Name = "txtReturnedProduct";
            this.txtReturnedProduct.Size = new System.Drawing.Size(357, 34);
            this.txtReturnedProduct.TabIndex = 271;
            // 
            // cmbReturnedWarehouse
            // 
            this.cmbReturnedWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReturnedWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReturnedWarehouse.BackColor = System.Drawing.Color.DimGray;
            this.cmbReturnedWarehouse.Enabled = false;
            this.cmbReturnedWarehouse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReturnedWarehouse.ForeColor = System.Drawing.Color.Maroon;
            this.cmbReturnedWarehouse.FormattingEnabled = true;
            this.cmbReturnedWarehouse.Location = new System.Drawing.Point(167, 251);
            this.cmbReturnedWarehouse.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReturnedWarehouse.Name = "cmbReturnedWarehouse";
            this.cmbReturnedWarehouse.Size = new System.Drawing.Size(358, 36);
            this.cmbReturnedWarehouse.TabIndex = 275;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(15, 258);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(93, 23);
            this.label41.TabIndex = 288;
            this.label41.Text = "To Branch:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(563, 37);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(84, 23);
            this.label42.TabIndex = 287;
            this.label42.Text = "Remarks:";
            // 
            // txtReturnedRemarks
            // 
            this.txtReturnedRemarks.BackColor = System.Drawing.Color.DimGray;
            this.txtReturnedRemarks.Enabled = false;
            this.txtReturnedRemarks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedRemarks.ForeColor = System.Drawing.Color.Maroon;
            this.txtReturnedRemarks.Location = new System.Drawing.Point(716, 28);
            this.txtReturnedRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnedRemarks.Name = "txtReturnedRemarks";
            this.txtReturnedRemarks.Size = new System.Drawing.Size(357, 34);
            this.txtReturnedRemarks.TabIndex = 277;
            // 
            // cmbReturnedBranch
            // 
            this.cmbReturnedBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReturnedBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReturnedBranch.BackColor = System.Drawing.Color.DimGray;
            this.cmbReturnedBranch.Enabled = false;
            this.cmbReturnedBranch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReturnedBranch.ForeColor = System.Drawing.Color.Maroon;
            this.cmbReturnedBranch.FormattingEnabled = true;
            this.cmbReturnedBranch.Location = new System.Drawing.Point(167, 214);
            this.cmbReturnedBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReturnedBranch.Name = "cmbReturnedBranch";
            this.cmbReturnedBranch.Size = new System.Drawing.Size(358, 36);
            this.cmbReturnedBranch.TabIndex = 274;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.White;
            this.label44.Location = new System.Drawing.Point(15, 222);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(117, 23);
            this.label44.TabIndex = 286;
            this.label44.Text = "From Branch:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.White;
            this.label49.Location = new System.Drawing.Point(15, 185);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(103, 23);
            this.label49.TabIndex = 285;
            this.label49.Text = "Return Qty:";
            // 
            // txtReturnedQty
            // 
            this.txtReturnedQty.BackColor = System.Drawing.Color.DimGray;
            this.txtReturnedQty.Enabled = false;
            this.txtReturnedQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtReturnedQty.Location = new System.Drawing.Point(168, 177);
            this.txtReturnedQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnedQty.Name = "txtReturnedQty";
            this.txtReturnedQty.Size = new System.Drawing.Size(357, 34);
            this.txtReturnedQty.TabIndex = 273;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Transparent;
            this.label50.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.White;
            this.label50.Location = new System.Drawing.Point(15, 295);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(133, 23);
            this.label50.TabIndex = 284;
            this.label50.Text = "Product Status:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Transparent;
            this.label51.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.White;
            this.label51.Location = new System.Drawing.Point(563, 76);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(112, 23);
            this.label51.TabIndex = 283;
            this.label51.Text = "Return Date:";
            // 
            // dkpReturedDate
            // 
            this.dkpReturedDate.CustomFormat = "dd-MM-yyyy";
            this.dkpReturedDate.Enabled = false;
            this.dkpReturedDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpReturedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpReturedDate.Location = new System.Drawing.Point(716, 66);
            this.dkpReturedDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpReturedDate.Name = "dkpReturedDate";
            this.dkpReturedDate.Size = new System.Drawing.Size(357, 34);
            this.dkpReturedDate.TabIndex = 278;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.White;
            this.label52.Location = new System.Drawing.Point(15, 111);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(130, 23);
            this.label52.TabIndex = 282;
            this.label52.Text = "Product Name:";
            // 
            // txtReturnedDelivery
            // 
            this.txtReturnedDelivery.BackColor = System.Drawing.Color.DimGray;
            this.txtReturnedDelivery.Enabled = false;
            this.txtReturnedDelivery.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedDelivery.ForeColor = System.Drawing.Color.Maroon;
            this.txtReturnedDelivery.Location = new System.Drawing.Point(168, 140);
            this.txtReturnedDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnedDelivery.Name = "txtReturnedDelivery";
            this.txtReturnedDelivery.Size = new System.Drawing.Size(357, 34);
            this.txtReturnedDelivery.TabIndex = 272;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.White;
            this.label53.Location = new System.Drawing.Point(15, 148);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(141, 23);
            this.label53.TabIndex = 281;
            this.label53.Text = "Return Delivery:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.White;
            this.label54.Location = new System.Drawing.Point(15, 74);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(115, 23);
            this.label54.TabIndex = 280;
            this.label54.Text = "Return Code:";
            // 
            // txtReturnedCode
            // 
            this.txtReturnedCode.BackColor = System.Drawing.Color.DimGray;
            this.txtReturnedCode.Enabled = false;
            this.txtReturnedCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedCode.ForeColor = System.Drawing.Color.Maroon;
            this.txtReturnedCode.Location = new System.Drawing.Point(168, 66);
            this.txtReturnedCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnedCode.Name = "txtReturnedCode";
            this.txtReturnedCode.Size = new System.Drawing.Size(357, 34);
            this.txtReturnedCode.TabIndex = 270;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.White;
            this.label55.Location = new System.Drawing.Point(15, 37);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(90, 23);
            this.label55.TabIndex = 279;
            this.label55.Text = "Return Id:";
            // 
            // txtReturnedId
            // 
            this.txtReturnedId.BackColor = System.Drawing.Color.DimGray;
            this.txtReturnedId.Enabled = false;
            this.txtReturnedId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnedId.ForeColor = System.Drawing.Color.Maroon;
            this.txtReturnedId.Location = new System.Drawing.Point(168, 30);
            this.txtReturnedId.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnedId.Name = "txtReturnedId";
            this.txtReturnedId.Size = new System.Drawing.Size(357, 34);
            this.txtReturnedId.TabIndex = 269;
            // 
            // imgReturn
            // 
            this.imgReturn.BackColor = System.Drawing.Color.Gray;
            this.imgReturn.Location = new System.Drawing.Point(1092, 21);
            this.imgReturn.Margin = new System.Windows.Forms.Padding(4);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(380, 314);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgReturn.TabIndex = 225;
            this.imgReturn.TabStop = false;
            // 
            // groupReturn
            // 
            this.groupReturn.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupReturn.Appearance.Options.UseBackColor = true;
            this.groupReturn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupReturn.Controls.Add(this.gridControlReturn);
            this.groupReturn.Controls.Add(this.textBox2);
            this.groupReturn.Location = new System.Drawing.Point(-1, 332);
            this.groupReturn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupReturn.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupReturn.Margin = new System.Windows.Forms.Padding(4);
            this.groupReturn.Name = "groupReturn";
            this.groupReturn.Size = new System.Drawing.Size(1477, 546);
            this.groupReturn.TabIndex = 173;
            this.groupReturn.Text = "List of Stock Return to Warehouse";
            // 
            // gridControlReturn
            // 
            this.gridControlReturn.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlReturn.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridControlReturn.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControlReturn.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridControlReturn.Location = new System.Drawing.Point(3, 21);
            this.gridControlReturn.MainView = this.gridReturn;
            this.gridControlReturn.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlReturn.Name = "gridControlReturn";
            this.gridControlReturn.Size = new System.Drawing.Size(1471, 522);
            this.gridControlReturn.TabIndex = 26;
            this.gridControlReturn.TabStop = false;
            this.gridControlReturn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridReturn,
            this.gridView8,
            this.gridView9,
            this.gridView10});
            // 
            // gridReturn
            // 
            this.gridReturn.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridReturn.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridReturn.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridReturn.Appearance.Empty.Options.UseBackColor = true;
            this.gridReturn.Appearance.Empty.Options.UseBorderColor = true;
            this.gridReturn.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridReturn.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridReturn.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridReturn.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridReturn.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridReturn.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridReturn.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridReturn.Appearance.FocusedRow.Options.UseFont = true;
            this.gridReturn.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridReturn.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridReturn.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridReturn.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gridReturn.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridReturn.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridReturn.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridReturn.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridReturn.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridReturn.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridReturn.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridReturn.Appearance.Row.Options.UseBackColor = true;
            this.gridReturn.Appearance.Row.Options.UseBorderColor = true;
            this.gridReturn.Appearance.Row.Options.UseFont = true;
            this.gridReturn.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridReturn.Appearance.ViewCaption.Options.UseFont = true;
            this.gridReturn.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridReturn.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridReturn.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridReturn.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridReturn.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridReturn.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridReturn.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridReturn.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridReturn.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridReturn.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridReturn.AppearancePrint.Row.Options.UseFont = true;
            this.gridReturn.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridReturn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridReturn.DetailHeight = 431;
            this.gridReturn.GridControl = this.gridControlReturn;
            this.gridReturn.Name = "gridReturn";
            this.gridReturn.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridReturn.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridReturn.OptionsBehavior.Editable = false;
            this.gridReturn.OptionsCustomization.AllowRowSizing = true;
            this.gridReturn.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridReturn.OptionsSelection.MultiSelect = true;
            this.gridReturn.OptionsView.EnableAppearanceEvenRow = true;
            this.gridReturn.OptionsView.RowAutoHeight = true;
            this.gridReturn.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridReturn.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridReturn_RowClick);
            this.gridReturn.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridReturn_FocusedRowChanged);
            this.gridReturn.LostFocus += new System.EventHandler(this.GridReturn_LostFocus);
            // 
            // gridView8
            // 
            this.gridView8.DetailHeight = 431;
            this.gridView8.GridControl = this.gridControlReturn;
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
            this.gridView9.GridControl = this.gridControlReturn;
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
            this.gridView10.GridControl = this.gridControlReturn;
            this.gridView10.Name = "gridView10";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DimGray;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Maroon;
            this.textBox2.Location = new System.Drawing.Point(-11, 26);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(12, 11);
            this.textBox2.TabIndex = 99;
            this.textBox2.Visible = false;
            // 
            // xtraSales
            // 
            this.xtraSales.Appearance.PageClient.BackColor = System.Drawing.Color.BurlyWood;
            this.xtraSales.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraSales.Controls.Add(this.groupSalesDetails);
            this.xtraSales.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraSales.ImageOptions.Image")));
            this.xtraSales.Margin = new System.Windows.Forms.Padding(4);
            this.xtraSales.Name = "xtraSales";
            this.xtraSales.Size = new System.Drawing.Size(1475, 884);
            this.xtraSales.Text = "Sales History";
            // 
            // groupSalesDetails
            // 
            this.groupSalesDetails.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupSalesDetails.Appearance.Options.UseBackColor = true;
            this.groupSalesDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupSalesDetails.Controls.Add(this.txtBranchName);
            this.groupSalesDetails.Controls.Add(this.label34);
            this.groupSalesDetails.Controls.Add(this.txtCustomerName);
            this.groupSalesDetails.Controls.Add(this.label39);
            this.groupSalesDetails.Controls.Add(this.label33);
            this.groupSalesDetails.Controls.Add(this.dkpSalesDate);
            this.groupSalesDetails.Controls.Add(this.txtSalesBarcode);
            this.groupSalesDetails.Controls.Add(this.txtNetSales);
            this.groupSalesDetails.Controls.Add(this.label35);
            this.groupSalesDetails.Controls.Add(this.label36);
            this.groupSalesDetails.Controls.Add(this.txtGrossSales);
            this.groupSalesDetails.Controls.Add(this.label37);
            this.groupSalesDetails.Controls.Add(this.txtSalesQty);
            this.groupSalesDetails.Controls.Add(this.label38);
            this.groupSalesDetails.Controls.Add(this.txtSalesInvoice);
            this.groupSalesDetails.Controls.Add(this.label43);
            this.groupSalesDetails.Controls.Add(this.label45);
            this.groupSalesDetails.Controls.Add(this.txtSalesDiscount);
            this.groupSalesDetails.Controls.Add(this.txtItemName);
            this.groupSalesDetails.Controls.Add(this.label46);
            this.groupSalesDetails.Controls.Add(this.label47);
            this.groupSalesDetails.Controls.Add(this.txtSalesPrice);
            this.groupSalesDetails.Controls.Add(this.label48);
            this.groupSalesDetails.Controls.Add(this.txtSalesId);
            this.groupSalesDetails.Controls.Add(this.imgSales);
            this.groupSalesDetails.Controls.Add(this.groupSales);
            this.groupSalesDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSalesDetails.Location = new System.Drawing.Point(0, 0);
            this.groupSalesDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSalesDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSalesDetails.Margin = new System.Windows.Forms.Padding(4);
            this.groupSalesDetails.Name = "groupSalesDetails";
            this.groupSalesDetails.Size = new System.Drawing.Size(1475, 884);
            this.groupSalesDetails.TabIndex = 175;
            // 
            // txtBranchName
            // 
            this.txtBranchName.BackColor = System.Drawing.Color.DimGray;
            this.txtBranchName.Enabled = false;
            this.txtBranchName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchName.ForeColor = System.Drawing.Color.Maroon;
            this.txtBranchName.Location = new System.Drawing.Point(720, 106);
            this.txtBranchName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(357, 34);
            this.txtBranchName.TabIndex = 337;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(549, 113);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(70, 23);
            this.label34.TabIndex = 338;
            this.label34.Text = "Branch:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.DimGray;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.ForeColor = System.Drawing.Color.Maroon;
            this.txtCustomerName.Location = new System.Drawing.Point(171, 290);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(357, 34);
            this.txtCustomerName.TabIndex = 335;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(15, 298);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(144, 23);
            this.label39.TabIndex = 336;
            this.label39.Text = "Customer Name:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(549, 150);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(98, 23);
            this.label33.TabIndex = 334;
            this.label33.Text = "Sales Date:";
            // 
            // dkpSalesDate
            // 
            this.dkpSalesDate.CustomFormat = "dd-MM-yyyy";
            this.dkpSalesDate.Enabled = false;
            this.dkpSalesDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpSalesDate.Location = new System.Drawing.Point(720, 143);
            this.dkpSalesDate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpSalesDate.Name = "dkpSalesDate";
            this.dkpSalesDate.Size = new System.Drawing.Size(357, 34);
            this.dkpSalesDate.TabIndex = 333;
            // 
            // txtSalesBarcode
            // 
            this.txtSalesBarcode.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesBarcode.Enabled = false;
            this.txtSalesBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesBarcode.Location = new System.Drawing.Point(171, 106);
            this.txtSalesBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesBarcode.Name = "txtSalesBarcode";
            this.txtSalesBarcode.Size = new System.Drawing.Size(357, 34);
            this.txtSalesBarcode.TabIndex = 305;
            // 
            // txtNetSales
            // 
            this.txtNetSales.BackColor = System.Drawing.Color.DimGray;
            this.txtNetSales.Enabled = false;
            this.txtNetSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetSales.ForeColor = System.Drawing.Color.Maroon;
            this.txtNetSales.Location = new System.Drawing.Point(720, 69);
            this.txtNetSales.Margin = new System.Windows.Forms.Padding(4);
            this.txtNetSales.Name = "txtNetSales";
            this.txtNetSales.Size = new System.Drawing.Size(357, 34);
            this.txtNetSales.TabIndex = 311;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(549, 76);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(89, 23);
            this.label35.TabIndex = 331;
            this.label35.Text = "Net Sales:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(549, 39);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(103, 23);
            this.label36.TabIndex = 330;
            this.label36.Text = "Gross Sales:";
            // 
            // txtGrossSales
            // 
            this.txtGrossSales.BackColor = System.Drawing.Color.DimGray;
            this.txtGrossSales.Enabled = false;
            this.txtGrossSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossSales.ForeColor = System.Drawing.Color.Maroon;
            this.txtGrossSales.Location = new System.Drawing.Point(720, 32);
            this.txtGrossSales.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrossSales.Name = "txtGrossSales";
            this.txtGrossSales.Size = new System.Drawing.Size(357, 34);
            this.txtGrossSales.TabIndex = 308;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(15, 187);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(127, 23);
            this.label37.TabIndex = 329;
            this.label37.Text = "Item Quantity:";
            // 
            // txtSalesQty
            // 
            this.txtSalesQty.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesQty.Enabled = false;
            this.txtSalesQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesQty.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesQty.Location = new System.Drawing.Point(171, 180);
            this.txtSalesQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesQty.Name = "txtSalesQty";
            this.txtSalesQty.Size = new System.Drawing.Size(357, 34);
            this.txtSalesQty.TabIndex = 307;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(15, 76);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(92, 23);
            this.label38.TabIndex = 328;
            this.label38.Text = "Invoice Id:";
            // 
            // txtSalesInvoice
            // 
            this.txtSalesInvoice.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesInvoice.Enabled = false;
            this.txtSalesInvoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesInvoice.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesInvoice.Location = new System.Drawing.Point(171, 69);
            this.txtSalesInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesInvoice.Name = "txtSalesInvoice";
            this.txtSalesInvoice.Size = new System.Drawing.Size(357, 34);
            this.txtSalesInvoice.TabIndex = 325;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(15, 261);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(127, 23);
            this.label43.TabIndex = 318;
            this.label43.Text = "Item Discount:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(15, 113);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(80, 23);
            this.label45.TabIndex = 316;
            this.label45.Text = "Barcode:";
            // 
            // txtSalesDiscount
            // 
            this.txtSalesDiscount.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesDiscount.Enabled = false;
            this.txtSalesDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesDiscount.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesDiscount.Location = new System.Drawing.Point(171, 254);
            this.txtSalesDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesDiscount.Name = "txtSalesDiscount";
            this.txtSalesDiscount.Size = new System.Drawing.Size(357, 34);
            this.txtSalesDiscount.TabIndex = 322;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.DimGray;
            this.txtItemName.Enabled = false;
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.ForeColor = System.Drawing.Color.Maroon;
            this.txtItemName.Location = new System.Drawing.Point(171, 143);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(357, 34);
            this.txtItemName.TabIndex = 306;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(15, 150);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(104, 23);
            this.label46.TabIndex = 315;
            this.label46.Text = "Item Name:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.Transparent;
            this.label47.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.White;
            this.label47.Location = new System.Drawing.Point(15, 224);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(93, 23);
            this.label47.TabIndex = 314;
            this.label47.Text = "Unit Price:";
            // 
            // txtSalesPrice
            // 
            this.txtSalesPrice.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesPrice.Enabled = false;
            this.txtSalesPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesPrice.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesPrice.Location = new System.Drawing.Point(171, 217);
            this.txtSalesPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesPrice.Name = "txtSalesPrice";
            this.txtSalesPrice.Size = new System.Drawing.Size(357, 34);
            this.txtSalesPrice.TabIndex = 303;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.White;
            this.label48.Location = new System.Drawing.Point(15, 39);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(76, 23);
            this.label48.TabIndex = 313;
            this.label48.Text = "Sales Id:";
            // 
            // txtSalesId
            // 
            this.txtSalesId.BackColor = System.Drawing.Color.DimGray;
            this.txtSalesId.Enabled = false;
            this.txtSalesId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesId.ForeColor = System.Drawing.Color.Maroon;
            this.txtSalesId.Location = new System.Drawing.Point(171, 32);
            this.txtSalesId.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(357, 34);
            this.txtSalesId.TabIndex = 312;
            // 
            // imgSales
            // 
            this.imgSales.BackColor = System.Drawing.Color.Gray;
            this.imgSales.Location = new System.Drawing.Point(1091, 26);
            this.imgSales.Margin = new System.Windows.Forms.Padding(4);
            this.imgSales.Name = "imgSales";
            this.imgSales.Size = new System.Drawing.Size(380, 304);
            this.imgSales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSales.TabIndex = 225;
            this.imgSales.TabStop = false;
            // 
            // groupSales
            // 
            this.groupSales.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupSales.Appearance.Options.UseBackColor = true;
            this.groupSales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupSales.Controls.Add(this.gridControlSales);
            this.groupSales.Location = new System.Drawing.Point(-1, 332);
            this.groupSales.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupSales.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupSales.Margin = new System.Windows.Forms.Padding(4);
            this.groupSales.Name = "groupSales";
            this.groupSales.Size = new System.Drawing.Size(1477, 546);
            this.groupSales.TabIndex = 173;
            this.groupSales.Text = "List of Item Sold";
            // 
            // gridControlSales
            // 
            this.gridControlSales.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSales.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridControlSales.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControlSales.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlSales.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridControlSales.Location = new System.Drawing.Point(3, 21);
            this.gridControlSales.MainView = this.gridSales;
            this.gridControlSales.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlSales.Name = "gridControlSales";
            this.gridControlSales.Size = new System.Drawing.Size(1471, 522);
            this.gridControlSales.TabIndex = 26;
            this.gridControlSales.TabStop = false;
            this.gridControlSales.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSales,
            this.gridView12,
            this.gridView13,
            this.gridView14});
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
            this.gridSales.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridSales.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridSales.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridSales.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridSales.Appearance.FocusedRow.Options.UseFont = true;
            this.gridSales.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridSales.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridSales.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSales.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
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
            this.gridSales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridSales.DetailHeight = 431;
            this.gridSales.GridControl = this.gridControlSales;
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
            this.gridSales.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridSales_RowClick);
            this.gridSales.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridSales_FocusedRowChanged);
            this.gridSales.LostFocus += new System.EventHandler(this.GridSales_LostFocus);
            // 
            // gridView12
            // 
            this.gridView12.DetailHeight = 431;
            this.gridView12.GridControl = this.gridControlSales;
            this.gridView12.Name = "gridView12";
            // 
            // gridView13
            // 
            this.gridView13.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView13.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridView13.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.gridView13.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Green;
            this.gridView13.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView13.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView13.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView13.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView13.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView13.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridView13.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridView13.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView13.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView13.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView13.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView13.Appearance.Row.Options.UseFont = true;
            this.gridView13.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridView13.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView13.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView13.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridView13.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridView13.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridView13.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView13.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView13.AppearancePrint.Row.Options.UseFont = true;
            this.gridView13.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridView13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.gridView13.DetailHeight = 431;
            this.gridView13.GridControl = this.gridControlSales;
            this.gridView13.Name = "gridView13";
            this.gridView13.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView13.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView13.OptionsBehavior.Editable = false;
            this.gridView13.OptionsBehavior.ReadOnly = true;
            this.gridView13.OptionsCustomization.AllowRowSizing = true;
            this.gridView13.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView13.OptionsSelection.MultiSelect = true;
            this.gridView13.OptionsView.ColumnAutoWidth = false;
            // 
            // gridView14
            // 
            this.gridView14.DetailHeight = 431;
            this.gridView14.GridControl = this.gridControlSales;
            this.gridView14.Name = "gridView14";
            // 
            // bntClear
            // 
            this.bntClear.BackColor = System.Drawing.Color.Firebrick;
            this.bntClear.Enabled = false;
            this.bntClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntClear.ForeColor = System.Drawing.Color.White;
            this.bntClear.Image = ((System.Drawing.Image)(resources.GetObject("bntClear.Image")));
            this.bntClear.Location = new System.Drawing.Point(5, 526);
            this.bntClear.Margin = new System.Windows.Forms.Padding(4);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(121, 128);
            this.bntClear.TabIndex = 132;
            this.bntClear.Text = "CLEAR";
            this.bntClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntClear.UseVisualStyleBackColor = false;
            this.bntClear.Click += new System.EventHandler(this.bntClear_Click);
            // 
            // bntCancel
            // 
            this.bntCancel.BackColor = System.Drawing.Color.DimGray;
            this.bntCancel.Enabled = false;
            this.bntCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCancel.ForeColor = System.Drawing.Color.White;
            this.bntCancel.Image = ((System.Drawing.Image)(resources.GetObject("bntCancel.Image")));
            this.bntCancel.Location = new System.Drawing.Point(128, 526);
            this.bntCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(121, 128);
            this.bntCancel.TabIndex = 133;
            this.bntCancel.Text = "CANCEL";
            this.bntCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntCancel.UseVisualStyleBackColor = false;
            this.bntCancel.Click += new System.EventHandler(this.bntCancel_Click);
            // 
            // bntSave
            // 
            this.bntSave.BackColor = System.Drawing.Color.Fuchsia;
            this.bntSave.Enabled = false;
            this.bntSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSave.ForeColor = System.Drawing.Color.White;
            this.bntSave.Image = ((System.Drawing.Image)(resources.GetObject("bntSave.Image")));
            this.bntSave.Location = new System.Drawing.Point(5, 396);
            this.bntSave.Margin = new System.Windows.Forms.Padding(4);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(244, 128);
            this.bntSave.TabIndex = 129;
            this.bntSave.Text = "SAVE";
            this.bntSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntSave.UseVisualStyleBackColor = false;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // bntUpdate
            // 
            this.bntUpdate.BackColor = System.Drawing.Color.Blue;
            this.bntUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntUpdate.ForeColor = System.Drawing.Color.White;
            this.bntUpdate.Image = ((System.Drawing.Image)(resources.GetObject("bntUpdate.Image")));
            this.bntUpdate.Location = new System.Drawing.Point(128, 267);
            this.bntUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.Size = new System.Drawing.Size(121, 128);
            this.bntUpdate.TabIndex = 131;
            this.bntUpdate.Text = "EDIT";
            this.bntUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntUpdate.UseVisualStyleBackColor = false;
            this.bntUpdate.Click += new System.EventHandler(this.bntUpdate_Click);
            // 
            // bntHome
            // 
            this.bntHome.BackColor = System.Drawing.Color.ForestGreen;
            this.bntHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntHome.ForeColor = System.Drawing.Color.White;
            this.bntHome.Image = ((System.Drawing.Image)(resources.GetObject("bntHome.Image")));
            this.bntHome.Location = new System.Drawing.Point(128, 655);
            this.bntHome.Margin = new System.Windows.Forms.Padding(4);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(121, 128);
            this.bntHome.TabIndex = 135;
            this.bntHome.Text = "HOME";
            this.bntHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntHome.UseVisualStyleBackColor = false;
            this.bntHome.Click += new System.EventHandler(this.bntHome_Click);
            // 
            // bntDelete
            // 
            this.bntDelete.BackColor = System.Drawing.Color.DarkOrange;
            this.bntDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntDelete.ForeColor = System.Drawing.Color.White;
            this.bntDelete.Image = ((System.Drawing.Image)(resources.GetObject("bntDelete.Image")));
            this.bntDelete.Location = new System.Drawing.Point(5, 655);
            this.bntDelete.Margin = new System.Windows.Forms.Padding(4);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(121, 128);
            this.bntDelete.TabIndex = 134;
            this.bntDelete.Text = "DELETE";
            this.bntDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntDelete.UseVisualStyleBackColor = false;
            this.bntDelete.Click += new System.EventHandler(this.bntDelete_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(-5, 204);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(256, 60);
            this.lblMainTitle.TabIndex = 136;
            this.lblMainTitle.Text = "Warehouse";
            // 
            // RightOptions
            // 
            this.RightOptions.Interval = 1;
            this.RightOptions.Tick += new System.EventHandler(this.RightOptions_Tick);
            // 
            // Options
            // 
            this.Options.Interval = 1;
            this.Options.Tick += new System.EventHandler(this.Options_Tick);
            // 
            // FirmWarehouseInvetory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlRightOptions);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FirmWarehouseInvetory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse Inventory";
            this.Load += new System.EventHandler(this.FirmWarehouseInvetory_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FirmWarehouseInvetory_MouseMove);
            this.pnlRightOptions.ResumeLayout(false);
            this.pnlRightMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptionsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChangePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xInventory)).EndInit();
            this.xInventory.ResumeLayout(false);
            this.xtraInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupInventoryDetail)).EndInit();
            this.groupInventoryDetail.ResumeLayout(false);
            this.groupInventoryDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInventory)).EndInit();
            this.groupInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHIS)).EndInit();
            this.xtraDelivery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupDeliveryDetails)).EndInit();
            this.groupDeliveryDetails.ResumeLayout(false);
            this.groupDeliveryDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDelivery)).EndInit();
            this.groupDelivery.ResumeLayout(false);
            this.groupDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            this.xtraReturn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupReturnDetails)).EndInit();
            this.groupReturnDetails.ResumeLayout(false);
            this.groupReturnDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupReturn)).EndInit();
            this.groupReturn.ResumeLayout(false);
            this.groupReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            this.xtraSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupSalesDetails)).EndInit();
            this.groupSalesDetails.ResumeLayout(false);
            this.groupSalesDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSales)).EndInit();
            this.groupSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView14)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Panel pnlRightOptions;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.PictureBox pbLogout;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Panel pnlOptionsMain;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pcSettings;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pcSchedule;
        private System.Windows.Forms.PictureBox pcBL;
        private System.Windows.Forms.PictureBox pcList;
        private System.Windows.Forms.PictureBox pcUser;
        private System.Windows.Forms.PictureBox pcAdd;
        private System.Windows.Forms.PictureBox pcChangePassword;
        private System.Windows.Forms.PictureBox pbHide;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bntAdd;
        private DevExpress.XtraTab.XtraTabControl xInventory;
        private DevExpress.XtraTab.XtraTabPage xtraInventory;
        private DevExpress.XtraEditors.GroupControl groupInventoryDetail;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dpkLastUpdated;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dpkCreatedDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dpkExpirationDate;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCostPerUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.PictureBox imgInventory;
        private System.Windows.Forms.ComboBox cmbItemLocation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dkpLastOrderDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Label lblHiredate;
        private System.Windows.Forms.DateTimePicker dkpLastStockedDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLastCostPerUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReorderLevel;
        private System.Windows.Forms.TextBox txtQuantityStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWarehouseSKU;
        private DevExpress.XtraEditors.GroupControl groupInventory;
        private DevExpress.XtraGrid.GridControl gridController;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView grdHIS;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtInventoryId;
        private DevExpress.XtraTab.XtraTabPage xtraDelivery;
        private DevExpress.XtraEditors.GroupControl groupDeliveryDetails;
        private DevExpress.XtraTab.XtraTabPage xtraSales;
        private DevExpress.XtraEditors.GroupControl groupSalesDetails;
        private System.Windows.Forms.Button bntClear;
        private System.Windows.Forms.Button bntCancel;
        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.Button bntUpdate;
        private System.Windows.Forms.Button bntHome;
        private System.Windows.Forms.Button bntDelete;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Timer RightOptions;
        private System.Windows.Forms.Timer Options;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBarcode;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private DevExpress.XtraTab.XtraTabPage xtraReturn;
        private DevExpress.XtraEditors.GroupControl groupDelivery;
        private DevExpress.XtraGrid.GridControl gridControlDelivery;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDelivery;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.GroupControl groupReturnDetails;
        private DevExpress.XtraEditors.GroupControl groupReturn;
        private DevExpress.XtraGrid.GridControl gridControlReturn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridReturn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.XtraEditors.GroupControl groupSales;
        private DevExpress.XtraGrid.GridControl gridControlSales;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSales;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView12;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView13;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView14;
        private System.Windows.Forms.PictureBox imgDelivery;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.PictureBox imgSales;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dkpDelUpdate;
        private System.Windows.Forms.TextBox txtDelProductName;
        private System.Windows.Forms.ComboBox cmbDelWarehouseCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDelDeliveryStatus;
        private System.Windows.Forms.TextBox txtDelRemarks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDelRemainQty;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDelQty;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDelItemPrice;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDelProduct;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbDelProductStatus;
        private System.Windows.Forms.ComboBox cmbDelBranch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker dkpDelDeliveryDate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtDelReceipt;
        private System.Windows.Forms.TextBox txtDelLastCost;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtDelWarehouseCode;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtDelWarehouseId;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DateTimePicker dkpSalesDate;
        private System.Windows.Forms.TextBox txtSalesBarcode;
        private System.Windows.Forms.TextBox txtNetSales;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtGrossSales;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtSalesQty;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtSalesInvoice;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtSalesDiscount;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtReturnedStatus;
        private System.Windows.Forms.TextBox txtReturnedProduct;
        private System.Windows.Forms.ComboBox cmbReturnedWarehouse;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtReturnedRemarks;
        private System.Windows.Forms.ComboBox cmbReturnedBranch;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox txtReturnedQty;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.DateTimePicker dkpReturedDate;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtReturnedDelivery;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtReturnedCode;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox txtReturnedId;
    }
}