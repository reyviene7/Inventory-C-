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
using ServeAll.Entities;

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
        private IEnumerable<ViewReportProductList> _products;
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

        public int DeliveredId { get; private set; }

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
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            warehouse_return = EnumerableUtils.getWareHouseReturn();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
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
            splashScreen.ShowWaitForm();
            _products = (IEnumerable<ViewReportProductList>)EnumerableUtils.getProductWarehouseList();
            _suppliers = EnumerableUtils.getSupplierWarehouseList();
            _statuses = EnumerableUtils.getStatusWarehouseList();
            _locations = EnumerableUtils.getLocationWarehouseList();
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
            txtCostPerUnit.Enabled = false;
            txtLastCostPerUnit.Enabled = false;
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
        private void grayReturn()
        {
            txtReturnedId.BackColor = Color.Gray;
            txtReturnedCode.BackColor = Color.Gray;
            txtReturnedProduct.BackColor = Color.Gray;
            txtReturnedDelivery.BackColor = Color.Gray;
            txtReturnedQty.BackColor = Color.Gray;
            cmbReturnedBranch.BackColor = Color.Gray;
            cmbReturnedWarehouse.BackColor = Color.Gray;
            txtReturnedStatus.BackColor = Color.Gray;
            txtReturnedRemarks.BackColor = Color.Gray;
        }
        private void grayDelivery()
        {
            txtDelWarehouseId.BackColor = Color.Gray;
            txtDelProduct.BackColor = Color.Gray;
            txtDelProductName.BackColor = Color.Gray;
            cmbDelProductStatus.BackColor = Color.Gray;
            cmbDelWarehouseCode.BackColor = Color.Gray;
            txtDelLastCost.BackColor = Color.Gray;
            txtDelItemPrice.BackColor = Color.Gray;
            txtDelRemainQty.BackColor = Color.Gray;
            cmbDelBranch.BackColor = Color.Gray;
            txtDelWarehouseCode.BackColor = Color.Gray;
            txtDelReceipt.BackColor = Color.Gray;
            txtDelQty.BackColor = Color.Gray;
            cmbDelDeliveryStatus.BackColor = Color.Gray;
            txtDelRemarks.BackColor = Color.Gray;
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
        private void clearDelivery()
        {
            txtDelWarehouseId.Clear();
            txtDelProduct.Clear();
            txtDelProductName.Clear();
            cmbDelProductStatus.Text = "";
            cmbDelWarehouseCode.Text = "";
            txtDelLastCost.Clear();
            txtDelItemPrice.Clear();
            txtDelRemainQty.Clear();
            cmbDelBranch.Text = "";
            txtDelWarehouseCode.Clear();
            txtDelReceipt.Clear();
            txtDelQty.Clear();
            cmbDelDeliveryStatus.Text = "";
            txtDelRemarks.Clear();
        }
        private void ClearReturn()
        {
            txtReturnedId.Clear();
            txtReturnedCode.Clear();
            txtReturnedProduct.Clear();
            txtReturnedDelivery.Clear();
            txtReturnedQty.Clear();
            cmbReturnedBranch.Text = "";
            cmbReturnedWarehouse.Text = "";
            txtReturnedStatus.Clear();
            txtReturnedRemarks.Clear();
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
        private void GenerateCode()
        {
            var lastWarehouseInventoryId = FetchUtils.getLastWarehouseInventoryId();
            var alphaNumeric = new GenerateAlpaNum("SKU", 3, lastWarehouseInventoryId);
            alphaNumeric.Increment();
            txtWarehouseSKU.Text = alphaNumeric.ToString();
        }
        private void insert()
        {
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
            cmbProductName.DataBindings.Clear();
            cmbSupplier.DataBindings.Clear();
            cmbStatus.DataBindings.Clear();
            cmbItemLocation.DataBindings.Clear();
            cmbProductName.DataSource = _products.Select(p => p.product_name).ToList();
            cmbSupplier.DataSource = _suppliers.Select(p => p.supplier_name).ToList();
            cmbStatus.DataSource = _statuses.Select(p => p.status_details).ToList();
            cmbItemLocation.DataSource = _locations.Select(p => p.location_code).ToList();
            if (_products.Any())
            {
                cmbProductName.SelectedIndex = 0;
                cmbProductName_SelectedIndexChanged(cmbProductName, EventArgs.Empty); // 👈 this line is key
            }
            GenerateCode();
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
            cmbProductName.DataBindings.Clear();
            cmbSupplier.DataBindings.Clear();
            cmbStatus.DataBindings.Clear();
            cmbItemLocation.DataBindings.Clear();
            cmbProductName.DataSource = _products.Select(p => p.product_name).ToList();
            cmbSupplier.DataSource = _suppliers.Select(p => p.supplier_name).ToList();
            cmbStatus.DataSource = _statuses.Select(p => p.status_details).ToList();
            cmbItemLocation.DataSource = _locations.Select(p => p.location_code).ToList();
            txtWarehouseSKU.Focus();
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
                _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            }
            if (_add == false && _edt && _del == false)
            {

                editInventory();
                buttonSave();
                inputDisabled();
                inputGray();
                inputClear();
                _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            }
            if (_add == false && _edt == false && _del)
            {
                deleteInventory();
                buttonSave();
                inputDisabled();
                inputGray();
                inputClear();
                _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridController.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgInventory.DataBindings.Clear();
            imgInventory.Image = null;
            bindWareHouse();
            bindDeliveryList();
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
            imgDelivery.DataBindings.Clear();
            imgReturn.DataBindings.Clear();
            imgSales.DataBindings.Clear();
            imgInventory.Image = null;
            imgDelivery.Image = null;
            imgReturn.Image = null;
            imgSales.Image = null;
            cmbProductName.Size = new System.Drawing.Size(285, 29);
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
            ButSav();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            bindRefreshed();
            buttonClear();
            inputWhite();
            inputClear();
            whiteReturn();
            whiteDelivery();
            whiteSales();
            clearDelivery();
            clearSales();
            ClearReturn();
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

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbProductName.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < _products.Count())
            {
                var selectedProduct = _products.ElementAt(selectedIndex);

                bindImage(selectedProduct.product_code);

                txtCostPerUnit.Text = selectedProduct.trade_price.ToString("N2");
                txtLastCostPerUnit.Text = selectedProduct.retail_price.ToString("N2");
                cmbSupplier.Text = selectedProduct.supplier_name;
                txtBarcode.Text = selectedProduct.product_code;
            }
        }

        /*
        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            cmbProductName.Size = new System.Drawing.Size(285, 29);
        }*/
        /*
        private void cmbProductName_MouseClick(object sender, MouseEventArgs e)
        {
            cmbProductName.Size = new System.Drawing.Size(422, 29);
        }*/

        private void bindImage(string barcode)
        {
            var img = searchProductImg(barcode);
            var imgLocation = img?.img_location;
            if (img == null || string.IsNullOrEmpty(imgLocation))
            {
                imgInventory.ImageLocation = ConstantUtils.defaultImgEmpty;
            }
            else
            {
                var location = ConstantUtils.defaultImgLocation + imgLocation;

                imgInventory.ImageLocation = location;
            }
        }
        private void bindRefreshed()
        {
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            bindWareHouse();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            bindDeliveryList();
            warehouse_return = EnumerableUtils.getWareHouseReturn();
            BindReturnWareHouse();
            _transaction_list = EnumerableUtils.getSalesParticular();
            bindSalesParticular();
        }
        private void xInventory_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraInventory)
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
            if (e.Page == xtraSales)
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
            bntCancel.Enabled = true;
        }

        private void gridDelivery_RowClick(object sender, RowClickEventArgs e)
        {
            gridViewDelivery(sender);
            bntCancel.Enabled = true;
        }

        private void GridInventory_RowClick(object sender, RowClickEventArgs e)
        {
            inputWhite();
            bntCancel.Enabled = true;
        }

        private void GridReturn_RowClick(object sender, RowClickEventArgs e)
        {
            whiteReturn();
            bntCancel.Enabled = true;
        }

        private void GridInventory_LostFocus(object sender, EventArgs e)
        {
            inputGray();
        }

        private void GridSales_LostFocus(object sender, EventArgs e)
        {
            graySales();
        }

        private void GridReturn_LostFocus(object sender, EventArgs e)
        {
            grayReturn();
        }

        private void GridDelivery_LostFocus(object sender, EventArgs e)
        {
            grayDelivery();
        }

        private ViewWareHouseInventory searchWarehouseInventoryId(string barcode)
        {
            return _warehouse_list.FirstOrDefault(Inventory => Inventory.product_code == barcode);
        }
        private ViewWarehouseDelivery searchWarehouseDeliveryId(int id)
        {
            return _warehouse_delivery.FirstOrDefault(Warehouse => Warehouse.delivery_id == id);
        }
        private ServeAll.Core.Entities.ViewReturnWarehouse searchReturnId(int id)
        {
            return warehouse_return.FirstOrDefault(Return => Return.return_id == id);
        }

        private void gridViewInventory(object sender)
        {
            if (gridInventory.RowCount > 0)
                try
                {
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("BARCODE").ToString();
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (barcode.Length > 0)
                    {
                        var w = searchWarehouseInventoryId(barcode);
                        cmbUser.Text = _userName;
                        txtInventoryId.Text = id;
                        txtWarehouseSKU.Text = w.sku;
                        txtBarcode.Text = barcode;
                        txtQuantityStock.Text = w.quantity_in_stock.ToString(CultureInfo.InvariantCulture);
                        cmbProductName.Text = _products.FirstOrDefault(p => p.product_code == barcode).product_name;
                        txtReorderLevel.Text = w.reorder_level.ToString(CultureInfo.InvariantCulture);
                        cmbSupplier.Text = w.supplier_name;
                        txtCostPerUnit.Text = w.cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtLastCostPerUnit.Text = w.last_cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtTotalValue.Text = w.total_value.ToString("N2", CultureInfo.InvariantCulture);
                        cmbStatus.Text = w.status_details;
                        cmbItemLocation.Text = w.location_code;
                        dkpLastStockedDate.Value = w.last_stocked_date;
                        dkpLastOrderDate.Value = w.last_ordered_date;
                        dpkExpirationDate.Value = w.expiration_date;

                        var img = searchProductImg(barcode);
                        var imgLocation = img?.img_location;
                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgInventory.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgInventory.ImageLocation = location;
                        }
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
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("BARCODE").ToString();
                    var deliveryId = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (barcode.Length > 0)
                    {
                        DeliveredId = int.Parse(deliveryId);
                        var w = searchWarehouseDeliveryId(DeliveredId);
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
                        var imgLocation = img?.img_location;
                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgDelivery.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;
                            imgDelivery.ImageLocation = location;
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
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("BARCODE").ToString();
                    var ReturnId = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
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
                        var imgLocation = img?.img_location;
                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgReturn.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;
                            imgReturn.ImageLocation = location;
                            imgReturn.Refresh();
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
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        var barcode = ((GridView)sender).GetFocusedRowCellValue("BARCODE").ToString();
                        var invoice = ((GridView)sender).GetFocusedRowCellValue("INVOICE").ToString();
                        txtSalesId.Text = id;
                        txtSalesBarcode.Text = barcode;
                        txtSalesInvoice.Text = invoice;
                        txtItemName.Text = ((GridView)sender).GetFocusedRowCellValue("PRODUCT").ToString();
                        txtSalesQty.Text = ((GridView)sender).GetFocusedRowCellValue("QTY").ToString();
                        txtSalesPrice.Text = ((GridView)sender).GetFocusedRowCellValue("UNITPRICE").ToString();
                        txtSalesDiscount.Text = ((GridView)sender).GetFocusedRowCellValue("DISCOUNT").ToString();
                        txtCustomerName.Text = ((GridView)sender).GetFocusedRowCellValue("CUSTOMER").ToString();
                        txtGrossSales.Text = ((GridView)sender).GetFocusedRowCellValue("GROSS").ToString();
                        txtNetSales.Text = ((GridView)sender).GetFocusedRowCellValue("NETSALES").ToString();
                        txtBranchName.Text = ((GridView)sender).GetFocusedRowCellValue("BRANCH").ToString();
                        dkpSalesDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("DATE");

                        var img = searchProductImg(barcode);
                        var imgLocation = img?.img_location;
                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgSales.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgSales.ImageLocation = location;
                        }
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
            var list = _warehouse_list.Select(p => new
            {
                ID = p.inventory_id,
                BARCODE = p.product_code,
                SKU = p.sku,
                QTY = p.quantity_in_stock,
                REORDER = p.reorder_level,
                LOCATION = p.location_code,
                SUPPLIER = p.supplier_name,
                COST = p.cost_per_unit,
                PRICE = p.last_cost_per_unit,
                TOTAL = p.total_value.ToString("N2"),
                STATUS = p.status_details,
                LSTOCKED = p.last_stocked_date,
                LORDERED = p.last_ordered_date,
                EXPIRY = p.expiration_date,
                CREATED = p.created_at,
                UPDATED = p.updated_at
            }).ToList();
            gridController.DataSource = list;
            gridController.Update();

            if (gridInventory.RowCount > 0)
            {
                gridInventory.Columns[0].Width = 40;
                gridInventory.Columns[1].Width = 120;
                gridInventory.Columns[2].Width = 65;
                gridInventory.Columns[3].Width = 40;
                gridInventory.Columns[4].Width = 40;
                gridInventory.Columns[5].Width = 80;
                gridInventory.Columns[6].Width = 110;
                gridInventory.Columns[7].Width = 50;
                gridInventory.Columns[8].Width = 50;
                gridInventory.Columns[9].Width = 65;
                gridInventory.Columns[10].Width = 70;
                gridInventory.Columns[11].Width = 80;
                gridInventory.Columns[12].Width = 80;
                gridInventory.Columns[13].Width = 80;
                gridInventory.Columns[14].Width = 80;
                gridInventory.Columns[15].Width = 80;
            }
        }

        private void bindDeliveryList()
        {
            clearGridDelivery();
            var list = _warehouse_delivery.Select(p => new
            {
                ID = p.delivery_id,
                BARCODE = p.product_code,
                DELCODE = p.delivery_code,
                PRODUCT = p.product_name,
                BRANCH = p.branch_details,
                DELIVERYDATE = p.delivery_date,
                STATUS = p.status_details,
                COST = p.cost_per_unit,
                QTY = p.delivery_qty,
                TOTAL = p.total_value.ToString("N2"),
                DELIVERYSTATUS = p.delivery_status,
                UPDATE = p.update_on,
            });

            gridControlDelivery.DataSource = list;
            gridControlDelivery.Update();
            if (gridDelivery.RowCount > 0)
            {
                gridDelivery.Columns[0].Width = 40;
                gridDelivery.Columns[1].Width = 100;
                gridDelivery.Columns[2].Width = 70;
                gridDelivery.Columns[3].Width = 250;
                gridDelivery.Columns[4].Width = 90;
                gridDelivery.Columns[5].Width = 90;
                gridDelivery.Columns[6].Width = 70;
                gridDelivery.Columns[7].Width = 65;
                gridDelivery.Columns[8].Width = 40;
                gridDelivery.Columns[9].Width = 65;
                gridDelivery.Columns[10].Width = 90;
            }
        }
        private void BindReturnWareHouse()
        {
            clearGridReturn();
            var list = warehouse_return.Select(r => new
            {
                ID = r.return_id,
                CODE = r.return_code,
                BARCODE = r.product_code,
                PRODUCT = r.product_name,
                QTY = r.return_quantity,
                DESTINATION = r.destination,
                STATUS = r.status,
                REMARKS = r.remarks,
                DATE = r.return_date
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
                    ID = x.id,
                    INVOICE = x.invoice,
                    BARCODE = x.barcode,
                    PRODUCT = x.item,
                    QTY = x.qty,
                    UNITPRICE = x.price,
                    DISCOUNT = x.discount,
                    GROSS = x.gross,
                    NETSALES = x.net,
                    CUSTOMER = x.customer,
                    BRANCH = x.branch,
                    DATE = x.date,
                }).ToList();
                gridControlSales.DataSource = list;
                gridControlSales.Update();
                gridSales.Columns[0].Width = 40;
                gridSales.Columns[1].Width = 50;
                gridSales.Columns[2].Width = 100;
                gridSales.Columns[3].Width = 300;
                gridSales.Columns[4].Width = 50;
                gridSales.Columns[5].Width = 50;
                gridSales.Columns[6].Width = 50;
                gridSales.Columns[7].Width = 50;
                gridSales.Columns[8].Width = 50;
                gridSales.Columns[9].Width = 150;
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
            var item = cmbProductName.Text.Trim();
            var supplier = cmbSupplier.Text.Trim(' ');
            var location = cmbItemLocation.Text.Trim(' ');
            var status = cmbStatus.Text.Trim(' ');
            if (item.Length > 0)
            {
                var productId = FetchUtils.getProductId(item);
                Console.WriteLine("Resolved Product ID: " + productId);
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

        private void TxtWarehouseSKU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                txtWarehouseSKU.Text = txtWarehouseSKU.Text.ToUpper(); 

                InputManipulation.InputBoxLeave(txtWarehouseSKU, cmbProductName, "Warehouse SKU",
                    Messages.TitleWarehouseInventory);
            }
        }

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbProductName, txtQuantityStock, "Product Name",
                Messages.TitleWarehouseInventory);
            }
        }

        private void txtQuantityStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtQuantityStock.Text.Length;

                if (len > 0)
                {
                    txtQuantityStock.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtQuantityStock, txtReorderLevel, "Warehouse Inventory Quantity", Messages.TitleWarehouseInventory);

                    // Calculate total value here
                    if (decimal.TryParse(txtQuantityStock.Text, out decimal quantity) &&
                        decimal.TryParse(txtCostPerUnit.Text, out decimal costPerUnit))
                    {
                        decimal totalValue = quantity * costPerUnit;
                        txtTotalValue.Text = totalValue.ToString("N2");

                        if (quantity == 0)
                        {
                            InputManipulation.InputBoxLeave(txtQuantityStock, txtReorderLevel, "Warehouse Inventory Quantity", Messages.TitleWarehouseInventory);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid numeric values for Quantity and Cost Per Unit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    txtQuantityStock.Text = @"0";
                    txtQuantityStock.BackColor = Color.Yellow;
                    txtQuantityStock.Focus();
                }

                e.SuppressKeyPress = true; // Prevent beep sound
            }
        }

        private void txtReorderLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtReorderLevel.Text.Length;
                if (len > 0)
                {
                    txtReorderLevel.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtReorderLevel, cmbSupplier, "Reorder Level",
                    Messages.TitleWarehouseInventory);
                }
                else
                {
                    txtReorderLevel.Text = @"0";
                    txtReorderLevel.BackColor = Color.Yellow;
                    txtReorderLevel.Focus();
                }
                if (txtReorderLevel.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtReorderLevel, cmbSupplier, "Reorder Level",
                        Messages.TitleWarehouseInventory);
                }
            }
        }

        private void cmbSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbSupplier, dkpLastStockedDate, "Supplier Name",
                Messages.TitleWarehouseInventory);
            }
        }

        private void txtCostPerUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtCostPerUnit.Text.Length;

                if (len > 0)
                {
                    txtCostPerUnit.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtCostPerUnit, txtLastCostPerUnit, "Cost Per Unit", Messages.TitleWarehouseInventory);

                    // Calculate total value here
                    if (decimal.TryParse(txtQuantityStock.Text, out decimal quantity) &&
                        decimal.TryParse(txtCostPerUnit.Text, out decimal costPerUnit))
                    {
                        decimal totalValue = quantity * costPerUnit;
                        txtTotalValue.Text = totalValue.ToString("N2");

                        if (costPerUnit == 0)
                        {
                            InputManipulation.InputBoxLeave(txtCostPerUnit, txtReorderLevel, "Warehouse Inventory Quantity", Messages.TitleWarehouseInventory);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid numeric values for Quantity and Cost Per Unit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    txtCostPerUnit.Text = @"0";
                    txtCostPerUnit.BackColor = Color.Yellow;
                    txtCostPerUnit.Focus();
                }

                e.SuppressKeyPress = true; // Prevent beep sound
            }
        }


        private void txtLastCostPerUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtLastCostPerUnit.Text.Length;

                if (len > 0)
                {
                    txtLastCostPerUnit.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtLastCostPerUnit, dkpLastStockedDate, "Last Cost Per Unit", Messages.TitleWarehouseInventory);
                }
                else
                {
                    txtLastCostPerUnit.Text = @"0";
                    txtLastCostPerUnit.BackColor = Color.Yellow;
                    txtLastCostPerUnit.Focus();
                }

                e.SuppressKeyPress = true;
            }
        }


        private void dkpLastStockedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(dkpLastStockedDate, dkpLastOrderDate, "Last Stocked Date",
                Messages.TitleWarehouseInventory);
            }
        }

        private void dkpLastOrderDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(dkpLastOrderDate, dpkExpirationDate, "Last Order Date",
                Messages.TitleWarehouseInventory);
            }
        }

        private void dpkExpirationDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(dpkExpirationDate, dpkCreatedDate, "Expiration Date",
                Messages.TitleWarehouseInventory);
            }
        }

        private void dpkCreatedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(dpkCreatedDate, dpkLastUpdated, "Created Date",
                Messages.TitleWarehouseInventory);
            }
        }

        private void dpkLastUpdated_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(dpkLastUpdated, cmbUser, "Last Updated",
                Messages.TitleWarehouseInventory);
            }
        }

        private void cmbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbUser, cmbItemLocation, "Operator",
                Messages.TitleWarehouseInventory);
            }
        }

        private void cmbItemLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbItemLocation, cmbStatus, "Item Location",
                Messages.TitleWarehouseInventory);
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab   )
            {
                InputManipulation.InputBoxLeave(cmbStatus, bntSave, "Status",
                Messages.TitleWarehouseInventory);
            }
        }

        private void txtWarehouseSKU_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = txtWarehouseSKU.SelectionStart;
            txtWarehouseSKU.Text = txtWarehouseSKU.Text.ToUpper();
            txtWarehouseSKU.SelectionStart = selectionStart;
        }

        private void txtCostPerUnit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtCostPerUnit_KeyDown(sender, new KeyEventArgs(Keys.Tab));
            }
        }

        private void txtQuantityStock_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtQuantityStock_KeyDown(sender, new KeyEventArgs(Keys.Tab));
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
            var inventoryId = Convert.ToInt32(txtInventoryId.Text.Trim());

            if (inventoryId > 0)
            {

                int deleteResult = RepositoryEntity.DeleteEntity<WarehouseInventory>(inventoryId, entity =>
                {
                    // Optional: Add logging or cleanup before delete
                });


                if (deleteResult > 0)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1,
                        "Warehouse Inventory: " + inventoryId + " Successfully Deleted!",
                        Messages.TitleSuccessDelete);

                    _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                    bindWareHouse();
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Failed to delete inventory.", "DELETE FAILED");
                }
            }
        }
    }
}
