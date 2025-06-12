using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.Entities;
using ServeAll.Core.Entities;
using ServeAll.Core.Entities.request;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;

namespace Inventory.MainForm
{
    public partial class FrmServices : Form
    {
        private int _deliver;
        private readonly int _userId;
        private readonly int _userTyp;
        private readonly string _userName;
        private IEnumerable<RequestProducts> _products;
        private IEnumerable<ViewRequestCategory> _category;
        private IEnumerable<ViewRequestStaff> _staff;
        private IEnumerable<ServiceStatus> _service_statuses;
        private IEnumerable<ViewServices> _services_list;
        private IEnumerable<ViewServiceImages> _service_image_list;
        private IEnumerable<Warehouse> _warehouse;
        public int Deliver
        {
            get { return _deliver; }
            set
            {
                _deliver = value;
                if (_deliver > 0)
                {
                    
                }
            }
        }
        private bool _extInvent;
        public bool ExiInven
        {
            get { return _extInvent; }
            set
            {
                _extInvent = value;
                if (_extInvent)
                    Close();
                FirmMain main = new FirmMain(_userId, _userTyp, _userName);
                main.Show();
            }
        }
        private FirmMain _main;
        private bool _add, _edt, _del;
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }
        public FrmServices(int userId, int userTy, string username)
        {
            _userName = username;
            _userId = userId;
            _userTyp = userTy;
            if (_userTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            _services_list = EnumerableUtils.getServicesList();
            _service_image_list = EnumerableUtils.getServiceImgList();
            gridServices.FocusedRowChanged += gridInventory_FocusedRowChanged;
            gridServices.Click += gridInventory_Click;
        }

        private void FirmWarehouseInvetory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            _products = EnumerableUtils.getProductWarehouseList();
            _category = EnumerableUtils.getRequestCategoryList();
            _staff = EnumerableUtils.getStaffList();
            _service_statuses = EnumerableUtils.getServiceStatusList();
            _warehouse = EnumerableUtils.getWarehouse();
            bindServices();
        }
        private ViewServiceImages searchServiceImg(string param)
        {
            return _service_image_list.FirstOrDefault(img => img.image_code == param);
        }

        private string selectedCode(int seletedIndex)
        {
            return _products.FirstOrDefault(i => i.product_id == seletedIndex).product_code;
        }

        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridServices.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                        cmbOperator.Text = _userName;
                        txtServiceId.Text = id;
                        txtServiceName.Text = ((GridView)sender).GetFocusedRowCellValue("ServiceName").ToString();
                        txtServiceDescription.Text = ((GridView)sender).GetFocusedRowCellValue("Details").ToString();
                        cmbServiceCategory.Text = ((GridView)sender).GetFocusedRowCellValue("Category").ToString();
                        txtServiceCharges.Text = ((GridView)sender).GetFocusedRowCellValue("Charges").ToString();
                        txtServiceCommision.Text = ((GridView)sender).GetFocusedRowCellValue("Commision").ToString();
                        cmbOperator.Text = ((GridView)sender).GetFocusedRowCellValue("User").ToString();
                        cmbStaff.Text = ((GridView)sender).GetFocusedRowCellValue("Staff").ToString();
                        cmbServiceStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status").ToString();
                        txtBarcode.Text = barcode;
                        txtServiceImgBarcode.Text = barcode;
                        txtServiceImgTitle.Text = ((GridView)sender).GetFocusedRowCellValue("ServiceName").ToString();
                        dpkServiceDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Date");
                        dpkCreatedDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Created");
                        dpkUpdated.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Updated");

                        var img = searchServiceImg(barcode);
                        var imgLocation = img?.img_location;

                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgProduct.ImageLocation = ConstantUtils.defaultImgEmpty;
                            imgServiceImages.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgProduct.ImageLocation = location;
                            imgServiceImages.ImageLocation = location;
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void gridInventory_Click(object sender, EventArgs e)
        {
            if (gridServices.RowCount > 0)
                InputWhit();
            bntCancel.Enabled = true;
        }

        private void addInventory()
        {
            var category = cmbServiceCategory.Text.Trim(' ');
            var staff = cmbStaff.Text.Trim(' ');
            var operators = cmbOperator.Text.Trim(' ');
            var statusId = FetchUtils.getServiceStatusId(cmbServiceStatus.Text.Trim(' '));
            var staffId = FetchUtils.getStaffId(staff);
            if (staffId > 0 || statusId > 0)
            {
                var categoryId = FetchUtils.getCategoryId(category);
                var operatorId = FetchUtils.getUserId(operators);
                ServeAll.Core.Entities.Services services = new ServeAll.Core.Entities.Services
                {
                    service_code = txtBarcode.Text.Trim(' '),
                    service_name = txtServiceName.Text.Trim(' '),
                    service_details = txtServiceDescription.Text.Trim(' '),
                    service_charges = decimal.Parse(txtServiceCharges.Text.Trim(' ')),
                    category_id = categoryId,
                    service_commission = decimal.Parse(txtServiceCommision.Text.Trim(' ')),
                    user_id = operatorId,
                    employee_id = staffId,
                    status_id = statusId,
                    service_date = dpkServiceDate.Value.Date,
                    created_date = dpkCreatedDate.Value.Date,
                    updated_date = dpkUpdated.Value.Date
                };
                var result = RepositoryEntity.AddEntity<ServeAll.Core.Entities.Services>(services);
                if (result > 0L)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.ErrorInsert,
                            Messages.TitleFailedInsert);
                }
            }
            else {
                splashScreen.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "Status Id and Staff Id must not be null!",
                            Messages.TitleFailedInsert);
            }
        }

        private void editInventory()
        {
            var serviceId = int.Parse(txtServiceId.Text.Trim(' '));
            if (serviceId > 0)
            {
                int result = RepositoryEntity.UpdateEntity<ServeAll.Core.Entities.Services>(serviceId, entity =>
                {
                    entity.service_code = txtBarcode.Text.Trim(' ');
                    entity.service_name = txtServiceName.Text.Trim(' ');
                    entity.service_charges = decimal.Parse(txtServiceCharges.Text);
                    entity.category_id = FetchUtils.getCategoryId(cmbServiceCategory.Text.Trim(' '));
                    entity.service_commission = decimal.Parse(txtServiceCommision.Text);
                    entity.user_id = FetchUtils.getUserId(cmbOperator.Text);
                    entity.employee_id = FetchUtils.getStaffId(cmbStaff.Text);
                    entity.status_id = FetchUtils.getServiceStatusId(cmbServiceStatus.Text);
                    entity.service_date = dpkServiceDate.Value.Date;
                    entity.created_date = dpkCreatedDate.Value.Date;
                    entity.updated_date = dpkUpdated.Value.Date;
                });
                if (result > 0)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                           Messages.TitleSuccessUpdate);
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.ErrorUpdate,
                            Messages.TitleFialedUpdate);
                }
            }
        }
        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if (que <= 0) return;
            var log = new FirmLogin();
            log.Show();
            Close();
        }
        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }

        private void InputWhit()
        {
            txtServiceId.BackColor = Color.White;
            txtServiceName.BackColor = Color.White;
            txtServiceDescription.BackColor = Color.White;
            txtServiceCharges.BackColor = Color.White;
            cmbServiceCategory.BackColor = Color.White;
            txtServiceCommision.BackColor = Color.White;
            txtBarcode.BackColor = Color.White;
            cmbOperator.BackColor = Color.White;
            cmbStaff.BackColor = Color.White;
            cmbServiceStatus.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtServiceName.Enabled = true;
            txtServiceDescription.Enabled = true;
            txtServiceCharges.Enabled = true;
            cmbServiceCategory.Enabled = true;
   
            txtServiceCommision.Enabled = true;
      
            dpkServiceDate.Enabled = true;
            dpkCreatedDate.Enabled = true;
            dpkUpdated.Enabled = true;
            cmbOperator.Enabled = true;
            cmbStaff.Enabled = true;
            cmbServiceStatus.Enabled = true;
        }
        private void InputDisb()
        {
            txtServiceName.Enabled = false;
            txtServiceDescription.Enabled = false;
            txtServiceCharges.Enabled = false;
            cmbServiceCategory.Enabled = false;
            txtServiceCommision.Enabled = false;
            txtBarcode.Enabled = false;
            dpkServiceDate.Enabled = false;
            dpkCreatedDate.Enabled = false;
            dpkUpdated.Enabled = false;
            cmbOperator.Enabled = false;
            cmbStaff.Enabled = false;
            cmbServiceStatus.Enabled = false;
        }
        private void InputClea()
        {
            txtServiceId.Clear();
            txtServiceName.Clear();
            txtServiceDescription.Clear();
            txtServiceCharges.Clear();
            cmbServiceCategory.Text = "";
            txtServiceCommision.Clear();
            txtBarcode.Text = "";
            dpkServiceDate.Value = DateTime.Now.Date;
            dpkCreatedDate.Value = DateTime.Now.Date;
            dpkUpdated.Value = DateTime.Now.Date;
            cmbOperator.Text = "";
            cmbStaff.Text = "";
            cmbServiceStatus.Text = "";
            dpkServiceDate.Value = DateTime.Now.Date;
            cmbOperator.Text = "";
        }
        private void InputDimG()
        {
            txtServiceId.BackColor = Color.DimGray;
            txtServiceName.BackColor = Color.DimGray;
            txtServiceDescription.BackColor = Color.DimGray;
            txtServiceCharges.BackColor = Color.DimGray;
            cmbServiceCategory.BackColor = Color.DimGray;
            txtServiceCommision.BackColor = Color.DimGray;
            txtBarcode.BackColor = Color.DimGray;
            cmbOperator.BackColor = Color.DimGray;
            cmbStaff.BackColor = Color.DimGray;
            cmbServiceStatus.BackColor = Color.DimGray;
        }
       
         
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var proId = Convert.ToInt32(txtServiceId.Text);
                    var repository = new Repository<WareHouse>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        unWork.Commit();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);

                }
            }
        }

        private void clearGrid()
        {
            gridController.DataSource = null;
            gridController.DataSource = "";
            gridServices.Columns.Clear();
        }

        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            InputClea();
            cmbOperator.Text = _userName;
            cmbStaff.Text = Constant.DefaultSource;
            _add = true;
            _edt = false;
            _del = false;
            gridController.Enabled = false;
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
            cmbServiceCategory.DataBindings.Clear();
            cmbServiceStatus.DataBindings.Clear();
            cmbStaff.DataBindings.Clear();
            cmbServiceCategory.DataSource = _category.Select(p => p.category_details).ToList();
            cmbStaff.DataSource = _staff.Select(p => p.staff).ToList();
            cmbServiceStatus.DataSource = _service_statuses.Select(p => p.status_name).ToList();
            txtServiceName.Focus();
            generateLastServiceCode();
        }
        private void ButtonAdd()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonUpd()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonDel()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = true;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonSav()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonClr()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = false;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonCan()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButUpd()
        {
            ButtonUpd();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = true;
            _del = false;
            gridController.Enabled = false;
        
        }
        private void ButDel()
        {
            ButtonDel();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gridController.Enabled = false;
        }
        private void ButSav()
        {
            splashScreen.ShowWaitForm();
            if (_add && _edt == false && _del == false)
            {
                addInventory();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt && _del == false)
            {

                editInventory();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt == false && _del)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridController.Enabled = true;
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
            _services_list = EnumerableUtils.getServicesList();
            bindServices();
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gridController.Enabled = true;
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
         
        }
        private void ButClr()
        {
            bindServices();
            ButtonClr();
            InputClea();
            InputWhit();
            InputDisb();
            gridController.Enabled = true;
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            ButAdd();
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            ButSav();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
        }



        private void bntDelete_Click(object sender, EventArgs e)
        {
            ButDel();
        }
     
        private void FirmWarehouseInvetory_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void cmbServiceStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbServiceStatus.DataBindings.Clear();
                cmbServiceStatus.DataSource = _service_statuses.Select(p => p.status_name).ToList();
            }
        }
        private void cmbServiceCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbServiceCategory.DataBindings.Clear();
                cmbServiceCategory.DataSource = _category.Select(p => p.category_details).ToList();
            }
        }

        private void cmbStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbStaff.DataBindings.Clear();
                cmbStaff.DataSource = _staff.Select(p => p.staff).ToList();
            }
        }

        private void pcUser_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void bntBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    string fileNameAndExtension = getfileExntesion(selectedFilePath);
                    txtServiceImgFileName.Text = fileNameAndExtension;

                    if (imgServiceImages.Image != null)
                    {
                        imgServiceImages.Image.Dispose();
                        imgServiceImages.Image = null;
                    }

                    try
                    {
                        using (var stream = new MemoryStream(File.ReadAllBytes(selectedFilePath)))
                        {
                            imgServiceImages.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        imgServiceImages.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    bntSaveImages.Enabled = true;
                    bntBrowseImage.Enabled = false;
                }
            }
        }

        private string getfileExntesion(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void bntSaveImages_Click(object sender, EventArgs e)
        {
            var code = txtServiceImgBarcode.Text.Trim(' ');
            var title = txtServiceImgTitle.Text.Trim(' ');
            var imgtype = cmbServiceImgType.Text.Trim(' ');
            var imgLocation = txtServiceImgFileName.Text.Trim(' ');
            if (code.Length > 0 && title.Length > 0 && imgtype.Length > 0 && imgLocation.Length > 0)
            {
                saveProductImage();
                bntSaveImages.Enabled = false;
                bntBrowseImage.Enabled = true;
                _service_image_list = EnumerableUtils.getServiceImgList();
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Please fill all the entries!", Messages.TitleFailedInsert);
            }
        }

        private string ExtractFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }
        private void txtServiceName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) {
                txtServiceDescription.Focus();
            }
        }
        private void saveProductImage()
        {
            var filePathLocation = txtServiceImgFileName.Text.Trim(' ');
            var filePath = ExtractFileName(filePathLocation);
            var img = new ServiceImages()
            {
                image_code = txtServiceImgBarcode.Text.Trim(' '),
                title = txtServiceImgTitle.Text.Trim(' '),
                img_type = cmbServiceImgType.Text.Trim(' '),
                img_location = filePath,
                created_on = DateTime.Now,
                updated_on = DateTime.Now
            };
            var result = RepositoryEntity.AddEntity<ServiceImages>(img);
            if (result > 0)
            {
                PopupNotification.PopUpMessages(1, "Service image: " + txtServiceImgTitle.Text.Trim(' ') + " " + Messages.SuccessInsert,
                 Messages.TitleSuccessInsert);
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Service image: " + txtServiceImgTitle.Text.Trim(' ') + " " + Messages.ErrorInsert,
                 Messages.TitleFailedInsert);
            }
        }

        private void GridServices_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
            bntCancel.Enabled = true;
        }

        private void GridServices_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }

        private void generateLastServiceCode()
        {
            var lastProductId = FetchUtils.getLastServiceId();
            var alphaNumeric = new GenerateAlpaNum("S", 3, lastProductId);
            alphaNumeric.Increment();
            txtBarcode.Text = alphaNumeric.ToString();
        }

        private void bindServices()
        {
            clearGrid();
            var list = _services_list.Select(p => new {
                Id = p.service_id,
                Barcode = p.service_code,
                ServiceName = p.service_name,
                Details = p.service_details,
                Category = p.category,
                Charges = p.service_charges,
                Commision = p.service_commission,
                User = p.username,
                Staff = p.staff,
                Status = p.status,
                Date = p.service_date,
                Created = p.created_date,
                Updated = p.updated_date
            }).ToList();
            gridController.DataSource = list;
            gridController.Update();
            if (gridServices.RowCount > 0)
                gridServices.Columns[0].Width = 40;
            gridServices.Columns[1].Width = 90;
            gridServices.Columns[2].Width = 200;
            gridServices.Columns[3].Width = 140;
            gridServices.Columns[4].Width = 90;
            gridServices.Columns[5].Width = 100;
            gridServices.Columns[6].Width = 100;
            gridServices.Columns[7].Width = 90;
            gridServices.Columns[8].Width = 90;
            gridServices.Columns[9].Width = 100;
            gridServices.Columns[10].Width = 100;
            gridServices.Columns[11].Width = 100;
            gridServices.Columns[12].Width = 100;
        }

    }
}
