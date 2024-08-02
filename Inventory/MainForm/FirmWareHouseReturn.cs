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
        private bool _lpg, _itm, _ret, _add, _edt, _del, _pop;
        private bool _edtItm, _edtLpg;
        private readonly int _userId;
        private readonly int _userTy;
        private IEnumerable<ViewInventoryList> listInventory;
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
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            listInventory = EnumerableUtils.EnumerableBranches();
            ShowBranch();
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
            _lpg = true;
            _itm = false;
            _add = true;
            _edt = false;
            _del = false;
            ButtonLpg();
            InputLpg();
            InputEnab();
            cmbProductName.Focus();
            GenerateReturn();
            cmbProductName.BackColor = Color.Yellow;
            cmbFromBranch.Text = GetBranch(_branch);
            cmbToBranch.Text = Constant.DefaultWareHouse;
            cmbProductStatus.Text = Constant.DefaultReturn;
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
            cmbProductName.Focus();
            GenerateReturn();
            cmbProductName.BackColor = Color.Yellow;
            cmbFromBranch.Text = GetBranch(_branch);
            cmbToBranch.Text = Constant.DefaultWareHouse;
            cmbProductStatus.Text = Constant.DefaultReturn;
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
            cmbProductName.Focus();
            cmbProductName.BackColor = Color.Yellow;
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
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
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
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
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
            txtReturnId.BackColor = Color.White;
            txtReturnCode.BackColor = Color.White;
            cmbProductName.BackColor = Color.White;
            txtDeliveryNo.BackColor = Color.White;
            txtReturnQty.BackColor = Color.White;
            cmbFromBranch.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
            txtRemarks.BackColor = Color.White;
            dkpReturnDelivery.BackColor = Color.White;
            dkpInputDate.BackColor = Color.White;
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
            dkpInputDate.Enabled = true;
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
            dkpInputDate.Enabled = false;
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
            dkpInputDate.Value = DateTime.Now.Date;
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
            dkpInputDate.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
            txtWarehouseQty.BackColor = Color.DimGray;
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
                    PopupNotification.PopUpMessages(0, "Product Id Error", "Product Inventory Details");
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
                    var query = repository.FindBy(x => x.branch_details == input);
                    return query.branch_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Branch Inventory Details");
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
                    return query.branch_details;
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
                    PopupNotification.PopUpMessages(0, "Product Status Id Error", "Product Status Inventory Details");
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
                        .Where(x => x.return_number == returnNo)
                        .Select(x => x.return_id)
                        .Count();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                    return 0;
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
                              orderby b.return_id descending
                              select b.return_code).Take(1).SingleOrDefault();
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
            gridDelivery.Columns.Clear();

        }
        private void BindWareHouse()
        {
            var branch = GetBranch(_branch);
            retWET.ShowWaitForm();
            ClearGrid();
            gDEL.DataSource = EnumerableWareHouse(branch);
            if (gridDelivery.RowCount > 0)
            {
                gridDelivery.Columns[0].Width = 40;
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
             // gCON.DataSource = EnumerableBranches(branch);
             gCON.DataSource = listInventory.Select(p => new { 
                Id = p.inventory_id,
                Item = p.product_name,
                Qty = p.quantity,
                Status = p.status,
                Branch = p.branch_details

            });  
            if (gridReturn.RowCount > 0)
            {
                gridReturn.Columns[0].Width = 50;
                gridReturn.Columns[1].Width = 400;
                gridReturn.Columns[2].Width = 80;
                gridReturn.Columns[3].Width = 120;
                gridReturn.Columns[4].Width = 160;

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
                    var repository = new Repository<ViewProductId>(unWork);
                    return repository
                        .SelectAll(Query.SelectAllProductId)
                        .Count(x => x.product_id == productId);
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
        private void ShowValue(int id)
        {
            var que = ShowEntity(id);
            if (que != null)
            {
                txtReturnId.Text = que.inventory_id.ToString();
                txtReturnCode.Text = que.product_code;
                cmbProductName.Text = que.product_name;
                txtDeliveryNo.Text = que.delivery_code;
                txtWarehouseQty.Text = que.quantity.ToString(CultureInfo.InvariantCulture);
                cmbFromBranch.Text = que.branch_details;
                dkpInputDate.Value = que.inventory_date.Date;
                cmbProductStatus.Text = que.status;
            }
        }
        private void ShowValueReturn(int id)
        {
            var que = ShowReturn(id);
            if (que != null)
            {
                txtReturnId.Text = que.return_id.ToString();
                txtGEN.Text = que.return_code;
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
                cmbProductName.DataBindings.Clear();
                cmbProductName.DataSource = query;
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
                cmbProductName.DataBindings.Clear();
                cmbProductName.DataSource = query;
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
                    return repository.FindBy(x => x.inventory_id == inventoryId);
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
                    return repository.FindBy(x => x.return_id == returnId);
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
                    var productId = GetProductId(cmbProductName.Text);
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
            if (gridReturn.RowCount > 0)
            {
                try
                {
                    if (_ret == false)
                    {
                        var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                        ShowValue(invId);
                        var imgId = GetProductImgId(cmbProductName.Text);
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
        private void gridReturn_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            InputWhit();
            var len = cmbProductName.Text.Length;
            if (_ret == false)
            {
                bntUPD.Enabled = false;
                if (len > 0)
                {
                    retWET.ShowWaitForm();
                    var item = cmbProductName.Text.Trim(' ');
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
                    var item = cmbProductName.Text.Trim(' ');
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

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (_lpg && _ret == false && _add == false)
                {
                    BindProductsLpg();
                }
                else if (_lpg == false && _ret == false && _add == false)
                {
                    BindProducts();
                }
            }
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
                    PopupNotification.PopUpMessages(0, "Item name must not be empty!", Messages.GasulPos);
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
                    PopupNotification.PopUpMessages(0, "Return Delivery No must not be empty!", Messages.GasulPos);
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
            if (_itm && _lpg == false)
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
                cmbProductStatus.Focus();
                cmbProductStatus.BackColor = Color.Yellow;
            }
        }

        private void cmbProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { BindStatus(); }
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
                        ProductId = GetProductId(cmbProductName.Text),
                        ReturnNo = txtDeliveryNo.Text.Trim(' '),
                        ReturnQty = decimal.Parse(txtReturnQty.Text),
                        BranchId = GetBranchId(cmbFromBranch.Text),
                        Destination = GetBranchId(cmbToBranch.Text),
                        ReturnDelivery = dkpReturnDelivery.Value.Date,
                        RefDate = dkpInputDate.Value.Date,
                        StatusId = GetProductStatus(cmbProductStatus.Text),
                        Remarks = txtRemarks.Text.Trim(' '), 
                        InventoryId = int.Parse(txtReturnId.Text)
                    };
                    retWET.ShowWaitForm();
                    unWork.Begin();
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var result = repository.Add(item);
                    if (result > 0)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,"Return Delivery No: "+txtDeliveryNo.Text.Trim(' ')+" successfully return to Warehouse!", Messages.GasulPos);
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
                    var returnId = int.Parse(txtReturnId.Text);
                    var returnCd = txtGEN.Text.Trim(' ');
                    var prodctId = GetProductId(cmbProductName.Text);
                    var returnNo = txtDeliveryNo.Text.Trim(' ');
                    var retrnQty = decimal.Parse(txtReturnQty.Text);
                    var branchId = _branch;
                    var destines = GetBranchId(cmbToBranch.Text);
                    var returnDt = dkpReturnDelivery.Value.Date;
                    var refDates = dkpInputDate.Value.Date;
                    var statusId = GetProductStatus(cmbProductStatus.Text);
                    var remarkss = txtRemarks.Text.Trim(' ');
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
                        PopupNotification.PopUpMessages(1, "Item: "+cmbProductName.Text.Trim(' ')+" successfully return to Warehouse!", Messages.GasulPos);
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
                    var returnId = int.Parse(txtReturnId.Text);
                    var returnCd = txtGEN.Text.Trim(' ');
                    var prodctId = GetProductId(cmbProductName.Text);
                    var returnNo = txtDeliveryNo.Text.Trim(' ');
                    var retrnQty = decimal.Parse(txtReturnQty.Text);
                    var branchId = _branch;
                    var destines = GetBranchId(cmbToBranch.Text);
                    var returnDt = dkpReturnDelivery.Value.Date;
                    var refDates = dkpInputDate.Value.Date;
                    var statusId = GetProductStatus(cmbProductStatus.Text);
                    var remarkss = txtRemarks.Text.Trim(' ');
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
                            "Item: " + cmbProductName.Text.Trim(' ') + " successfully updated to Warehouse!", Messages.GasulPos);
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
                    var returnId = int.Parse(txtReturnId.Text);
                    var returnCd = txtGEN.Text.Trim(' ');
                    var prodctId = GetProductId(cmbProductName.Text);
                    var returnNo = txtDeliveryNo.Text.Trim(' ');
                    var retrnQty = decimal.Parse(txtReturnQty.Text);
                    var branchId = _branch;
                    var destines = GetBranchId(cmbToBranch.Text);
                    var returnDt = dkpReturnDelivery.Value.Date;
                    var refDates = dkpInputDate.Value.Date;
                    var statusId = GetProductStatus(cmbProductStatus.Text);
                    var remarkss = txtRemarks.Text.Trim(' ');
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
                        PopupNotification.PopUpMessages(1, "Item: " + cmbProductName.Text.Trim(' ') + " successfully updated!", Messages.GasulPos);
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
                    var returnId = int.Parse(txtReturnId.Text);
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    var que = repository.FindBy(x => x.ReturnId == returnId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        retWET.CloseWaitForm();
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1,
                            "Item: " + cmbProductName.Text.Trim(' ') + " successfully deleted!", Messages.GasulPos);
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
                        PopupNotification.PopUpMessages(1, "Item: " + cmbProductName.Text.Trim(' ') + " successfully deleted!", Messages.GasulPos);
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
                var query = repository.SelectAll(Query.AllProductStatus).Select(x => x.status).Distinct().ToList();
                cmbProductStatus.DataBindings.Clear();
                cmbProductStatus.DataSource = query;
            }
        }
    }
}
