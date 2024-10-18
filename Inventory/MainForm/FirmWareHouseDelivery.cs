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
    public partial class FirmWareHouseDelivery : Form
    {
        private FirmMain _main;
        private bool _add, _del, _edt;
        private readonly int _userId;
        private readonly int _userTy;
        private IEnumerable<RequestProducts> _products;
        private IEnumerable<WarehouseStatus> _warehouseStatus;
        private IEnumerable<Warehouse> _warehouse;
        private IEnumerable<DeliveryStatus> _delivery;
        private IEnumerable<Branch> _branch;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;
        private IEnumerable<ViewWarehouseDelivery> _warehouse_delivery;
        private IEnumerable<ViewImageProduct> imgList;
        private int previousDelQty = 0;
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FirmWareHouseDelivery(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            if (_userTy != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            _warehouse = EnumerableUtils.getWarehouse();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            _warehouseStatus = EnumerableUtils.getStatusWarehouseList();
            _delivery = EnumerableUtils.getWarehouseDelivery();
            _branch = EnumerableUtils.getBranchDetails();
            imgList = EnumerableUtils.getImgProductList();
        }
        private void FirmWarehouseDelivery_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            _products = EnumerableUtils.getProductWarehouseList();
            try
            {
                splashDelivery.ShowWaitForm();
                BindDeliveryList();
            }
            finally
            {
                if (splashDelivery.IsSplashFormVisible)
                {
                    splashDelivery.CloseWaitForm();
                }
                BindWareHouse();
            }
        }
        
        private void clearGridWarehouse()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            gridInventory.Columns.Clear();
        }

        private void clearGridDelivery()
        {
            gridControlDelivery.DataSource = null;
            gridControlDelivery.DataSource = "";
            gridDelivery.Columns.Clear();
        }

        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }
        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }
        private void FirmWareHouseDelivery_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
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
        private void bntADD_Click(object sender, EventArgs e)
        {
            ButAdd();
        }
        private void bntUPD_Click(object sender, EventArgs e)
        {
            ButUpd();
        }
        private void bntSAV_Click(object sender, EventArgs e)
        {
            ButSav();
        }
        private void bntCLR_Click(object sender, EventArgs e)
        {
            splashDelivery.ShowWaitForm();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            imgList = EnumerableUtils.getImgProductList();
            ButtonClr();
            splashDelivery.CloseWaitForm();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
        }
        private void bntDEL_Click(object sender, EventArgs e)
        {

            InputWhit();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delivery No: " + txtDelWarehouseId.Text.Trim(' ') + " " + "?", "Delivery Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
        }
        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            GenerateWareHouseCode();
            GenerateReceiptCode();
            txtProductName.Enabled = false;
            cmbProductStatus.DataBindings.Clear();
            cmbWarehouse.DataBindings.Clear();
            cmbDeliveryStatus.DataBindings.Clear();
            cmbProductStatus.DataSource = _warehouseStatus.Select(p => p.status_details).ToList();
            cmbWarehouse.DataSource = _warehouse.Select(p => p.warehouse_name).ToList();
            cmbDeliveryStatus.DataSource = _delivery.Select(p => p.delivery_status).ToList();
            txtLastCost.BackColor = Color.Yellow;
            txtLastCost.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
            cmbWarehouseBranch.Text = "Main Branch";
            cmbDeliveryStatus.Text = "Processing";
            txtRemarks.Text = "N/A";
        }
        private void ButUpd()
        {
            ButtonUpd();
            inputEnableDelivery();
            InputWhit();
            cmbDelProductStatus.DataBindings.Clear();
            cmbDelWarehouseCode.DataBindings.Clear();
            cmbDelDeliveryStatus.DataBindings.Clear();
            cmbDelProductStatus.DataSource = _warehouseStatus.Select(p => p.status_details).ToList();
            cmbDelWarehouseCode.DataSource = _warehouse.Select(p => p.warehouse_name).ToList();
            cmbDelDeliveryStatus.DataSource = _delivery.Select(p => p.delivery_status).ToList();
            _add = false;
            _edt = true;
            _del = false;
            gridControlDelivery.Enabled = false;
        }
        private void ButDel()
        {
            ButtonDel();
            inputEnableDelivery();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gridControlDelivery.Enabled = false;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDisbDel();
            InputDimG();
            InputClea();
            InputCleaDel();
            gridControl.Enabled = true;
            gridControlDelivery.Enabled = true;
            txtProductName.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
            ImagePreview.DataBindings.Clear();
            ImagePreview.Image = null;
        }
        private void ButSav()
        {
            if (_add && _edt == false && _del == false)
            {
                if (string.IsNullOrEmpty(txtDeliveryQty.Text) || !int.TryParse(txtDeliveryQty.Text, out int deliveryQty) || deliveryQty <= 0)
                {
                    // Show a popup notification for invalid delivery quantity
                    PopupNotification.PopUpMessages(0, "Invalid delivery quantity. Please enter a valid number.", "Inventory System");
                    return; // Exit the method if the condition is not met
                }
                InsertData();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
                
            }
            if (_add == false && _edt && _del == false)
            {
                UpdateDelivery();
                ButtonSav();
                InputDisbDel();
                InputDimG();
                InputCleaDel();
                _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            }
            if (_add == false && _edt == false && _del)
            {
                DeleteData();
                ButtonSav();
                InputDisbDel();
                InputDimG();
                InputCleaDel();
                _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            }
            BindWareHouse();
            BindDeliveryList();
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            gridControlDelivery.Enabled = true;
            txtProductName.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
            ImagePreview.DataBindings.Clear();
            ImagePreview.Image = null;
        }
        private void ButtonAdd()
        {
            bntADD.Enabled = true;
            bntUPDATE.Enabled = false;
            bntDELETE.Enabled = false;
            bntSAVE.Enabled = true;
            bntCLEAR.Enabled = false;
            bntCANCEL.Enabled = true;
            bntHOME.Enabled = false;

        }
        private void ButtonUpd()
        {
            bntADD.Enabled = false;
            bntUPDATE.Enabled = true;
            bntDELETE.Enabled = false;
            bntSAVE.Enabled = true;
            bntCLEAR.Enabled = false;
            bntCANCEL.Enabled = true;
            bntHOME.Enabled = false;
        }
        private void ButtonDel()
        {
            bntADD.Enabled = false;
            bntUPDATE.Enabled = false;
            bntDELETE.Enabled = true;
            bntSAVE.Enabled = true;
            bntCLEAR.Enabled = false;
            bntCANCEL.Enabled = true;
            bntHOME.Enabled = false;

        }
        private void ButtonSav()
        {
            bntADD.Enabled = true;
            bntUPDATE.Enabled = true;
            bntDELETE.Enabled = true;
            bntSAVE.Enabled = false;
            bntCLEAR.Enabled = true;
            bntCANCEL.Enabled = false;
            bntHOME.Enabled = true;

        }
        private void ButtonClr()
        {
            bntADD.Enabled = true;
            bntUPDATE.Enabled = true;
            bntDELETE.Enabled = true;
            bntSAVE.Enabled = false;
            bntCLEAR.Enabled = false;
            bntCANCEL.Enabled = false;
            bntHOME.Enabled = true;

        }
        private void ButtonCan()
        {
            bntADD.Enabled = true;
            bntUPDATE.Enabled = true;
            bntDELETE.Enabled = true;
            bntSAVE.Enabled = false;
            bntCLEAR.Enabled = true;
            bntCANCEL.Enabled = false;
            bntHOME.Enabled = true;

        }
        private void InputWhit()
        {
            txtInventoryId.BackColor = Color.White;
            txtProductBarcode.BackColor = Color.White;
            txtDeliveryCode.BackColor = Color.White;
            txtProductName.BackColor = Color.White;
            txtLastCost.BackColor = Color.White;
            txtReceiptNum.BackColor = Color.White;
            txtWarehouseQty.BackColor = Color.White;
            cmbWarehouseBranch.BackColor = Color.White;
            txtLastCost.BackColor = Color.White;
            cmbWarehouse.BackColor = Color.White;
            dkpDeliveryDate.BackColor = Color.White;
            txtItemPrice.BackColor = Color.White;
            txtDeliveryQty.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
            cmbDeliveryStatus.BackColor = Color.White;
            txtRemarks.BackColor = Color.White;
            txtDelWarehouseId.BackColor = Color.White;
            txtDelWarehouseCode.BackColor = Color.White;
            txtDelProduct.BackColor = Color.White;
            cmbDelWarehouseCode.BackColor = Color.White;
            txtDelProductName.BackColor = Color.White;
            txtDelLastCost.BackColor = Color.White;
            txtDelReceipt.BackColor = Color.White;
            txtDelRemainQty.BackColor = Color.White;
            cmbDelBranch.BackColor = Color.White;
            dkpDelDeliveryDate.BackColor = Color.White;
            cmbDelProductStatus.BackColor = Color.White;
            txtDelItemPrice.BackColor = Color.White;
            txtDelQty.BackColor = Color.White;
            cmbDelDeliveryStatus.BackColor = Color.White;
            txtDelRemarks.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtDeliveryCode.Enabled = true;
            cmbWarehouse.Enabled = true;
            txtProductName.Enabled = true;
            txtLastCost.Enabled = true;
            txtReceiptNum.Enabled = true;
            cmbWarehouseBranch.Enabled = true;
            dkpDeliveryDate.Enabled = true;
            txtItemPrice.Enabled = true;
            txtDeliveryQty.Enabled = true;
            cmbProductStatus.Enabled = true;
            cmbDeliveryStatus.Enabled = true;
            txtRemarks.Enabled = true;
        }
        private void inputEnableDelivery()
        {
            txtDelWarehouseCode.Enabled = true;
            cmbDelWarehouseCode.Enabled = true;
            txtDelProductName.Enabled = true;
            txtDelLastCost.Enabled = true;
            txtDelReceipt.Enabled = true;
            cmbDelBranch.Enabled = true;
            dkpDelDeliveryDate.Enabled = true;
            txtDelItemPrice.Enabled = true;
            txtDelQty.Enabled = true;
            cmbDelProductStatus.Enabled = true;
            cmbDelDeliveryStatus.Enabled = true;
            txtDelRemarks.Enabled = true;
        }
        private void InputDisb()
        {
            txtInventoryId.Enabled = false;
            txtProductBarcode.Enabled = false;
            txtDeliveryCode.Enabled = false;
            cmbWarehouse.Enabled = false;
            txtProductName.Enabled = false;
            txtLastCost.Enabled = false;
            txtReceiptNum.Enabled = false;
            txtWarehouseQty.Enabled = false;
            cmbWarehouseBranch.Enabled = false;
            dkpDeliveryDate.Enabled = false;
            cmbProductStatus.Enabled = false;
            txtItemPrice.Enabled = false;
            txtDeliveryQty.Enabled = false;
            cmbDeliveryStatus.Enabled = false;
            txtRemarks.Enabled = false;
        }
        private void InputDisbDel()
        {
            txtDelWarehouseId.Enabled = false;
            txtDelProduct.Enabled = false;
            txtDelRemainQty.Enabled = false;
            txtDelWarehouseCode.Enabled = false;
            cmbDelWarehouseCode.Enabled = false;
            txtDelProductName.Enabled = false;
            txtDelLastCost.Enabled = false;
            txtDelReceipt.Enabled = false;
            cmbDelBranch.Enabled = false;
            dkpDelDeliveryDate.Enabled = false;
            txtDelItemPrice.Enabled = false;
            txtDelQty.Enabled = false;
            cmbDelProductStatus.Enabled = false;
            cmbDelDeliveryStatus.Enabled = false;
            txtDelRemarks.Enabled = false;
        }
        private void InputClea()
        {
            txtInventoryId.Clear();
            txtProductBarcode.Clear();
            txtDeliveryCode.Clear();
            cmbWarehouse.Text = "";
            txtProductName.Clear();
            txtLastCost.Clear();
            txtReceiptNum.Clear();
            txtWarehouseQty.Clear();
            cmbWarehouseBranch.Text = "";
            dkpDeliveryDate.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
            txtItemPrice.Clear();
            txtDeliveryQty.Clear();
            cmbDeliveryStatus.Text = "";
            txtRemarks.Clear();
        }
        private void InputCleaDel()
        {
            txtDelWarehouseId.Clear();
            txtDelProduct.Clear();
            txtDelWarehouseCode.Clear();
            cmbDelWarehouseCode.Text = "";
            txtDelProductName.Clear();
            txtDelLastCost.Clear();
            txtDelReceipt.Clear();
            txtDelRemainQty.Clear();
            cmbDelBranch.Text = "";
            dkpDelDeliveryDate.Value = DateTime.Now.Date;
            cmbDelProductStatus.Text = "";
            txtDelItemPrice.Clear();
            txtDelQty.Clear();
            cmbDelDeliveryStatus.Text = "";
            txtDelRemarks.Clear();
        }
        private void InputDimG()
        {
            txtInventoryId.BackColor = Color.DimGray;
            txtProductBarcode.BackColor = Color.DimGray;
            txtDeliveryCode.BackColor = Color.DimGray;
            cmbWarehouse.BackColor = Color.DimGray;
            txtProductName.BackColor = Color.DimGray;
            txtLastCost.BackColor = Color.DimGray;
            txtReceiptNum.BackColor = Color.DimGray;
            txtWarehouseQty.BackColor = Color.DimGray;
            cmbWarehouseBranch.BackColor = Color.DimGray;
            txtLastCost.BackColor = Color.DimGray;
            dkpDeliveryDate.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
            txtItemPrice.BackColor = Color.DimGray;
            txtDeliveryQty.BackColor = Color.DimGray;
            cmbDeliveryStatus.BackColor = Color.DimGray;
            txtRemarks.BackColor = Color.DimGray;
            txtDelWarehouseId.BackColor = Color.DimGray;
            txtDelWarehouseCode.BackColor = Color.DimGray;
            txtDelProduct.BackColor = Color.DimGray;
            cmbDelWarehouseCode.BackColor = Color.DimGray;
            txtDelProductName.BackColor = Color.DimGray;
            txtDelLastCost.BackColor = Color.DimGray;
            txtDelReceipt.BackColor = Color.DimGray;
            txtDelRemainQty.BackColor = Color.DimGray;
            cmbDelBranch.BackColor = Color.DimGray;
            dkpDelDeliveryDate.BackColor = Color.DimGray;
            cmbDelProductStatus.BackColor = Color.DimGray;
            txtDelItemPrice.BackColor = Color.DimGray;
            txtDelQty.BackColor = Color.DimGray;
            cmbDelDeliveryStatus.BackColor = Color.DimGray;
            txtDelRemarks.BackColor = Color.DimGray;
        }
        //KEY DOWN
        private void txtLastCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtLastCost.Text.Length;
                if (len > 0)
                {
                    txtLastCost.BackColor = Color.White;
                    txtItemPrice.Focus();
                    txtItemPrice.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Last Cost must must have be a value!", Messages.InventorySystem);
                    txtLastCost.BackColor = Color.Yellow;
                    txtLastCost.Focus();
                }
            }
        }

        private void txtItemPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtItemPrice.Text.Length;
                if (len > 0)
                {
                    txtItemPrice.BackColor = Color.White;
                    txtDeliveryQty.Focus();
                    txtDeliveryQty.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Item Price must have be a value!", Messages.InventorySystem);
                    txtItemPrice.BackColor = Color.Yellow;
                    txtItemPrice.Focus();
                }
            }
        }

        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtWarehouseQty.Text.Length;
                if (len > 0)
                {
                    txtWarehouseQty.BackColor = Color.White;
                    cmbWarehouseBranch.Focus();
                    cmbWarehouseBranch.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Quantity to deliver must not be empty!", Messages.InventorySystem);
                    txtWarehouseQty.BackColor = Color.Yellow;
                    txtWarehouseQty.Focus();
                }
            }
        }

        private void txtDeliveryQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var warehouseItem = int.Parse(txtWarehouseQty.Text);

                if (!int.TryParse(txtDeliveryQty.Text, out int deliveryQty) || deliveryQty <= 0)
                {
                    PopupNotification.PopUpMessages(0, "Invalid delivery quantity. Please enter a valid number.", "INVALID ENTRY");
                    txtDeliveryQty.BackColor = Color.Red;
                    txtDeliveryQty.Focus();
                    e.SuppressKeyPress = true;
                    return;
                }

                if (warehouseItem > 0)
                {
                    if (warehouseItem >= deliveryQty)
                    {
                        txtWarehouseQty.Text = (warehouseItem - deliveryQty).ToString();
                        txtDeliveryQty.BackColor = Color.White;
                        txtWarehouseQty.BackColor = Color.White;
                        cmbDeliveryStatus.Focus();
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Insufficient warehouse quantity!", "INVALID ENTRY");
                        e.Handled = true; 
                        txtWarehouseQty.Focus();
                    }
                }
            }
        }

        private void cmbWarehouseBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbWarehouseBranch.Text.Length;
                if (len > 0)
                {
                    cmbWarehouseBranch.BackColor = Color.White;
                    dkpDeliveryDate.Focus();
                    dkpDeliveryDate.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Branch must not be empty!", Messages.InventorySystem);
                    cmbWarehouseBranch.BackColor = Color.Yellow;
                    cmbWarehouseBranch.Focus();
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                cmbWarehouseBranch.DataBindings.Clear();
                cmbWarehouseBranch.DataSource = _branch.Select(p => p.branch_details).ToList();
            }
        }

        private void dkpDeliveryDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = dkpDeliveryDate.Text.Length;
                if (len > 0)
                {
                    dkpDeliveryDate.BackColor = Color.White; 
                    bntSAVE.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Delivery Date must not be empty!", Messages.InventorySystem);
                    dkpDeliveryDate.BackColor = Color.Yellow;
                    dkpDeliveryDate.Focus();
                }
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtRemarks.Text.Length;
                if (len > 0)
                {
                    txtRemarks.BackColor = Color.White;
                    dkpDeliveryDate.Focus();
                    dkpDeliveryDate.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Remarks must not be empty!", Messages.InventorySystem);
                    txtRemarks.BackColor = Color.Yellow;
                    txtRemarks.Focus();
                }
            }
        }

        private void txtDelQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var warehouseDelItem = int.Parse(txtDelRemainQty.Text);
                var deliveryDelQty = int.Parse(txtDelQty.Text);
                var qtyDifference = deliveryDelQty - previousDelQty; 
                if (warehouseDelItem > 0)
                {
                    if (warehouseDelItem >= qtyDifference)
                    {
                        txtDelRemainQty.Text = (warehouseDelItem - qtyDifference).ToString();
                        txtDelRemainQty.BackColor = Color.White;
                        cmbDelDeliveryStatus.Focus();
                        previousDelQty = deliveryDelQty;
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Insufficient warehouse quantity!", "INVALID ENTRY");
                        e.Handled = true; 
                        txtDelRemainQty.Focus();
                    }
                }
            }
            else
            {
                previousDelQty = int.Parse(txtDelQty.Text); 
            }
        }


        private void cmbDelProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbDelProductStatus.DataBindings.Clear();
                cmbDelProductStatus.DataSource = _warehouseStatus.Select(p => p.status_details).ToList();
            }
        }
        private void cmbProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbProductStatus.DataBindings.Clear();
                cmbProductStatus.DataSource = _warehouseStatus.Select(p => p.status_details).ToList();
            }
        }
        private void cmbWarehouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbWarehouse.DataBindings.Clear();
                cmbWarehouse.DataSource = _warehouse.Select(p => p.warehouse_name).ToList();
            }
        }
        private void cmbDelWarehouseCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbDelWarehouseCode.DataBindings.Clear();
                cmbDelWarehouseCode.DataSource = _warehouse.Select(p => p.warehouse_name).ToList();
            }
        }
        private void cmbDeliveryStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbDeliveryStatus.DataBindings.Clear();
                cmbDeliveryStatus.DataSource = _delivery.Select(p => p.delivery_status).ToList();
            }
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbDeliveryStatus.Text.Length;
                if (len > 0)
                {
                    cmbDeliveryStatus.BackColor = Color.White;
                    txtRemarks.Focus();
                    txtRemarks.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Delivery Status must not be empty!", Messages.InventorySystem);
                    cmbDeliveryStatus.BackColor = Color.Yellow;
                    cmbDeliveryStatus.Focus();
                }
            }
        }
        private void cmbDelDeliveryStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbDelDeliveryStatus.DataBindings.Clear();
                cmbDelDeliveryStatus.DataSource = _delivery.Select(p => p.delivery_status).ToList();
            }
        }

        private void cmbDelBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbDelBranch.DataBindings.Clear();
                cmbDelBranch.DataSource = _branch.Select(p => p.branch_details).ToList();
            }
        }

        private void gridList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewWarehouse(sender);
        }

        private void gridDelivery_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewDelivery(sender);
        }

        private void gridViewWarehouse(object sender)
        {
            if (gridInventory.RowCount > 0)
                try
                {
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                    var inventoryId = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (barcode.Length > 0)
                    {

                        var ent = searchWarehouseInventoryId(barcode);
                        txtInventoryId.Text = inventoryId;
                        txtProductBarcode.Text = barcode;
                        cmbWarehouse.Text = ent.warehouse_name;
                        txtProductName.Text = _products.FirstOrDefault(p => p.product_code == barcode).product_name;
                        txtLastCost.Text = ent.last_cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtWarehouseQty.Text = ent.quantity_in_stock.ToString(CultureInfo.InvariantCulture);
                        cmbProductStatus.Text = ent.status_details;
                        txtItemPrice.Text = ent.cost_per_unit.ToString(CultureInfo.InvariantCulture);

                        var img = searchProductImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            imgPRO.ImageLocation = location;
                        }
                        else
                            imgPRO.Image = null;
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
                            ImagePreview.ImageLocation = location;
                            ImagePreview.Refresh();
                        }
                        else
                        {
                            ImagePreview.Image = null;
                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }

        private ViewWareHouseInventory searchWarehouseInventoryId(string barcode)
        {
            return _warehouse_list.FirstOrDefault(Inventory => Inventory.product_code == barcode);
        }
        private ViewWarehouseDelivery searchWarehouseDeliveryId(string barcode)
        {
            return _warehouse_delivery.FirstOrDefault(Warehouse => Warehouse.product_code == barcode);
        }

        private void gridDelivery_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridDelivery.RowCount > 0)
            {
                InputWhit();
            }
        }

        private void gridBranch_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridInventory.RowCount > 0)
            {
                InputWhit();
            }
        }
        private void GenerateWareHouseCode()
        {
            var lastWarehouseDeliveryCode = FetchUtils.GetLastWarehouseDeliveryCode();
            int lastWarehouseDeliveryNumber;

            if (string.IsNullOrEmpty(lastWarehouseDeliveryCode) || !int.TryParse(lastWarehouseDeliveryCode.Replace("DC", ""), out lastWarehouseDeliveryNumber))
            {
                lastWarehouseDeliveryNumber = 0;
            }

            var alphaNumeric = new GenerateAlpaDev("DC", 3, lastWarehouseDeliveryNumber);
            alphaNumeric.Increment();
            txtDeliveryCode.Text = alphaNumeric.ToString();
            txtDeliveryCode.Focus();
        }
        private void GenerateReceiptCode()
        {
            var lastReceiptCode = FetchUtils.GetLastReceiptCode();
            int lastReceiptNumber;

            if (string.IsNullOrEmpty(lastReceiptCode) || !int.TryParse(lastReceiptCode.Replace("RCPT", ""), out lastReceiptNumber))
            {
                lastReceiptNumber = 0;
            }

            var alphaNumeric = new GenerateAlpaRcpt("RCPT", 3, lastReceiptNumber);
            alphaNumeric.Increment();
            txtReceiptNum.Text = alphaNumeric.ToString();
            txtReceiptNum.Focus();
        }
        private void BindWareHouse()
        {
            clearGridWarehouse();
            var list = _warehouse_list.Select(p => new {
                Id = p.inventory_id,
                Barcode = p.product_code,
                SKU = p.sku,
                Qty = p.quantity_in_stock,
                Location = p.location_code,
                Supplier = p.supplier_name,
                Price = p.cost_per_unit,
                LastCost = p.last_cost_per_unit,
                Total = p.total_value,
                Expire = p.expiration_date,
                Status = p.status_details
            }).ToList();

            gridControl.DataSource = list;
            gridControl.Update();

            if (gridInventory.RowCount > 0)
            {
                gridInventory.Columns[0].Width = 40;
                gridInventory.Columns[1].Width = 130;
                gridInventory.Columns[2].Width = 65;
                gridInventory.Columns[3].Width = 40;
                gridInventory.Columns[4].Width = 100;
                gridInventory.Columns[5].Width = 180;
            }
        }
        private void BindDeliveryList()
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
        private void InsertData()
        {
            int warehouseQty = int.Parse(txtWarehouseQty.Text);
            int deliveryQty = int.Parse(txtDeliveryQty.Text);
            int inventoryId = int.Parse(txtInventoryId.Text);
            var warehouseId = FetchUtils.getWarehouseId(cmbWarehouse.Text);
            if (deliveryQty >= warehouseQty)
            {
                PopupNotification.PopUpMessages(0, "Delivery quantity must be less than the warehouse quantity.", "Invalid Input");
                return;
            }
            if (deliveryQty > 0)
            {
                splashDelivery.ShowWaitForm();
                WarehouseDelivery warehouseDel = new WarehouseDelivery
                {
                    product_id = FetchUtils.getProductIdBarcode(txtProductBarcode.Text),
                    delivery_code = txtDeliveryCode.Text.Trim(),
                    warehouse_id = warehouseId,
                    last_cost_per_unit = decimal.Parse(txtLastCost.Text),
                    receipt_number = txtReceiptNum.Text.Trim(),
                    inventory_id = inventoryId,
                    branch_id = FetchUtils.getBranchId(cmbWarehouseBranch.Text),
                    status_id = FetchUtils.getStatusId(cmbProductStatus.Text),
                    user_id = _userId,
                    item_price = decimal.Parse(txtItemPrice.Text),
                    delivery_qty = deliveryQty,
                    delivery_status_id = FetchUtils.getDeliveryStatus(cmbDeliveryStatus.Text),
                    remarks = txtRemarks.Text.Trim(),
                    delivery_date = dkpDeliveryDate.Value.Date
                };
                var result = RepositoryEntity.AddEntity<WarehouseDelivery>(warehouseDel);
                if (result > 0)
                {
                    splashDelivery.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Delivery Code: " + txtDeliveryCode.Text.Trim() + " Successfully Delivered!", Messages.InventorySystem);
                    _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                    BindWareHouse();
                }
                else
                {
                    splashDelivery.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Delivery Code: " + txtDeliveryCode.Text.Trim() + " Failed to Add!", Messages.InventorySystem);
                }
            }
        }

        private void UpdateDelivery()
        {
            var deliveryId = int.Parse(txtDelWarehouseId.Text.Trim());
            int warehouseQty = int.Parse(txtDelRemainQty.Text);
            int deliveryQty = int.Parse(txtDelQty.Text.Trim());
            var warehouseId = FetchUtils.getWarehouseId(cmbDelWarehouseCode.Text);
            var productId = FetchUtils.getProductIdBarcode(txtDelProduct.Text.Trim());
            int qtyDifference = 0;
            if (deliveryId > 0)
            {
                splashDelivery.ShowWaitForm();

                    int deliveryResult = RepositoryEntity.UpdateEntity<WarehouseDelivery>(deliveryId, entity =>
                    {
                        int oldDeliveryQty = entity.delivery_qty;
                        qtyDifference = deliveryQty - oldDeliveryQty;

                        entity.delivery_code = txtDelWarehouseCode.Text.Trim();
                        entity.product_id = productId;
                        entity.warehouse_id = warehouseId;
                        entity.last_cost_per_unit = decimal.Parse(txtDelLastCost.Text.Trim());
                        entity.receipt_number = txtDelReceipt.Text.Trim();
                        // Keep the same inventory ID
                        entity.inventory_id = entity.inventory_id;
                        entity.branch_id = FetchUtils.getBranchId(cmbDelBranch.Text.Trim());
                        entity.status_id = FetchUtils.getStatusId(cmbDelProductStatus.Text.Trim());
                        entity.user_id = _userId;
                        entity.item_price = decimal.Parse(txtDelItemPrice.Text.Trim());
                        entity.delivery_qty = deliveryQty;
                        entity.delivery_status_id = FetchUtils.getDeliveryStatus(cmbDelDeliveryStatus.Text.Trim());
                        entity.remarks = txtDelRemarks.Text.Trim();
                        entity.delivery_date = dkpDeliveryDate.Value.Date;
                        entity.update_on = DateTime.Now;
                    });
                    if (deliveryResult > 0)
                    {
                    
                    // Update the request quantity in stock
                    var inventoryResult = RepositoryEntity.UpdateEntity<WarehouseDelivery>(deliveryId, entity =>
                    {
                        var inventoryId = entity.inventory_id; 
                        var quantityResult = RepositoryEntity.UpdateEntity<RequestQuantity>(inventoryId, reqEntity =>
                        {
                            reqEntity.quantity_in_stock -= qtyDifference; // Make sure this property exists
                            splashDelivery.CloseWaitForm();
                            PopupNotification.PopUpMessages(1, "Delivery ID: " + deliveryId + " Successfully Updated!", "UPDATE DELIVERY");
                            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                            BindWareHouse();
                        });
                    });
                    if (inventoryResult == 0)
                    {
                        splashDelivery.CloseWaitForm();
                        PopupNotification.PopUpMessages(0, "Failed to retrieve inventory.", "UPDATE FAILED");
                    }
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Failed to update delivery.", "UPDATE FAILED");
                }
            }
        }
        private void DeleteData()
        {
            var deliveryId = Convert.ToInt32(txtDelWarehouseId.Text.Trim());

            if (deliveryId > 0)
            {
                splashDelivery.ShowWaitForm();

                int deleteResult = RepositoryEntity.DeleteEntity<WarehouseDelivery>(deliveryId, entity =>
                {
                    int? inventoryId = entity.inventory_id;
                    if (inventoryId.HasValue)
                    {
                        RepositoryEntity.UpdateEntity<RequestQuantity>(inventoryId.Value, qtyEntity =>
                        {
                            qtyEntity.quantity_in_stock += entity.delivery_qty;
                        });
                    }
                });

                if (deleteResult > 0)
                {
                    splashDelivery.CloseWaitForm();
                    PopupNotification.PopUpMessages(1,
                        "Delivery ID: " + deliveryId + " Successfully Deleted!",
                        Messages.TitleSuccessDelete);

                    _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
                    BindDeliveryList();
                }
                else
                {
                    splashDelivery.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Failed to delete delivery.", "DELETE FAILED");
                }
            }
        }

    }
}