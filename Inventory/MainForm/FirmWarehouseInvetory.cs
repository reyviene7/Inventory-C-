using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
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
        private IEnumerable<ViewReturnWarehouse> warehouse_return;
        private IEnumerable<ViewWarehouseDelivery> _warehouse_delivery;
        private IEnumerable<ViewSalesPart> _transaction_list;
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
        public int ReturnedId { get; private set; }
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
            if (_userTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);
                this.DialogResult = DialogResult.Cancel;

                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        private void FirmWarehouseInvetory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            splashScreen.ShowWaitForm();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            warehouse_return = EnumerableUtils.getWareHouseReturn();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            imgList = EnumerableUtils.getImgProductList();
            bindDeliveryList();
            bindWareHouse();
            BindReturnWareHouse();
            splashScreen.CloseWaitForm();
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }

        private void gridInventory_Click(object sender, EventArgs e)
        {
            if (gridInventory.RowCount > 0)
                inputWhite();
            bntClear.Enabled = true;
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
            PopupNotification.PopUpMessageExit();
        }

        private void inputWhite()
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
            txtBarcode.BackColor = Color.White;
            cmbUser.BackColor = Color.White;
            cmbItemLocation.BackColor = Color.White;
            cmbStatus.BackColor = Color.White;
        }
        private void inputEnabled()
        {
            txtWarehouseSKU.Enabled = true;
            cmbProductName.Enabled = true;
            txtQuantityStock.Enabled = true;
            txtReorderLevel.Enabled = true;
            cmbSupplier.Enabled = true;
            txtCostPerUnit.Enabled = true;
            txtLastCostPerUnit.Enabled = true;
            txtTotalValue.Enabled = false;
            dkpLastStockedDate.Enabled = true;
            dkpLastOrderDate.Enabled = true;
            dpkExpirationDate.Enabled = true;
            dpkCreatedDate.Enabled = true;
            dpkLastUpdated.Enabled = true;
            cmbUser.Enabled = true;
            cmbItemLocation.Enabled = true;
            cmbStatus.Enabled = true;
        }
        private void inputDisabled()
        {
            txtWarehouseSKU.Enabled = false;
            cmbProductName.Enabled = false;
            txtQuantityStock.Enabled = false;
            txtReorderLevel.Enabled = false;
            cmbSupplier.Enabled = false;
            txtCostPerUnit.Enabled = false;
            txtLastCostPerUnit.Enabled = false;
            txtTotalValue.Enabled = false;
            txtBarcode.Enabled = false;
            dkpLastStockedDate.Enabled = false;
            dkpLastOrderDate.Enabled = false;
            dpkExpirationDate.Enabled = false;
            dpkCreatedDate.Enabled = false;
            dpkLastUpdated.Enabled = false;
            cmbUser.Enabled = false;
            cmbItemLocation.Enabled = false;
            cmbStatus.Enabled = false;
        }

        private void disabledSales()
        {
            txtSalesId.Enabled = false;
            txtSalesInvoice.Enabled = false;
            txtSalesBarcode.Enabled = false;
            txtItemName.Enabled = false;
            txtSalesQty.Enabled = false;
            txtSalesPrice.Enabled = false;
            txtSalesDiscount.Enabled = false;
            txtCustomerName.Enabled = false;
            txtGrossSales.Enabled = false;
            txtNetSales.Enabled = false;
            txtBranchName.Enabled = false;
            dkpSalesDate.Enabled = false;
        }

        private void clearSales()
        {
            txtSalesId.Clear();
            txtSalesInvoice.Clear();
            txtSalesBarcode.Clear();
            txtItemName.Clear();
            txtSalesQty.Clear();
            txtSalesPrice.Clear();
            txtSalesDiscount.Clear();
            txtCustomerName.Clear();
            txtGrossSales.Clear();
            txtNetSales.Clear();
            txtBranchName.Clear();
            dkpSalesDate.Value = DateTime.Now;
        }

        private void whiteDelivery()
        {
            txtDelWarehouseId.BackColor = Color.White;
            txtDelProduct.BackColor = Color.White;
            txtDelProductName.BackColor = Color.White;
            cmbDelProductStatus.BackColor = Color.White;
            cmbDelWarehouseCode.BackColor = Color.White;
            txtDelLastCost.BackColor = Color.White;
            txtDelItemPrice.BackColor = Color.White;
            txtDelRemainQty.BackColor = Color.White;
            cmbDelBranch.BackColor = Color.White;
            txtDelWarehouseCode.BackColor = Color.White;
            txtDelReceipt.BackColor = Color.White;
            txtDelQty.BackColor = Color.White;
            cmbDelDeliveryStatus.BackColor = Color.White;
            txtDelRemarks.BackColor = Color.White;
        }
        private void whiteReturn()
        {
            txtReturnedId.BackColor = Color.White;
            txtReturnedCode.BackColor = Color.White;
            txtReturnedProduct.BackColor = Color.White;
            txtReturnedDelivery.BackColor = Color.White;
            txtReturnedQty.BackColor = Color.White;
            cmbReturnedBranch.BackColor = Color.White;
            cmbReturnedWarehouse.BackColor = Color.White;
            txtReturnedStatus.BackColor = Color.White;
            txtReturnedRemarks.BackColor = Color.White;
        }
        private void whiteSales()
        {
            txtSalesId.BackColor = Color.White;
            txtSalesInvoice.BackColor = Color.White;
            txtSalesBarcode.BackColor = Color.White;
            txtItemName.BackColor = Color.White;
            txtSalesQty.BackColor = Color.White;
            txtSalesPrice.BackColor = Color.White;
            txtSalesDiscount.BackColor = Color.White;
            txtCustomerName.BackColor = Color.White;
            txtGrossSales.BackColor = Color.White;
            txtNetSales.BackColor = Color.White;
            txtBranchName.BackColor = Color.White;
        }

        private void graySales()
        {
            txtSalesId.BackColor = Color.Gray;
            txtSalesInvoice.BackColor = Color.Gray;
            txtSalesBarcode.BackColor = Color.Gray;
            txtItemName.BackColor = Color.Gray;
            txtSalesQty.BackColor = Color.Gray;
            txtSalesPrice.BackColor = Color.Gray;
            txtSalesDiscount.BackColor = Color.Gray;
            txtCustomerName.BackColor = Color.Gray;
            txtGrossSales.BackColor = Color.Gray;
            txtNetSales.BackColor = Color.Gray;
            txtBranchName.BackColor = Color.Gray;
        }

        private void inputClear()
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
            txtBarcode.Text = "";
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
        private void inputGray()
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
            txtBarcode.BackColor = Color.DimGray;
            cmbUser.BackColor = Color.DimGray;
            cmbItemLocation.BackColor = Color.DimGray;
            cmbStatus.BackColor = Color.DimGray;
        }

        private void insert()
        {
            splashScreen.ShowWaitForm();
            _products = EnumerableUtils.getProductWarehouseList();
            _suppliers = EnumerableUtils.getSupplierWarehouseList();
            _statuses = EnumerableUtils.getStatusWarehouseList();
            _locations = EnumerableUtils.getLocationWarehouseList();
            ButtonAdd();
            inputEnabled();
            inputWhite();
            inputClear();
            cmbUser.Text = _userName;
            cmbItemLocation.Text = Constant.DefaultSource;
            cmbProductName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridController.Enabled = false;
            imgInventory.DataBindings.Clear();
            imgInventory.Image = null;
            cmbProductName.DataBindings.Clear();
            cmbSupplier.DataBindings.Clear();
            cmbStatus.DataBindings.Clear();
            cmbItemLocation.DataBindings.Clear();
            cmbProductName.DataSource = _products.Select(p => p.product_name ).ToList();
            cmbSupplier.DataSource = _suppliers.Select(p => p.supplier_name).ToList();
            cmbStatus.DataSource = _statuses.Select(p => p.status_details).ToList();
            cmbItemLocation.DataSource = _locations.Select(p => p.location_code).ToList();
            splashScreen.CloseWaitForm();
            txtWarehouseSKU.Focus();
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
        private void buttonUpdate()
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
        private void buttonDelete()
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
        private void buttonSave()
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
        private void buttonClear()
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
        private void buttonCancel()
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
        private void update()
        {
            buttonUpdate();
            inputEnabled();
            inputWhite();
            _add = false;
            _edt = true;
            _del = false;
            gridController.Enabled = false;
        
        }
        private void delete()
        {
            buttonDelete();
            inputEnabled();
            inputWhite();
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
                buttonSave();
                inputDisabled();
                inputGray();
                inputClear();
            }
            if (_add == false && _edt && _del == false)
            {

                editInventory();
                buttonSave();
                inputDisabled();
                inputGray();
                inputClear();
            }
            if (_add == false && _edt == false && _del)
            {
                deleteInventory();
                buttonSave();
                inputDisabled();
                inputGray();
                inputClear();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridController.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgInventory.DataBindings.Clear();
            imgInventory.Image = null;
           
        }
        private void cancel()
        {
            buttonCancel();
            inputDisabled();
            inputGray();
            inputClear();
            gridController.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgInventory.DataBindings.Clear();
            imgInventory.Image = null;
            cmbProductName.Size = new System.Drawing.Size(285, 29);
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
                    PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.InventorySystem);
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
        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            insert();
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            update();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            buttonSave();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            inputWhite();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {

            var result = PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Inventory: " + cmbProductName.Text.Trim(' ') + " " + "?", "Inventory Details");
            if (result)
            {
                delete();
            }
            else
            {
                cancel();
            }
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

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbProductName.SelectedIndex;
            var productCode = _products.ElementAt(selectedIndex).product_code;
            bindImage(productCode);
        }

        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            cmbProductName.Size = new System.Drawing.Size(285, 29);
        }

        private void cmbProductName_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProductName.Size = new System.Drawing.Size(422, 29);
        }

        private void bindImage(string barcode)
        {
            var img = searchProductImg(barcode);
            var imgLocation = img.img_location;
            if (imgLocation.Length > 0)
            {
                var location = ConstantUtils.defaultImgLocation + imgLocation;

                imgInventory.ImageLocation = location;
            }
            else
                imgInventory.Image = null;
        }

        /** when tab is selected **/
        private void xInventory_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(e.Page == xtraInventory)
            {
                splashScreen.ShowWaitForm();
                inputWhite();
                inputDisabled();
                _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                bindWareHouse();
                splashScreen.CloseWaitForm();
            }
            if (e.Page == xtraDelivery)
            {
                splashScreen.ShowWaitForm();
                whiteDelivery();
                _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
                bindDeliveryList();
                splashScreen.CloseWaitForm();
            }
            if (e.Page == xtraReturn)
            {
                splashScreen.ShowWaitForm();
                whiteReturn();
                warehouse_return = EnumerableUtils.getWareHouseReturn();
                BindReturnWareHouse();
                splashScreen.CloseWaitForm();
            }
            if(e.Page == xtraSales)
            {
                splashScreen.ShowWaitForm();
                whiteSales();
                disabledSales();
                _transaction_list = EnumerableUtils.getSalesParticular();
                bindSalesParticular();
                splashScreen.CloseWaitForm();
            }
        }

        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewInventory(sender);
        }

        private void gridDelivery_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewDelivery(sender);
        }

        private void gridReturn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewReturn(sender);
        }

        private void gridSales_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewSales(sender);
        }

        private void gridSales_RowClick(object sender, RowClickEventArgs e)
        {
            gridViewSales(sender);
        }

        private void gridDelivery_RowClick(object sender, RowClickEventArgs e)
        {
            gridViewDelivery(sender);
        }

        private ViewWarehouseDelivery searchWarehouseDeliveryId(string barcode)
        {
            return _warehouse_delivery.FirstOrDefault(Warehouse => Warehouse.product_code == barcode);
        }
        private ViewReturnWarehouse searchReturnId(int id)
        {
            return warehouse_return.FirstOrDefault(Return => Return.return_id == id);
        }

        private void gridViewInventory(object sender)
        {
            if (gridInventory.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                        cmbUser.Text = _userName;
                        txtInventoryId.Text = id;
                        txtWarehouseSKU.Text = ((GridView)sender).GetFocusedRowCellValue("SKU").ToString(); ;
                        txtBarcode.Text = barcode;
                        txtQuantityStock.Text = ((GridView)sender).GetFocusedRowCellValue("Qty").ToString();
                        cmbProductName.Text = _products.FirstOrDefault(p => p.product_code == barcode).product_name;
                        txtReorderLevel.Text = ((GridView)sender).GetFocusedRowCellValue("ReQty").ToString();
                        cmbSupplier.Text = ((GridView)sender).GetFocusedRowCellValue("Supplier").ToString();
                        txtCostPerUnit.Text = ((GridView)sender).GetFocusedRowCellValue("Price").ToString();
                        txtLastCostPerUnit.Text = ((GridView)sender).GetFocusedRowCellValue("LastCost").ToString();
                        txtTotalValue.Text = ((GridView)sender).GetFocusedRowCellValue("Total").ToString();
                        cmbStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status").ToString();
                        cmbItemLocation.Text = ((GridView)sender).GetFocusedRowCellValue("Location").ToString();
                        dkpLastStockedDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("LStocked");
                        dkpLastOrderDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("LOrder");
                        dpkExpirationDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Expire");
                        
                        var img = searchProductImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgInventory.ImageLocation = location;
                        }
                        else
                            imgInventory.Image = null;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void gridViewDelivery(object sender)
        {
            if (gridDelivery.RowCount > 0)
                try
                {
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                    var deliveryId = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (barcode.Length > 0)
                    {
                        var w = searchWarehouseDeliveryId(barcode);
                        txtDelWarehouseId.Text = deliveryId;
                        txtDelProduct.Text = barcode;
                        txtDelWarehouseCode.Text = w.delivery_code;
                        cmbDelWarehouseCode.Text = w.warehouse_name;
                        txtDelProductName.Text = w.product_name;
                        txtDelLastCost.Text = w.last_cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtDelReceipt.Text = w.receipt_number;
                        txtDelRemainQty.Text = w.quantity_in_stock.ToString(CultureInfo.InvariantCulture);
                        cmbDelBranch.Text = w.branch_details;
                        dkpDelDeliveryDate.Value = w.delivery_date;
                        cmbDelProductStatus.Text = w.status_details;
                        txtDelItemPrice.Text = w.cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtDelQty.Text = w.delivery_qty.ToString(CultureInfo.InvariantCulture);
                        cmbDelDeliveryStatus.Text = w.delivery_status;
                        txtDelRemarks.Text = w.remarks;
                        dkpDelUpdate.Value = w.update_on;
                        
                        var img = searchProductImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;
                            imgDelivery.ImageLocation = location;
                            imgDelivery.Refresh();
                        }
                        else
                        {
                            imgDelivery.Image = null;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        private void gridViewReturn(object sender)
        {
            if (gridReturn.RowCount > 0)
                try
                {
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                    var ReturnId = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (barcode.Length > 0)
                    {
                        ReturnedId = int.Parse(ReturnId);
                        var ent = searchReturnId(ReturnedId);
                        txtReturnedId.Text = ReturnId;
                        txtReturnedCode.Text = ent.return_code;
                        txtReturnedProduct.Text = barcode;
                        txtReturnedDelivery.Text = ent.return_number;
                        txtReturnedQty.Text = ent.return_quantity.ToString(CultureInfo.InvariantCulture);
                        cmbReturnedBranch.Text = ent.branch_details;
                        cmbReturnedWarehouse.Text = ent.destination;
                        txtReturnedStatus.Text = ent.status;
                        txtReturnedRemarks.Text = ent.remarks;
                        dkpReturedDate.Value = ent.return_date;
                        var img = searchProductImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;
                            imgReturn.ImageLocation = location;
                            imgReturn.Refresh();
                        }
                        else
                        {
                            imgReturn.Image = null;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void gridViewSales(object sender)
        {
            if (gridSales.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                        var invoice = ((GridView)sender).GetFocusedRowCellValue("Invoice").ToString();
                        txtSalesId.Text = id;
                        txtSalesBarcode.Text = barcode;
                        txtSalesInvoice.Text = invoice;
                        txtItemName.Text = ((GridView)sender).GetFocusedRowCellValue("Item").ToString();
                        txtSalesQty.Text = ((GridView)sender).GetFocusedRowCellValue("Qty").ToString();
                        txtSalesPrice.Text = ((GridView)sender).GetFocusedRowCellValue("UnitPrice").ToString();
                        txtSalesDiscount.Text = ((GridView)sender).GetFocusedRowCellValue("Discount").ToString();
                        txtCustomerName.Text = ((GridView)sender).GetFocusedRowCellValue("Customer").ToString();
                        txtGrossSales.Text = ((GridView)sender).GetFocusedRowCellValue("Gross").ToString();
                        txtNetSales.Text = ((GridView)sender).GetFocusedRowCellValue("NetSales").ToString();
                        txtBranchName.Text = ((GridView)sender).GetFocusedRowCellValue("Branch").ToString();
                        dkpSalesDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("Date");
                        
                        var img = searchProductImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgSales.ImageLocation = location;
                        }
                        else
                            imgSales.Image = null;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void bindWareHouse()
        {
            clearGrid();
            var list = _warehouse_list.Select(p => new {
                Id = p.inventory_id,
                Barcode = p.product_code,
                SKU = p.sku,
                Qty = p.quantity_in_stock,
                ReQty = p.reorder_level,
                Location = p.location_code,
                Supplier = p.supplier_name,
                LStocked = p.last_stocked_date,
                LOrder = p.last_ordered_date,
                Expire = p.expiration_date,
                Price = p.cost_per_unit,
                LastCost = p.last_cost_per_unit,
                Total = p.total_value,
                Status = p.status_details,
                Created = p.created_at,
                Updated = p.updated_at
            }).ToList();
            gridController.DataSource = list;
            gridController.Update();

            if (gridInventory.RowCount > 0)
                gridInventory.Columns[0].Width = 40;
            gridInventory.Columns[1].Width = 90;
            gridInventory.Columns[2].Width = 65;
            gridInventory.Columns[3].Width = 40;
            gridInventory.Columns[4].Width = 40;
            gridInventory.Columns[6].Width = 180;
        }

        private void bindDeliveryList()
        {
            clearGridDelivery();
            var list = _warehouse_delivery.Select(p => new
            {
                Id = p.delivery_id,
                Barcode = p.product_code,
                Code = p.delivery_code,
                Product = p.product_name,
                Destination = p.branch_details,
                DeliveryDate = p.delivery_date,
                Status = p.status_details,
                CostPerItem = p.cost_per_unit,
                Qty = p.delivery_qty,
                Total = p.total_value,
                DeliveryStatus = p.delivery_status,
                Update = p.update_on,
            });

            gridControlDelivery.DataSource = list;
            gridControlDelivery.Update();
            if (gridDelivery.RowCount > 0)
            {
                gridDelivery.Columns[0].Width = 50;
                gridDelivery.Columns[1].Width = 100;
                gridDelivery.Columns[2].Width = 40;
                gridDelivery.Columns[3].Width = 250;
                gridDelivery.Columns[4].Width = 70;
                gridDelivery.Columns[5].Width = 70;
                gridDelivery.Columns[6].Width = 70;
                gridDelivery.Columns[7].Width = 50;
                gridDelivery.Columns[8].Width = 30;
                gridDelivery.Columns[9].Width = 70;
                gridDelivery.Columns[10].Width = 80;
            }
        }
        private void BindReturnWareHouse()
        {
            clearGridReturn();
            var list = warehouse_return.Select(r => new
            {
                Id = r.return_id,
                Code = r.return_code,
                Barcode = r.product_code,
                Item = r.product_name,
                Qty = r.return_quantity,
                Destination = r.destination,
                Status = r.status,
                Remarks = r.remarks,
                ReturnDate = r.return_date
            }).ToList();
            gridControlReturn.DataSource = list;
            gridControlReturn.Update();
            if (gridReturn.RowCount > 0)
            {
                gridReturn.Columns[0].Width = 40;
                gridReturn.Columns[1].Width = 60;
                gridReturn.Columns[2].Width = 120;
                gridReturn.Columns[3].Width = 400;
                gridReturn.Columns[4].Width = 40;
                gridReturn.Columns[5].Width = 100;
                gridReturn.Columns[6].Width = 100;
                gridReturn.Columns[7].Width = 100;
            }
        }
        private void bindSalesParticular()
        {
            gridControlSales.Update();
            try
            {
                clearGridSales();
                var list = _transaction_list.Select(x => new
                {
                    Id = x.id,
                    Invoice = x.invoice,
                    Barcode = x.barcode,
                    Item = x.item,
                    Qty = x.qty,
                    UnitPrice = x.price,
                    Discount = x.discount,
                    Gross = x.gross,
                    NetSales = x.net,
                    Customer = x.customer,
                    Branch = x.branch,
                    Date = x.date,
                }).ToList();
                gridControlSales.DataSource = list;
                gridControlSales.Update();
                gridSales.Columns[0].Width = 40;
                gridSales.Columns[1].Width = 50;
                gridSales.Columns[2].Width = 100;
                gridSales.Columns[3].Width = 340;
                gridSales.Columns[4].Width = 50;
                gridSales.Columns[5].Width = 50;
                gridSales.Columns[6].Width = 50;
                gridSales.Columns[7].Width = 50;
                gridSales.Columns[8].Width = 50;
                gridSales.Columns[9].Width = 110;
                gridSales.Columns[10].Width = 90;
                gridSales.Columns[11].Width = 100;
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void clearGrid()
        {
            gridController.DataSource = null;
            gridController.DataSource = "";
            gridInventory.Columns.Clear();
        }

        private void clearGridDelivery()
        {
            gridControlDelivery.DataSource = null;
            gridControlDelivery.DataSource = "";
            gridDelivery.Columns.Clear();
        }

        private void clearGridReturn()
        {
            gridControlReturn.DataSource = null;
            gridControlReturn.DataSource = "";
            gridReturn.Columns.Clear();
        }

        private void clearGridSales()
        {
            gridControlSales.DataSource = null;
            gridControlSales.DataSource = "";
            gridSales.Columns.Clear();
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
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessInsert + " to warehouse inventory!", Messages.TitleSuccessInsert);
                    _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                    bindWareHouse();
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.TitleFailedInsert + " to warehouse inventory!", Messages.TitleFailedInsert);
                }
            }
        }

        private void editInventory()
        {
            var inventoryId = int.Parse(txtInventoryId.Text.Trim(' '));
            if (inventoryId > 0)
            {
                var item = cmbProductName.Text.Trim(' ');
                var supplier = cmbSupplier.Text.Trim(' ');
                var location = cmbItemLocation.Text.Trim(' ');
                var status = cmbStatus.Text.Trim(' ');
                var productId = FetchUtils.getProductId(item);
                var supplierId = FetchUtils.getSupplierId(supplier);
                var locationId = FetchUtils.getLocationId(location);
                var statusId = FetchUtils.getStatusId(status);
                var qtyStock = int.Parse(txtQuantityStock.Text.Trim(' '));
                var reoderLevel = int.Parse(txtReorderLevel.Text.Trim(' '));
                var unitCost = decimal.Parse(txtCostPerUnit.Text.Trim(' '));
                var lastCost = decimal.Parse(txtLastCostPerUnit.Text.Trim(' '));
                int result = RepositoryEntity.UpdateEntity<WarehouseInventory>(inventoryId, entity =>
                {
                    entity.product_id = productId;
                    entity.sku = txtWarehouseSKU.Text.Trim(' ');
                    entity.quantity_in_stock = qtyStock;
                    entity.reorder_level = reoderLevel;
                    entity.location_id = locationId;
                    entity.warehouse_id = 1;
                    entity.user_id = _userId;
                    entity.supplier_id = supplierId;
                    entity.last_stocked_date = dkpLastStockedDate.Value.Date;
                    entity.last_ordered_date = dkpLastOrderDate.Value.Date;
                    entity.expiration_date = dpkExpirationDate.Value.Date;
                    entity.cost_per_unit = unitCost;
                    entity.last_cost_per_unit = lastCost;
                    entity.status_id = statusId;
                    entity.created_at = dpkCreatedDate.Value.Date;
                    entity.updated_at = dpkLastUpdated.Value.Date;
                });
                if (result > 0)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessUpdate + " to warehouse inventory!", Messages.TitleSuccessUpdate);
                    _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                    bindWareHouse();
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.ErrorUpdate + " to warehouse inventory!", Messages.TitleFialedUpdate);
                }
            }
        }

        private void deleteInventory()
        {

        }
    }
}
