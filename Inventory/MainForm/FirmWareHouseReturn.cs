using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.PopupForm;
 
using ServeAll.Core.Entities;
using ServeAll.Core.Helper;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWareHouseReturn : Form
    {
        private bool _lpg, _itm, _ret, _add, _edt, _del, _pop;
        private bool _edtItm, _edtLpg;
        private readonly int _userId;
        private readonly int _userTy;
        private int _branch;
        public int Branch
        {
            get { return _branch; }
            set
            {
                _branch = value;
                if (_branch > 0)
                {
                    var branch = GetBranch(_branch);
                    BindInventory(branch);
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
            ShowBranch();
        }
        private void bntADD_Click(object sender, EventArgs e)
        {
            ButAdd();
        }
        private void bntUPD_Click(object sender, EventArgs e)
        {
            var len = txtRID.Text.Length;
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
            var len = txtRID.Text.Length;
            if (len > 0)
            {
                InputWhit();
                var que =
                    PopupNotification.PopUpMessageQuestion(
                        "Are you sure you want to Delete Return Delivery No: " + txtREN.Text.Trim(' ') + " " + "?", "Return Inventory Details");
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
                cmbSAT.Focus();
                cmbSAT.BackColor = Color.Yellow;
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
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (_lpg && _ret==false && _add==false)
                {
                    BindProductsLpg();
                }
                else if (_lpg == false && _ret==false && _add == false)
                {
                    BindProducts();
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbNAM.Text.Length;
                if (len > 0)
                {
                    cmbNAM.BackColor = Color.White;
                    txtREN.BackColor = Color.Yellow;
                    txtREN.Focus();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Item name must not be empty!", Messages.GasulPos);
                    cmbNAM.BackColor = Color.Yellow;
                    cmbNAM.Focus();
                }

            }

        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { BindStatus(); }
            var len = cmbSAT.Text.Length;
            if (len > 0)
            {
                txtMAR.BackColor = Color.Yellow;
                txtMAR.Focus();
            }
            else
            {
                cmbSAT.Text = Constant.DefaultReturn;
            }
        }
        private void ButLpg()
        {
            _lpg = true;
            _itm = false;
            _add = true;
            _edt = false;
            _del = false;
            ButtonLpg();
            InputLpg();
            InputEnab();
            cmbNAM.Focus();
            GenerateReturn();
            cmbNAM.BackColor = Color.Yellow;
            cmbBRA.Text = GetBranch(_branch);
            cmbDES.Text = Constant.DefaultWareHouse;
            cmbSAT.Text = Constant.DefaultReturn;
            gCON.Enabled = false;
        }
        private void ButAdd()
        {
            _add = true;
            _lpg = false;
            _itm = true;
            _edt = false;
            _del = false;
            ButtonAdd();
            InputItem();
            InputWhit();
            InputEnab();
            cmbNAM.Focus();
            GenerateReturn();
            cmbNAM.BackColor = Color.Yellow;
            cmbBRA.Text = GetBranch(_branch);
            cmbDES.Text = Constant.DefaultWareHouse;
            cmbSAT.Text = Constant.DefaultReturn;
            gCON.Enabled = false;
        }
        private void ButUpd()
        {
            _lpg = false;
            _itm = false;
            _add = false;
            _edt = true;
            _del = false;
            ButtonUpd();
            InputWhit();
            InputEnab();
            cmbNAM.Focus();
            cmbNAM.BackColor = Color.Yellow;
            gCON.Enabled = false;
        }
        private void ButDel()
        {
            _lpg = false;
            _itm = false;
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
            _lpg = false;
            _itm = false;
            _edtItm = false;
            _edtLpg = false;
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void ButSav()
        {

            if (_lpg && _add && _edt == false && _del == false)
            {

                ReturnLpg();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();

            }
            if (_add && _itm  && _edt == false && _del == false)
            {
                ReturnItem();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();
            }
            if (_edtItm && _add == false && _edt && _del ==false && _edtLpg==false)
            {
                ReturnItmEdt();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();
            }
            if (_edtItm == false && _add == false && _edt && _del == false && _edtLpg)
            {
                
                ReturnLpgEdt();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();
            }
            if (_edtItm == false && _add == false && _edt == false && _del && _edtLpg)
            {

                ReturnLpgDel();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();
            }
            if (_edtItm && _add == false && _edt == false && _del && _edtLpg == false)
            {
                ReturnItmDel();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                ClearGrid();
            }
            _add = false;
            _edt = false;
            _del = false;
            _lpg = false;
            _itm = false;
            _edtItm = false;
            _edtLpg = false;
            gCON.Enabled = true;
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void ButtonAdd()
        {
           // bntADD.Enabled = true;
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
          //  bntADD.Enabled = false;
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
          //  bntADD.Enabled = false;
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
          //  bntADD.Enabled = true;
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
        private void ButtonLpg()
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
         //   bntADD.Enabled = true;
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
            cmbBRA.BackColor = Color.White;
            cmbSAT.BackColor = Color.White;
            txtMAR.BackColor = Color.White;
            dkpPUR.BackColor = Color.White;
            dkpREF.BackColor = Color.White;
            cmbSAT.BackColor = Color.White;
            txtWER.BackColor = Color.White;
        }
        private void InputEnab()
        {
            cmbNAM.Enabled = true;
            txtREN.Enabled = true;
            txtMAR.Enabled = true;
            txtQTY.Enabled = true;
            dkpPUR.Enabled = true;
            dkpREF.Enabled = true;
            txtMAR.Enabled = true;
            cmbSAT.Enabled = true;
        }
        private void InputDisb()
        {
            txtRID.Enabled = false;
            txtCOD.Enabled = false;
            cmbNAM.Enabled = false;
            txtREN.Enabled = false;
            txtQTY.Enabled = false;
            cmbBRA.Enabled = false;
            cmbSAT.Enabled = false;
            txtMAR.Enabled = false;
            dkpPUR.Enabled = false;
            dkpREF.Enabled = false;
            cmbSAT.Enabled = false;
        }
        private void InputClea()
        {
            txtRID.Clear();
            txtCOD.Clear();
            cmbNAM.Text = "";
            txtREN.Clear();
            txtWER.Clear();
            txtQTY.Clear();
            cmbBRA.Text = "";
            txtMAR.Clear();
            dkpPUR.Value = DateTime.Now.Date;
            dkpREF.Value = DateTime.Now.Date;
            cmbSAT.Text = "";
        }
        private void InputItem()
        {
            txtREN.Clear();
            txtMAR.Clear();
        }
        private void InputLpg()
        {
            txtREN.Clear();
            txtQTY.Clear();
            txtMAR.Clear();
           
        }
        private void InputDimG()
        {
            txtRID.BackColor = Color.DimGray;
            txtCOD.BackColor = Color.DimGray;
            cmbNAM.BackColor = Color.DimGray;
            txtREN.BackColor = Color.DimGray;
            txtQTY.BackColor = Color.DimGray;
            cmbBRA.BackColor = Color.DimGray;
            cmbSAT.BackColor = Color.DimGray;
            txtMAR.BackColor = Color.DimGray;
            dkpPUR.BackColor = Color.DimGray;
            dkpREF.BackColor = Color.DimGray;
            cmbSAT.BackColor = Color.DimGray;
            txtWER.BackColor = Color.DimGray;
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
        private int VerifyReturnNo(string returnNo)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.SelectAll(Query.SelectCountReturnNo)
                        .Where(x => x.ReturnNo == returnNo)
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
                    var query = repository.FindBy(x => x.image_id == imgId);
                    return query.image;
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
            txtGEN.Text = alphaNumeric.ToString();
        }
        private string GetLastReturnId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewReturnWarehouse>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllReturnWareHs)
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
        private void ClearGrid()
        {
            gCON.DataSource = null;
            gCON.DataSource = "";
            gDEL.DataSource = "";
            gDEL.DataSource = null;
            gridReturn.Columns.Clear();
            gridDEL.Columns.Clear();

        }
        private void BindWareHouse()
        {
            var branch = GetBranch(_branch);
            retWET.ShowWaitForm();
            ClearGrid();
            gDEL.DataSource = EnumerableWareHouse(branch);
            if (gridDEL.RowCount > 0)
            {
                gridDEL.Columns[0].Width = 40;
            }
            retWET.CloseWaitForm();

        }
        private void BindReturnWareHouse()
        {
            var branch = GetBranch(_branch);
            retWET.ShowWaitForm();
            ClearGrid();
            gCON.DataSource = EnumerableWareHouse(branch);
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
            gCON.DataSource = EnumerableBranches(branch);
            if (gridReturn.RowCount > 0)
            {
                gridReturn.Columns[0].Width = 40;
                gridReturn.Columns[2].Width = 170;
            }
            retWET.CloseWaitForm();

        }
        
        private int SearchLpg(int productId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewLpgGasul>(unWork);
                    return repository
                        .SelectAll(Query.SelectAllLpgGasul)
                        .Count(x => x.ProductId == productId);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        private IEnumerable<ViewReturnWarehouse> EnumerableWareHouse(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.SelectAll(Query.SelectAllReturnWareHs)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private IEnumerable<ViewInventoryList> EnumerableBranches(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewInventoryList>(unWork);
                    return repository.SelectAll(Query.AllInventoryList)
                        .Where(x => x.Branch == branch)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    return null;
                }
            }
        }
        private void ShowValue(int id)
        {
            var que = ShowEntity(id);
            if (que != null)
            {
                txtRID.Text = que.InventoryId.ToString();
                txtCOD.Text = que.Barcode;
                cmbNAM.Text = que.Product;
                txtREN.Text = que.DeliveryNo;
                txtWER.Text = que.QtyStock.ToString(CultureInfo.InvariantCulture);
                cmbBRA.Text = que.Branch;
                dkpPUR.Value = que.PurDate.Date;
                dkpREF.Value = que.InvDate.Date;
                cmbSAT.Text = que.Status;
                txtMAR.Text = que.Warranty;
            }
        }
        private void ShowValueReturn(int id)
        {
            var que = ShowReturn(id);
            if (que != null)
            {
                txtRID.Text = que.Id.ToString();
                txtGEN.Text = que.Code;
                txtCOD.Text = que.Code;
                cmbNAM.Text = que.Item;
                txtREN.Text = que.ReturnNo;
                txtWER.Text = Constant.DefaultZero.ToString();
                cmbBRA.Text = que.Origin;
                cmbDES.Text = que.Destination;
                dkpPUR.Value = que.RetDate.Date;
                dkpREF.Value = que.RefDate.Date;
                cmbSAT.Text = que.Status;
                txtMAR.Text = que.Remarks;
                txtQTY.Text = que.ReturnQty.ToString(CultureInfo.InvariantCulture);
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
        private void BindProductsLpg()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = (from r in repository.SelectAll(Query.AllProducts)
                    where r.product_name.Contains(Constant.AddFilterLpg)
                    where !r.product_name.Contains(Constant.AddFilterEmp)
                    select r.product_name).Distinct().ToList();
                cmbNAM.DataBindings.Clear();
                cmbNAM.DataSource = query;
            }
        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = (from r in repository.SelectAll(Query.AllProducts)
                    where !r.product_name.Contains(Constant.AddFilterLpg)
                    where !r.product_name.Contains(Constant.AddFilterEmp)
                    select r.product_name).Distinct().ToList();
                cmbNAM.DataBindings.Clear();
                cmbNAM.DataSource = query;
            }
        }
        private ViewInventory ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.FindBy(x => x.InventoryId == inventoryId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
                
            }
        }
        private ViewReturnWarehouse ShowReturn(int returnId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.FindBy(x => x.Id == returnId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }

            }
        }
        private void xCON_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(xCON.SelectedTabPage == tabHIS)
            {
                if (_branch > 0)
                {
                    ButCan();
                    bntADD.Enabled = false;
                    bntCLR.Enabled = false;
                    BindWareHouse();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Please Select branch first!", Messages.GasulPos);
                }
               
            }
            if (xCON.SelectedTabPage == tabINV)
            {
                ShowBranch();
            }
        }
        private void txtREN_Leave(object sender, EventArgs e)
        {
             
     
        }
        private void txtQTY_Leave(object sender, EventArgs e)
        {
            if (_itm && _lpg == false)
            {
                var len = txtQTY.Text.Length;
                if (len > 0)
                {
                    var inQty = decimal.Parse(txtWER.Text);
                    var reQty = decimal.Parse(txtQTY.Text);
                    if (inQty >= reQty)
                    {
                        var tlQty = inQty - reQty;
                        txtWER.Text = tlQty.ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        PopupNotification.PopUpMessages(0, "Return item quantity must not be greater than item number in Inventory!", Messages.GasulPos);
                        txtQTY.Focus();
                        txtQTY.BackColor = Color.Yellow;
                    }
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
                _lpg = false;
                _itm = false;
                _ret = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                _ret = false;
                if (_branch > 0)
                {
                    var branch = GetBranch(_branch);
                    BindInventory(branch);
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                ClearGrid();
                ShowBranch();
                _ret = false;
            }
            if (e.KeyCode == Keys.R)
            {
                if (_pop)
                {
                    var productId = GetProductId(cmbNAM.Text);
                    var inventoId = int.Parse(txtRID.Text);
                    var origin = cmbBRA.Text;
                    var destin = Constant.DefaultWareHouse;
                    var prodct = cmbNAM.Text;
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
        private void gridReturn_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            InputWhit();
            var len = cmbNAM.Text.Length;
            if (_ret == false)
            {
                bntUPD.Enabled = false;
                if (len > 0)
                {
                    retWET.ShowWaitForm();
                    var item = cmbNAM.Text.Trim(' ');
                    var productId = GetProductId(item);
                    var result = SearchLpg(productId);
                    if (result > 0)
                    {
                        _pop = true;
                        _lpg = true;
                        _itm = false;
                        _edtItm = false;
                        _edtLpg = false;
                        bntCLR.BackColor = Color.Maroon;
                        bntCLR.Enabled = true;
                        bntADD.Enabled = false;
                    }
                    else
                    {
                        _pop = false;
                        _lpg = false;
                        _itm = true;
                        _edtItm = false;
                        _edtLpg = false;
                        bntCLR.BackColor = Color.Black;
                        bntCLR.Enabled = false;
                        bntADD.Enabled = true;
                    }
                    retWET.CloseWaitForm();
                }
            }else if (_ret)
            {
                bntUPD.Enabled = true;
                bntDEL.Enabled = true;
                if (len > 0)
                {
                    retWET.ShowWaitForm();
                    var item = cmbNAM.Text.Trim(' ');
                    var productId = GetProductId(item);
                    var result = SearchLpg(productId);
                    if (result > 0)
                    {
                        _lpg = false;
                        _itm = false;
                        _edtItm = false;
                        _edtLpg = true;
                        _pop = false;
                    }
                    else
                    {
                        _lpg = false;
                        _itm = false;
                        _edtItm = true;
                        _edtLpg = false;
                        _pop = false;
                    }
                    retWET.CloseWaitForm();
                }
            }
            
        }
      
        private void ReturnLpg()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var item = new ReturnWareHouse
                    {
                        ReturnCode = txtGEN.Text.Trim(' '),
                        ProductId = GetProductId(cmbNAM.Text),
                        ReturnNo = txtREN.Text.Trim(' '),
                        ReturnQty = decimal.Parse(txtQTY.Text),
                        BranchId = GetBranchId(cmbBRA.Text),
                        Destination = GetBranchId(cmbDES.Text),
                        ReturnDelivery = dkpPUR.Value.Date,
                        RefDate = dkpREF.Value.Date,
                        StatusId = GetProductStatus(cmbSAT.Text),
                        Remarks = txtMAR.Text.Trim(' '), 
                        InventoryId = int.Parse(txtRID.Text)
                    };
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.Add(item);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,"Return Delivery No: "+txtREN.Text.Trim(' ')+" successfully return to Warehouse!", Messages.GasulPos);
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
        private void ReturnItem()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    var returnId = int.Parse(txtRID.Text);
                    var returnCd = txtGEN.Text.Trim(' ');
                    var prodctId = GetProductId(cmbNAM.Text);
                    var returnNo = txtREN.Text.Trim(' ');
                    var retrnQty = decimal.Parse(txtQTY.Text);
                    var branchId = _branch;
                    var destines = GetBranchId(cmbDES.Text);
                    var returnDt = dkpPUR.Value.Date;
                    var refDates = dkpREF.Value.Date;
                    var statusId = GetProductStatus(cmbSAT.Text);
                    var remarkss = txtMAR.Text.Trim(' ');
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.ExecuteReturnWarehouse(StoredProcedure.UspReturnItemWareh,
                        SqlVariables.ReturnId, returnId,
                        SqlVariables.ReturnCode, returnCd,
                        SqlVariables.ProductId, prodctId,
                        SqlVariables.ReturnNo, returnNo,
                        SqlVariables.ReturnQty, retrnQty,
                        SqlVariables.BranchId, branchId,
                        SqlVariables.Destination, destines,
                        SqlVariables.ReturnDel, returnDt,
                        SqlVariables.RefDate, refDates,
                        SqlVariables.StatusId, statusId,
                        SqlVariables.Remarks, remarkss, 
                        SqlVariables.InventoryId, returnId);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Item: "+cmbNAM.Text.Trim(' ')+" successfully return to Warehouse!", Messages.GasulPos);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void ReturnLpgEdt()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var returnId = int.Parse(txtRID.Text);
                    var returnCd = txtGEN.Text.Trim(' ');
                    var prodctId = GetProductId(cmbNAM.Text);
                    var returnNo = txtREN.Text.Trim(' ');
                    var retrnQty = decimal.Parse(txtQTY.Text);
                    var branchId = _branch;
                    var destines = GetBranchId(cmbDES.Text);
                    var returnDt = dkpPUR.Value.Date;
                    var refDates = dkpREF.Value.Date;
                    var statusId = GetProductStatus(cmbSAT.Text);
                    var remarkss = txtMAR.Text.Trim(' ');
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var que = repository.FindBy(x => x.ReturnId == returnId);
                        que.ReturnCode = returnCd;
                        que.ProductId  = prodctId;
                        que.ReturnNo   = returnNo;
                        que.ReturnQty = retrnQty;
                        que.BranchId = branchId;
                        que.Destination = destines;
                        que.ReturnDelivery = returnDt;
                        que.RefDate = refDates;
                        que.StatusId = statusId;
                        que.Remarks = remarkss;
                    var result = repository.Update(que);
                    if (result)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item: " + cmbNAM.Text.Trim(' ') + " successfully updated to Warehouse!", Messages.GasulPos);
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
        private void ReturnItmEdt() {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    var returnId = int.Parse(txtRID.Text);
                    var returnCd = txtGEN.Text.Trim(' ');
                    var prodctId = GetProductId(cmbNAM.Text);
                    var returnNo = txtREN.Text.Trim(' ');
                    var retrnQty = decimal.Parse(txtQTY.Text);
                    var branchId = _branch;
                    var destines = GetBranchId(cmbDES.Text);
                    var returnDt = dkpPUR.Value.Date;
                    var refDates = dkpREF.Value.Date;
                    var statusId = GetProductStatus(cmbSAT.Text);
                    var remarkss = txtMAR.Text.Trim(' ');
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.ExecuteRetUpdWarehouse(StoredProcedure.UspReturnUpdWarehs,
                        SqlVariables.ReturnId, returnId,
                        SqlVariables.ReturnCode, returnCd,
                        SqlVariables.ProductId, prodctId,
                        SqlVariables.ReturnNo, returnNo,
                        SqlVariables.ReturnQty, retrnQty,
                        SqlVariables.BranchId, branchId,
                        SqlVariables.Destination, destines,
                        SqlVariables.ReturnDel, returnDt,
                        SqlVariables.RefDate, refDates,
                        SqlVariables.StatusId, statusId,
                        SqlVariables.Remarks, remarkss);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Item: " + cmbNAM.Text.Trim(' ') + " successfully updated!", Messages.GasulPos);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void ReturnLpgDel()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var returnId = int.Parse(txtRID.Text);
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var que = repository.FindBy(x => x.ReturnId == returnId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item: " + cmbNAM.Text.Trim(' ') + " successfully deleted!", Messages.GasulPos);
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
                    var returnId = int.Parse(txtRID.Text);
                     var retrnQty = decimal.Parse(txtQTY.Text);
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.ExecuteRetDelWarehouse(StoredProcedure.UspReturnDelWarehs,
                        SqlVariables.ReturnId, returnId,
                        SqlVariables.ReturnQty, retrnQty);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Item: " + cmbNAM.Text.Trim(' ') + " successfully deleted!", Messages.GasulPos);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void BindStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ProductStatus>(unWork);
                var query = repository.SelectAll(Query.AllProductStatus).Select(x => x.Status).Distinct().ToList();
                cmbSAT.DataBindings.Clear();
                cmbSAT.DataSource = query;
            }
        }
    }
}
