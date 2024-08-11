using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Inventory.Config;
using Inventory.Entities;
using Inventory.PopupForm;
using Inventory.Services;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWareHouseDelivery : Form
    {
        private FirmMain _main;
        private bool _add, _del, _edt, _wer, _bra;
        private readonly int _userId;
        private readonly int _userTy;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;

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
        }
        private async void FirmWarehouseDelivery_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            _bra = true;
            _wer = true;

            try
            {
                // Start showing the wait form
                braWET.ShowWaitForm();

                // Bind the other lists
                BindDeliveryList();
            }
            finally
            {
                // Ensure the wait form is closed
                if (braWET.IsSplashFormVisible)
                {
                    braWET.CloseWaitForm();
                }

                // Bind the warehouse data after closing the wait form
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

            gridControl.DataSource = list;
            gridControl.Update();

            if (gridList.RowCount > 0)
            {
                gridList.Columns[0].Width = 40;
                gridList.Columns[1].Width = 90;
                gridList.Columns[2].Width = 65;
                gridList.Columns[3].Width = 40;
                gridList.Columns[4].Width = 40;
                gridList.Columns[6].Width = 180;
            }
        }

        private void clearGrid()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            gridList.Columns.Clear();
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
                        "Are you sure you want to Delivery No: " + txtLastItemCost.Text.Trim(' ') + " " + "?", "Delivery Details");
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
                if (cmbProductName.Text.Length > 0)
                {
                    var imgId = GetProductImgId(cmbProductName.Text);
                }
            }
        }
     
       
        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtWarehouseQty.Focus();
                txtWarehouseQty.BackColor = Color.Yellow;
            }
            else
            {
                txtWarehouseQty.BackColor = Color.White;
            }
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
                txtOnOrder.Focus();
                txtOnOrder.BackColor = Color.Yellow;
            }
            else
            {
                txtOnOrder.BackColor = Color.White;
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
                    var len = cmbProductName.Text.Length;
                    if (len > 0)
                    {
                        cmbProductName.BackColor = Color.White;
                        txtLastItemCost.BackColor = Color.Yellow;
                        txtLastItemCost.Focus();
                        txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                        txtItemPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                        cmbProductName.BackColor = Color.Yellow;
                        cmbProductName.Focus();
                    }
                }
            }
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtLastItemCost.Text.Length;
                if (len > 0)
                {
                    txtLastItemCost.BackColor = Color.White;
                    txtReceiptNum.Focus();
                    txtReceiptNum.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Delivery No must not be empty!", Messages.GasulPos);
                    txtLastItemCost.BackColor = Color.Yellow;
                    txtLastItemCost.Focus();
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
                    txtOnOrder.Focus();
                    txtOnOrder.BackColor = Color.Yellow;
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
                var len = txtOnOrder.Text.Length;
                if (len > 0)
                {
                    txtOnOrder.BackColor = Color.White;
                    dkpDeliveryDate.Focus();
                    dkpDeliveryDate.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "On Order must not be empty!", Messages.GasulPos);
                    txtOnOrder.BackColor = Color.Yellow;
                    txtOnOrder.Focus();
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
            if (_wer && _bra == false)
            {
                ButtonAdd();
                txtLastItemCost.Enabled = true;
                txtReceiptNum.Enabled = true;
                txtWarehouseQty.Enabled = true;
                cmbWarehouseBranch.Enabled = true;
                dkpDeliveryDate.Enabled = true;
                cmbProductStatus.Enabled = true;
                txtLastItemCost.Clear();
                txtReceiptNum.Clear();
                InputWhit();
                GenerateWareHouseCode();
            }
            //indProducts();
            cmbProductName.Enabled = false;
            BindBranch();
            BindProductStatus();
            txtLastItemCost.BackColor = Color.Yellow;
            txtLastItemCost.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void ButUpd()
        {
            ButtonUpd();
            InputEnab();
            InputWhit();
            _add = false;
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
            cmbProductName.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void ButSav()
        {
            if (_add && _edt == false && _del == false)
            {
                if (_wer && _bra == false)
                {
                    InsertData();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    InputClea();
                    ClearGrid();
                }
               
            }
            if (_add == false && _edt && _del == false)
            {

                if (_bra && _wer == false)
                {
                   UpdateBranch();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    ClearGrid();
                    InputClea();
                }
            }
            if (_add == false && _edt == false && _del)
            {

                if (_bra && _wer == false)
                {
                    DeleteData();
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    InputClea();
                    ClearGrid();
                }
            }
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            cmbProductName.DataBindings.Clear();
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
            txtDeliveryID.BackColor = Color.White;
            txtDeliveryCode.BackColor = Color.White;
            cmbProductName.BackColor = Color.White;
            txtLastItemCost.BackColor = Color.White;
            txtReceiptNum.BackColor = Color.White;
            txtWarehouseQty.BackColor = Color.White;
            cmbWarehouseBranch.BackColor = Color.White;
            txtLastCost.BackColor = Color.White;
            txtOnOrder.BackColor = Color.White;
            dkpDeliveryDate.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtDeliveryID.Enabled = true;
            txtDeliveryCode.Enabled = true;
            cmbProductName.Enabled = true;
            txtLastItemCost.Enabled = true;
            txtReceiptNum.Enabled = true;
            txtWarehouseQty.Enabled = true;
            cmbWarehouseBranch.Enabled = true;
            txtLastCost.Enabled = true;
            txtOnOrder.Enabled = true;
            dkpDeliveryDate.Enabled = true;
            cmbProductStatus.Enabled = true;
        }
        private void InputDisb()
        {
            txtDeliveryID.Enabled = false;
            txtDeliveryCode.Enabled = false;
            cmbProductName.Enabled = false;
            txtLastItemCost.Enabled = false;
            txtReceiptNum.Enabled = false;
            txtWarehouseQty.Enabled = false;
            cmbWarehouseBranch.Enabled = false;
            txtLastCost.Enabled = false;
            txtOnOrder.Enabled = false;
            dkpDeliveryDate.Enabled = false;
            cmbProductStatus.Enabled = false;
        }
        private void InputClea()
        {
            txtDeliveryID.Clear();
            txtDeliveryCode.Clear();
            cmbProductName.Text = "";
            txtLastItemCost.Clear();
            txtReceiptNum.Clear();
            txtWarehouseQty.Clear();
            cmbWarehouseBranch.Text = "";
            //cmbProductWarranty.Text = @"NO WARRANTY";
            txtLastCost.Clear();
            txtOnOrder.Clear();
            dkpDeliveryDate.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
        }
        private void InputDimG()
        {
            txtDeliveryID.BackColor = Color.DimGray;
            txtDeliveryCode.BackColor = Color.DimGray;
            cmbProductName.BackColor = Color.DimGray;
            txtLastItemCost.BackColor = Color.DimGray;
            txtReceiptNum.BackColor = Color.DimGray;
            txtWarehouseQty.BackColor = Color.DimGray;
            cmbWarehouseBranch.BackColor = Color.DimGray;
            txtLastCost.BackColor = Color.DimGray;
            txtOnOrder.BackColor = Color.DimGray;
            dkpDeliveryDate.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
        }
        private void ClearGrid()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            gridList.Columns.Clear();

        }
        private string GetLastWareHouseId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewWarehouse>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllWareHouse)
                              orderby b.warehouse_name descending
                              select b.contact_name).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
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
            var lastCode = GetLastWareHouseId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum("D", 3, lastId);
            alphaNumeric.Increment();
            txtDeliveryCode.Text = alphaNumeric.ToString();
        }
        private void BindStockMovementList()
        {
            braWET.ShowWaitForm();
            ClearGrid();
            var list = EnumerableUtils.getStockMovementList().Select(p => new
            {
                ID = p.stock_movement_id,
                Code = p.movement_code,
                Destination = p.destination,
                DeliveryDate = p.delivery_date,
                MoveType = p.movement_type,
                ProductCount = p.distinct_product_count
            });
            gridControl.DataSource = list;
            if (gridList.RowCount > 0)
            {
                gridList.Columns[0].Width = 10;
                gridList.Columns[1].Width = 60;
                gridList.Columns[2].Width = 60;
                gridList.Columns[3].Width = 40;
                gridList.Columns[4].Width = 30;
                gridList.Columns[5].Width = 30;
            }
            braWET.CloseWaitForm();
        }
        private void BindDeliveryList()
        {
            ClearGrid();
            var list = EnumerableUtils.getDeliveryList().Select(p => new
            {
                ID = p.delivery_id,
                Code = p.delivery_code,
                Destination = p.destination,
                Status = p.delivery_status,
                ProductCount = p.distinct_product_count,
                DeliveryDate = p.delivery_date
            });
            gridControl1.DataSource = list;
            if (gridList.RowCount > 0)
            {
                gridList.Columns[0].Width = 10;
                gridList.Columns[1].Width = 60;
                gridList.Columns[2].Width = 60;
                gridList.Columns[3].Width = 40;
                gridList.Columns[4].Width = 30;
                gridList.Columns[5].Width = 30;
            }
        }

        private void BindBranchDel()
        {
            braWET.ShowWaitForm();
            ClearGrid();
            gridControl.DataSource = EnumerableBranch();
            if (gridList.RowCount > 0)
            {
                gridList.Columns[0].Width = 40;
                gridList.Columns[1].Width = 90;
                gridList.Columns[2].Width = 280;
                gridList.Columns[3].Width = 100;
                gridList.Columns[3].Width = 120;
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
                cmbProductName.DataBindings.Clear();
                cmbProductName.DataSource = query;
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
                var query = repository.SelectAll(Query.SelectAllBranchExcWareH).Select(x => x.BranchDetails).Distinct().ToList();
                cmbWarehouseBranch.DataBindings.Clear();
                cmbWarehouseBranch.DataSource = query;
            }
        }
        private void BindProductStatus()
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
            cmbProductName.Text = ent.Item;
            txtLastItemCost.Text = ent.Delivery;
            txtReceiptNum.Text = ent.Receipt;
            txtWarehouseQty.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbWarehouseBranch.Text = ent.Branch;
            txtLastCost.Text = Constant.DefaultZero.ToString();
            txtOnOrder.Text = Constant.DefaultZero.ToString();
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
                    var query = repository.FindBy(x => x.product_name == input);
                    return query.product_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Id Error", "Inventory Details");
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
                    var query = repository.FindBy(x => x.warehouse_Id == input);
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
                    var repository = new Repository<ProductStatus>(unWork);
                    var query = repository.FindBy(x => x.status == input);
                    return query.status_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Product Status Id Error", "Inventory Details");
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
        private static int VerifyDelNo(string deliveryNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.Delivery == deliveryNo)
                        .Select(x => x.Id)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        private static int VerifyReceiptNo(string receiptNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.Receipt == receiptNo)
                        .Select(x => x.Id)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }/*
        private static ViewWarehouse ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewWarehouse>(unWork);
                    var query = repository.FindBy(x => x.Id == inventoryId);
                    return query;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }*/
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
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    braWET.ShowWaitForm();
                    var branchDel = new BranchDelivery
                    {
                        Code         = txtDeliveryCode.Text.Trim(' '),
                        ProductId    = GetProductId(cmbProductName.Text),
                        WareHouseId  = int.Parse(txtDeliveryID.Text),
                        QtyStock     = decimal.Parse(txtWarehouseQty.Text),
                        DeliveryNo   = txtLastItemCost.Text.Trim(' '),
                        ReceiptNo    = txtReceiptNum.Text.Trim(' '),
                        BranchId     = GetBranchId(cmbWarehouseBranch.Text),
                        LastCost     = decimal.Parse(txtLastCost.Text),
                        OnOrder      = int.Parse(txtOnOrder.Text),
                        StatusId     = GetProductStatus(cmbProductStatus.Text),
                        DeliveryDate = dkpDeliveryDate.Value.Date
                    };
                    var quantity = txtWarehouseQty.Text.Trim(' ');
                    var product = cmbProductName.Text.Trim(' ');
                    var branch = cmbWarehouseBranch.Text.Trim(' ');
                    unWork.Begin();
                    var repository = new Repository<BranchDelivery>(unWork);
                    var result = repository.Add(branchDel);
                    if (result > 0)
                    {
                        braWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, "Item Name: " + product + " with quantity " + quantity + " successfully delivered to branch " + branch, Messages.GasulPos);
                        Close();
                    }
                }
                catch (Exception e)
                {
                    unWork.Rollback();
                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void UpdateBranch()
        {
            using (var session = new DalSession())
            {
                var deliveryId = int.Parse(txtDeliveryID.Text);
                var unWork = session.UnitofWrk;
                try
                {
                braWET.ShowWaitForm();
                unWork.Begin();
                var repository = new Repository<BranchDelivery>(unWork);
                var que = repository.FindBy(x => x.BranchDeliveryId == deliveryId);
                que.Code        = txtDeliveryCode.Text;
                que.ProductId   = GetProductId(cmbProductName.Text);
                que.WareHouseId = int.Parse(txtDeliveryQty.Text);
                que.QtyStock    = decimal.Parse(txtWarehouseQty.Text);
                que.DeliveryNo  = txtLastItemCost.Text.Trim(' ');
                que.ReceiptNo   = txtReceiptNum.Text.Trim(' ');
                que.BranchId    = GetBranchId(cmbWarehouseBranch.Text);
                que.LastCost    = decimal.Parse(txtLastCost.Text);
                que.OnOrder     = int.Parse(txtOnOrder.Text);
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
                            "Delivery No: " + txtLastItemCost.Text.Trim(' ') + " successfully Deleted!", Messages.GasulPos);
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
        private void gridBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ButCan();
                _wer = false;
                _bra = true;
                bntADD.BackColor = Color.DimGray;
                bntADD.Enabled = false;
                PopupNotification.PopUpMessages(1, "Warehouse Delivery to Branches Inventory List", Messages.GasulPos);
                BindBranchDel();
            }
            if (e.KeyCode == Keys.F2)
            {
                _wer = true;
                _bra = false;
                bntADD.BackColor = Color.Red;
                bntADD.Enabled = true;
                PopupNotification.PopUpMessages(1, "Warehouse Inventory List", Messages.GasulPos);
                BindWareHouse();
            }
        }
        private void gridBranch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridList.RowCount > 0)
            {
                try
                {
                    if (_wer && _bra == false)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        //ShowValue(invId);
                        var imgId = GetProductImgId(cmbProductName.Text);
                        txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                        txtItemPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                    }
                    if (_wer == false && _bra)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        ShowBranch(invId);
                        var imgId = GetProductImgId(cmbProductName.Text);
                        txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                        txtItemPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
        private void gridBranch_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridList.RowCount > 0)
            {
                InputWhit();
            }
        }
    }
}
