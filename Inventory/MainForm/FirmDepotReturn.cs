using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.Entities;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmDepotReturn : Form
    {
        public FirmMain Main { protected get; set; }
        private bool _add, _edt, _del, _ret;
        private readonly int _userId;
        private readonly int _userTy;
        public FirmDepotReturn(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            InitializeComponent();
        }
        private void FirmWareHouseDepot_Load(object sender, EventArgs e)
        {
           
            BindReturnWareHouse();

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
        private int VerifyReturnNo(string returnNo)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnDepot>(unWork);
                    return repository.SelectAll(Query.SelectCountDepotsId)
                        .Where(x => x.DeliveryNo == returnNo)
                        .Select(x => x.Id)
                        .Count();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                    return 0;
                }
            }
        }
        private void BindReturnWareHouse()
        {
            var branchName = Constant.DefaultWareHouse;
            retWET.ShowWaitForm();
            ClearGrid();
            gCON.DataSource = EnumerableWareHouse(branchName);
            if (gridReturn.RowCount > 0)
            {
                gridReturn.Columns[0].Width = 40;

                gridReturn.Columns[2].Width = 195;
            }
            retWET.CloseWaitForm();

        }
        private void BindReturnDepot()
        {
            retWET.ShowWaitForm();
            ClearGrid();
            gCON.DataSource = EnumerableDepot();
            if (gridReturn.RowCount > 0)
            {
                gridReturn.Columns[0].Width = 40;

                gridReturn.Columns[2].Width = 195;
            }
            retWET.CloseWaitForm();

        }
        private void ClearGrid()
        {
            gCON.DataSource = null;
            gCON.DataSource = "";
            gDEL.DataSource = "";
            gDEL.DataSource = null;
            gridReturn.Columns.Clear();
            gridDEL.Columns.Clear();

        }
        private IEnumerable<ViewReturnWareHouseDepot> EnumerableWareHouse(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewReturnWareHouseDepot>(unWork);
                    return repository.SelectAll(Query.SelectWareHouseDepot)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private IEnumerable<ViewReturnDepotDelivery> EnumerableDepot()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewReturnDepotDelivery>(unWork);
                    return repository.SelectAll(Query.SelectReturnDepotDel)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private int GetProductId(string input)
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
        private int GetBranchId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.BranchDetails == input);
                    return query.branch_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private int GetFinalId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Final>(unWork);
                    var query = repository.FindBy(x => x.Details == input);
                    return query.FinalId;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Final Id Error", "Inventory Details");
                    throw;
                }
            }
        }
        private string GetBranch(int input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_id == input);
                    return query.BranchDetails;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private int GetProductStatus(string input)
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
        private int GetProductImgId(string input)
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
                catch (Exception e)
                {
                   Console.WriteLine(e.ToString());
                   return 0;
                }
            }
        }
        private void ButAdd()
        {
            _ret = false;
            _add = true;
            _edt = false;
            _del = false;
            InputWhit();
            ButtonAdd();
            InputLpg();
            InputEnab();
            txtDeliveryNo.Focus();
            GenerateReturn();
            txtDeliveryNo.BackColor = Color.Yellow;
            cmbProductStatus.Text = Constant.DefaultReturn;
            gCON.Enabled = false;
        }
        private void ButCan()
        {
            _ret = false;
            _add = false;
            _edt = false;
            _del = false;
            ButtonCan();
            InputDisb();
            InputClea();
            gCON.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
        }
        private void ButUpd()
        {
            ButtonUpd();
            _ret = true;
            _add = false;
            _edt = true;
            _del = false;
            InputEnab();
            InputWhit();
            gCON.Enabled = false;
            
        }
        private void ButDel()
        {
            ButtonDel();
            InputEnab();
            InputWhit();
            _ret = true;
            _add = false;
            _edt = false;
            _del = true;
            gCON.Enabled = false;
        }
        private void ButSav()
        {
            if (_add && _edt == false && _del == false && _ret ==false)
            {

                InsertData();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();

            }
            if (_add == false && _edt && _del == false && _ret)
            {
                var returnId = int.Parse(txtReturnId.Text);
                if (returnId > 0)
                {
                    UpdateData(returnId);
                    ButtonSav();
                    InputDisb();
                    InputDimG();
                    InputClea();
                    ClearGrid();
                }
  
            }
            if (_add == false && _edt == false && _del && _ret)
            {

                var returnId = int.Parse(txtReturnId.Text);
                if (returnId > 0)
                {
                    DeleteData(returnId);
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
            _ret = false;
            gCON.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
        }
        private void InputLpg()
        {
            txtDeliveryNo.Clear();
            txtReturnQty.Clear();
            txtRemarks.Clear();

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
        private void InputWhit()
        {
            txtReturnId.BackColor = Color.White;
            txtReturnCode.BackColor = Color.White;
            cmbProductName.BackColor = Color.White;
            txtDeliveryNo.BackColor = Color.White;
            txtReturnQty.BackColor = Color.White;
            txtStockDestine.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
            txtRemarks.BackColor = Color.White;
            dkpReturnDelivery.BackColor = Color.White;
            dkpInputDate.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
            txtWarehouseQty.BackColor = Color.White;
            txtWarehouseId.BackColor = Color.White;
            txtStockOrigin.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtDeliveryNo.Enabled = true;
            txtRemarks.Enabled = true;
            txtReturnQty.Enabled = true;
            dkpReturnDelivery.Enabled = true;
            dkpInputDate.Enabled = true;
            txtRemarks.Enabled = true;
        }
        private void InputDisb()
        {
            txtReturnId.Enabled = false;
            txtReturnCode.Enabled = false;
            cmbProductName.Enabled = false;
            txtDeliveryNo.Enabled = false;
            txtReturnQty.Enabled = false;
            txtStockDestine.Enabled = false;
            cmbProductStatus.Enabled = false;
            txtRemarks.Enabled = false;
            dkpReturnDelivery.Enabled = false;
            dkpInputDate.Enabled = false;
            cmbProductStatus.Enabled = false;
            txtWarehouseId.Enabled = false;
            txtStockOrigin.Enabled = false;
        }
        private void InputDimG()
        {
            txtReturnId.BackColor = Color.DimGray;
            txtReturnCode.BackColor = Color.DimGray;
            cmbProductName.BackColor = Color.DimGray;
            txtDeliveryNo.BackColor = Color.DimGray;
            txtReturnQty.BackColor = Color.DimGray;
            txtStockDestine.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
            txtRemarks.BackColor = Color.DimGray;
            dkpReturnDelivery.BackColor = Color.DimGray;
            dkpInputDate.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
            txtWarehouseQty.BackColor = Color.DimGray;
            txtWarehouseId.BackColor = Color.DimGray;
            txtStockOrigin.BackColor = Color.DimGray;
        }
        private void InputClea()
        {
            txtReturnId.Clear();
            txtReturnCode.Clear();
            cmbProductName.Text = "";
            txtDeliveryNo.Clear();
            txtWarehouseQty.Clear();
            txtReturnQty.Clear();
            txtStockDestine.Text = "";
            txtRemarks.Clear();
            dkpReturnDelivery.Value = DateTime.Now.Date;
            dkpInputDate.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
            txtWarehouseId.Clear();
            txtStockOrigin.Clear();
        }
        private void GenerateReturn()
        {
            var lastCode = GetLastReturnId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum("D", 3, lastId);
            alphaNumeric.Increment();
            txtReturnCode.Text = alphaNumeric.ToString();
        }
        private string GetLastReturnId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewReturnDepot>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectCountDepotsId)
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
        private void ShowValue(int id)
        {
            var que = ShowEntity(id);
            if (que != null)
            {
                txtReturnId.Text = que.Id.ToString();
                txtReturnCode.Text = que.Code;
                cmbProductName.Text = que.Item;
                txtDeliveryNo.Text = que.DeliveryNo;
                txtWarehouseQty.Text = que.WareHouse.ToString(CultureInfo.InvariantCulture);
                txtStockDestine.Text = @"Depot";
                txtStockOrigin.Text = que.Origin;
                dkpReturnDelivery.Value = que.Delivery.Date;
                dkpInputDate.Value = que.Ref.Date;
                cmbProductStatus.Text = que.Status;
                txtRemarks.Text = que.Remarks;
                txtWarehouseId.Text = que.Id.ToString();
            }
        }
        private void ShowValueReturn(int id)
        {
            var que = ShowReturn(id);
            if (que != null)
            {
                txtReturnId.Text = que.Id.ToString();
                txtReturnCode.Text = que.Code;
                cmbProductName.Text = que.Item;
                txtDeliveryNo.Text = que.ReturnNo;
                txtReturnQty.Text = que.Qty.ToString(CultureInfo.InvariantCulture);
                txtWarehouseQty.Text = Constant.DefaultZero.ToString();
                txtStockDestine.Text = que.Destination;
                txtStockOrigin.Text = que.Origin;
                dkpReturnDelivery.Value = que.Delivery.Date;
                dkpInputDate.Value = que.RefDate.Date;
                cmbProductStatus.Text = que.Status;
                txtRemarks.Text = que.Remarks;
                txtWarehouseId.Text = que.WareHouseId.ToString();
            }
        }
        private ViewReturnWareHouseDepot ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnWareHouseDepot>(unWork);
                    return repository.FindBy(x => x.Id == inventoryId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }

            }
        }
        private ViewReturnDepotDelivery ShowReturn(int returnId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnDepotDelivery>(unWork);
                    return repository.FindBy(x => x.Id == returnId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }

            }
        }
        private void gridReturn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridReturn.RowCount > 0)
            {
                try
                {
                    if (_ret == false)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        ShowValue(invId);
                    }
                    if (_ret)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        ShowValueReturn(invId);
                        var imgId = GetProductImgId(cmbProductName.Text);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private void gridReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                bntAdd.Enabled = true;
                bntUpdate.Enabled = false;
                bntDelete.Enabled = false;
                _ret = false;
                BindReturnWareHouse();
            }
            if (e.KeyCode == Keys.F2)
            {
                bntAdd.Enabled = false;
                bntUpdate.Enabled = true;
                bntDelete.Enabled = true;
                _ret = true;
                BindReturnDepot();
            }
             
        }
        private void gridReturn_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            InputWhit();
        }
        private void InsertData()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    var ret = new ReturnDepot
                    {
                        ReturnCode  = txtReturnCode.Text.Trim(' '),
                        ProductId   = GetProductId(cmbProductName.Text), 
                        ReturnNo    = txtDeliveryNo.Text.Trim(' '),
                        ReturnQty   = decimal.Parse(txtReturnQty.Text),
                        Origin      = GetBranchId(txtStockOrigin.Text), 
                        ToDepot     = GetFinalId(Constant.DefaultReturnHome),
                        Delivery    = dkpReturnDelivery.Value.Date,
                        RefDate     = dkpInputDate.Value.Date,
                        StatusId    = GetProductStatus(cmbProductStatus.Text),
                        Remarks     = txtRemarks.Text.Trim(' '),
                        WareHouseId = int.Parse(txtWarehouseId.Text)
                    };
                    unWork.Begin();
                    var repository = new Repository<ReturnDepot>(unWork);
                    var result = repository.Add(ret);
                    if (result > 0)
                    {
                        var item = cmbProductName.Text.Trim(' ');
                        var qty = txtReturnQty.Text;
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item :" + item + " with Quantity: " + qty + " successfully added to Return to Depot!",
                            Messages.GasulPos);
                    }
                    else
                    {
                        unWork.Rollback();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            } 
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

        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            InputWhit();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Item Name: " + cmbProductName.Text.Trim(' ') + " in Depot Delivery?", "Inventory Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
        }

        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
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
                    PopupNotification.PopUpMessages(0, "Return Delivery No must not be empty!", Messages.GasulPos);
                    txtDeliveryNo.BackColor = Color.Yellow;
                    txtDeliveryNo.Focus();
                }
            }
        }

        private void txtReturnQty_KeyDown(object sender, KeyEventArgs e)
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

        private void txtReturnQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtReturnQty_Leave(object sender, EventArgs e)
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
                    PopupNotification.PopUpMessages(0, "Return item quantity must not be greater than item number in Inventory!", Messages.GasulPos);
                    txtReturnQty.Focus();
                    txtReturnQty.BackColor = Color.Yellow;
                }
            }
        }

        private void dkpReturnDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpInputDate.Focus();
            }
        }

        private void dkpInputDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemarks.Focus();
                txtRemarks.BackColor = Color.Yellow;
            }
        }

        private void cmbProductStatus_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtRemarks.Text.Length;
                if (len > 0)
                {
                    txtRemarks.BackColor = Color.White;
                    bntSave.Focus();
                }
                else
                {
                    txtRemarks.Text = Constant.DefaultNone;
                }
            }
        }

        private void UpdateData(int returnId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                   
                    unWork.Begin();
                    var repository = new Repository<ReturnDepot>(unWork);
                    var que = repository.FindBy(x => x.ReturnId == returnId);

                    que.ReturnCode  = txtReturnCode.Text.Trim(' ');
                    que.ProductId   = GetProductId(cmbProductName.Text);
                    que.ReturnNo    = txtDeliveryNo.Text.Trim(' ');
                    que.ReturnQty   = decimal.Parse(txtReturnQty.Text);
                    que.Origin      = GetBranchId(txtStockOrigin.Text);
                    que.ToDepot     = GetFinalId(Constant.DefaultReturnHome);
                    que.Delivery    = dkpReturnDelivery.Value.Date;
                    que.RefDate     = dkpInputDate.Value.Date;
                    que.StatusId    = GetProductStatus(cmbProductStatus.Text);
                    que.Remarks     = txtRemarks.Text.Trim(' ');
                    que.WareHouseId = int.Parse(txtWarehouseId.Text);
                    var result = repository.Update(que);
                    if (result)
                    {
                        var item = cmbProductName.Text.Trim(' ');
                        var qty = txtReturnQty.Text;
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item :" + item + " with Quantity: " + qty + " successfully updated to Return to Depot!",
                            Messages.GasulPos);
                    }
                    else
                    {
                        unWork.Rollback();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void DeleteData(int returnId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();

                    unWork.Begin();
                    var repository = new Repository<ReturnDepot>(unWork);
                    var que = repository.FindBy(x => x.ReturnId == returnId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        var item = cmbProductName.Text.Trim(' ');
                        var qty = txtReturnQty.Text;
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item :" + item + " with Quantity: " + qty + " successfully deleted to Return to Depot!",
                            Messages.GasulPos);
                    }
                    else
                    {
                        unWork.Rollback();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void xCON_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xCON.SelectedTabPage == tabHIS)
            {
               
            }
        }
    }
}
