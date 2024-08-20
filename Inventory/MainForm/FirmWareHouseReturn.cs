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
using ServeAll.Core.Helper;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWareHouseReturn : Form
    {
        private bool _add, _edt, _del, _pop;
        private readonly int _userId;
        private readonly int _userTy;
        private IEnumerable<ViewReturnWarehouse> _return_list;
        private IEnumerable<ViewInventoryList> listInventory;
        private IEnumerable<ViewImageProduct> imgList;
        private int _branchId;
        private string _branch;
        private int InventoryId;

        public string branch { 
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
        public FirmWareHouseReturn(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            InitializeComponent();
        }
        private void FirmBranchesWareHouse_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            _return_list = EnumerableUtils.getWareHouseReturnList();
            listInventory = EnumerableUtils.getInventoryList();
            imgList = EnumerableUtils.getImgProductList();
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
            var len = txtReturnId.Text.Length;
            if (len > 0)
            {
                ButUpd();
            }
            else
            {
                bntUPD.Enabled = false;
            }
        }
        private void bntSAV_Click(object sender, EventArgs e)
        {
            ButSav();
        }
        private void bntCLR_Click(object sender, EventArgs e)
        {
           ButLpg();
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
        }
        private void bntDEL_Click(object sender, EventArgs e)
        {
            var len = txtReturnId.Text.Length;
            if (len > 0)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Return Delivery No: " + txtDeliveryNo.Text.Trim(' ') + " " + "?", "Return Inventory Details");
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
        private void ButLpg()
        {
            _add = true;
            _edt = false;
            _del = false;
            ButtonReturn();
            InputLpg();
            InputEnab();
            cmbProductName.Focus();
            GenerateReturn();
            cmbProductName.BackColor = Color.Yellow;
            cmbFromBranch.Text = branch;
            cmbToBranch.Text = Constant.DefaultWareHouse;
            cmbProductStatus.Text = Constant.DefaultReturn;
            gCON.Enabled = false;
        }
        private void ButAdd()
        {
            _add = true;
            _edt = false;
            _del = false;
            ButtonAdd();
            InputItem();
            InputWhit();
            InputEnab();
            cmbProductName.Focus();
            GenerateReturn();
            cmbProductName.BackColor = Color.Yellow;
            cmbFromBranch.Text = branch;
            cmbToBranch.Text = Constant.DefaultWareHouse;
            cmbProductStatus.Text = Constant.DefaultReturn;
            gCON.Enabled = false;
        }
        private void ButUpd()
        {
            _add = false;
            _edt = true;
            _del = false;
            ButtonUpd();
            InputWhit();
            InputEnab();
            cmbProductName.Focus();
            cmbProductName.BackColor = Color.Yellow;
            gCON.Enabled = false;
        }
        private void ButDel()
        {
            _add = false;
            _edt = false;
            _del = true;
            ButtonDel();
            InputWhit();
            InputEnab();
            gCON.Enabled = false;
        }
        private void ButCan()
        {
            _add = false;
            _edt = false;
            _del = false;
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
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
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();
            }
            if (_add == false && _edt == false && _del)
            {
                DeleteReturn();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();
            }
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
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
            bntADD.Enabled = false;
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
            cmbProductName.BackColor = Color.White;
            txtDeliveryNo.BackColor = Color.White;
            txtReturnQty.BackColor = Color.White;
            cmbFromBranch.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
            txtRemarks.BackColor = Color.White;
            dkpReturnDelivery.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
            txtWarehouseQty.BackColor = Color.White;
        }
        private void InputEnab()
        {
            cmbProductName.Enabled = true;
            txtDeliveryNo.Enabled = true;
            txtRemarks.Enabled = true;
            txtReturnQty.Enabled = true;
            dkpReturnDelivery.Enabled = true;
            txtRemarks.Enabled = true;
            cmbProductStatus.Enabled = true;
        }
        private void InputDisb()
        {
            txtReturnId.Enabled = false;
            txtReturnCode.Enabled = false;
            cmbProductName.Enabled = false;
            txtDeliveryNo.Enabled = false;
            txtReturnQty.Enabled = false;
            cmbFromBranch.Enabled = false;
            cmbProductStatus.Enabled = false;
            txtRemarks.Enabled = false;
            dkpReturnDelivery.Enabled = false;
            cmbProductStatus.Enabled = false;
        }
        private void InputClea()
        {
            txtReturnId.Clear();
            txtReturnCode.Clear();
            cmbProductName.Text = "";
            txtDeliveryNo.Clear();
            txtWarehouseQty.Clear();
            txtReturnQty.Clear();
            cmbFromBranch.Text = "";
            txtRemarks.Clear();
            dkpReturnDelivery.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
        }
        private void InputItem()
        {
            txtDeliveryNo.Clear();
            txtRemarks.Clear();
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
            cmbProductName.BackColor = Color.DimGray;
            txtDeliveryNo.BackColor = Color.DimGray;
            txtReturnQty.BackColor = Color.DimGray;
            cmbFromBranch.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
            txtRemarks.BackColor = Color.DimGray;
            dkpReturnDelivery.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
            txtWarehouseQty.BackColor = Color.DimGray;
        }

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbProductName.Text.Length;
                if (len > 0)
                {
                    cmbProductName.BackColor = Color.White;
                    txtDeliveryNo.BackColor = Color.Yellow;
                    txtDeliveryNo.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Item name must not be empty!", Messages.InventorySystem);
                    cmbProductName.BackColor = Color.Yellow;
                    cmbProductName.Focus();
                }

            }
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
                    dkpReturnDelivery.Focus();
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
        private void cmbProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            var len = cmbProductStatus.Text.Length;
            if (len > 0)
            {
                txtRemarks.BackColor = Color.Yellow;
                txtRemarks.Focus();
            }
            else
            {
                cmbProductStatus.Text = Constant.DefaultReturn;
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
        private void gridReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindReturnWareHouse();
                InputClea();
                bntADD.Enabled = false;
                bntCLR.Enabled = false;
            }
            if (e.KeyCode == Keys.F2)
            {
                if (branch.Length > 0)
                {
                    BindInventory(branch);
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                ClearGrid();
                ShowBranch();
            }
            if (e.KeyCode == Keys.R)
            {
                if (_pop)
                {
                    var productId = FetchUtils.getProductId(cmbProductName.Text);
                    var inventoId = int.Parse(txtReturnId.Text);
                    var origin = cmbFromBranch.Text;
                    var destin = Constant.DefaultWareHouse;
                    var prodct = cmbProductName.Text;
                    var pop = new FirmPopReturnEmpty(productId, inventoId, origin, destin, prodct)
                    {
                        Main = this
                    };
                    pop.ShowDialog();
                }

            }
        }
        private void gridReturn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewReturn(sender);
            
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
                            cmbProductName.Text = ent.product_name;
                            txtWarehouseQty.Text = ent.quantity.ToString(CultureInfo.InvariantCulture);
                            cmbFromBranch.Text = ent.branch_details;
                            cmbProductStatus.Text = ent.status;

                            var img = searchProductImg(barcode);
                            var imgLocation = img.img_location;
                            if (imgLocation.Length > 0)
                            {
                                var location = ConstantUtils.defaultImgLocation + imgLocation;
                                imgPreview.ImageLocation = location;
                            }
                            else
                            {
                                imgPreview.Image = null;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private ViewInventoryList searchInventoryId(int id)
        {
            return listInventory.FirstOrDefault(Inventory => Inventory.inventory_id == id);
        }
        private void gridReturn_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridReturn.RowCount > 0)
            {
                InputWhit();
            }
        } 
        
        private void GenerateReturn()
        {
            var lastCode = FetchUtils.getLastReturnId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum("D", 3, lastId);
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
        private void BindWareHouse()
        {
            retWET.ShowWaitForm();
            ClearGrid();
            gDEL.DataSource = EnumerableUtils.getEnumerableWareHouse(branch);
            if (gridDelivery.RowCount > 0)
            {
                gridDelivery.Columns[0].Width = 40;
            }
            retWET.CloseWaitForm();

        }
        private void BindReturnWareHouse()
        {
            retWET.ShowWaitForm();
            ClearGrid();
            gCON.DataSource = EnumerableUtils.getEnumerableWareHouse(branch);
            if (gridReturn.RowCount > 0)
            {
                gridReturn.Columns[0].Width = 40;
             
                gridReturn.Columns[2].Width = 195;
            }
            retWET.CloseWaitForm();

        }
        private void BindInventory(string branch)
        {
            retWET.ShowWaitForm();
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
            retWET.CloseWaitForm();
        }
        private void ShowValueReturn(int id)
        {
            var que = FetchUtils.getShowReturn(id);
            if (que != null)
            {
                txtReturnId.Text = que.return_id.ToString();
                txtReturnCode.Text = que.return_code;
                cmbProductName.Text = que.product_code;
                txtDeliveryNo.Text = que.return_number;
                txtWarehouseQty.Text = Constant.DefaultZero.ToString();
                //cmbFromBranch.Text = que.Origin;
                cmbToBranch.Text = que.destination;
                dkpReturnDelivery.Value = que.return_date.Date;
                //dkpInputDate.Value = que.RefDate.Date;
                cmbProductStatus.Text = que.status_id;
                txtRemarks.Text = que.remarks;
                txtReturnQty.Text = que.return_quantity.ToString(CultureInfo.InvariantCulture);
                var barcode = que.product_code;
                var img = searchProductImg(barcode);
                var imgLocation = img.img_location;
                if (imgLocation.Length > 0)
                {
                    var location = ConstantUtils.defaultImgLocation + imgLocation;

                    imgPreview.ImageLocation = location;
                }
                else
                    imgPreview.Image = null;
            }
        }

        private void ShowBranch()
        {
            var pop = new FirmPopBranches(_userId, _userTy)
            {
                ReturnBranch = this,
                Return = true
            };
            pop.ShowDialog();
        }
        private void xCON_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(xCON.SelectedTabPage == xtraDelivery)
            {
                if (branch.Length > 0)
                {
                    ButCan();
                    bntADD.Enabled = false;
                    bntCLR.Enabled = false;
                    BindWareHouse();
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
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var item = new ReturnWareHouse
                    {
                        return_code = "",
                        product_id = FetchUtils.getProductId(cmbProductName.Text),
                        return_number = txtDeliveryNo.Text.Trim(' '),
                        return_quantity = decimal.Parse(txtReturnQty.Text),
                        branch_id = FetchUtils.getBranchId(cmbFromBranch.Text),
                        destination = FetchUtils.getBranchId(cmbToBranch.Text),
                        return_date = dkpReturnDelivery.Value.Date,
                        status_id = FetchUtils.getProductStatus(cmbProductStatus.Text),
                        remarks = txtRemarks.Text.Trim(' '), 
                        inventory_id = int.Parse(txtReturnId.Text)
                    };
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.Add(item);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,"Return Delivery No: "+txtDeliveryNo.Text.Trim(' ')+" successfully return to Warehouse!", Messages.InventorySystem);
                    }
                    else
                    {
                        retWET.CloseWaitForm();
                        unWork.Rollback();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        } 
        private void UpdateReturn()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var returnId = int.Parse(txtReturnId.Text);
                    var returnCd = "";
                    var prodctId = FetchUtils.getProductId(cmbProductName.Text);
                    var returnNo = txtDeliveryNo.Text.Trim(' ');
                    var retrnQty = decimal.Parse(txtReturnQty.Text);
                    var destines = FetchUtils.getBranchId(cmbToBranch.Text);
                    var returnDt = dkpReturnDelivery.Value.Date;
                    var statusId = FetchUtils.getProductStatus(cmbProductStatus.Text);
                    var remarkss = txtRemarks.Text.Trim(' ');
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var que = repository.FindBy(x => x.return_id == returnId);
                        que.return_code = returnCd;
                        que.product_id  = prodctId;
                        que.return_number   = returnNo;
                        que.return_quantity = retrnQty;
                        que.branch_id = _branchId;
                        que.destination = destines;
                        que.return_date = returnDt;
                        que.status_id = statusId;
                        que.remarks = remarkss;
                    var result = repository.Update(que);
                    if (result)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item: " + cmbProductName.Text.Trim(' ') + " successfully updated to Warehouse!", Messages.InventorySystem);
                    }
                    else
                    {
                        retWET.CloseWaitForm();
                        unWork.Rollback();
                    }

                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }
                
            }
        }
        private void DeleteReturn()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var returnId = int.Parse(txtReturnId.Text);
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var que = repository.FindBy(x => x.return_id == returnId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item: " + cmbProductName.Text.Trim(' ') + " successfully deleted!", Messages.InventorySystem);
                    }
                    else
                    {
                        retWET.CloseWaitForm();
                        unWork.Rollback();
                    }

                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                }

            }
        }
        private void ReturnItmDel()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    var returnId = int.Parse(txtReturnId.Text);
                     var retrnQty = decimal.Parse(txtReturnQty.Text);
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.ExecuteRetDelWarehouse(StoredProcedure.UspReturnDelWarehs,
                        SqlVariables.ReturnId, returnId,
                        SqlVariables.ReturnQty, retrnQty);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Item: " + cmbProductName.Text.Trim(' ') + " successfully deleted!", Messages.InventorySystem);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }
    }
}
