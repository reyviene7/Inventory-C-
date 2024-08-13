using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Inventory.Config;
using Inventory.Entities;
using ServeAll.Core.Entities;
using ServeAll.Core.Entities.request;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWareHouseDelivery : Form
    {
        private FirmMain _main;
        private bool _add, _del, _edt, _wer, _bra;
        private readonly int _userId;
        private readonly int _userTy;
        private IEnumerable<RequestProducts> _products;
        private IEnumerable<RequestQuantity> _quantity;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;
        private IEnumerable<ViewWarehouseDelivery> _warehouse_delivery;
        private IEnumerable<ViewImageProduct> imgList;
        private int InventoryId = 0; 
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FirmWareHouseDelivery(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            InitializeComponent();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
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
            _quantity = EnumerableUtils.getProductWarehouseQuantity();

            try
            {
                braWET.ShowWaitForm();
                BindDeliveryList();
            }
            finally
            {
                if (braWET.IsSplashFormVisible)
                {
                    braWET.CloseWaitForm();
                }
                BindWareHouse();
            }
        }


        private void BindWareHouse()
        {
            clearGrid();

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

        private void clearGrid()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            gridInventory.Columns.Clear();
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
            PopupNotification.PopUpMassageLogOff();
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
           ButtonClr();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
        }
        private void bntDEL_Click(object sender, EventArgs e)
        {
            if (_bra && _wer == false)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delivery No: " + txtLastCost.Text.Trim(' ') + " " + "?", "Delivery Details");
                if (que)
                {
                    ButDel();
                }
                else { ButCan(); }
            }
        }
        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void cmbNAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_wer && _bra == false)
            {
                if (txtProductName.Text.Length > 0)
                {
                    var imgId = GetProductImgId(txtProductName.Text);
                }
            }
        }


        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void txtLST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtLastCost.Focus();
                txtLastCost.BackColor = Color.Yellow;
            }
            else
            {
                txtLastCost.BackColor = Color.White;
            }
        }
        private void txtORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                cmbWarehouse.Focus();
                cmbWarehouse.BackColor = Color.Yellow;
            }
            else
            {
                cmbWarehouse.BackColor = Color.White;
            }
        }
//KEY DOWN
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProducts();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (_wer && _bra == false)
                {
                    var len = txtProductName.Text.Length;
                    if (len > 0)
                    {
                        txtProductName.BackColor = Color.White;
                        txtLastCost.BackColor = Color.Yellow;
                        txtLastCost.Focus();
                        txtProductBarcode.Text = SearchBarcode(txtProductName.Text).product_code;
                        txtItemPrice.Text = SearchBarcode(txtProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                        txtProductName.BackColor = Color.Yellow;
                        txtProductName.Focus();
                    }
                }
            }
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtLastCost.Text.Length;
                if (len > 0)
                {
                    txtLastCost.BackColor = Color.White;
                    txtReceiptNum.Focus();
                    txtReceiptNum.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Delivery No must not be empty!", Messages.GasulPos);
                    txtLastCost.BackColor = Color.Yellow;
                    txtLastCost.Focus();
                }
            }
        }
        private void txtREC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtReceiptNum.Text.Length;
                if (len > 0)
                {
                    txtReceiptNum.BackColor = Color.White;
                    txtWarehouseQty.Focus();
                    txtWarehouseQty.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Receipt No must not be empty!", Messages.GasulPos);
                    txtReceiptNum.BackColor = Color.Yellow;
                    txtReceiptNum.Focus();
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
                    PopupNotification.PopUpMessages(0, "Quantity to deliver must not be empty!", Messages.GasulPos);
                    txtWarehouseQty.BackColor = Color.Yellow;
                    txtWarehouseQty.Focus();
                }
            }
        }
        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
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
                    PopupNotification.PopUpMessages(0, "Branch must not be empty!", Messages.GasulPos);
                    cmbWarehouseBranch.BackColor = Color.Yellow;
                    cmbWarehouseBranch.Focus();
                }
            }
        }
        private void txtLST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtLastCost.Text.Length;
                if (len > 0)
                {
                    txtLastCost.BackColor = Color.White;
                    cmbWarehouse.Focus();
                    cmbWarehouse.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Price on Last Order must not be empty!", Messages.GasulPos);
                    txtLastCost.BackColor = Color.Yellow;
                    txtLastCost.Focus();
                }
            }
        }
        private void txtORD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbWarehouse.Text.Length;
                if (len > 0)
                {
                    cmbWarehouse.BackColor = Color.White;
                    dkpDeliveryDate.Focus();
                    dkpDeliveryDate.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "On Order must not be empty!", Messages.GasulPos);
                    cmbWarehouse.BackColor = Color.Yellow;
                    cmbWarehouse.Focus();
                }
            }
        }
        private void dkpPUR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //pInputDate.Focus();
            }
        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProductStatus.Focus();
            }
        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindStatus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbProductStatus.Text.Length;
                if (len > 0)
                {
                    cmbProductStatus.BackColor = Color.White;
                    //cmbProductWarranty.Focus();
                    //cmbProductWarranty.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product Status must not be empty!", Messages.GasulPos);
                    cmbProductStatus.BackColor = Color.Yellow;
                    cmbProductStatus.Focus();
                }
            }
        }
        private void ButAdd()
        {
            
            ButtonAdd();
            InputEnab();
            InputWhit();
            GenerateWareHouseCode();
            GenerateReceiptCode();
            //indProducts();
            txtProductName.Enabled = false;
            BindBranch();
            BindWarehouseStatus();
            BindDeliveryStatus();
            txtLastCost.BackColor = Color.Yellow;
            txtLastCost.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
        }
        private void ButUpd()
        {
            ButtonUpd();
            InputEnab();
            InputWhit();
            _add = true;
            _edt = true;
            _del = false;
            gridControl.Enabled = false;
        }
        private void ButDel()
        {
            ButtonDel();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gridControl.Enabled = false;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gridControl.Enabled = true;
            txtProductName.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void ButSav()
        {
            if (_add && _edt == false && _del == false)
            {
                    InsertData();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    InputClea();
                    BindWareHouse();
                    BindDeliveryList();
            }
            if (_add == false && _edt && _del == false)
            {
                    UpdateDelivery();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    ClearGrid();
                    InputClea();
            }
            if (_add == false && _edt == false && _del)
            {
                    DeleteData();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    InputClea();
                    ClearGrid();
            }
            BindWareHouse();
            BindDeliveryList();
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            txtProductName.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
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
            bntADD.Enabled = true;
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
            txtDeliveryID.BackColor = Color.White;
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
        private void InputDisb()
        {
            txtDeliveryID.Enabled = false;
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
        private void InputClea()
        {
            txtDeliveryID.Clear();
            txtProductBarcode.Clear();
            txtDeliveryCode.Clear();
            cmbWarehouse.Text = "";
            txtProductName.Clear();
            txtLastCost.Clear();
            txtReceiptNum.Clear();
            txtWarehouseQty.Clear();
            cmbWarehouseBranch.Text = "";
            //cmbProductWarranty.Text = @"NO WARRANTY";
            dkpDeliveryDate.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
            txtItemPrice.Clear();
            txtDeliveryQty.Clear();
            cmbDeliveryStatus.Text = "";
            txtRemarks.Clear();
        }
        private void InputDimG()
        {
            txtDeliveryID.BackColor = Color.DimGray;
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
        private void ClearGrid()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            gridInventory.Columns.Clear();

        }
        private string GetLastBranchesId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewBranchDelivery>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllBranchDelivery)
                              orderby b.Id descending
                              select b.Code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
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
        private void BindDeliveryList()
        {
            ClearGrid();
            var list = EnumerableUtils.getWareHouseDeliveryList().Select(p => new
            {
                ID = p.delivery_id,
                Barcode = p.product_code,
                Code = p.delivery_code,
                Product = p.product_name,
                Destination = p.branch_details,
                DeliveryDate = p.delivery_date,
                Status = p.status_details,
                CostPerItem = p.cost_per_unit,
                DeliverQty = p.delivery_qty,
                DeliveryStatus = p.delivery_status,

        });
            gridControl1.DataSource = list;
            if (gridView1.RowCount > 0)
            {
                gridView1.Columns[0].Width = 10;
                gridView1.Columns[1].Width = 100;
                gridView1.Columns[2].Width = 40;
                gridView1.Columns[3].Width = 300;
                gridView1.Columns[4].Width = 80;
                gridView1.Columns[5].Width = 80;
                gridView1.Columns[6].Width = 80;
                gridView1.Columns[7].Width = 50;
                gridView1.Columns[8].Width = 50;
                gridView1.Columns[9].Width = 100;
            }
        }

        private void BindBranchDel()
        {
            braWET.ShowWaitForm();
            ClearGrid();
            gridControl.DataSource = EnumerableBranch();
            if (gridInventory.RowCount > 0)
            {
                gridInventory.Columns[0].Width = 40;
                gridInventory.Columns[1].Width = 90;
                gridInventory.Columns[2].Width = 280;
                gridInventory.Columns[3].Width = 100;
                gridInventory.Columns[3].Width = 120;
            }
            braWET.CloseWaitForm();

        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = (from r in repository.SelectAll(Query.AllProducts)
                    where r.product_name.Contains(Constant.AddFilterLpg)
                    where !r.product_name.Contains(Constant.AddFilterEmp)
                    select r.product_name.Distinct()).ToList();
                txtProductName.DataBindings.Clear();
                //txtProductName.DataSource = query;
            }
        }
        private void BindStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ProductStatus>(unWork);
                var query = repository.SelectAll(Query.AllProductStatus).Select(x => x.status).Distinct().ToList();
                cmbProductStatus.DataBindings.Clear();
                cmbProductStatus.DataSource = query;
            }
        }
     
        private void BindBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Branch>(unWork);
                var query = repository.SelectAll(Query.SelectAllBranchExcWareH).Select(x => x.branch_details).Distinct().ToList();
                cmbWarehouseBranch.DataBindings.Clear();
                cmbWarehouseBranch.DataSource = query;
            }
        }
        private void BindWarehouseStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<WarehouseStatus>(unWork);
                var query = repository.SelectAll(Query.AllWarehouseStatus).Select(x => x.status_details).Distinct().ToList();
                cmbProductStatus.DataBindings.Clear();
                cmbProductStatus.DataSource = query;
            }
        }
        private void BindDeliveryStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<DeliveryStatus>(unWork);
                var query = repository.SelectAll(Query.AllDeliveryStatus).Select(x => x.delivery_status).Distinct().ToList();
                cmbDeliveryStatus.DataBindings.Clear();
                cmbDeliveryStatus.DataSource = query;
            }
        }
        /*
        private void BindProductWarranty()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Warranty>(unWork);
                var query = repository.SelectAll(Query.AllWarranty).Select(x => x.Name).Distinct().ToList();
                cmbProductWarranty.DataBindings.Clear();
                cmbProductWarranty.DataSource = query;
            }
        }
        */
        /*  private void ShowValue(int inventoryId)
          {
              var ent = ShowEntity(inventoryId);
              txtDeliveryID.Text = ent.Id.ToString();
              txtDeliveryCode.Text = ent.Code;
              cmbProductName.Text = ent.Item;
              txtDeliveryNum.Text = ent.Delivery;
              txtReceiptNum.Text = ent.Receipt;
              txtWarehouseQty.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
              cmbWarehouseBranch.Text = ent.Branch;
              txtLastCost.Text = ent.LastCost.ToString(CultureInfo.InvariantCulture);
              txtOnOrder.Text = ent.OnOrder.ToString();
              dkpDeliveryDate.Value = ent.Purchase;
              dkpInputDate.Value = ent.RefDate;
              cmbProductWarranty.Text = ent.Warranty;
              cmbProductStatus.Text = ent.Status;
              txtDepotID.Text = ent.DepotId.ToString();
          }*/
        private void ShowBranch(int inventoryId)
        {
            var ent = ShowDelivery(inventoryId);
            txtDeliveryID.Text = ent.Id.ToString();
            txtDeliveryCode.Text = ent.Code;
            txtProductName.Text = ent.Item;
            txtLastCost.Text = ent.Delivery;
            txtReceiptNum.Text = ent.Receipt;
            txtWarehouseQty.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbWarehouseBranch.Text = ent.Branch;
            txtLastCost.Text = Constant.DefaultZero.ToString();
            cmbWarehouse.Text = Constant.DefaultZero.ToString();
            dkpDeliveryDate.Value = ent.RefDate;
            cmbProductStatus.Text = ent.Status;
            txtDeliveryQty.Text = ent.WareHouseId.ToString();
        }
        private static int GetProductId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.FindBy(x => x.product_code == input);
                    return query.product_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private static int GetWarehouseCode(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Warehouse>(unWork);
                    var query = repository.FindBy(x => x.warehouse_name == input);
                    return query.warehouse_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Warehouse Id Error", "Warehouse Details");
                    throw;
                }
            }
        }
        private static int GetBranchId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_details == input);
                    return query.branch_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private string GetWarehouse(int input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Warehouse>(unWork);
                    var query = repository.FindBy(x => x.warehouse_id == input);
                    return query.warehouse_name;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static int GetWarrantyId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Warranty>(unWork);
                    var query = repository.FindBy(x => x.Name == input);
                    return query.WarrantyId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Warranty Id Error", "Product Details");
                    throw;
                }
            }
        }
        private static int GetProductStatus(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<WarehouseStatus>(unWork);
                    var query = repository.FindBy(x => x.status_details == input);
                    return query.status_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Warehouse Status Id Error", "Warehouse Details");
                    throw;
                }
            }
        }
        private static int GetDeliveryStatus(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<DeliveryStatus>(unWork);
                    var query = repository.FindBy(x => x.delivery_status == input);
                    return query.delivery_status_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Delivery Status Id Error", "Delivery Details");
                    throw;
                }
            }
        }
        private static int GetProductImgId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProductCategory>(unWork);
                    var query = repository.FindBy(x => x.product_name == input);
                    return query.image_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Image Id Error", "Product Details");
                    throw;
                }
            }
        }
        private static ViewBranchDelivery ShowDelivery(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    var query = repository.FindBy(x => x.Id == inventoryId);
                    return query;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
        private static Products SearchBarcode(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.FindBy(x => x.product_name == input);
                    return query;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product entity Error", "Inventory Details");
                    throw;
                }
            }
        }
        private static IEnumerable<ViewWarehouse> EnumerableWarehouse()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewWarehouse>(unWork);
                    return repository.SelectAll(Query.SelectAllWareHouse)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }


        private static IEnumerable<ViewBranchDelivery> EnumerableBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    return repository.SelectAll(Query.SelectAllBranchDelivery)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }   
        }
        private void InsertData()
        {
            int warehouseQty = int.Parse(txtWarehouseQty.Text);
            int deliveryQty = int.Parse(txtDeliveryQty.Text);

            if (warehouseQty <= deliveryQty)
            {
                PopupNotification.PopUpMessages(0, "Delivery quantity must be less than the warehouse quantity.", "Invalid Input");
                return;
            }

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    braWET.ShowWaitForm();
                    var repository = new Repository<WarehouseDelivery>(unWork);
                    WarehouseDelivery warehouseDel = new WarehouseDelivery
                    {
                        product_id = GetProductId(txtProductBarcode.Text),
                        delivery_code = txtDeliveryCode.Text.Trim(),
                        warehouse_id = GetWarehouseCode(cmbWarehouse.Text),
                        last_cost_per_unit = decimal.Parse(txtLastCost.Text),
                        receipt_number = txtReceiptNum.Text.Trim(),
                        inventory_id = warehouseQty,
                        branch_id = GetBranchId(cmbWarehouseBranch.Text),
                        status_id = GetProductStatus(cmbProductStatus.Text),
                        item_price = decimal.Parse(txtItemPrice.Text),
                        delivery_qty = deliveryQty,
                        delivery_status_id = GetDeliveryStatus(cmbDeliveryStatus.Text),
                        remarks = txtRemarks.Text.Trim(),
                        delivery_date = dkpDeliveryDate.Value.Date
                    };
                    var result = repository.Add(warehouseDel);
                    if (result > 0)
                    {
                        braWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Product Name: " + txtProductName.Text.Trim() + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                        _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                        BindWareHouse();
                    }
                }
                catch (Exception e)
                {
                    braWET.CloseWaitForm();
                    unWork.Rollback();
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private void UpdateDelivery()
        {
            using (var session = new DalSession())
            {
                var deliveryId = int.Parse(txtDeliveryID.Text);
                var unWork = session.UnitofWrk;
                try
                {
                braWET.ShowWaitForm();
                unWork.Begin();
                var repository = new Repository<WarehouseDelivery>(unWork);
                var que = repository.FindBy(x => x.delivery_id == deliveryId);
                que.delivery_code        = txtDeliveryCode.Text;
                que.product_id   = GetProductId(txtProductName.Text);
                que.delivery_qty = int.Parse(txtDeliveryQty.Text);
                    /*
                que.3    = decimal.Parse(txtWarehouseQty.Text);
                que.last  = txtLastCost.Text.Trim(' ');
                que.ReceiptNo   = txtReceiptNum.Text.Trim(' ');
                que.BranchId    = GetBranchId(cmbWarehouseBranch.Text);
                que.LastCost    = decimal.Parse(txtLastCost.Text);
                que.OnOrder     = int.Parse(cmbWarehouse.Text);
                que.StatusId    = GetProductStatus(cmbProductStatus.Text);
                que.DeliveryDate = dkpDeliveryDate.Value.Date;
                var result      = repository.Update(que);
                    if (result)
                    {
                        braWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Delivery Id: " + deliveryId + " successfully Updated!",
                            Messages.GasulPos);
                    }
                    else
                    {
                        braWET.CloseWaitForm();
                        unWork.Rollback();
                    }
                    */

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        private void DeleteData()
        {
            var deliverId = int.Parse(txtDeliveryID.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    braWET.ShowWaitForm();
                    unWork.Begin();
                    var repository = new Repository<BranchDelivery>(unWork);
                    var query = repository.FindBy(x => x.BranchDeliveryId == deliverId);
                    var result = repository.Delete(query);
                    if (result)
                    {
                        braWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Delivery No: " + txtLastCost.Text.Trim(' ') + " successfully Deleted!", Messages.GasulPos);
                    }
                    else
                    {
                        braWET.CloseWaitForm();
                        unWork.Rollback();
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
            }
        }
        private void gridList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridInventory.RowCount > 0)
                try
                {
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                    var inventoryId = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (barcode.Length > 0)
                    {

                        var ent = searchWarehouseInventoryId(barcode);
                          txtDeliveryID.Text = inventoryId;
                          txtProductBarcode.Text = barcode;
                          //txtDeliveryCode.Text = ent.delivery_code;
                          cmbWarehouse.Text = ent.warehouse_name;
                          txtProductName.Text = _products.FirstOrDefault(p => p.product_code == barcode).product_name;
                          txtLastCost.Text = ent.last_cost_per_unit.ToString(CultureInfo.InvariantCulture);
                          //txtReceiptNum.Text = ent.receipt_number;
                          txtWarehouseQty.Text = ent.quantity_in_stock.ToString(CultureInfo.InvariantCulture);
                          //cmbWarehouseBranch.Text = ent.branch_details;
                          //dkpDeliveryDate.Text = ent.delivery_date.ToString(CultureInfo.InvariantCulture);
                          cmbProductStatus.Text = ent.status_details;
                          txtItemPrice.Text = ent.cost_per_unit.ToString(CultureInfo.InvariantCulture);
                          //txtDeliveryQty.Text = ent.delivery_qty.ToString(CultureInfo.InvariantCulture);
                          //cmbDeliveryStatus.Text = dev.delivery_status;
                          //txtRemarks.Text = ent.remarks; 

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
        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount > 0)
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
                        dkpDelDeliveryDate.Text = w.delivery_date.ToString(CultureInfo.InvariantCulture);
                        cmbDelProductStatus.Text = w.status_details;
                        txtDelItemPrice.Text = w.cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtDelQty.Text = w.delivery_qty.ToString(CultureInfo.InvariantCulture);
                        cmbDelDeliveryStatus.Text = w.delivery_status;
                        txtDelRemarks.Text = w.remarks; 

                        var img = searchProductImg(barcode);
                        var imgLocation = img.img_location;
                        if (imgLocation.Length > 0)
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            ImagePreview.ImageLocation = location;
                        }
                        else
                            ImagePreview.Image = null;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        private ViewWareHouseInventory searchWarehouseInventoryId(string barcode)
        {
            return _warehouse_list.FirstOrDefault(Inventory => Inventory.product_code == barcode);
        }

        private void txtDeliveryQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var warehouseItem = int.Parse(txtWarehouseQty.Text);
                var deliveryQty = int.Parse(txtDeliveryQty.Text);

                if (warehouseItem > 0)
                {
                    if (warehouseItem >= deliveryQty)
                    {
                        txtWarehouseQty.Text = (warehouseItem - deliveryQty).ToString();
                        txtWarehouseQty.BackColor = Color.White;
                        cmbDeliveryStatus.Focus();
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Insufficient warehouse quantity!", "INVALID ENTRY");
                        e.Handled = true; // Prevents the invalid operation
                        txtWarehouseQty.Focus();
                    }
                }
            }
        }

        private ViewWarehouseDelivery searchWarehouseDeliveryId(string barcode)
        {
            return _warehouse_delivery.FirstOrDefault(Warehouse => Warehouse.product_code == barcode);
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }
        private string selectedCode(int seletedIndex)
        {
            return _products.FirstOrDefault(i => i.product_id == seletedIndex).product_code;
        }
        private void gridBranch_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridInventory.RowCount > 0)
            {
                InputWhit();
            }
        }
        private void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                InputWhit();
            }
        }
    }
}
