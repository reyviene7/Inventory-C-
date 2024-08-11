using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using Inventory.Config;
using Inventory.Entities;
using ServeAll.Core.Entities;
using ServeAll.Core.Entities.request;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;

namespace Inventory.MainForm
{
    public partial class FirmWarehouseInvetory : Form
    {
        private int _branchId;
        private int _deliver;
        private string _branch;
        private readonly int _userId;
        private readonly int _userTyp;
        private readonly string _userName;
        private IEnumerable<RequestProducts> _products;
        private IEnumerable<RequestSupplier> _suppliers;
        private IEnumerable<WarehouseStatus> _statuses;
        private IEnumerable<Location> _locations;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;
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
        public int BranchId
        {
            get { return _branchId; }
            set
            {
                _branchId = value;
                cmbItemLocation.Text = _branch;
               
            }
        }
        private FirmMain _main;
        private bool _add, _edt, _del;
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }
        public FirmWarehouseInvetory(int userId, int userTy, string username)
        {
            _userName = username;
            _userId = userId;
            _userTyp = userTy;
            InitializeComponent();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            imgList = EnumerableUtils.getImgProductList();
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
            _suppliers = EnumerableUtils.getSupplierWarehouseList();
            _statuses = EnumerableUtils.getStatusWarehouseList();
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

        private void bindWareHouse()
        {
            clearGrid();
            var list = _warehouse_list.Select(p => new { 
                Id = p.inventory_id,
                Barcode = p.product_code,
                SKU = p.sku,
                QtyStock = p.quantity_in_stock,
                ReOrder = p.reorder_level,
                Location = p.location_code,
                Supplier = p.supplier_name,
                LastStocked = p.last_stocked_date,
                LastOrder = p.last_ordered_date,
                Expiration = p.expiration_date,
                UnitCost = p.cost_per_unit,
                LastCost = p.last_cost_per_unit,
                Total = p.total_value,
                Created = p.created_at,
                Updated = p.updated_at
            }).ToList();
            gridController.DataSource = list;
            gridController.Update();
        }

        private void addInventory()
        {
            var item = cmbProductName.Text.Trim(' ');
            var supplier = cmbSupplier.Text.Trim(' ');
            var location = cmbItemLocation.Text.Trim(' ');
            var status = cmbStatus.Text.Trim(' ');
            if (item.Length > 0)
            {
                var productId = FetchUtils.getProductId(item);
                var supplierId = FetchUtils.getSupplierId(supplier);
                var locationId = FetchUtils.getLocationId(location);
                var statusId = FetchUtils.getStatusId(status);
                var qtyStock = int.Parse(txtQuantityStock.Text.Trim(' '));
                var reoderLevel = int.Parse(txtReorderLevel.Text.Trim(' '));
                var unitCost = decimal.Parse(txtCostPerUnit.Text.Trim(' '));
                var lastCost = decimal.Parse(txtLastCostPerUnit.Text.Trim(' '));
                WarehouseInventory warehouse = new WarehouseInventory
                {
                    product_id = productId,
                    sku = txtWarehouseSKU.Text.Trim(' '),
                    quantity_in_stock = qtyStock,
                    reorder_level = reoderLevel,
                    location_id = locationId,
                    warehouse_id = 1,
                    user_id = _userId,
                    supplier_id = supplierId,
                    last_stocked_date = dkpLastStockedDate.Value.Date,
                    last_ordered_date = dkpLastOrderDate.Value.Date,
                    expiration_date = dpkExpirationDate.Value.Date,
                    cost_per_unit = unitCost,
                    last_cost_per_unit = lastCost,
                    status_id = statusId,
                    created_at = dpkCreatedDate.Value.Date,
                    updated_at = dpkLastUpdated.Value.Date
                };
                var result = RepositoryEntity.AddEntity<WarehouseInventory>(warehouse);
                if (result > 0L)
                {
                    PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessInsert + " to warehouse inventory!", Messages.TitleSuccessInsert);
                    _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                    bindWareHouse();
                } else
                {
                    PopupNotification.PopUpMessages(0, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.TitleFailedInsert + " to warehouse inventory!", Messages.TitleFailedInsert);
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
       

        private void gridInventory_Click(object sender, EventArgs e)
        {
            if (gridInventory.RowCount > 0)
                InputWhit();
                bntClear.Enabled = true;
        }
        private void InputWhit()
        {
            txtInventoryId.BackColor = Color.White;
            txtWarehouseSKU.BackColor = Color.White;
            cmbProductName.BackColor = Color.White;
            txtQuantityStock.BackColor = Color.White;
            txtReorderLevel.BackColor = Color.White;
            cmbSupplier.BackColor = Color.White;
            txtCostPerUnit.BackColor = Color.White;
            txtLastCostPerUnit.BackColor = Color.White;
            txtTotalValue.BackColor = Color.White;
            cmbWarranty.BackColor = Color.White;
            cmbUser.BackColor = Color.White;
            cmbItemLocation.BackColor = Color.White;
            cmbStatus.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtWarehouseSKU.Enabled = true;
            cmbProductName.Enabled = true;
            txtQuantityStock.Enabled = true;
            txtReorderLevel.Enabled = true;
            cmbSupplier.Enabled = true;
            txtCostPerUnit.Enabled = true;
            txtLastCostPerUnit.Enabled = true;
            txtTotalValue.Enabled = false;
            cmbWarranty.Enabled = true;
            dkpLastStockedDate.Enabled = true;
            dkpLastOrderDate.Enabled = true;
            dpkExpirationDate.Enabled = true;
            dpkCreatedDate.Enabled = true;
            dpkLastUpdated.Enabled = true;
            cmbUser.Enabled = true;
            cmbItemLocation.Enabled = true;
            cmbStatus.Enabled = true;
        }
        private void InputDisb()
        {
            txtWarehouseSKU.Enabled = false;
            cmbProductName.Enabled = false;
            txtQuantityStock.Enabled = false;
            txtReorderLevel.Enabled = false;
            cmbSupplier.Enabled = false;
            txtCostPerUnit.Enabled = false;
            txtLastCostPerUnit.Enabled = false;
            txtTotalValue.Enabled = false;
            cmbWarranty.Enabled = false;
            dkpLastStockedDate.Enabled = false;
            dkpLastOrderDate.Enabled = false;
            dpkExpirationDate.Enabled = false;
            dpkCreatedDate.Enabled = false;
            dpkLastUpdated.Enabled = false;
            cmbUser.Enabled = false;
            cmbItemLocation.Enabled = false;
            cmbStatus.Enabled = false;
        }
        private void InputClea()
        {
            txtInventoryId.Clear();
            txtWarehouseSKU.Clear();
            cmbProductName.Text = "";
            txtQuantityStock.Clear();
            txtReorderLevel.Clear();
            cmbSupplier.Text = "";
            txtCostPerUnit.Clear();
            txtLastCostPerUnit.Clear();
            txtTotalValue.Clear();
            cmbWarranty.Text = "";
            dkpLastStockedDate.Value = DateTime.Now.Date;
            dkpLastOrderDate.Value = DateTime.Now.Date;
            dpkExpirationDate.Value = DateTime.Now.Date;
            dpkCreatedDate.Value = DateTime.Now.Date;
            dpkLastUpdated.Value = DateTime.Now.Date;
            cmbUser.Text = "";
            cmbItemLocation.Text = "";
            cmbStatus.Text = "";
            dkpLastStockedDate.Value = DateTime.Now.Date;
            dkpLastOrderDate.Value = DateTime.Now.Date;
            cmbUser.Text = "";
        }
        private void InputDimG()
        {
            txtInventoryId.BackColor = Color.DimGray;
            txtWarehouseSKU.BackColor = Color.DimGray;
            cmbProductName.BackColor = Color.DimGray;
            txtQuantityStock.BackColor = Color.DimGray;
            txtReorderLevel.BackColor = Color.DimGray;
            cmbSupplier.BackColor = Color.DimGray;
            txtCostPerUnit.BackColor = Color.DimGray;
            txtLastCostPerUnit.BackColor = Color.DimGray;
            txtTotalValue.BackColor = Color.DimGray;
            cmbWarranty.BackColor = Color.DimGray;
            cmbUser.BackColor = Color.DimGray;
            cmbItemLocation.BackColor = Color.DimGray;
            cmbStatus.BackColor = Color.DimGray;
        }
       
        private void GenerateCode()
        {
            
        }
         
        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var proId       = Convert.ToInt32(txtInventoryId.Text);
                    var repository  = new Repository<WareHouse>(unWork);
                    var que         = repository.Id(proId);
                    que.Code        = txtWarehouseSKU.Text;
             
                    que.DeliveryNo  = txtQuantityStock.Text;
                    que.ReceiptNo   = txtReorderLevel.Text;
                    que.QtyStock    = Convert.ToDecimal(txtCostPerUnit.Text);
                    
                    que.LastCost    = Convert.ToDecimal(txtLastCostPerUnit.Text);
                    que.OnOrder     = Convert.ToInt32(txtTotalValue.Text);
                    que.PurDate     = dkpLastStockedDate.Value.Date;
                    que.InvDate     = dkpLastOrderDate.Value.Date;
                  
                  
              
                    var result      = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                         Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);

                }
            }
        }
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var proId = Convert.ToInt32(txtInventoryId.Text);
                    var repository = new Repository<WareHouse>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessDelete,
                         Messages.TitleSuccessDelete);
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
            cmbUser.Text = _userName;
            cmbItemLocation.Text = Constant.DefaultSource;
            cmbProductName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridController.Enabled = false;
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
           // cmbProductName.Size = new Size(422, 29);
            cmbProductName.DataBindings.Clear();
            cmbSupplier.DataBindings.Clear();
            cmbStatus.DataBindings.Clear();
            cmbItemLocation.DataBindings.Clear();
            cmbProductName.DataSource = _products.Select(p => p.product_name ).ToList();
            cmbSupplier.DataSource = _suppliers.Select(p => p.supplier_name).ToList();
            cmbStatus.DataSource = _statuses.Select(p => p.status_details).ToList();
            cmbItemLocation.DataSource = _locations.Select(p => p.location_code).ToList();
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

                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList();

            }
            if (_add == false && _edt == false && _del)
            {

                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList();

            }
            _add = false;
            _edt = false;
            _del = false;
            gridController.Enabled = true;
            cmbProductName.DataBindings.Clear();
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
            cmbProductName.DataBindings.Clear();
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
            cmbProductName.Size = new Size(285, 29);
        }
        private void DisplayImage(int imgId)
        {
           
        }
       
        private void BindProductList()
        {
            gridController.Update();
            try
            {
                gridController.DataBindings.Clear();
                gridController.DataSource = null;
                gridController.DataSource = null;
                if (gridInventory.RowCount > 0)
                {
                    gridInventory.Columns[0].Width = 40;
                    gridInventory.Columns[1].Width = 90;
                    gridInventory.Columns[2].Width = 280;
                    gridInventory.Columns[3].Width = 100;
                    gridInventory.Columns[3].Width = 120;

                }
            }
            catch (Exception ex)
            {
                gridController.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
      
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbProductName.Text.Length;
                if (len > 0)
                {
                    cmbProductName.BackColor = Color.White;
                    txtQuantityStock.BackColor = Color.Yellow;
                    txtQuantityStock.Focus();

                   
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                    cmbProductName.BackColor = Color.Yellow;
                    cmbProductName.Focus();
                }
            }
        }
        private void cmbNAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.Text.Length > 0)
            {
              
            }
        }
        private void cmbNAM_Leave(object sender, EventArgs e)
        {
            cmbProductName.Size = new Size(269, 29);
            
        }
        private void cmbNAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbProductName.Size = new Size(422, 29);
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtQuantityStock, txtReorderLevel, "Inventory Delivery No.",
                Messages.TitleInventory);
            }
        }
        private void txtREC_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtReorderLevel, txtCostPerUnit, "Inventory Receipt No.",
                Messages.TitleInventory);
            }
        }
        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtCostPerUnit.Text.Length;
                if (len > 0)
                {
                    txtCostPerUnit.BackColor = Color.White;
                    cmbItemLocation.BackColor = Color.Yellow;
                    cmbItemLocation.Focus();
                }
                else
                {
                    txtCostPerUnit.Text = @"0";
                    txtCostPerUnit.BackColor = Color.White;
                    cmbItemLocation.BackColor = Color.Yellow;
                    cmbItemLocation.Focus();
                }
            }
        }
        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtCostPerUnit.Focus();
                txtCostPerUnit.BackColor = Color.Yellow;
            }
            else
            {
                txtCostPerUnit.BackColor = Color.White;
            }
        }
        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbItemLocation, txtLastCostPerUnit, "Branch Name",
                Messages.TitleInventory);
            }
            if (e.KeyCode == Keys.F1)
            {
                 
            }
        }
        private void txtLST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtLastCostPerUnit.Text.Length;
                if (len > 0)
                {
                    txtLastCostPerUnit.BackColor = Color.White;
                    txtTotalValue.BackColor = Color.Yellow;
                    txtTotalValue.Focus();
                }
                else
                {
                    txtLastCostPerUnit.Text = @"0";
                    txtLastCostPerUnit.BackColor = Color.White;
                    txtTotalValue.BackColor = Color.Yellow;
                    txtTotalValue.Focus();
                }


            }
        }
        private void txtLST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtLastCostPerUnit.Focus();
                txtLastCostPerUnit.BackColor = Color.Yellow;
            }
            else
            {
                txtLastCostPerUnit.BackColor = Color.White;
            }
        }
        private void txtORD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                var len = txtTotalValue.Text.Length;
                if (len > 0)
                {
                    txtTotalValue.BackColor = Color.White;
                    dkpLastStockedDate.Focus();
                }
                else
                {
                    txtTotalValue.Text = @"0";
                    txtTotalValue.BackColor = Color.White;
                    dkpLastStockedDate.Focus();
                }

            }
        }
        private void txtORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtTotalValue.Focus();
                txtTotalValue.BackColor = Color.Yellow;
            }
            else
            {
                txtTotalValue.BackColor = Color.White;
            }
        }
        private void dkpPUR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpLastOrderDate.Focus();
            }
        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUser.Focus();
            }
        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
              
            }
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbUser.Text.Length;
                if (len > 0)
                {
                    cmbUser.BackColor = Color.White;
                    cmbWarranty.Focus();
                }
            }
        }
        private void cmbWAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
             
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbUser, bntSave, "Product Warranty",
                    Messages.TitleInventory);
            }
        }
        private Products ProductWareH(int productId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    return repository.FindBy(x => x.product_id == productId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
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

            var result = PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Inventory: " + cmbProductName.Text.Trim(' ') + " " + "?", "Inventory Details");
            if (result)
            {
                ButDel();
            }
            else
            {
                ButCan();
            }
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

        private void txtReorderLevel_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbSupplier_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCostPerUnit_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtLastCostPerUnit_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTotalValue_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbWarranty_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dkpLastStockedDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dkpLastOrderDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dpkExpirationDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dpkCreatedDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dpkLastUpdated_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbUser_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbItemLocation_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtQuantityStock_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbProductName.SelectedIndex;
            var productCode = _products.ElementAt(selectedIndex).product_code;
            bindImage(productCode);
        }

        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            cmbProductName.Size = new Size(285, 29);
        }

        private void cmbProductName_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProductName.Size = new Size(422, 29);
        }

    }
}
