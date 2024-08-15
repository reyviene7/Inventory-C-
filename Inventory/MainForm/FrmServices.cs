using System;
using System.Collections.Generic;
using System.Drawing;
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
        private int _branchId;
        private int _deliver;
        private readonly int _userId;
        private readonly int _userTyp;
        private readonly string _userName;
        private IEnumerable<RequestProducts> _products;
        private IEnumerable<ViewRequestCategory> _category;
        private IEnumerable<users> _staff;
        private IEnumerable<Location> _locations;
        private IEnumerable<ViewServices> _services_list;
        private IEnumerable<ViewImageProduct> imgList;
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
                var main = new FirmMain(_userId, _userTyp, _userName);
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
            InitializeComponent();
            _services_list = EnumerableUtils.getServicesList();
            imgList = EnumerableUtils.getImgProductList();
            gridInventory.FocusedRowChanged += gridInventory_FocusedRowChanged;
            gridInventory.Click += gridInventory_Click;
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
            _staff = EnumerableUtils.getUserNameList();
            _locations = EnumerableUtils.getLocationWarehouseList();
            bindWareHouse();
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }

        private string selectedCode(int seletedIndex)
        {
            return _products.FirstOrDefault(i => i.product_id == seletedIndex).product_code;
        }

        private void generateLastServiceCode()
        {
            var lastProductId = FetchUtils.getLastServiceId();
            var alphaNumeric = new GenerateAlpaNum("S", 3, lastProductId);
            alphaNumeric.Increment();
            txtBarcode.Text = alphaNumeric.ToString();
        }

        private void bindWareHouse()
        {
            clearGrid();
            var list = _services_list.Select(p => new { 
                Id = p.service_id,
                Barcode = p.service_code,
                ServiceName = p.service_name,
                Category = p.category,
                Charges = p.service_charges,
                Commision = p.service_commission,
                Duration = p.service_duration,
                User = p.username,
                Staff = p.staff,
                Status = p.service_status,
                Date = p.service_date,
                Created = p.created_date,
                Updated = p.updated_date
            }).ToList();
            gridController.DataSource = list;
            gridController.Update();
            if(gridInventory.RowCount > 0)
                gridInventory.Columns[0].Width = 40;
                gridInventory.Columns[1].Width = 90;
                gridInventory.Columns[2].Width = 200;
                gridInventory.Columns[3].Width = 140;
                gridInventory.Columns[4].Width = 90;
                gridInventory.Columns[5].Width = 100;
                gridInventory.Columns[6].Width = 100;
                gridInventory.Columns[7].Width = 90;
                gridInventory.Columns[8].Width = 90;
                gridInventory.Columns[9].Width = 100;
                gridInventory.Columns[10].Width = 100;
                gridInventory.Columns[11].Width = 100;
                gridInventory.Columns[12].Width = 100;
        }

        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridInventory.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                        cmbOperator.Text = _userName;
                        txtServiceId.Text = id;
                        txtServiceName.Text = ((GridView)sender).GetFocusedRowCellValue("ServiceName").ToString();
                        cmbServiceCategory.Text = ((GridView)sender).GetFocusedRowCellValue("Category").ToString();
                        txtServiceCharges.Text = ((GridView)sender).GetFocusedRowCellValue("Charges").ToString();
                        txtServiceCommision.Text = ((GridView)sender).GetFocusedRowCellValue("Commision").ToString();
                        txtServiceDuration.Text = ((GridView)sender).GetFocusedRowCellValue("Duration").ToString();
                        cmbOperator.Text = ((GridView)sender).GetFocusedRowCellValue("User").ToString();
                        cmbStaff.Text = ((GridView)sender).GetFocusedRowCellValue("Staff").ToString();
                        cmbServiceStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status").ToString();
                        txtBarcode.Text = barcode;
                        dpkServiceDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Date");
                        dpkCreatedDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Created");
                        dpkUpdated.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Updated");
                        var img = searchProductImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgProduct.ImageLocation = location;
                        }
                        else
                            imgProduct.Image = null;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void gridInventory_Click(object sender, EventArgs e)
        {
            if (gridInventory.RowCount > 0)
                InputWhit();
            bntClear.Enabled = true;
        }

        private void addInventory()
        {
            var category = cmbServiceCategory.Text.Trim(' ');
            var staff = cmbStaff.Text.Trim(' ');
            var operators = cmbOperator.Text.Trim(' ');
            if (category.Length > 0)
            {
                var categoryId = FetchUtils.getCategoryId(category);
                var staffId = FetchUtils.getUserId(staff);
                var operatorId = FetchUtils.getUserId(operators);
  
                ServeAll.Core.Entities.Services services = new ServeAll.Core.Entities.Services
                {
                        service_code = txtBarcode.Text.Trim(' '),
                        service_name = txtServiceName.Text.Trim(' '),
                        service_details = txtServiceDescription.Text.Trim(' '),
                        service_charges = decimal.Parse(txtServiceCharges.Text.Trim(' ')),
                        category_id = categoryId,
                        service_duration = int.Parse(txtServiceDuration.Text.Trim(' ')),
                        service_commission = int.Parse(txtServiceCommision.Text.Trim(' ')),
                        user_id = operatorId,
                        staff_id = staffId,
                        service_status = cmbServiceStatus.Text.Trim(' '),
                        service_date = dpkServiceDate.Value.Date,
                        created_date = dpkCreatedDate.Value.Date,
                        updated_date = dpkUpdated.Value.Date
                };
                var result = RepositoryEntity.AddEntity<ServeAll.Core.Entities.Services>(services);
                if (result > 0L)
                {
                    PopupNotification.PopUpMessages(1, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                } else
                {
                    PopupNotification.PopUpMessages(0, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.ErrorInsert,
                            Messages.TitleFailedInsert);
                }
            }
        }

        private void editInventory()
        {
            var inventoryId = int.Parse(txtServiceId.Text.Trim(' '));
            if (inventoryId > 0)
            {
               
                var supplier = cmbServiceCategory.Text.Trim(' ');
                var location = cmbStaff.Text.Trim(' ');
                var status = cmbServiceStatus.Text.Trim(' ');
              
                var supplierId = FetchUtils.getSupplierId(supplier);
                var locationId = FetchUtils.getLocationId(location);
                var statusId = FetchUtils.getStatusId(status);
                var qtyStock = int.Parse(txtServiceDescription.Text.Trim(' '));
                var reoderLevel = int.Parse(txtServiceCharges.Text.Trim(' '));
                var unitCost = decimal.Parse(txtServiceDuration.Text.Trim(' '));
                var lastCost = decimal.Parse(txtServiceCommision.Text.Trim(' '));
                int result = RepositoryEntity.UpdateEntity<WarehouseInventory>(inventoryId, entity =>
                {
                    entity.product_id = 1;
                    entity.sku = txtServiceName.Text.Trim(' ');
                    entity.quantity_in_stock = qtyStock;
                    entity.reorder_level = reoderLevel;
                    entity.location_id = locationId;
                    entity.warehouse_id = 1;
                    entity.user_id = _userId;
                    entity.supplier_id = supplierId;
                    entity.last_stocked_date = dpkServiceDate.Value.Date;
                   
                    entity.cost_per_unit = unitCost;
                    entity.last_cost_per_unit = lastCost;
                    entity.status_id = statusId;
                    entity.created_at = dpkCreatedDate.Value.Date;
                    entity.updated_at = dpkUpdated.Value.Date;
                });
                if (result > 0)
                {
                  
                }
                else
                {
                   
                }
            }
        }

        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbLogout_Click(object sender, EventArgs e)
        {

        }
        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbExit_Click(object sender, EventArgs e)
        {

        }

        private void InputWhit()
        {
            txtServiceId.BackColor = Color.White;
            txtServiceName.BackColor = Color.White;
            txtServiceDescription.BackColor = Color.White;
            txtServiceCharges.BackColor = Color.White;
            cmbServiceCategory.BackColor = Color.White;
            txtServiceDuration.BackColor = Color.White;
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
            txtServiceDuration.Enabled = true;
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
            txtServiceDuration.Enabled = false;
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
            txtServiceDuration.Clear();
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
            txtServiceDuration.BackColor = Color.DimGray;
            txtServiceCommision.BackColor = Color.DimGray;
       
            txtBarcode.BackColor = Color.DimGray;
            cmbOperator.BackColor = Color.DimGray;
            cmbStaff.BackColor = Color.DimGray;
            cmbServiceStatus.BackColor = Color.DimGray;
        }
       
        private void GenerateCode()
        {
            
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
            gridInventory.Columns.Clear();
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
            cmbStaff.DataBindings.Clear();
            cmbServiceCategory.DataSource = _category.Select(p => p.category_details).ToList();
            cmbStaff.DataSource = _staff.Select(p => p.username).ToList();
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
            inventoryScreen.ShowWaitForm();
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

            InputWhit();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
        }



        private void bntDelete_Click(object sender, EventArgs e)
        {

           
        }

        private void bindImage(string barcode)
        {
            var img = searchProductImg(barcode);
            var imgLocation = img.img_location;
            if (imgLocation.Length > 0)
            {
                var location = ConstantUtils.defaultImgLocation + imgLocation;

                imgProduct.ImageLocation = location;
            }
            else
                imgProduct.Image = null;
        }

     
        private void FirmWarehouseInvetory_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }

     

    }
}
