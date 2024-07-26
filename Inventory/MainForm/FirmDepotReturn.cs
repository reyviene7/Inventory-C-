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
                    "Are you sure you want to Delete Item Name: " + cmbNAM.Text.Trim(' ') + " in Depot Delivery?", "Inventory Details");
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
        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            Constant.ApplicationExit();
        }
        private void txtREN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtREN.Text.Length;
                if (len > 0)
                {
                    var capz = txtREN.Text.Trim(' ');
                    capz = string.Format(capz).ToUpper();
                    txtREN.BackColor = Color.White;
                    txtREN.Text = capz;
                    txtQTY.BackColor = Color.Yellow;
                    txtQTY.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Return Delivery No must not be empty!", Messages.GasulPos);
                    txtREN.BackColor = Color.Yellow;
                    txtREN.Focus();
                }
            }
        }
        private void txtREN_Leave(object sender, EventArgs e)
        {

        }
        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtQTY.Text.Length;
                if (len > 0)
                {
                    txtQTY.BackColor = Color.White;
                    dkpPUR.Focus();
                }
                else
                {
                    txtQTY.Text = Constant.DefaultZero.ToString();
                }
            }
        }
        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtQTY.Focus();
                txtQTY.BackColor = Color.Yellow;
            }
            else
            {
                txtQTY.BackColor = Color.White;
            }
        }
        private void dkpPUR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpREF.Focus();
            }
        }
        private void dkpREF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMAR.Focus();
                txtMAR.BackColor = Color.Yellow;
            }
        }
        private void txtQTY_Leave(object sender, EventArgs e)
        {
            
                var len = txtQTY.Text.Length;
                if (len > 0)
                {
                    var inQty = decimal.Parse(txtWQT.Text);
                    var reQty = decimal.Parse(txtQTY.Text);
                    if (inQty >= reQty)
                    {
                        var tlQty = inQty - reQty;
                        txtWQT.Text = tlQty.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Return item quantity must not be greater than item number in Inventory!", Messages.GasulPos);
                        txtQTY.Focus();
                        txtQTY.BackColor = Color.Yellow;
                    }
               

            }
        }
        private void txtMAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtMAR.Text.Length;
                if (len > 0)
                {
                    txtMAR.BackColor = Color.White;
                    bntSAV.Focus();
                }
                else
                {
                    txtMAR.Text = Constant.DefaultNone;
                }
            }
        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {

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
                    var query = repository.FindBy(x => x.Name == input);
                    return query.ProductId;
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
                    return query.BranchId;
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
                    var query = repository.FindBy(x => x.BranchId == input);
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
                    var query = repository.FindBy(x => x.Status == input);
                    return query.StatusId;
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
                    var query = repository.FindBy(x => x.Name == input);
                    return query.ImageId;
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
            txtREN.Focus();
            GenerateReturn();
            txtREN.BackColor = Color.Yellow;
            cmbSAT.Text = Constant.DefaultReturn;
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
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
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
                var returnId = int.Parse(txtRID.Text);
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

                var returnId = int.Parse(txtRID.Text);
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
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void InputLpg()
        {
            txtREN.Clear();
            txtQTY.Clear();
            txtMAR.Clear();

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
            txtRID.BackColor = Color.White;
            txtCOD.BackColor = Color.White;
            cmbNAM.BackColor = Color.White;
            txtREN.BackColor = Color.White;
            txtQTY.BackColor = Color.White;
            txtDES.BackColor = Color.White;
            cmbSAT.BackColor = Color.White;
            txtMAR.BackColor = Color.White;
            dkpPUR.BackColor = Color.White;
            dkpREF.BackColor = Color.White;
            cmbSAT.BackColor = Color.White;
            txtWQT.BackColor = Color.White;
            txtWID.BackColor = Color.White;
            txtORG.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtREN.Enabled = true;
            txtMAR.Enabled = true;
            txtQTY.Enabled = true;
            dkpPUR.Enabled = true;
            dkpREF.Enabled = true;
            txtMAR.Enabled = true;
        }
        private void InputDisb()
        {
            txtRID.Enabled = false;
            txtCOD.Enabled = false;
            cmbNAM.Enabled = false;
            txtREN.Enabled = false;
            txtQTY.Enabled = false;
            txtDES.Enabled = false;
            cmbSAT.Enabled = false;
            txtMAR.Enabled = false;
            dkpPUR.Enabled = false;
            dkpREF.Enabled = false;
            cmbSAT.Enabled = false;
            txtWID.Enabled = false;
            txtORG.Enabled = false;
        }
        private void InputDimG()
        {
            txtRID.BackColor = Color.DimGray;
            txtCOD.BackColor = Color.DimGray;
            cmbNAM.BackColor = Color.DimGray;
            txtREN.BackColor = Color.DimGray;
            txtQTY.BackColor = Color.DimGray;
            txtDES.BackColor = Color.DimGray;
            cmbSAT.BackColor = Color.DimGray;
            txtMAR.BackColor = Color.DimGray;
            dkpPUR.BackColor = Color.DimGray;
            dkpREF.BackColor = Color.DimGray;
            cmbSAT.BackColor = Color.DimGray;
            txtWQT.BackColor = Color.DimGray;
            txtWID.BackColor = Color.DimGray;
            txtORG.BackColor = Color.DimGray;
        }
        private void InputClea()
        {
            txtRID.Clear();
            txtCOD.Clear();
            cmbNAM.Text = "";
            txtREN.Clear();
            txtWQT.Clear();
            txtQTY.Clear();
            txtDES.Text = "";
            txtMAR.Clear();
            dkpPUR.Value = DateTime.Now.Date;
            dkpREF.Value = DateTime.Now.Date;
            cmbSAT.Text = "";
            txtWID.Clear();
            txtORG.Clear();
        }
        private void DisplayImage(int imgId)
        {

            imgPRO.DataBindings.Clear();
            var img = GetByImage(imgId);
            if (img != null)
            {
                MemoryStream memoryStream = new MemoryStream(img);
                imgPRO.Image = Image.FromStream(memoryStream);

            }
            else
            {

                imgPRO.Image = null;
            }
        }
        private byte[] GetByImage(int imgId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    var query = repository.FindBy(x => x.ImageId == imgId);
                    return query.ProductImage;
                }
                catch (Exception ex)
                {
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.ErrorInternal);
                    throw;
                }
            }
        }
        private void GenerateReturn()
        {
            var lastCode = GetLastReturnId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "D");
            alphaNumeric.Increment();
            txtCOD.Text = alphaNumeric.ToString();
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
                txtRID.Text = que.Id.ToString();
                txtCOD.Text = que.Code;
                cmbNAM.Text = que.Item;
                txtREN.Text = que.DeliveryNo;
                txtWQT.Text = que.WareHouse.ToString(CultureInfo.InvariantCulture);
                txtDES.Text = @"Depot";
                txtORG.Text = que.Origin;
                dkpPUR.Value = que.Delivery.Date;
                dkpREF.Value = que.Ref.Date;
                cmbSAT.Text = que.Status;
                txtMAR.Text = que.Remarks;
                txtWID.Text = que.Id.ToString();
            }
        }
        private void ShowValueReturn(int id)
        {
            var que = ShowReturn(id);
            if (que != null)
            {
                txtRID.Text = que.Id.ToString();
                txtCOD.Text = que.Code;
                cmbNAM.Text = que.Item;
                txtREN.Text = que.ReturnNo;
                txtQTY.Text = que.Qty.ToString(CultureInfo.InvariantCulture);
                txtWQT.Text = Constant.DefaultZero.ToString();
                txtDES.Text = que.Destination;
                txtORG.Text = que.Origin;
                dkpPUR.Value = que.Delivery.Date;
                dkpREF.Value = que.RefDate.Date;
                cmbSAT.Text = que.Status;
                txtMAR.Text = que.Remarks;
                txtWID.Text = que.WareHouseId.ToString();
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
                        var imgId = GetProductImgId(cmbNAM.Text);
                        DisplayImage(imgId);
                    }
                    if (_ret)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        ShowValueReturn(invId);
                        var imgId = GetProductImgId(cmbNAM.Text);
                        DisplayImage(imgId);
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
                bntADD.Enabled = true;
                bntUPD.Enabled = false;
                bntDEL.Enabled = false;
                _ret = false;
                BindReturnWareHouse();
            }
            if (e.KeyCode == Keys.F2)
            {
                bntADD.Enabled = false;
                bntUPD.Enabled = true;
                bntDEL.Enabled = true;
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
                        ReturnCode  = txtCOD.Text.Trim(' '),
                        ProductId   = GetProductId(cmbNAM.Text), 
                        ReturnNo    = txtREN.Text.Trim(' '),
                        ReturnQty   = decimal.Parse(txtQTY.Text),
                        Origin      = GetBranchId(txtORG.Text), 
                        ToDepot     = GetFinalId(Constant.DefaultReturnHome),
                        Delivery    = dkpPUR.Value.Date,
                        RefDate     = dkpREF.Value.Date,
                        StatusId    = GetProductStatus(cmbSAT.Text),
                        Remarks     = txtMAR.Text.Trim(' '),
                        WareHouseId = int.Parse(txtWID.Text)
                    };
                    unWork.Begin();
                    var repository = new Repository<ReturnDepot>(unWork);
                    var result = repository.Add(ret);
                    if (result > 0)
                    {
                        var item = cmbNAM.Text.Trim(' ');
                        var qty = txtQTY.Text;
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

                    que.ReturnCode  = txtCOD.Text.Trim(' ');
                    que.ProductId   = GetProductId(cmbNAM.Text);
                    que.ReturnNo    = txtREN.Text.Trim(' ');
                    que.ReturnQty   = decimal.Parse(txtQTY.Text);
                    que.Origin      = GetBranchId(txtORG.Text);
                    que.ToDepot     = GetFinalId(Constant.DefaultReturnHome);
                    que.Delivery    = dkpPUR.Value.Date;
                    que.RefDate     = dkpREF.Value.Date;
                    que.StatusId    = GetProductStatus(cmbSAT.Text);
                    que.Remarks     = txtMAR.Text.Trim(' ');
                    que.WareHouseId = int.Parse(txtWID.Text);
                    var result = repository.Update(que);
                    if (result)
                    {
                        var item = cmbNAM.Text.Trim(' ');
                        var qty = txtQTY.Text;
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
                        var item = cmbNAM.Text.Trim(' ');
                        var qty = txtQTY.Text;
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
