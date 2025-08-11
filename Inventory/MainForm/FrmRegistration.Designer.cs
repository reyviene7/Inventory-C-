using System.Drawing;

namespace Inventory.MainForm
{
    partial class FrmRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistration));
            this.splashManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pcLOG = new System.Windows.Forms.PictureBox();
            this.xtraControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraProfile = new DevExpress.XtraTab.XtraTabPage();
            this.GbPersonal = new DevExpress.XtraEditors.GroupControl();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dkpDateRegistered = new System.Windows.Forms.DateTimePicker();
            this.gbCON = new DevExpress.XtraEditors.GroupControl();
            this.gridCtlProfile = new DevExpress.XtraGrid.GridControl();
            this.gridProfile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdHIS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblHiredate = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.dkpDateHired = new System.Windows.Forms.DateTimePicker();
            this.lblPostion = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtProfileID = new System.Windows.Forms.TextBox();
            this.lblCivilStatus = new System.Windows.Forms.Label();
            this.cmbCivilStatus = new System.Windows.Forms.ComboBox();
            this.imgProfile = new System.Windows.Forms.PictureBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhilhealthNumber = new System.Windows.Forms.TextBox();
            this.lblPhilhealth = new System.Windows.Forms.Label();
            this.cmbProvince = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSSSNumber = new System.Windows.Forms.TextBox();
            this.lblSSS = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblProvicen = new System.Windows.Forms.Label();
            this.lblDatebirth = new System.Windows.Forms.Label();
            this.dkpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbgender = new System.Windows.Forms.ComboBox();
            this.txtMiddleInitial = new System.Windows.Forms.TextBox();
            this.lblMiddleInitial = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFName = new System.Windows.Forms.Label();
            this.txtPIR = new System.Windows.Forms.TextBox();
            this.xtraAddress = new DevExpress.XtraTab.XtraTabPage();
            this.groupAddress = new DevExpress.XtraEditors.GroupControl();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBarcodeAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddressID = new System.Windows.Forms.TextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlAddress = new DevExpress.XtraGrid.GridControl();
            this.gridAddress = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarangay = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dkpDateRegister = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.ComboBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.xtraContact = new DevExpress.XtraTab.XtraTabPage();
            this.groupContact = new DevExpress.XtraEditors.GroupControl();
            this.label17 = new System.Windows.Forms.Label();
            this.txtContactBarcode = new System.Windows.Forms.TextBox();
            this.txtFaxNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtWebUrl = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSecondMobile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactId = new System.Windows.Forms.TextBox();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlContact = new DevExpress.XtraGrid.GridControl();
            this.gridContact = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dkpContactDateReg = new System.Windows.Forms.DateTimePicker();
            this.txtFirstMobile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPositionName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.xtraImage = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label20 = new System.Windows.Forms.Label();
            this.dkpImgCreadOn = new System.Windows.Forms.DateTimePicker();
            this.bntBrowseImage = new DevExpress.XtraEditors.SimpleButton();
            this.bntSaveImages = new DevExpress.XtraEditors.SimpleButton();
            this.cmbProfileImgType = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtProfileImgFileName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtProfileImgTitle = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtProfileImgBarcode = new System.Windows.Forms.TextBox();
            this.imgProfileImages = new System.Windows.Forms.PictureBox();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.bntHome = new System.Windows.Forms.Button();
            this.bntDelete = new System.Windows.Forms.Button();
            this.bntClear = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            this.bntSave = new System.Windows.Forms.Button();
            this.bntUpdate = new System.Windows.Forms.Button();
            this.bntInsert = new System.Windows.Forms.Button();
            this.pnlRightOptions = new System.Windows.Forms.Panel();
            this.pcRight = new System.Windows.Forms.PictureBox();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.pbLogout = new System.Windows.Forms.PictureBox();
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
            this.RightOptions = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLOG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraControl)).BeginInit();
            this.xtraControl.SuspendLayout();
            this.xtraProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GbPersonal)).BeginInit();
            this.GbPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).BeginInit();
            this.gbCON.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtlProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProfile)).BeginInit();
            this.xtraAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAddress)).BeginInit();
            this.groupAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtraContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupContact)).BeginInit();
            this.groupContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.xtraImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProfileImages)).BeginInit();
            this.pnlRightOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcRight)).BeginInit();
            this.pnlRightMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
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
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlMain.Controls.Add(this.pcLOG);
            this.pnlMain.Controls.Add(this.xtraControl);
            this.pnlMain.Controls.Add(this.lblMainTitle);
            this.pnlMain.Controls.Add(this.bntHome);
            this.pnlMain.Controls.Add(this.bntDelete);
            this.pnlMain.Controls.Add(this.bntClear);
            this.pnlMain.Controls.Add(this.bntCancel);
            this.pnlMain.Controls.Add(this.bntSave);
            this.pnlMain.Controls.Add(this.bntUpdate);
            this.pnlMain.Controls.Add(this.bntInsert);
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1720, 827);
            this.pnlMain.TabIndex = 63;
            // 
            // pcLOG
            // 
            this.pcLOG.BackColor = System.Drawing.Color.Gray;
            this.pcLOG.Image = ((System.Drawing.Image)(resources.GetObject("pcLOG.Image")));
            this.pcLOG.Location = new System.Drawing.Point(64, 62);
            this.pcLOG.Margin = new System.Windows.Forms.Padding(4);
            this.pcLOG.Name = "pcLOG";
            this.pcLOG.Size = new System.Drawing.Size(120, 135);
            this.pcLOG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcLOG.TabIndex = 205;
            this.pcLOG.TabStop = false;
            // 
            // xtraControl
            // 
            this.xtraControl.Location = new System.Drawing.Point(256, 39);
            this.xtraControl.Margin = new System.Windows.Forms.Padding(4);
            this.xtraControl.Name = "xtraControl";
            this.xtraControl.SelectedTabPage = this.xtraProfile;
            this.xtraControl.Size = new System.Drawing.Size(1353, 788);
            this.xtraControl.TabIndex = 1;
            this.xtraControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraProfile,
            this.xtraAddress,
            this.xtraContact,
            this.xtraImage});
            this.xtraControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraControl_SelectedPageChanged);
            // 
            // xtraProfile
            // 
            this.xtraProfile.Appearance.PageClient.BackColor = System.Drawing.Color.Black;
            this.xtraProfile.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraProfile.Controls.Add(this.GbPersonal);
            this.xtraProfile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraProfile.ImageOptions.Image")));
            this.xtraProfile.Margin = new System.Windows.Forms.Padding(4);
            this.xtraProfile.Name = "xtraProfile";
            this.xtraProfile.Size = new System.Drawing.Size(1351, 758);
            this.xtraProfile.Text = "Personal Profile";
            // 
            // GbPersonal
            // 
            this.GbPersonal.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.GbPersonal.Appearance.Options.UseBackColor = true;
            this.GbPersonal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.GbPersonal.Controls.Add(this.label14);
            this.GbPersonal.Controls.Add(this.txtBarcode);
            this.GbPersonal.Controls.Add(this.lblDept);
            this.GbPersonal.Controls.Add(this.label2);
            this.GbPersonal.Controls.Add(this.dkpDateRegistered);
            this.GbPersonal.Controls.Add(this.gbCON);
            this.GbPersonal.Controls.Add(this.lblHiredate);
            this.GbPersonal.Controls.Add(this.cmbDepartment);
            this.GbPersonal.Controls.Add(this.txtMobile);
            this.GbPersonal.Controls.Add(this.lblBarcode);
            this.GbPersonal.Controls.Add(this.lblMobile);
            this.GbPersonal.Controls.Add(this.dkpDateHired);
            this.GbPersonal.Controls.Add(this.lblPostion);
            this.GbPersonal.Controls.Add(this.lblPhone);
            this.GbPersonal.Controls.Add(this.cmbPosition);
            this.GbPersonal.Controls.Add(this.txtPhone);
            this.GbPersonal.Controls.Add(this.txtProfileID);
            this.GbPersonal.Controls.Add(this.lblCivilStatus);
            this.GbPersonal.Controls.Add(this.cmbCivilStatus);
            this.GbPersonal.Controls.Add(this.imgProfile);
            this.GbPersonal.Controls.Add(this.lblEmail);
            this.GbPersonal.Controls.Add(this.txtAddress);
            this.GbPersonal.Controls.Add(this.txtPhilhealthNumber);
            this.GbPersonal.Controls.Add(this.lblPhilhealth);
            this.GbPersonal.Controls.Add(this.cmbProvince);
            this.GbPersonal.Controls.Add(this.txtEmail);
            this.GbPersonal.Controls.Add(this.txtSSSNumber);
            this.GbPersonal.Controls.Add(this.lblSSS);
            this.GbPersonal.Controls.Add(this.lblAddress);
            this.GbPersonal.Controls.Add(this.lblProvicen);
            this.GbPersonal.Controls.Add(this.lblDatebirth);
            this.GbPersonal.Controls.Add(this.dkpBirthdate);
            this.GbPersonal.Controls.Add(this.lblGender);
            this.GbPersonal.Controls.Add(this.cmbgender);
            this.GbPersonal.Controls.Add(this.txtMiddleInitial);
            this.GbPersonal.Controls.Add(this.lblMiddleInitial);
            this.GbPersonal.Controls.Add(this.txtLastName);
            this.GbPersonal.Controls.Add(this.lblLastName);
            this.GbPersonal.Controls.Add(this.txtFirstName);
            this.GbPersonal.Controls.Add(this.lblFName);
            this.GbPersonal.Controls.Add(this.txtPIR);
            this.GbPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbPersonal.Location = new System.Drawing.Point(0, 0);
            this.GbPersonal.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.GbPersonal.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GbPersonal.Margin = new System.Windows.Forms.Padding(4);
            this.GbPersonal.Name = "GbPersonal";
            this.GbPersonal.Size = new System.Drawing.Size(1351, 758);
            this.GbPersonal.TabIndex = 173;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(4, 69);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 23);
            this.label14.TabIndex = 176;
            this.label14.Text = "Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.DimGray;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Black;
            this.txtBarcode.Location = new System.Drawing.Point(133, 62);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(356, 34);
            this.txtBarcode.TabIndex = 175;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.BackColor = System.Drawing.Color.Transparent;
            this.lblDept.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDept.ForeColor = System.Drawing.Color.White;
            this.lblDept.Location = new System.Drawing.Point(499, 255);
            this.lblDept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(113, 23);
            this.lblDept.TabIndex = 144;
            this.lblDept.Text = "Department:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(499, 332);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 174;
            this.label2.Text = "Register:";
            // 
            // dkpDateRegistered
            // 
            this.dkpDateRegistered.CustomFormat = "dd-MM-yyyy";
            this.dkpDateRegistered.Enabled = false;
            this.dkpDateRegistered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDateRegistered.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDateRegistered.Location = new System.Drawing.Point(613, 321);
            this.dkpDateRegistered.Margin = new System.Windows.Forms.Padding(4);
            this.dkpDateRegistered.Name = "dkpDateRegistered";
            this.dkpDateRegistered.Size = new System.Drawing.Size(317, 34);
            this.dkpDateRegistered.TabIndex = 19;
            this.dkpDateRegistered.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpREG_KeyDown);
            // 
            // gbCON
            // 
            this.gbCON.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbCON.Appearance.Options.UseBackColor = true;
            this.gbCON.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gbCON.Controls.Add(this.gridCtlProfile);
            this.gbCON.Location = new System.Drawing.Point(1, 394);
            this.gbCON.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gbCON.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gbCON.Margin = new System.Windows.Forms.Padding(4);
            this.gbCON.Name = "gbCON";
            this.gbCON.Size = new System.Drawing.Size(1347, 357);
            this.gbCON.TabIndex = 172;
            this.gbCON.Text = "Profile List:";
            // 
            // gridCtlProfile
            // 
            this.gridCtlProfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCtlProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtlProfile.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridCtlProfile.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridCtlProfile.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridCtlProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridCtlProfile.Location = new System.Drawing.Point(3, 21);
            this.gridCtlProfile.MainView = this.gridProfile;
            this.gridCtlProfile.Margin = new System.Windows.Forms.Padding(4);
            this.gridCtlProfile.Name = "gridCtlProfile";
            this.gridCtlProfile.Size = new System.Drawing.Size(1341, 333);
            this.gridCtlProfile.TabIndex = 101;
            this.gridCtlProfile.TabStop = false;
            this.gridCtlProfile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProfile,
            this.grdHIS});
            // 
            // gridProfile
            // 
            this.gridProfile.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridProfile.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridProfile.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridProfile.Appearance.Empty.Options.UseBackColor = true;
            this.gridProfile.Appearance.Empty.Options.UseBorderColor = true;
            this.gridProfile.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridProfile.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridProfile.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridProfile.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProfile.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridProfile.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridProfile.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridProfile.Appearance.FocusedRow.Options.UseFont = true;
            this.gridProfile.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridProfile.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridProfile.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridProfile.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gridProfile.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridProfile.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridProfile.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridProfile.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridProfile.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridProfile.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridProfile.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProfile.Appearance.Row.Options.UseBackColor = true;
            this.gridProfile.Appearance.Row.Options.UseBorderColor = true;
            this.gridProfile.Appearance.Row.Options.UseFont = true;
            this.gridProfile.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProfile.Appearance.ViewCaption.Options.UseFont = true;
            this.gridProfile.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridProfile.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProfile.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridProfile.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridProfile.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridProfile.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridProfile.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridProfile.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridProfile.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridProfile.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridProfile.AppearancePrint.Row.Options.UseFont = true;
            this.gridProfile.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridProfile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridProfile.DetailHeight = 431;
            this.gridProfile.GridControl = this.gridCtlProfile;
            this.gridProfile.Name = "gridProfile";
            this.gridProfile.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridProfile.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridProfile.OptionsBehavior.Editable = false;
            this.gridProfile.OptionsCustomization.AllowRowSizing = true;
            this.gridProfile.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridProfile.OptionsSelection.MultiSelect = true;
            this.gridProfile.OptionsView.EnableAppearanceEvenRow = true;
            this.gridProfile.OptionsView.RowAutoHeight = true;
            this.gridProfile.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridProfile.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridEmployee_RowClick);
            this.gridProfile.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridEmployee_FocusedRowChanged);
            this.gridProfile.LostFocus += new System.EventHandler(this.gridEmployee_LostFocus);
            // 
            // grdHIS
            // 
            this.grdHIS.DetailHeight = 431;
            this.grdHIS.GridControl = this.gridCtlProfile;
            this.grdHIS.Name = "grdHIS";
            // 
            // lblHiredate
            // 
            this.lblHiredate.AutoSize = true;
            this.lblHiredate.BackColor = System.Drawing.Color.Transparent;
            this.lblHiredate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiredate.ForeColor = System.Drawing.Color.White;
            this.lblHiredate.Location = new System.Drawing.Point(499, 295);
            this.lblHiredate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHiredate.Name = "lblHiredate";
            this.lblHiredate.Size = new System.Drawing.Size(92, 23);
            this.lblHiredate.TabIndex = 143;
            this.lblHiredate.Text = "Hire Date:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDepartment.BackColor = System.Drawing.Color.DimGray;
            this.cmbDepartment.Enabled = false;
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.ForeColor = System.Drawing.Color.Black;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(613, 247);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(317, 36);
            this.cmbDepartment.TabIndex = 17;
            this.cmbDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDEP_KeyDown);
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.DimGray;
            this.txtMobile.Enabled = false;
            this.txtMobile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.ForeColor = System.Drawing.Color.Black;
            this.txtMobile.Location = new System.Drawing.Point(133, 357);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(356, 34);
            this.txtMobile.TabIndex = 10;
            this.txtMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMON_KeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.White;
            this.lblBarcode.Location = new System.Drawing.Point(4, 34);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(89, 23);
            this.lblBarcode.TabIndex = 142;
            this.lblBarcode.Text = "Profile Id:";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.BackColor = System.Drawing.Color.Transparent;
            this.lblMobile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.ForeColor = System.Drawing.Color.White;
            this.lblMobile.Location = new System.Drawing.Point(4, 363);
            this.lblMobile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(86, 23);
            this.lblMobile.TabIndex = 136;
            this.lblMobile.Text = "Mobile #:";
            // 
            // dkpDateHired
            // 
            this.dkpDateHired.CustomFormat = "dd-MM-yyyy";
            this.dkpDateHired.Enabled = false;
            this.dkpDateHired.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDateHired.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDateHired.Location = new System.Drawing.Point(613, 284);
            this.dkpDateHired.Margin = new System.Windows.Forms.Padding(4);
            this.dkpDateHired.Name = "dkpDateHired";
            this.dkpDateHired.Size = new System.Drawing.Size(317, 34);
            this.dkpDateHired.TabIndex = 18;
            this.dkpDateHired.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpHIR_KeyDown);
            // 
            // lblPostion
            // 
            this.lblPostion.AutoSize = true;
            this.lblPostion.BackColor = System.Drawing.Color.Transparent;
            this.lblPostion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostion.ForeColor = System.Drawing.Color.White;
            this.lblPostion.Location = new System.Drawing.Point(499, 218);
            this.lblPostion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostion.Name = "lblPostion";
            this.lblPostion.Size = new System.Drawing.Size(78, 23);
            this.lblPostion.TabIndex = 141;
            this.lblPostion.Text = "Position:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(4, 328);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(96, 23);
            this.lblPhone.TabIndex = 137;
            this.lblPhone.Text = "Telephone:";
            // 
            // cmbPosition
            // 
            this.cmbPosition.AutoCompleteCustomSource.AddRange(new string[] {
            "Chief Operating Officer",
            "Finance Manager",
            "Marketing Manager",
            "Public Relation Manager",
            "Warehouse/Human Resources",
            "Staff",
            "Driver",
            "Assistant Driver ",
            "Helper"});
            this.cmbPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPosition.BackColor = System.Drawing.Color.DimGray;
            this.cmbPosition.Enabled = false;
            this.cmbPosition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPosition.ForeColor = System.Drawing.Color.Black;
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "Chief Operating Officer",
            "Finance Manager",
            "Marketing Manager",
            "Public Relation Manager",
            "Warehouse/Human Resources",
            "Staff",
            "Driver",
            "Assistant Driver ",
            "Helper"});
            this.cmbPosition.Location = new System.Drawing.Point(613, 210);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(317, 36);
            this.cmbPosition.TabIndex = 16;
            this.cmbPosition.Text = "Staff";
            this.cmbPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPOS_KeyDown);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.DimGray;
            this.txtPhone.Enabled = false;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(133, 320);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(357, 34);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPON_KeyDown);
            // 
            // txtProfileID
            // 
            this.txtProfileID.BackColor = System.Drawing.Color.DimGray;
            this.txtProfileID.Enabled = false;
            this.txtProfileID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfileID.ForeColor = System.Drawing.Color.Black;
            this.txtProfileID.Location = new System.Drawing.Point(133, 25);
            this.txtProfileID.Margin = new System.Windows.Forms.Padding(4);
            this.txtProfileID.Name = "txtProfileID";
            this.txtProfileID.Size = new System.Drawing.Size(356, 34);
            this.txtProfileID.TabIndex = 1;
            // 
            // lblCivilStatus
            // 
            this.lblCivilStatus.AutoSize = true;
            this.lblCivilStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCivilStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCivilStatus.ForeColor = System.Drawing.Color.White;
            this.lblCivilStatus.Location = new System.Drawing.Point(4, 293);
            this.lblCivilStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCivilStatus.Name = "lblCivilStatus";
            this.lblCivilStatus.Size = new System.Drawing.Size(105, 23);
            this.lblCivilStatus.TabIndex = 140;
            this.lblCivilStatus.Text = "Civil Status:";
            // 
            // cmbCivilStatus
            // 
            this.cmbCivilStatus.AutoCompleteCustomSource.AddRange(new string[] {
            "Single",
            "Married",
            "Divorce",
            "Widow"});
            this.cmbCivilStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCivilStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCivilStatus.BackColor = System.Drawing.Color.DimGray;
            this.cmbCivilStatus.Enabled = false;
            this.cmbCivilStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCivilStatus.ForeColor = System.Drawing.Color.Black;
            this.cmbCivilStatus.FormattingEnabled = true;
            this.cmbCivilStatus.Items.AddRange(new object[] {
            "Single",
            "Married",
            "Divorse"});
            this.cmbCivilStatus.Location = new System.Drawing.Point(133, 283);
            this.cmbCivilStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCivilStatus.Name = "cmbCivilStatus";
            this.cmbCivilStatus.Size = new System.Drawing.Size(357, 36);
            this.cmbCivilStatus.TabIndex = 8;
            this.cmbCivilStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCIV_KeyDown);
            // 
            // imgProfile
            // 
            this.imgProfile.BackColor = System.Drawing.Color.Gray;
            this.imgProfile.Location = new System.Drawing.Point(940, 28);
            this.imgProfile.Margin = new System.Windows.Forms.Padding(4);
            this.imgProfile.Name = "imgProfile";
            this.imgProfile.Size = new System.Drawing.Size(400, 358);
            this.imgProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgProfile.TabIndex = 139;
            this.imgProfile.TabStop = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(499, 33);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 23);
            this.lblEmail.TabIndex = 138;
            this.lblEmail.Text = "Email:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.DimGray;
            this.txtAddress.Enabled = false;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(613, 63);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(317, 34);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtADD_KeyDown);
            // 
            // txtPhilhealthNumber
            // 
            this.txtPhilhealthNumber.BackColor = System.Drawing.Color.DimGray;
            this.txtPhilhealthNumber.Enabled = false;
            this.txtPhilhealthNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhilhealthNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPhilhealthNumber.Location = new System.Drawing.Point(613, 174);
            this.txtPhilhealthNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhilhealthNumber.Name = "txtPhilhealthNumber";
            this.txtPhilhealthNumber.Size = new System.Drawing.Size(317, 34);
            this.txtPhilhealthNumber.TabIndex = 15;
            this.txtPhilhealthNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPHH_KeyDown);
            // 
            // lblPhilhealth
            // 
            this.lblPhilhealth.AutoSize = true;
            this.lblPhilhealth.BackColor = System.Drawing.Color.Transparent;
            this.lblPhilhealth.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhilhealth.ForeColor = System.Drawing.Color.White;
            this.lblPhilhealth.Location = new System.Drawing.Point(499, 181);
            this.lblPhilhealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhilhealth.Name = "lblPhilhealth";
            this.lblPhilhealth.Size = new System.Drawing.Size(105, 23);
            this.lblPhilhealth.TabIndex = 135;
            this.lblPhilhealth.Text = "Phil-Health:";
            // 
            // cmbProvince
            // 
            this.cmbProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProvince.BackColor = System.Drawing.Color.DimGray;
            this.cmbProvince.Enabled = false;
            this.cmbProvince.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProvince.ForeColor = System.Drawing.Color.Black;
            this.cmbProvince.FormattingEnabled = true;
            this.cmbProvince.Items.AddRange(new object[] {
            "Abra",
            "Agusan del Norte",
            "Agusan del Sur",
            "Aklan",
            "Albay",
            "Antique",
            "Apayao",
            "Aurora",
            "Basilan",
            "Bataan",
            "Batanes",
            "Batangas",
            "Benguet",
            "Biliran",
            "Biliran",
            "Bukidnon",
            "Bulacan",
            "Cagayan",
            "Camarines Norte",
            "Camarines Sur",
            "Camiguin",
            "Capiz",
            "Catanduanes",
            "Cavite",
            "Cebu",
            "Compostela Valley",
            "Cotabato",
            "Davao del Norte",
            "Davao del Sur",
            "Davao Oriental",
            "Eastern Samar",
            "Guimaras",
            "Ifugao",
            "Ilocos Norte",
            "Ilocos Sur",
            "Iloilo",
            "Isabela",
            "Kalinga",
            "La Union",
            "Laguna",
            "Lanao del Norte",
            "1st District of Iligan City",
            "Lanao del Sur",
            "Leyte",
            "Maguindanao",
            "Marinduque",
            "Masbate",
            "Misamis Occidental",
            "Misamis Oriental-Cagayan de Oro City",
            "Mountain Province",
            "Negros Occidental",
            "Negros Oriental",
            "Northern Samar",
            "Nueva Ecija",
            "Nueva Vizcaya",
            "Occidental Mindoro",
            "Oriental Mindoro",
            "Palawan",
            "Pampanga",
            "Pangasinan",
            "Quezon",
            "Quirino",
            "Rizal",
            "Romblon",
            "Samar",
            "Sarangani",
            "Siquijor",
            "Sorsogon",
            "South Cotabato",
            "Southern Leyte",
            "Sultan Kudarat",
            "Sulu",
            "Surigao del Norte",
            "Surigao del Sur",
            "Tarlac",
            "Tawi-Tawi",
            "Unknown",
            "Zambales",
            "Zamboanga del Norte",
            "Zamboanga del Sur",
            "Zamboanga Sibugay",
            "Metro Manila"});
            this.cmbProvince.Location = new System.Drawing.Point(613, 100);
            this.cmbProvince.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Size = new System.Drawing.Size(317, 36);
            this.cmbProvince.TabIndex = 13;
            this.cmbProvince.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPRV_KeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.DimGray;
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(613, 26);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(317, 34);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEML_KeyDown);
            // 
            // txtSSSNumber
            // 
            this.txtSSSNumber.BackColor = System.Drawing.Color.DimGray;
            this.txtSSSNumber.Enabled = false;
            this.txtSSSNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSSNumber.ForeColor = System.Drawing.Color.Black;
            this.txtSSSNumber.Location = new System.Drawing.Point(613, 137);
            this.txtSSSNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtSSSNumber.Name = "txtSSSNumber";
            this.txtSSSNumber.Size = new System.Drawing.Size(317, 34);
            this.txtSSSNumber.TabIndex = 14;
            this.txtSSSNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSSS_KeyDown);
            // 
            // lblSSS
            // 
            this.lblSSS.AutoSize = true;
            this.lblSSS.BackColor = System.Drawing.Color.Transparent;
            this.lblSSS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSS.ForeColor = System.Drawing.Color.White;
            this.lblSSS.Location = new System.Drawing.Point(499, 144);
            this.lblSSS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSSS.Name = "lblSSS";
            this.lblSSS.Size = new System.Drawing.Size(45, 23);
            this.lblSSS.TabIndex = 134;
            this.lblSSS.Text = "SSS:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(499, 70);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(103, 23);
            this.lblAddress.TabIndex = 133;
            this.lblAddress.Text = "Street Add:";
            // 
            // lblProvicen
            // 
            this.lblProvicen.AutoSize = true;
            this.lblProvicen.BackColor = System.Drawing.Color.Transparent;
            this.lblProvicen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvicen.ForeColor = System.Drawing.Color.White;
            this.lblProvicen.Location = new System.Drawing.Point(499, 107);
            this.lblProvicen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProvicen.Name = "lblProvicen";
            this.lblProvicen.Size = new System.Drawing.Size(83, 23);
            this.lblProvicen.TabIndex = 132;
            this.lblProvicen.Text = "Province:";
            // 
            // lblDatebirth
            // 
            this.lblDatebirth.AutoSize = true;
            this.lblDatebirth.BackColor = System.Drawing.Color.Transparent;
            this.lblDatebirth.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatebirth.ForeColor = System.Drawing.Color.White;
            this.lblDatebirth.Location = new System.Drawing.Point(4, 257);
            this.lblDatebirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatebirth.Name = "lblDatebirth";
            this.lblDatebirth.Size = new System.Drawing.Size(98, 23);
            this.lblDatebirth.TabIndex = 131;
            this.lblDatebirth.Text = "Birth Date:";
            // 
            // dkpBirthdate
            // 
            this.dkpBirthdate.CustomFormat = "dd-MM-yyyy";
            this.dkpBirthdate.Enabled = false;
            this.dkpBirthdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpBirthdate.Location = new System.Drawing.Point(135, 246);
            this.dkpBirthdate.Margin = new System.Windows.Forms.Padding(4);
            this.dkpBirthdate.Name = "dkpBirthdate";
            this.dkpBirthdate.Size = new System.Drawing.Size(356, 34);
            this.dkpBirthdate.TabIndex = 6;
            this.dkpBirthdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpDOB_KeyDown);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(4, 217);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(74, 23);
            this.lblGender.TabIndex = 122;
            this.lblGender.Text = "Gender:";
            // 
            // cmbgender
            // 
            this.cmbgender.AutoCompleteCustomSource.AddRange(new string[] {
            "Female",
            "Male"});
            this.cmbgender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbgender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbgender.BackColor = System.Drawing.Color.DimGray;
            this.cmbgender.Enabled = false;
            this.cmbgender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbgender.ForeColor = System.Drawing.Color.Black;
            this.cmbgender.FormattingEnabled = true;
            this.cmbgender.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cmbgender.Location = new System.Drawing.Point(133, 209);
            this.cmbgender.Margin = new System.Windows.Forms.Padding(4);
            this.cmbgender.Name = "cmbgender";
            this.cmbgender.Size = new System.Drawing.Size(357, 36);
            this.cmbgender.TabIndex = 5;
            this.cmbgender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGEN_KeyDown);
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.BackColor = System.Drawing.Color.DimGray;
            this.txtMiddleInitial.Enabled = false;
            this.txtMiddleInitial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleInitial.ForeColor = System.Drawing.Color.Black;
            this.txtMiddleInitial.Location = new System.Drawing.Point(133, 172);
            this.txtMiddleInitial.Margin = new System.Windows.Forms.Padding(4);
            this.txtMiddleInitial.MaxLength = 2;
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.Size = new System.Drawing.Size(356, 34);
            this.txtMiddleInitial.TabIndex = 4;
            this.txtMiddleInitial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMID_KeyDown);
            // 
            // lblMiddleInitial
            // 
            this.lblMiddleInitial.AutoSize = true;
            this.lblMiddleInitial.BackColor = System.Drawing.Color.Transparent;
            this.lblMiddleInitial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleInitial.ForeColor = System.Drawing.Color.White;
            this.lblMiddleInitial.Location = new System.Drawing.Point(4, 180);
            this.lblMiddleInitial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMiddleInitial.Name = "lblMiddleInitial";
            this.lblMiddleInitial.Size = new System.Drawing.Size(123, 23);
            this.lblMiddleInitial.TabIndex = 118;
            this.lblMiddleInitial.Text = "Middle Initial:";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.DimGray;
            this.txtLastName.Enabled = false;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Location = new System.Drawing.Point(133, 135);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(356, 34);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLSN_KeyDown);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Location = new System.Drawing.Point(4, 143);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(99, 23);
            this.lblLastName.TabIndex = 115;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.DimGray;
            this.txtFirstName.Enabled = false;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Location = new System.Drawing.Point(133, 98);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(356, 34);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFNM_KeyDown);
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.BackColor = System.Drawing.Color.Transparent;
            this.lblFName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.ForeColor = System.Drawing.Color.White;
            this.lblFName.Location = new System.Drawing.Point(4, 106);
            this.lblFName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(102, 23);
            this.lblFName.TabIndex = 113;
            this.lblFName.Text = "First Name:";
            // 
            // txtPIR
            // 
            this.txtPIR.BackColor = System.Drawing.Color.White;
            this.txtPIR.Enabled = false;
            this.txtPIR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPIR.ForeColor = System.Drawing.Color.Maroon;
            this.txtPIR.Location = new System.Drawing.Point(-15, 23);
            this.txtPIR.Margin = new System.Windows.Forms.Padding(4);
            this.txtPIR.Multiline = true;
            this.txtPIR.Name = "txtPIR";
            this.txtPIR.Size = new System.Drawing.Size(12, 11);
            this.txtPIR.TabIndex = 109;
            this.txtPIR.Visible = false;
            // 
            // xtraAddress
            // 
            this.xtraAddress.Appearance.PageClient.BackColor = System.Drawing.Color.Turquoise;
            this.xtraAddress.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraAddress.Controls.Add(this.groupAddress);
            this.xtraAddress.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraAddress.ImageOptions.Image")));
            this.xtraAddress.Margin = new System.Windows.Forms.Padding(4);
            this.xtraAddress.Name = "xtraAddress";
            this.xtraAddress.Size = new System.Drawing.Size(1351, 758);
            this.xtraAddress.Text = "Profile Address";
            // 
            // groupAddress
            // 
            this.groupAddress.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupAddress.Appearance.Options.UseBackColor = true;
            this.groupAddress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupAddress.Controls.Add(this.label18);
            this.groupAddress.Controls.Add(this.txtBarcodeAddress);
            this.groupAddress.Controls.Add(this.label3);
            this.groupAddress.Controls.Add(this.txtAddressID);
            this.groupAddress.Controls.Add(this.groupControl2);
            this.groupAddress.Controls.Add(this.label12);
            this.groupAddress.Controls.Add(this.txtBarangay);
            this.groupAddress.Controls.Add(this.label16);
            this.groupAddress.Controls.Add(this.cmbCountry);
            this.groupAddress.Controls.Add(this.label22);
            this.groupAddress.Controls.Add(this.dkpDateRegister);
            this.groupAddress.Controls.Add(this.label23);
            this.groupAddress.Controls.Add(this.txtProvince);
            this.groupAddress.Controls.Add(this.txtZipCode);
            this.groupAddress.Controls.Add(this.label24);
            this.groupAddress.Controls.Add(this.txtCity);
            this.groupAddress.Controls.Add(this.label25);
            this.groupAddress.Controls.Add(this.txtStreet);
            this.groupAddress.Controls.Add(this.label26);
            this.groupAddress.Controls.Add(this.textBox17);
            this.groupAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAddress.Location = new System.Drawing.Point(0, 0);
            this.groupAddress.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupAddress.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupAddress.Margin = new System.Windows.Forms.Padding(4);
            this.groupAddress.Name = "groupAddress";
            this.groupAddress.Size = new System.Drawing.Size(1351, 758);
            this.groupAddress.TabIndex = 174;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(8, 84);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 23);
            this.label18.TabIndex = 176;
            this.label18.Text = "Barcode:";
            // 
            // txtBarcodeAddress
            // 
            this.txtBarcodeAddress.BackColor = System.Drawing.Color.DimGray;
            this.txtBarcodeAddress.Enabled = false;
            this.txtBarcodeAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeAddress.ForeColor = System.Drawing.Color.Black;
            this.txtBarcodeAddress.Location = new System.Drawing.Point(133, 76);
            this.txtBarcodeAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarcodeAddress.Name = "txtBarcodeAddress";
            this.txtBarcodeAddress.Size = new System.Drawing.Size(357, 34);
            this.txtBarcodeAddress.TabIndex = 175;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 174;
            this.label3.Text = "Address Id:";
            // 
            // txtAddressID
            // 
            this.txtAddressID.BackColor = System.Drawing.Color.DimGray;
            this.txtAddressID.Enabled = false;
            this.txtAddressID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressID.ForeColor = System.Drawing.Color.Black;
            this.txtAddressID.Location = new System.Drawing.Point(133, 39);
            this.txtAddressID.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddressID.Name = "txtAddressID";
            this.txtAddressID.Size = new System.Drawing.Size(357, 34);
            this.txtAddressID.TabIndex = 27;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl2.Controls.Add(this.gridControlAddress);
            this.groupControl2.Controls.Add(this.textBox2);
            this.groupControl2.Location = new System.Drawing.Point(-1, 390);
            this.groupControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1347, 361);
            this.groupControl2.TabIndex = 172;
            this.groupControl2.Text = "Address List:";
            // 
            // gridControlAddress
            // 
            this.gridControlAddress.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAddress.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridControlAddress.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControlAddress.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridControlAddress.Location = new System.Drawing.Point(3, 21);
            this.gridControlAddress.MainView = this.gridAddress;
            this.gridControlAddress.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlAddress.Name = "gridControlAddress";
            this.gridControlAddress.Size = new System.Drawing.Size(1341, 337);
            this.gridControlAddress.TabIndex = 101;
            this.gridControlAddress.TabStop = false;
            this.gridControlAddress.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAddress,
            this.gridView2});
            // 
            // gridAddress
            // 
            this.gridAddress.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridAddress.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridAddress.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridAddress.Appearance.Empty.Options.UseBackColor = true;
            this.gridAddress.Appearance.Empty.Options.UseBorderColor = true;
            this.gridAddress.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridAddress.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridAddress.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridAddress.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAddress.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridAddress.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridAddress.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridAddress.Appearance.FocusedRow.Options.UseFont = true;
            this.gridAddress.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridAddress.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridAddress.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridAddress.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gridAddress.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridAddress.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridAddress.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridAddress.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridAddress.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridAddress.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridAddress.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAddress.Appearance.Row.Options.UseBackColor = true;
            this.gridAddress.Appearance.Row.Options.UseBorderColor = true;
            this.gridAddress.Appearance.Row.Options.UseFont = true;
            this.gridAddress.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAddress.Appearance.ViewCaption.Options.UseFont = true;
            this.gridAddress.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridAddress.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAddress.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridAddress.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridAddress.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridAddress.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridAddress.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridAddress.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridAddress.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridAddress.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridAddress.AppearancePrint.Row.Options.UseFont = true;
            this.gridAddress.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridAddress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridAddress.DetailHeight = 431;
            this.gridAddress.GridControl = this.gridControlAddress;
            this.gridAddress.Name = "gridAddress";
            this.gridAddress.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridAddress.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridAddress.OptionsBehavior.Editable = false;
            this.gridAddress.OptionsCustomization.AllowRowSizing = true;
            this.gridAddress.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridAddress.OptionsSelection.MultiSelect = true;
            this.gridAddress.OptionsView.EnableAppearanceEvenRow = true;
            this.gridAddress.OptionsView.RowAutoHeight = true;
            this.gridAddress.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridAddress.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridAddress_FocusedRowChanged);
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 431;
            this.gridView2.GridControl = this.gridControlAddress;
            this.gridView2.Name = "gridView2";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(8, 158);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 23);
            this.label12.TabIndex = 142;
            this.label12.Text = "Barangay:";
            // 
            // txtBarangay
            // 
            this.txtBarangay.BackColor = System.Drawing.Color.DimGray;
            this.txtBarangay.Enabled = false;
            this.txtBarangay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarangay.ForeColor = System.Drawing.Color.Black;
            this.txtBarangay.Location = new System.Drawing.Point(133, 150);
            this.txtBarangay.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarangay.Name = "txtBarangay";
            this.txtBarangay.Size = new System.Drawing.Size(357, 34);
            this.txtBarangay.TabIndex = 28;
            this.txtBarangay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarangay_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(498, 122);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 23);
            this.label16.TabIndex = 140;
            this.label16.Text = "Country:";
            // 
            // cmbCountry
            // 
            this.cmbCountry.AutoCompleteCustomSource.AddRange(new string[] {
            "Single",
            "Married",
            "Divorce",
            "Widow"});
            this.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCountry.BackColor = System.Drawing.Color.DimGray;
            this.cmbCountry.Enabled = false;
            this.cmbCountry.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.ForeColor = System.Drawing.Color.Black;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(613, 115);
            this.cmbCountry.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(357, 36);
            this.cmbCountry.TabIndex = 33;
            this.cmbCountry.Text = "Philippines";
            this.cmbCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCountry_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(498, 160);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 23);
            this.label22.TabIndex = 131;
            this.label22.Text = "Date Reg:";
            // 
            // dkpDateRegister
            // 
            this.dkpDateRegister.CustomFormat = "dd-MM-yyyy";
            this.dkpDateRegister.Enabled = false;
            this.dkpDateRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpDateRegister.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpDateRegister.Location = new System.Drawing.Point(612, 154);
            this.dkpDateRegister.Margin = new System.Windows.Forms.Padding(4);
            this.dkpDateRegister.Name = "dkpDateRegister";
            this.dkpDateRegister.Size = new System.Drawing.Size(356, 34);
            this.dkpDateRegister.TabIndex = 34;
            this.dkpDateRegister.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpDateRegister_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(498, 85);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 23);
            this.label23.TabIndex = 122;
            this.label23.Text = "Province:";
            // 
            // txtProvince
            // 
            this.txtProvince.AutoCompleteCustomSource.AddRange(new string[] {
            "Female",
            "Male"});
            this.txtProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtProvince.BackColor = System.Drawing.Color.DimGray;
            this.txtProvince.Enabled = false;
            this.txtProvince.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvince.ForeColor = System.Drawing.Color.Black;
            this.txtProvince.FormattingEnabled = true;
            this.txtProvince.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.txtProvince.Location = new System.Drawing.Point(612, 76);
            this.txtProvince.Margin = new System.Windows.Forms.Padding(4);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(357, 36);
            this.txtProvince.TabIndex = 32;
            this.txtProvince.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvince_KeyDown);
            // 
            // txtZipCode
            // 
            this.txtZipCode.BackColor = System.Drawing.Color.DimGray;
            this.txtZipCode.Enabled = false;
            this.txtZipCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZipCode.ForeColor = System.Drawing.Color.Black;
            this.txtZipCode.Location = new System.Drawing.Point(612, 39);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtZipCode.MaxLength = 25;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(356, 34);
            this.txtZipCode.TabIndex = 31;
            this.txtZipCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtZipCode_KeyDown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(498, 46);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 23);
            this.label24.TabIndex = 118;
            this.label24.Text = "Zip Code:";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.DimGray;
            this.txtCity.Enabled = false;
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.ForeColor = System.Drawing.Color.Black;
            this.txtCity.Location = new System.Drawing.Point(133, 187);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(357, 34);
            this.txtCity.TabIndex = 30;
            this.txtCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCity_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(8, 194);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 23);
            this.label25.TabIndex = 115;
            this.label25.Text = "City:";
            // 
            // txtStreet
            // 
            this.txtStreet.BackColor = System.Drawing.Color.DimGray;
            this.txtStreet.Enabled = false;
            this.txtStreet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.ForeColor = System.Drawing.Color.Black;
            this.txtStreet.Location = new System.Drawing.Point(133, 113);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(357, 34);
            this.txtStreet.TabIndex = 29;
            this.txtStreet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStreet_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(8, 121);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 23);
            this.label26.TabIndex = 113;
            this.label26.Text = "Street:";
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.White;
            this.textBox17.Enabled = false;
            this.textBox17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.ForeColor = System.Drawing.Color.Maroon;
            this.textBox17.Location = new System.Drawing.Point(-15, 23);
            this.textBox17.Margin = new System.Windows.Forms.Padding(4);
            this.textBox17.Multiline = true;
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(12, 11);
            this.textBox17.TabIndex = 109;
            this.textBox17.Visible = false;
            // 
            // xtraContact
            // 
            this.xtraContact.Controls.Add(this.groupContact);
            this.xtraContact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraContact.ImageOptions.Image")));
            this.xtraContact.Margin = new System.Windows.Forms.Padding(4);
            this.xtraContact.Name = "xtraContact";
            this.xtraContact.Size = new System.Drawing.Size(1351, 758);
            this.xtraContact.Text = "Profile Contact";
            // 
            // groupContact
            // 
            this.groupContact.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupContact.Appearance.Options.UseBackColor = true;
            this.groupContact.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupContact.Controls.Add(this.label17);
            this.groupContact.Controls.Add(this.txtContactBarcode);
            this.groupContact.Controls.Add(this.txtFaxNumber);
            this.groupContact.Controls.Add(this.label15);
            this.groupContact.Controls.Add(this.txtWebUrl);
            this.groupContact.Controls.Add(this.label13);
            this.groupContact.Controls.Add(this.txtEmailAddress);
            this.groupContact.Controls.Add(this.label8);
            this.groupContact.Controls.Add(this.txtSecondMobile);
            this.groupContact.Controls.Add(this.label6);
            this.groupContact.Controls.Add(this.label4);
            this.groupContact.Controls.Add(this.txtContactId);
            this.groupContact.Controls.Add(this.groupControl3);
            this.groupContact.Controls.Add(this.label5);
            this.groupContact.Controls.Add(this.txtContactName);
            this.groupContact.Controls.Add(this.label7);
            this.groupContact.Controls.Add(this.dkpContactDateReg);
            this.groupContact.Controls.Add(this.txtFirstMobile);
            this.groupContact.Controls.Add(this.label9);
            this.groupContact.Controls.Add(this.txtPhoneNumber);
            this.groupContact.Controls.Add(this.label10);
            this.groupContact.Controls.Add(this.txtPositionName);
            this.groupContact.Controls.Add(this.label11);
            this.groupContact.Controls.Add(this.textBox10);
            this.groupContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupContact.Location = new System.Drawing.Point(0, 0);
            this.groupContact.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupContact.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupContact.Margin = new System.Windows.Forms.Padding(4);
            this.groupContact.Name = "groupContact";
            this.groupContact.Size = new System.Drawing.Size(1351, 758);
            this.groupContact.TabIndex = 175;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(4, 82);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 186;
            this.label17.Text = "Barcode:";
            // 
            // txtContactBarcode
            // 
            this.txtContactBarcode.BackColor = System.Drawing.Color.DimGray;
            this.txtContactBarcode.Enabled = false;
            this.txtContactBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactBarcode.ForeColor = System.Drawing.Color.Black;
            this.txtContactBarcode.Location = new System.Drawing.Point(134, 75);
            this.txtContactBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactBarcode.Name = "txtContactBarcode";
            this.txtContactBarcode.Size = new System.Drawing.Size(357, 34);
            this.txtContactBarcode.TabIndex = 185;
            // 
            // txtFaxNumber
            // 
            this.txtFaxNumber.BackColor = System.Drawing.Color.DimGray;
            this.txtFaxNumber.Enabled = false;
            this.txtFaxNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFaxNumber.ForeColor = System.Drawing.Color.Black;
            this.txtFaxNumber.Location = new System.Drawing.Point(636, 151);
            this.txtFaxNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtFaxNumber.MaxLength = 100;
            this.txtFaxNumber.Name = "txtFaxNumber";
            this.txtFaxNumber.Size = new System.Drawing.Size(356, 34);
            this.txtFaxNumber.TabIndex = 43;
            this.txtFaxNumber.Text = "000-000-000";
            this.txtFaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFaxNumber_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(499, 158);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 23);
            this.label15.TabIndex = 184;
            this.label15.Text = "Fax Number:";
            // 
            // txtWebUrl
            // 
            this.txtWebUrl.BackColor = System.Drawing.Color.DimGray;
            this.txtWebUrl.Enabled = false;
            this.txtWebUrl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebUrl.ForeColor = System.Drawing.Color.Black;
            this.txtWebUrl.Location = new System.Drawing.Point(636, 114);
            this.txtWebUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtWebUrl.MaxLength = 100;
            this.txtWebUrl.Name = "txtWebUrl";
            this.txtWebUrl.Size = new System.Drawing.Size(356, 34);
            this.txtWebUrl.TabIndex = 42;
            this.txtWebUrl.Text = "www.google.com";
            this.txtWebUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWebUrl_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(499, 121);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 23);
            this.label13.TabIndex = 180;
            this.label13.Text = "Web Url:";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.BackColor = System.Drawing.Color.DimGray;
            this.txtEmailAddress.Enabled = false;
            this.txtEmailAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.ForeColor = System.Drawing.Color.Black;
            this.txtEmailAddress.Location = new System.Drawing.Point(636, 77);
            this.txtEmailAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailAddress.MaxLength = 100;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(356, 34);
            this.txtEmailAddress.TabIndex = 41;
            this.txtEmailAddress.Text = "myemail@gmail.com";
            this.txtEmailAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailAddress_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(499, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 23);
            this.label8.TabIndex = 178;
            this.label8.Text = "Email Add:";
            // 
            // txtSecondMobile
            // 
            this.txtSecondMobile.BackColor = System.Drawing.Color.DimGray;
            this.txtSecondMobile.Enabled = false;
            this.txtSecondMobile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondMobile.ForeColor = System.Drawing.Color.Black;
            this.txtSecondMobile.Location = new System.Drawing.Point(636, 38);
            this.txtSecondMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtSecondMobile.MaxLength = 50;
            this.txtSecondMobile.Name = "txtSecondMobile";
            this.txtSecondMobile.Size = new System.Drawing.Size(356, 34);
            this.txtSecondMobile.TabIndex = 40;
            this.txtSecondMobile.Text = "09000000";
            this.txtSecondMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecondMobile_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(499, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 23);
            this.label6.TabIndex = 176;
            this.label6.Text = "Mobile No 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 174;
            this.label4.Text = "Contact Id:";
            // 
            // txtContactId
            // 
            this.txtContactId.BackColor = System.Drawing.Color.DimGray;
            this.txtContactId.Enabled = false;
            this.txtContactId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactId.ForeColor = System.Drawing.Color.Black;
            this.txtContactId.Location = new System.Drawing.Point(134, 38);
            this.txtContactId.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactId.Name = "txtContactId";
            this.txtContactId.Size = new System.Drawing.Size(357, 34);
            this.txtContactId.TabIndex = 35;
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl3.Controls.Add(this.gridControlContact);
            this.groupControl3.Controls.Add(this.textBox4);
            this.groupControl3.Location = new System.Drawing.Point(-1, 430);
            this.groupControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl3.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1347, 320);
            this.groupControl3.TabIndex = 172;
            this.groupControl3.Text = "Address List:";
            // 
            // gridControlContact
            // 
            this.gridControlContact.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlContact.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.Silver;
            this.gridControlContact.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControlContact.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlContact.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.gridControlContact.Location = new System.Drawing.Point(3, 21);
            this.gridControlContact.MainView = this.gridContact;
            this.gridControlContact.Margin = new System.Windows.Forms.Padding(4);
            this.gridControlContact.Name = "gridControlContact";
            this.gridControlContact.Size = new System.Drawing.Size(1341, 296);
            this.gridControlContact.TabIndex = 101;
            this.gridControlContact.TabStop = false;
            this.gridControlContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridContact,
            this.gridView3});
            // 
            // gridContact
            // 
            this.gridContact.Appearance.Empty.BackColor = System.Drawing.Color.LightGray;
            this.gridContact.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridContact.Appearance.Empty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridContact.Appearance.Empty.Options.UseBackColor = true;
            this.gridContact.Appearance.Empty.Options.UseBorderColor = true;
            this.gridContact.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridContact.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridContact.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.gridContact.Appearance.FocusedRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridContact.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridContact.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridContact.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridContact.Appearance.FocusedRow.Options.UseFont = true;
            this.gridContact.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridContact.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridContact.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridContact.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gridContact.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridContact.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridContact.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridContact.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.gridContact.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gridContact.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridContact.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridContact.Appearance.Row.Options.UseBackColor = true;
            this.gridContact.Appearance.Row.Options.UseBorderColor = true;
            this.gridContact.Appearance.Row.Options.UseFont = true;
            this.gridContact.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridContact.Appearance.ViewCaption.Options.UseFont = true;
            this.gridContact.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gridContact.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridContact.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridContact.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridContact.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.gridContact.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.gridContact.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridContact.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridContact.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridContact.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
            this.gridContact.AppearancePrint.Row.Options.UseFont = true;
            this.gridContact.AppearancePrint.Row.Options.UseForeColor = true;
            this.gridContact.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gridContact.DetailHeight = 431;
            this.gridContact.GridControl = this.gridControlContact;
            this.gridContact.Name = "gridContact";
            this.gridContact.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridContact.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridContact.OptionsBehavior.Editable = false;
            this.gridContact.OptionsCustomization.AllowRowSizing = true;
            this.gridContact.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridContact.OptionsSelection.MultiSelect = true;
            this.gridContact.OptionsView.EnableAppearanceEvenRow = true;
            this.gridContact.OptionsView.RowAutoHeight = true;
            this.gridContact.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.gridContact.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridContact_FocusedRowChanged);
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 431;
            this.gridView3.GridControl = this.gridControlContact;
            this.gridView3.Name = "gridView3";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DimGray;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Maroon;
            this.textBox4.Location = new System.Drawing.Point(-11, 26);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(12, 11);
            this.textBox4.TabIndex = 99;
            this.textBox4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 23);
            this.label5.TabIndex = 142;
            this.label5.Text = "Name:";
            // 
            // txtContactName
            // 
            this.txtContactName.BackColor = System.Drawing.Color.DimGray;
            this.txtContactName.Enabled = false;
            this.txtContactName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactName.ForeColor = System.Drawing.Color.Black;
            this.txtContactName.Location = new System.Drawing.Point(134, 111);
            this.txtContactName.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(357, 34);
            this.txtContactName.TabIndex = 36;
            this.txtContactName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactName_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(499, 195);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 23);
            this.label7.TabIndex = 131;
            this.label7.Text = "Date Reg:";
            // 
            // dkpContactDateReg
            // 
            this.dkpContactDateReg.CustomFormat = "dd-MM-yyyy";
            this.dkpContactDateReg.Enabled = false;
            this.dkpContactDateReg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpContactDateReg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpContactDateReg.Location = new System.Drawing.Point(636, 188);
            this.dkpContactDateReg.Margin = new System.Windows.Forms.Padding(4);
            this.dkpContactDateReg.Name = "dkpContactDateReg";
            this.dkpContactDateReg.Size = new System.Drawing.Size(356, 34);
            this.dkpContactDateReg.TabIndex = 44;
            this.dkpContactDateReg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpContactDateReg_KeyDown);
            // 
            // txtFirstMobile
            // 
            this.txtFirstMobile.BackColor = System.Drawing.Color.DimGray;
            this.txtFirstMobile.Enabled = false;
            this.txtFirstMobile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstMobile.ForeColor = System.Drawing.Color.Black;
            this.txtFirstMobile.Location = new System.Drawing.Point(134, 222);
            this.txtFirstMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstMobile.MaxLength = 50;
            this.txtFirstMobile.Name = "txtFirstMobile";
            this.txtFirstMobile.Size = new System.Drawing.Size(357, 34);
            this.txtFirstMobile.TabIndex = 39;
            this.txtFirstMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirstMobile_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(4, 230);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 23);
            this.label9.TabIndex = 118;
            this.label9.Text = "Mobile No:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.DimGray;
            this.txtPhoneNumber.Enabled = false;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Location = new System.Drawing.Point(134, 185);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(357, 34);
            this.txtPhoneNumber.TabIndex = 38;
            this.txtPhoneNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhoneNumber_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(4, 193);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 115;
            this.label10.Text = "Telephone:";
            // 
            // txtPositionName
            // 
            this.txtPositionName.BackColor = System.Drawing.Color.DimGray;
            this.txtPositionName.Enabled = false;
            this.txtPositionName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPositionName.ForeColor = System.Drawing.Color.Black;
            this.txtPositionName.Location = new System.Drawing.Point(134, 148);
            this.txtPositionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Size = new System.Drawing.Size(357, 34);
            this.txtPositionName.TabIndex = 37;
            this.txtPositionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPositionName_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(4, 156);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 23);
            this.label11.TabIndex = 113;
            this.label11.Text = "Position:";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.White;
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.ForeColor = System.Drawing.Color.Maroon;
            this.textBox10.Location = new System.Drawing.Point(-15, 23);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(12, 11);
            this.textBox10.TabIndex = 109;
            this.textBox10.Visible = false;
            // 
            // xtraImage
            // 
            this.xtraImage.Controls.Add(this.groupControl1);
            this.xtraImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraImage.ImageOptions.Image")));
            this.xtraImage.Margin = new System.Windows.Forms.Padding(4);
            this.xtraImage.Name = "xtraImage";
            this.xtraImage.Size = new System.Drawing.Size(1351, 758);
            this.xtraImage.Text = "Profile Picture";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl1.Controls.Add(this.label20);
            this.groupControl1.Controls.Add(this.dkpImgCreadOn);
            this.groupControl1.Controls.Add(this.bntBrowseImage);
            this.groupControl1.Controls.Add(this.bntSaveImages);
            this.groupControl1.Controls.Add(this.cmbProfileImgType);
            this.groupControl1.Controls.Add(this.label28);
            this.groupControl1.Controls.Add(this.txtProfileImgFileName);
            this.groupControl1.Controls.Add(this.label29);
            this.groupControl1.Controls.Add(this.label30);
            this.groupControl1.Controls.Add(this.txtProfileImgTitle);
            this.groupControl1.Controls.Add(this.label31);
            this.groupControl1.Controls.Add(this.txtProfileImgBarcode);
            this.groupControl1.Controls.Add(this.imgProfileImages);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1351, 758);
            this.groupControl1.TabIndex = 175;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(735, 199);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 23);
            this.label20.TabIndex = 245;
            this.label20.Text = "Created Date:";
            // 
            // dkpImgCreadOn
            // 
            this.dkpImgCreadOn.CustomFormat = "dd-MM-yyyy";
            this.dkpImgCreadOn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dkpImgCreadOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpImgCreadOn.Location = new System.Drawing.Point(919, 190);
            this.dkpImgCreadOn.Margin = new System.Windows.Forms.Padding(4);
            this.dkpImgCreadOn.Name = "dkpImgCreadOn";
            this.dkpImgCreadOn.Size = new System.Drawing.Size(393, 34);
            this.dkpImgCreadOn.TabIndex = 106;
            // 
            // bntBrowseImage
            // 
            this.bntBrowseImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntBrowseImage.ImageOptions.Image")));
            this.bntBrowseImage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntBrowseImage.Location = new System.Drawing.Point(919, 268);
            this.bntBrowseImage.Margin = new System.Windows.Forms.Padding(4);
            this.bntBrowseImage.Name = "bntBrowseImage";
            this.bntBrowseImage.Size = new System.Drawing.Size(198, 71);
            this.bntBrowseImage.TabIndex = 108;
            this.bntBrowseImage.ToolTip = "User Manual";
            this.bntBrowseImage.Click += new System.EventHandler(this.bntBrowseImage_Click);
            // 
            // bntSaveImages
            // 
            this.bntSaveImages.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntSaveImages.ImageOptions.Image")));
            this.bntSaveImages.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntSaveImages.Location = new System.Drawing.Point(1114, 268);
            this.bntSaveImages.Margin = new System.Windows.Forms.Padding(4);
            this.bntSaveImages.Name = "bntSaveImages";
            this.bntSaveImages.Size = new System.Drawing.Size(198, 71);
            this.bntSaveImages.TabIndex = 109;
            this.bntSaveImages.ToolTip = "Service Manual";
            this.bntSaveImages.Click += new System.EventHandler(this.bntSaveImages_Click);
            // 
            // cmbProfileImgType
            // 
            this.cmbProfileImgType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProfileImgType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProfileImgType.BackColor = System.Drawing.Color.White;
            this.cmbProfileImgType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProfileImgType.ForeColor = System.Drawing.Color.Maroon;
            this.cmbProfileImgType.FormattingEnabled = true;
            this.cmbProfileImgType.Items.AddRange(new object[] {
            "JPG",
            "PNG",
            "BMP"});
            this.cmbProfileImgType.Location = new System.Drawing.Point(919, 117);
            this.cmbProfileImgType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProfileImgType.Name = "cmbProfileImgType";
            this.cmbProfileImgType.Size = new System.Drawing.Size(393, 36);
            this.cmbProfileImgType.TabIndex = 103;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(734, 161);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(148, 23);
            this.label28.TabIndex = 231;
            this.label28.Text = "Profile FileName:";
            // 
            // txtProfileImgFileName
            // 
            this.txtProfileImgFileName.BackColor = System.Drawing.Color.White;
            this.txtProfileImgFileName.Enabled = false;
            this.txtProfileImgFileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfileImgFileName.ForeColor = System.Drawing.Color.Maroon;
            this.txtProfileImgFileName.Location = new System.Drawing.Point(919, 154);
            this.txtProfileImgFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProfileImgFileName.Name = "txtProfileImgFileName";
            this.txtProfileImgFileName.Size = new System.Drawing.Size(393, 34);
            this.txtProfileImgFileName.TabIndex = 105;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(735, 125);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(166, 23);
            this.label29.TabIndex = 229;
            this.label29.Text = "Profile Image Type:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(734, 87);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(164, 23);
            this.label30.TabIndex = 228;
            this.label30.Text = "Profile Image Title:";
            // 
            // txtProfileImgTitle
            // 
            this.txtProfileImgTitle.BackColor = System.Drawing.Color.White;
            this.txtProfileImgTitle.Enabled = false;
            this.txtProfileImgTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfileImgTitle.ForeColor = System.Drawing.Color.Maroon;
            this.txtProfileImgTitle.Location = new System.Drawing.Point(919, 79);
            this.txtProfileImgTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtProfileImgTitle.Name = "txtProfileImgTitle";
            this.txtProfileImgTitle.Size = new System.Drawing.Size(393, 34);
            this.txtProfileImgTitle.TabIndex = 102;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(734, 50);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(169, 23);
            this.label31.TabIndex = 226;
            this.label31.Text = "Profile Image Code:";
            // 
            // txtProfileImgBarcode
            // 
            this.txtProfileImgBarcode.BackColor = System.Drawing.Color.White;
            this.txtProfileImgBarcode.Enabled = false;
            this.txtProfileImgBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfileImgBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.txtProfileImgBarcode.Location = new System.Drawing.Point(919, 43);
            this.txtProfileImgBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtProfileImgBarcode.Name = "txtProfileImgBarcode";
            this.txtProfileImgBarcode.Size = new System.Drawing.Size(393, 34);
            this.txtProfileImgBarcode.TabIndex = 101;
            // 
            // imgProfileImages
            // 
            this.imgProfileImages.BackColor = System.Drawing.Color.Gray;
            this.imgProfileImages.Location = new System.Drawing.Point(35, 43);
            this.imgProfileImages.Margin = new System.Windows.Forms.Padding(4);
            this.imgProfileImages.Name = "imgProfileImages";
            this.imgProfileImages.Size = new System.Drawing.Size(673, 583);
            this.imgProfileImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgProfileImages.TabIndex = 224;
            this.imgProfileImages.TabStop = false;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(15, 0);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(197, 60);
            this.lblMainTitle.TabIndex = 59;
            this.lblMainTitle.Text = "PROFILE";
            // 
            // bntHome
            // 
            this.bntHome.BackColor = System.Drawing.Color.ForestGreen;
            this.bntHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntHome.ForeColor = System.Drawing.Color.White;
            this.bntHome.Image = ((System.Drawing.Image)(resources.GetObject("bntHome.Image")));
            this.bntHome.Location = new System.Drawing.Point(127, 594);
            this.bntHome.Margin = new System.Windows.Forms.Padding(4);
            this.bntHome.Name = "bntHome";
            this.bntHome.Size = new System.Drawing.Size(121, 128);
            this.bntHome.TabIndex = 16;
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
            this.bntDelete.Location = new System.Drawing.Point(4, 594);
            this.bntDelete.Margin = new System.Windows.Forms.Padding(4);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(121, 128);
            this.bntDelete.TabIndex = 25;
            this.bntDelete.Text = "DELETE";
            this.bntDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntDelete.UseVisualStyleBackColor = false;
            this.bntDelete.Click += new System.EventHandler(this.bntDelete_Click);
            // 
            // bntClear
            // 
            this.bntClear.BackColor = System.Drawing.Color.Firebrick;
            this.bntClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntClear.ForeColor = System.Drawing.Color.White;
            this.bntClear.Image = ((System.Drawing.Image)(resources.GetObject("bntClear.Image")));
            this.bntClear.Location = new System.Drawing.Point(4, 465);
            this.bntClear.Margin = new System.Windows.Forms.Padding(4);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(121, 128);
            this.bntClear.TabIndex = 23;
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
            this.bntCancel.Location = new System.Drawing.Point(127, 465);
            this.bntCancel.Margin = new System.Windows.Forms.Padding(4);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(121, 128);
            this.bntCancel.TabIndex = 24;
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
            this.bntSave.Location = new System.Drawing.Point(4, 336);
            this.bntSave.Margin = new System.Windows.Forms.Padding(4);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(244, 128);
            this.bntSave.TabIndex = 20;
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
            this.bntUpdate.Location = new System.Drawing.Point(127, 207);
            this.bntUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.Size = new System.Drawing.Size(121, 128);
            this.bntUpdate.TabIndex = 22;
            this.bntUpdate.Text = "EDIT";
            this.bntUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntUpdate.UseVisualStyleBackColor = false;
            this.bntUpdate.Click += new System.EventHandler(this.bntUpdate_Click);
            // 
            // bntInsert
            // 
            this.bntInsert.BackColor = System.Drawing.Color.Red;
            this.bntInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntInsert.ForeColor = System.Drawing.Color.White;
            this.bntInsert.Image = ((System.Drawing.Image)(resources.GetObject("bntInsert.Image")));
            this.bntInsert.Location = new System.Drawing.Point(4, 207);
            this.bntInsert.Margin = new System.Windows.Forms.Padding(4);
            this.bntInsert.Name = "bntInsert";
            this.bntInsert.Size = new System.Drawing.Size(121, 128);
            this.bntInsert.TabIndex = 21;
            this.bntInsert.Text = "ADD";
            this.bntInsert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntInsert.UseVisualStyleBackColor = false;
            this.bntInsert.Click += new System.EventHandler(this.bntInsert_Click);
            // 
            // pnlRightOptions
            // 
            this.pnlRightOptions.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlRightOptions.Controls.Add(this.pcRight);
            this.pnlRightOptions.Controls.Add(this.pnlRightMain);
            this.pnlRightOptions.Location = new System.Drawing.Point(1728, 1);
            this.pnlRightOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRightOptions.Name = "pnlRightOptions";
            this.pnlRightOptions.Size = new System.Drawing.Size(103, 942);
            this.pnlRightOptions.TabIndex = 65;
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
            this.pbExit.Location = new System.Drawing.Point(4, 551);
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
            this.pnlOptions.Location = new System.Drawing.Point(-3, 850);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1731, 91);
            this.pnlOptions.TabIndex = 64;
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
            // RightOptions
            // 
            this.RightOptions.Interval = 1;
            this.RightOptions.Tick += new System.EventHandler(this.RightOptions_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(377, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 144;
            this.label1.Text = "Department:";
            // 
            // FrmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1827, 944);
            this.Controls.Add(this.pnlRightOptions);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee Registration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRegistration_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmRegistration_MouseMove);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLOG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraControl)).EndInit();
            this.xtraControl.ResumeLayout(false);
            this.xtraProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GbPersonal)).EndInit();
            this.GbPersonal.ResumeLayout(false);
            this.GbPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbCON)).EndInit();
            this.gbCON.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtlProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProfile)).EndInit();
            this.xtraAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupAddress)).EndInit();
            this.groupAddress.ResumeLayout(false);
            this.groupAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtraContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupContact)).EndInit();
            this.groupContact.ResumeLayout(false);
            this.groupContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.xtraImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProfileImages)).EndInit();
            this.pnlRightOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcRight)).EndInit();
            this.pnlRightMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
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

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Button bntHome;
        private System.Windows.Forms.Button bntDelete;
        private System.Windows.Forms.Button bntClear;
        private System.Windows.Forms.Button bntCancel;
        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.Button bntUpdate;
        private System.Windows.Forms.Button bntInsert;
        private System.Windows.Forms.Panel pnlRightOptions;
        private System.Windows.Forms.PictureBox pcRight;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.PictureBox pbLogout;
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
        private DevExpress.XtraTab.XtraTabControl xtraControl;
        private DevExpress.XtraTab.XtraTabPage xtraProfile;
        private DevExpress.XtraEditors.GroupControl GbPersonal;
        private DevExpress.XtraEditors.GroupControl gbCON;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblHiredate;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.DateTimePicker dkpDateHired;
        private System.Windows.Forms.Label lblPostion;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.TextBox txtProfileID;
        private System.Windows.Forms.Label lblCivilStatus;
        private System.Windows.Forms.ComboBox cmbCivilStatus;
        private System.Windows.Forms.PictureBox imgProfile;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtPhilhealthNumber;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblPhilhealth;
        private System.Windows.Forms.ComboBox cmbProvince;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSSSNumber;
        private System.Windows.Forms.Label lblSSS;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblProvicen;
        private System.Windows.Forms.Label lblDatebirth;
        private System.Windows.Forms.DateTimePicker dkpBirthdate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbgender;
        private System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.Label lblMiddleInitial;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.TextBox txtPIR;
        private DevExpress.XtraTab.XtraTabPage xtraContact;
        private System.Windows.Forms.Timer Options;
        private System.Windows.Forms.Timer RightOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dkpDateRegistered;
        private DevExpress.XtraGrid.GridControl gridCtlProfile;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProfile;
        private DevExpress.XtraGrid.Views.Grid.GridView grdHIS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDept;
        private DevExpress.XtraTab.XtraTabPage xtraAddress;
        private DevExpress.XtraEditors.GroupControl groupAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddressID;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControlAddress;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAddress;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBarangay;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dkpDateRegister;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox txtProvince;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox17;
        private DevExpress.XtraEditors.GroupControl groupContact;
        private System.Windows.Forms.TextBox txtFaxNumber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtWebUrl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSecondMobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContactId;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControlContact;
        private DevExpress.XtraGrid.Views.Grid.GridView gridContact;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dkpContactDateReg;
        private System.Windows.Forms.TextBox txtFirstMobile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPositionName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.PictureBox pcLOG;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtContactBarcode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBarcodeAddress;
        private DevExpress.XtraTab.XtraTabPage xtraImage;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dkpImgCreadOn;
        private DevExpress.XtraEditors.SimpleButton bntBrowseImage;
        private DevExpress.XtraEditors.SimpleButton bntSaveImages;
        private System.Windows.Forms.ComboBox cmbProfileImgType;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtProfileImgFileName;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtProfileImgTitle;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtProfileImgBarcode;
        private System.Windows.Forms.PictureBox imgProfileImages;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashManager;
    }
}