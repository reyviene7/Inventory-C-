using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.PopupForm;

using ServeAll.Core.Entities;
using ServeAll.Core.Entities.request;
using ServeAll.Core.Helper;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWareHouseReturn : Form
    {
        private bool _add, _edt, _del;
        private bool _isCanceled;
        private readonly int _userId;
        private readonly int _userTy;
        private IEnumerable<ViewReturnWarehouse> _return_list;
        private IEnumerable<RequestProducts> _products;
        private IEnumerable<ViewReturnWarehouse> warehouse_return;
        private IEnumerable<ViewInventory> listInventory;
        private IEnumerable<ViewImageProduct> imgList;
        private int _branchId;
        private string _branch;
        private int InventoryId;

        public string branch
        {
            get { return _branch; }
            set
            {
                _branch = value;
            }
        }

        public int BranchId
        {
            get { return _branchId; }
            set
            {
                _branchId = value;
                if (_branchId > 0)
                {
                    BindInventory(_branch);
                }
            }
        }
        public FirmMain Main { protected get; set; }
        public int ReturnedId { get; private set; }

        public FirmWareHouseReturn(int userId, int userTy)
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
        }
        private void FirmBranchesWareHouse_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            warehouse_return = EnumerableUtils.getEnumerableWareHouse(branch);
            _return_list = EnumerableUtils.getWareHouseReturnList();
            listInventory = EnumerableUtils.getInventoryList();
            imgList = EnumerableUtils.getImgProductList();
            _products = EnumerableUtils.getProductWarehouseList();
            ShowBranch();
            BindInventory(_branch);
        }

        private void FirmBranchesWareHouse_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }
        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }
        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
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
            ButClear();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
        }
        private void bntDEL_Click(object sender, EventArgs e)
        {
            var len = txtReturnedId.Text.Length;
            if (len > 0)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Return Delivery No: " + txtReturnedDelivery.Text.Trim(' ') + " " + "?", "Return Inventory Details");
                if (que)
                {
                    ButDel();
                }
                else
                {
                    ButCan();
                }
            }
            else
            {
                bntDEL.Enabled = false;
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
            Constant.ApplicationExit();
        }
        private void ButClear()
        {
            BindInventory(_branch);
            BindReturnWareHouse();
            ButtonReturn();
            InputLpg();
            InputDisb();
            InputWhit();
            InputWhitRet();
            InputClea();
            InputCleaRet();
            cmbFromBranch.Text = branch;
            cmbToBranch.Text = Constant.DefaultWareHouse;
            txtProductStatus.Text = Constant.DefaultReturn;
            gCON.Enabled = true;
        }
        private void ButAdd()
        {
            _add = true;
            _edt = false;
            _del = false;
            ButtonAdd();
            InputWhit();
            InputEnab();
            txtReturnQty.Focus();
            txtReturnQty.BackColor = Color.Yellow;
            GenerateReturn();
            GenerateReturnId();
            cmbFromBranch.Text = branch;
            cmbToBranch.Text = Constant.DefaultWareHouse;
            txtProductStatus.Text = Constant.DefaultReturn;
            txtRemarks.Text = "N/A";
            gCON.Enabled = false;
        }
        private void ButUpd()
        {
            _add = false;
            _edt = true;
            _del = false;
            ButtonUpd();
            InputWhitRet();
            InputEnabRet();
            txtReturnedQty.Focus();
            txtReturnedQty.BackColor = Color.Yellow;
            gDEL.Enabled = false;
        }
        private void ButDel()
        {
            _add = false;
            _edt = false;
            _del = true;
            ButtonDel();
            InputWhitRet();
            InputEnabRet();
            gDEL.Enabled = false;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputDimGRet();
            InputClea();
            gCON.Enabled = true;
            gDEL.Enabled = true;
            txtProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
            ImageReturnedPreview.DataBindings.Clear();
            ImageReturnedPreview.Image = null;
        }
        private void ButSav()
        {

            if (_add && _edt == false && _del == false)
            {

                InsertReturn();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();

            }
            if (_add == false && _edt && _del == false)
            {
                UpdateReturn();
                ButtonSav();
                InputDisbRet();
                InputDimGRet();
                InputCleaRet();
                ClearGrid();
                warehouse_return = EnumerableUtils.getEnumerableWareHouse(branch);
            }
            if (_add == false && _edt == false && _del)
            {
                DeleteReturn();
                ButtonSav();
                InputDisbRet();
                InputDimGRet();
                InputCleaRet();
                ClearGrid();
                warehouse_return = EnumerableUtils.getEnumerableWareHouse(branch);
            }
            BindReturnWareHouse();
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
            gDEL.Enabled = true;
            txtProductName.DataBindings.Clear();
            txtReturnedProduct.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            ImageReturnedPreview.DataBindings.Clear();
            imgPreview.Image = null;
            ImageReturnedPreview.Image = null;
        }
        private void ButtonAdd()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = false;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonUpd()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = true;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonDel()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = false;
            bntDEL.Enabled = true;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonSav()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonReturn()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = false;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonCan()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void InputWhit()
        {
            txtReturnId.BackColor = Color.White;
            txtReturnCode.BackColor = Color.White;
            txtProductName.BackColor = Color.White;
            txtDeliveryNo.BackColor = Color.White;
            txtReturnQty.BackColor = Color.White;
            cmbFromBranch.BackColor = Color.White;
            txtProductStatus.BackColor = Color.White;
            txtRemarks.BackColor = Color.White;
            dkpReturnDelivery.BackColor = Color.White;
            txtWarehouseQty.BackColor = Color.White;
        }
        private void InputWhitRet()
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
            dkpReturedDate.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtRemarks.Enabled = true;
            txtReturnQty.Enabled = true;
            dkpReturnDelivery.Enabled = true;
        }
        private void InputEnabRet()
        {
            txtReturnedRemarks.Enabled = true;
            txtReturnedQty.Enabled = true;
            dkpReturnedUpdate.Enabled = true;
        }
        private void InputDisb()
        {
            txtReturnId.Enabled = false;
            txtReturnCode.Enabled = false;
            txtProductName.Enabled = false;
            txtDeliveryNo.Enabled = false;
            txtReturnedQty.Enabled = false;
            txtReturnQty.Enabled = false;
            cmbFromBranch.Enabled = false;
            txtProductStatus.Enabled = false;
            txtReturnedRemarks.Enabled = false;
            txtRemarks.Enabled = false;           
            dkpReturnDelivery.Enabled = false;
        }
        private void InputDisbRet()
        {
            txtReturnedId.Enabled = false;
            txtReturnedCode.Enabled = false;
            txtReturnedProduct.Enabled = false;
            txtReturnedDelivery.Enabled = false;
            txtReturnedQty.Enabled = false;
            cmbReturnedBranch.Enabled = false;
            txtReturnedStatus.Enabled = false;
            txtReturnedRemarks.Enabled = false;
            dkpReturedDate.Enabled = false;
            dkpReturnedUpdate.Enabled = false;
        }
        private void InputClea()
        {
            txtReturnId.Clear();
            txtReturnCode.Clear();
            txtProductName.Text = "";
            txtDeliveryNo.Text = "";
            txtWarehouseQty.Clear();
            txtReturnQty.Clear();
            cmbFromBranch.Text = "";
            txtRemarks.Clear();
            dkpReturnDelivery.Value = DateTime.Now.Date;
            txtProductStatus.Text = "";
        }
        private void InputCleaRet()
        {
            txtReturnedId.Clear();
            txtReturnedCode.Clear();
            txtReturnedProduct.Text = "";
            txtReturnedDelivery.Clear();
            txtReturnedQty.Clear();
            cmbReturnedBranch.Text = "";
            txtReturnedRemarks.Clear();
            dkpReturnedUpdate.Value = DateTime.Now.Date;
            txtReturnedStatus.Text = "";
        }
        private void InputLpg()
        {
            txtDeliveryNo.Clear();
            txtReturnQty.Clear();
            txtRemarks.Clear();
        }
        private void InputDimG()
        {
            txtReturnId.BackColor = Color.DimGray;
            txtReturnCode.BackColor = Color.DimGray;
            txtProductName.BackColor = Color.DimGray;
            txtDeliveryNo.BackColor = Color.DimGray;
            txtReturnQty.BackColor = Color.DimGray;
            cmbFromBranch.BackColor = Color.DimGray;
            txtProductStatus.BackColor = Color.DimGray;
            txtRemarks.BackColor = Color.DimGray;
            dkpReturnDelivery.BackColor = Color.DimGray;
            txtWarehouseQty.BackColor = Color.DimGray;
        }
        private void InputDimGRet()
        {
            txtReturnedId.BackColor = Color.DimGray;
            txtReturnedCode.BackColor = Color.DimGray;
            txtReturnedProduct.BackColor = Color.DimGray;
            txtReturnedDelivery.BackColor = Color.DimGray;
            txtReturnedQty.BackColor = Color.DimGray;
            cmbReturnedBranch.BackColor = Color.DimGray;
            txtReturnedStatus.BackColor = Color.DimGray;
            txtReturnedRemarks.BackColor = Color.DimGray;
            dkpReturedDate.BackColor = Color.DimGray;
            dkpReturnedUpdate.BackColor = Color.DimGray;
        }

        private void txtDeliveryNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtDeliveryNo.Text.Length;
                if (len > 0)
                {
                    var capz = txtDeliveryNo.Text.Trim(' ');
                    capz = string.Format(capz).ToUpper();
                    txtDeliveryNo.BackColor = Color.White;
                    txtDeliveryNo.Text = capz;
                    txtReturnQty.BackColor = Color.Yellow;
                    txtReturnQty.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Return Delivery No must not be empty!", Messages.InventorySystem);
                    txtDeliveryNo.BackColor = Color.Yellow;
                    txtDeliveryNo.Focus();
                }
            }
        }

        private void txtReturnQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtReturnQty.Text.Length;
                if (len > 0)
                {
                    txtReturnQty.BackColor = Color.White;
                    txtRemarks.Focus();
                }
                else
                {
                    txtReturnQty.Text = Constant.DefaultZero.ToString();
                }
            }
        }

        private void txtReturnQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtReturnQty.Focus();
                txtReturnQty.BackColor = Color.Yellow;
            }
            else
            {
                txtReturnQty.BackColor = Color.White;
            }
        }

        private void txtReturnQTY_Leave(object sender, EventArgs e)
        {

            var len = txtReturnQty.Text.Length;
            if (len > 0)
            {
                var inQty = decimal.Parse(txtWarehouseQty.Text);
                var reQty = decimal.Parse(txtReturnQty.Text);
                if (inQty >= reQty)
                {
                    var tlQty = inQty - reQty;
                    txtWarehouseQty.Text = tlQty.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Return item quantity must not be greater than item number in Inventory!", Messages.InventorySystem);
                    txtReturnQty.Focus();
                    txtReturnQty.BackColor = Color.Yellow;
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
                    bntSAV.Focus();
                }
                else
                {
                    txtRemarks.Text = Constant.DefaultNone;
                }
            }
        }
        private void txtReturnedQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtReturnedQty, txtReturnedRemarks, "Return Quantity", Messages.TitleReturn);
            }
        }

        private void txtReturnedRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtReturnedRemarks, bntSAV, "Returned Remarks", Messages.TitleReturn);
            }
        }
        private void gridReturn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewReturn(sender);

        }
        private void gridDelivery_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewReturned(sender);
        }
        private void gridViewReturn(object sender)
        {
            if (gridReturn.RowCount > 0)
            {
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        InventoryId = int.Parse(id);
                        var ent = searchInventoryId(InventoryId);
                        var barcode = ent.product_code;
                        txtProductName.Text = ent.product_name;
                        txtWarehouseQty.Text = ent.quantity.ToString(CultureInfo.InvariantCulture);
                        txtDeliveryNo.Text = ent.delivery_code;
                        cmbFromBranch.Text = ent.branch_details;
                        txtProductStatus.Text = Constant.DefaultReturn;

                        var img = searchProductImg(barcode);
                        var imgLocation = img?.img_location;
                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgPreview.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;
                            imgPreview.ImageLocation = location;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void gridViewReturned(object sender)
        {
            if (gridDelivery.RowCount > 0)
            {
                try
                {
                    var ReturnId = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (ReturnId.Length > 0)
                    {
                        ReturnedId = int.Parse(ReturnId);
                        var ent = searchReturnId(ReturnedId);
                        var barcode = ent.product_code;
                        txtReturnedId.Text = ReturnId;
                        txtReturnedCode.Text = ent.return_code;
                        txtReturnedProduct.Text = _products.FirstOrDefault(p => p.product_code == barcode).product_name;
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
                            ImageReturnedPreview.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;
                            ImageReturnedPreview.ImageLocation = location;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private ViewInventory searchInventoryId(int id)
        {
            return listInventory.FirstOrDefault(Inventory => Inventory.inventory_id == id);
        }
        private ViewReturnWarehouse searchReturnId(int id)
        {
            return warehouse_return.FirstOrDefault(Return => Return.return_id == id);
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }
        private void gridReturn_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridReturn.RowCount > 0)
            {
                InputWhit();
            }
            bntCAN.Enabled = true;
        }
        private void gridDelivery_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridDelivery.RowCount > 0)
            {
                InputWhitRet();
            }
            bntCAN.Enabled = true;
        }

        private void GridReturn_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        private void GenerateReturnId()
        {
            var lastIdNumber = FetchUtils.GetLastReturnId();
            var newIdNumber = lastIdNumber + 1;
            txtReturnId.Text = newIdNumber.ToString();
        }
        private void GenerateReturn()
        {
            var lastReturnCode = FetchUtils.getLastReturnId();
            int lastReturnNumber;

            if (string.IsNullOrEmpty(lastReturnCode) || !int.TryParse(lastReturnCode.Replace("R", ""), out lastReturnNumber))
            {
                lastReturnNumber = 0;
            }
            var alphaNumeric = new GenerateAlpaNum("R", 3, lastReturnNumber);
            alphaNumeric.Increment();
            txtReturnCode.Text = alphaNumeric.ToString();
        }
        private void ClearGrid()
        {
            gCON.DataSource = null;
            gCON.DataSource = "";
            gDEL.DataSource = "";
            gDEL.DataSource = null;
            gridReturn.Columns.Clear();
            gridDelivery.Columns.Clear();
        }
        private void BindReturnWareHouse()
        {
            ClearGrid();
            var list = warehouse_return.Select(r => new
            {
                Id = r.return_id,
                Code = r.return_code,
                ProductCode = r.product_code,
                Item = r.product_name,
                Qty = r.return_quantity,
                Destination = r.destination,
                Status = r.status,
                Remarks = r.remarks,
                ReturnDate = r.return_date
            }).ToList();
            gDEL.DataSource = list;
            gDEL.Update();
            if (gridDelivery.RowCount > 0)
            {
                gridDelivery.Columns[0].Width = 40;
                gridDelivery.Columns[1].Width = 60;
                gridDelivery.Columns[2].Width = 120;
                gridDelivery.Columns[3].Width = 400;
                gridDelivery.Columns[4].Width = 40;
                gridDelivery.Columns[5].Width = 100;
                gridDelivery.Columns[6].Width = 100;
                gridDelivery.Columns[7].Width = 100;
            }
        }
        private void BindInventory(string branch)
        {
            splashReturn.ShowWaitForm();
            ClearGrid();
            gCON.DataSource = listInventory.Select(p => new {
                Id = p.inventory_id,
                Item = p.product_name,
                Qty = p.quantity,
                Status = p.status,
                Branch = p.branch_details
            });
            gCON.Update();
            if (gridReturn.RowCount > 0)
            {
                gridReturn.Columns[0].Width = 40;
                gridReturn.Columns[1].Width = 400;
                gridReturn.Columns[2].Width = 80;
                gridReturn.Columns[3].Width = 120;
                gridReturn.Columns[4].Width = 160;
            }
            splashReturn.CloseWaitForm();
        }
        private void ShowBranch()
        {
            var pop = new FirmPopBranches(_userId, _userTy)
            {
                ReturnBranch = this,
                Return = true
            };
            pop.ShowDialog();

            _isCanceled = pop.DialogResult == DialogResult.Cancel;

            if (_isCanceled)
            {
                MessageBox.Show("Operation canceled by the user.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Main.Show();
                Close();
            }
        }
        private void xCON_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xCON.SelectedTabPage == xtraDelivery)
            {
                if (branch.Length > 0)
                {
                    ButCan();
                    bntADD.Enabled = true;
                    bntCLR.Enabled = false;
                    BindReturnWareHouse();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Please Select branch first!", Messages.InventorySystem);
                }

            }
            if (xCON.SelectedTabPage == xtraReturn)
            {
                ShowBranch();
            }
        }
        private void InsertReturn()
        {
            splashReturn.ShowWaitForm();
            var returnWarehouse = new ReturnWareHouse
            {
                return_code = txtReturnCode.Text.Trim(' '),
                product_id = FetchUtils.getProductId(txtProductName.Text),
                return_number = txtDeliveryNo.Text.Trim(' '),
                return_quantity = int.Parse(txtReturnQty.Text),
                branch_id = FetchUtils.getBranchId(cmbFromBranch.Text),
                destination = cmbToBranch.Text,
                return_date = dkpReturnDelivery.Value.Date,
                update_on = DateTime.Now.Date,
                status_id = FetchUtils.getProductStatusId(txtProductStatus.Text),
                remarks = txtRemarks.Text.Trim(' '),
                inventory_id = InventoryId
            };
            var returnResult = RepositoryEntity.AddEntity<ReturnWareHouse>(returnWarehouse);
            if (returnResult > 0)
            {
                splashReturn.CloseWaitForm();
                PopupNotification.PopUpMessages(1, "Return Delivery No: " + txtDeliveryNo.Text.Trim(' ') + " successfully return to Warehouse!", Messages.InventorySystem);
                warehouse_return = EnumerableUtils.getEnumerableWareHouse(branch);
            }
            else
            {
                splashReturn.CloseWaitForm();
            }
        }

        private void UpdateReturn()
        {
            var returned = txtReturnedId.Text.Trim();
            if (returned.Length > 0)
            {
                var returnId = int.Parse(returned);
                var returnQty = int.Parse(txtReturnedQty.Text);
                var remarks = txtReturnedRemarks.Text.Trim(' ');
                var update = DateTime.Now.Date;
                int returnResult = RepositoryEntity.UpdateEntity<ReturnWareHouse>(returnId, entity =>
                {
                    splashReturn.ShowWaitForm();

                    entity.return_quantity = returnQty;
                    entity.remarks = remarks;
                    entity.update_on = update;
                });
                if (returnResult > 0)
                {
                    splashReturn.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Item Return:" + txtReturnedProduct.Text.Trim(' ') + " successfully updated!", "UPDATE RETURN");
                    warehouse_return = EnumerableUtils.getEnumerableWareHouse(branch);
                    BindReturnWareHouse();
                }
                else
                {
                    splashReturn.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Item Return:" + txtReturnedProduct.Text.Trim(' ') + " was not updated to return warehouse!", "UPDATE FAILED");
                }
            }
        }
        private void DeleteReturn()
        {
            var returnedId = Convert.ToInt32(txtReturnedId.Text.Trim());

            if (returnedId > 0)
            {
                splashReturn.ShowWaitForm();
                int deleteResult = RepositoryEntity.DeleteEntity<ReturnWareHouse>(returnedId, entity =>
                {
                    int? inventoryId = entity.inventory_id;
                    if (inventoryId.HasValue)
                    {
                        RepositoryEntity.UpdateEntity<RequestQuantity>(inventoryId.Value, qtyEntity =>
                        {
                            qtyEntity.quantity_in_stock += entity.return_quantity;
                        });
                    }
                });

                if (deleteResult > 0)
                {
                    splashReturn.CloseWaitForm();
                    PopupNotification.PopUpMessages(1,
                        "Return ID: " + returnedId + " Successfully Deleted!",
                        Messages.TitleSuccessDelete);
                    warehouse_return = EnumerableUtils.getEnumerableWareHouse(branch);
                    BindReturnWareHouse();
                }
                else
                {
                    splashReturn.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Failed to delete return.", "DELETE FAILED");
                }
            }
        }
    }
}