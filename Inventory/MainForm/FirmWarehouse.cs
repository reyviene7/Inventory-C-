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
using Inventory.PopupForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWarehouse : Form
    {
        private int _branchId;
        private int _deliver;
        private string _deliveryBranches;
        private string _branch;
        private int _close;
        private readonly int _userId;
        private readonly int _userTyp;
        public string DeliveryBranches
        {
            get { return _deliveryBranches; }
            set
            {
                _deliveryBranches = value;
                if (_deliveryBranches.Length > 0)
                {
                    BindBranchDeliverList(_deliveryBranches);
                }
            }
        }
        public new int Close
        {
            get { return _close; }
            set
            {
                _close = value;
                if (_close > 0)
                    xCON.SelectedTabPage = tabINV;
            }
        }
        public int Deliver
        {
            get { return _deliver; }
            set
            {
                _deliver = value;
                if (_deliver > 0)
                {
                    BindProductList();
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
                var main = new FirmMain(_userId, _userTyp);
                main.Show();
            }
        }
        public int BranchId
        {
            get { return _branchId; }
            set
            {
                _branchId = value;

                _branch = GetBranchName(_branchId);
                cmbDIS.Text = _branch;
                BindProductList();
            }
        }
        private bool _add, _edt, _del;
        public FirmMain Main { get; set; }
        public FirmWarehouse(int userId, int userTy)
        {
            _userId = userId;
            _userTyp = userTy;
            InitializeComponent();
        }
        private void FirmWarehouseInvetory_Load(object sender, EventArgs e)
        {
            BindProductList();
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
            var len = txtIND.Text.Length;
            if (len > 0)
            {
                
                var wareHouseId = int.Parse(txtIND.Text);
                var wareHousCod = txtICD.Text.Trim(' ');
                var wareHousQty = decimal.Parse(txtQTY.Text);
                var proLastCost = decimal.Parse(txtLST.Text);
                var productIdWh = GetProductId(cmbNAM.Text);
                var productName = cmbNAM.Text.Trim(' ');
                var productCode = ProductWareH(productIdWh).product_code;
                var itemOnOrder = int.Parse(txtORD.Text);
                var delivery = new FirmPopDeliveryInvBranch(_userId, _userTyp, wareHouseId, wareHousCod, proLastCost, productIdWh, productName, productCode, wareHousQty, itemOnOrder)
                {
                    Main = this
                };
                delivery.ShowDialog();
            }

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
                    "Are you sure you want to Delete Inventory: " + cmbNAM.Text.Trim(' ') + " " + "?", "Inventory Details");
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

        }
        private void txtDEL_Leave(object sender, EventArgs e)
        {
            var capz = string.Format(txtDEL.Text).ToUpper();
            var len = txtDEL.Text.Length;
            txtDEL.Text = capz;
            if (len <= 0) return;
            var verify = VerifyDelNo(capz);
            if (verify <= 0) return;
            if (_add) return;
            PopupNotification.PopUpMessages(0, "Delivery No: " + capz + " already exist!",
                "Delivery Number");
            txtDEL.Focus();
            txtDEL.BackColor = Color.Yellow;
            txtREC.BackColor = Color.White;
        }
        private void txtREC_Leave(object sender, EventArgs e)
        {

        }
        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = gridInventory;
            if (grid.RowCount <= 0) return;
            try
            {
                var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                ShowValue(invId);
                var imgId = GetProductImgId(cmbNAM.Text);
                DisplayImage(imgId);
                txtBAR.Text = SearchBarcode(cmbNAM.Text).product_code;
                txtPRC.Text = SearchBarcode(cmbNAM.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                bntCLR.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void gridInventory_Click(object sender, EventArgs e)
        {
            if (gridInventory.RowCount > 0)
                InputWhit();
                bntCLR.Enabled = true;
        }
        private void InputWhit()
        {
            txtIND.BackColor = Color.White;
            txtICD.BackColor = Color.White;
            cmbNAM.BackColor = Color.White;
            txtDEL.BackColor = Color.White;
            txtREC.BackColor = Color.White;
            txtQTY.BackColor = Color.White;
            cmbDIS.BackColor = Color.White;
            cmbWAR.BackColor = Color.White;
            txtLST.BackColor = Color.White;
            txtORD.BackColor = Color.White;
            dkpPUR.BackColor = Color.White;
            dkpDET.BackColor = Color.White;
            cmbSAT.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtIND.Enabled = true;
            txtICD.Enabled = true;
            cmbNAM.Enabled = true;
            txtDEL.Enabled = true;
            txtREC.Enabled = true;
            txtQTY.Enabled = true;
            cmbDIS.Enabled = true;
            cmbWAR.Enabled = true;
            txtLST.Enabled = true;
            txtORD.Enabled = true;
            dkpPUR.Enabled = true;
            dkpDET.Enabled = true;
            cmbSAT.Enabled = true;
        }
        private void InputDisb()
        {
            txtIND.Enabled = false;
            txtICD.Enabled = false;
            cmbNAM.Enabled = false;
            txtDEL.Enabled = false;
            txtREC.Enabled = false;
            txtQTY.Enabled = false;
            cmbDIS.Enabled = false;
            cmbWAR.Enabled = false;
            txtLST.Enabled = false;
            txtORD.Enabled = false;
            dkpPUR.Enabled = false;
            dkpDET.Enabled = false;
            cmbSAT.Enabled = false;
        }
        private void InputClea()
        {
            txtIND.Clear();
            txtICD.Clear();
            cmbNAM.Text = "";
            txtDEL.Clear();
            txtREC.Clear();
            txtQTY.Clear();
            cmbDIS.Text = "";
            cmbWAR.Text = @"NO WARRANTY";
            txtLST.Clear();
            txtORD.Clear();
            dkpPUR.Value = DateTime.Now.Date;
            dkpDET.Value = DateTime.Now.Date;
            cmbSAT.Text = "";
        }
        private void InputDimG()
        {
            txtIND.BackColor = Color.DimGray;
            txtICD.BackColor = Color.DimGray;
            cmbNAM.BackColor = Color.DimGray;
            txtDEL.BackColor = Color.DimGray;
            txtREC.BackColor = Color.DimGray;
            txtQTY.BackColor = Color.DimGray;
            cmbDIS.BackColor = Color.DimGray;
            cmbWAR.BackColor = Color.DimGray;
            txtLST.BackColor = Color.DimGray;
            txtORD.BackColor = Color.DimGray;
            dkpPUR.BackColor = Color.DimGray;
            dkpDET.BackColor = Color.DimGray;
            cmbSAT.BackColor = Color.DimGray;
        }
        private void GenerateCode()
        {
            var lastCode = GetLastId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "PR");
            alphaNumeric.Increment();
            txtICD.Text = alphaNumeric.ToString();
        }
        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<WareHouse>(unWork);
                    var product = new WareHouse()
                    {
                        Code        = txtICD.Text,
                        ProductId   = GetProductId(cmbNAM.Text.TrimReduced()),
                        DeliveryNo  = txtDEL.Text.TrimReduced(),
                        ReceiptNo   = txtREC.Text.TrimReduced(),
                        QtyStock    = Convert.ToInt32(txtQTY.Text),
                        BranchId    = GetBranchId(cmbDIS.Text),
                        LastCost    = Convert.ToDecimal(txtLST.Text.TrimReduced()),
                        OnOrder     = Convert.ToInt32(txtORD.Text.TrimReduced()),
                        PurDate     = dkpPUR.Value.Date,
                        InvDate     = dkpDET.Value.Date,
                        WarrantyId  = GetWarrantyId(cmbWAR.Text.TrimReduced()),
                        StatusId    = GetProductStatus(cmbSAT.Text.TrimReduced()), 
                        DepotId     = Constant.DefaultZero
                    };
                    var result = repository.Add(product);
                    if (result <= 0) return;
                    PopupNotification.PopUpMessages(1, "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessInsert,
                        Messages.TitleSuccessInsert);
                    unWork.Commit();
                }
                catch (Exception ex)
                {

                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);

                }
            }
        }
        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var proId       = Convert.ToInt32(txtIND.Text);
                    var repository  = new Repository<WareHouse>(unWork);
                    var que         = repository.Id(proId);
                    que.Code        = txtICD.Text;
                    que.ProductId   = GetProductId(cmbNAM.Text);
                    que.DeliveryNo  = txtDEL.Text;
                    que.ReceiptNo   = txtREC.Text;
                    que.QtyStock    = Convert.ToDecimal(txtQTY.Text);
                    que.BranchId    = GetBranchId(cmbDIS.Text);
                    que.LastCost    = Convert.ToDecimal(txtLST.Text);
                    que.OnOrder     = Convert.ToInt32(txtORD.Text);
                    que.PurDate     = dkpPUR.Value.Date;
                    que.InvDate     = dkpDET.Value.Date;
                    que.WarrantyId  = GetWarrantyId(cmbWAR.Text);
                    que.StatusId    = GetProductStatus(cmbSAT.Text);
                    que.DepotId     = int.Parse(txtDEP.Text);
                    var result      = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                         Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);

                }
            }
        }
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var proId = Convert.ToInt32(txtIND.Text);
                    var repository = new Repository<WareHouse>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbNAM.Text.Trim(' ') + " " + Messages.SuccessDelete,
                         Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);

                }
            }
        }
        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            InputClea();
            GenerateCode();
            BindProducts();
          //  BindBranch();
            cmbDIS.Text = Constant.DefaultSource;
            BindProductStatus();
            BindProductWarranty();
            cmbNAM.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
            cmbNAM.Size = new Size(422, 29);
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
        private void ButUpd()
        {
            ButtonUpd();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = true;
            _del = false;
            gCON.Enabled = false;
        
        }
        private void ButDel()
        {
            ButtonDel();
            InputEnab();
            InputWhit();
            _add = false;
            _edt = false;
            _del = true;
            gCON.Enabled = false;
        
        }
        //private void ButClr()
        //{
        //    ButtonClr();
        //    InputEnab();
        //    InputWhit();
        //    InputClea();
        //    gCON.Enabled = true;
        //    cmbNAM.DataBindings.Clear();

        //}
        private void ButSav()
        {

            if (_add && _edt == false && _del == false)
            {

                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList();

            }
            if (_add == false && _edt && _del == false)
            {

                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList();

            }
            if (_add == false && _edt == false && _del)
            {

                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList();

            }
            _add = false;
            _edt = false;
            _del = false;
            gCON.Enabled = true;
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbNAM.DataBindings.Clear();
            imgPRO.DataBindings.Clear();
            imgPRO.Image = null;
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
        private void BindProductList()
        {
            gCON.Update();
            try
            {
                gCON.DataBindings.Clear();
                gCON.DataSource = null;
                gCON.DataSource = RebindInventory();
                if (gridInventory.RowCount > 0)
                {
                    gridInventory.Columns[0].Width = 40;
                    gridInventory.Columns[1].Width = 90;
                    gridInventory.Columns[2].Width = 280;
                    gridInventory.Columns[3].Width = 100;
                    gridInventory.Columns[3].Width = 120;

                }
            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void BindBranchDeliverList(string branch)
        {
            gDEL.Update();
            try
            {
                werWET.ShowWaitForm();
                gDEL.DataBindings.Clear();
                gDEL.DataSource = null;
                gDEL.DataSource = BindBranchDeliver(branch);
                if (gridDEL.RowCount > 0)
                {
                    gridDEL.Columns[0].Width = 40;
                }
                werWET.CloseWaitForm();
            }
            catch (Exception ex)
            {
                gDEL.EndUpdate();
                Console.Write(ex.ToString());
            }
        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = repository.SelectAll(Query.AllItemNotInDepot)
                    .Select(x => x.product_id)
                    .Distinct()
                    .ToList();
                cmbNAM.DataBindings.Clear();
                cmbNAM.DataSource = query;
            }
        }
        private void BindBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Branch>(unWork);
                var query = repository.SelectAll(Query.AllBranch).Select(x => x.BranchDetails).Distinct().ToList();
                cmbDIS.DataBindings.Clear();
                cmbDIS.DataSource = query;
            }
        }
        private void BindProductStatus()
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
        private void BindProductWarranty()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Warranty>(unWork);
                var query = repository.SelectAll(Query.AllWarranty).Select(x => x.Name).Distinct().ToList();
                cmbWAR.DataBindings.Clear();
                cmbWAR.DataSource = query;
            }
        }
        private void ShowValue(int inventoryId)
        {
            var ent = ShowEntity(inventoryId);
            txtIND.Text = ent.Id.ToString();
            txtICD.Text = ent.Code;
            cmbNAM.Text = ent.Item;
            txtDEL.Text = ent.Delivery;
            txtREC.Text = ent.Receipt;
            txtQTY.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbDIS.Text = ent.Branch;
            txtLST.Text = ent.LastCost.ToString(CultureInfo.InvariantCulture);
            txtORD.Text = ent.OnOrder.ToString();
            dkpPUR.Value = ent.Purchase;
            dkpDET.Value = ent.RefDate;
            cmbWAR.Text = ent.Warranty;
            cmbSAT.Text = ent.Status;
            txtDEP.Text = ent.DepotId.ToString();
        }
        private static ViewWareHouse ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewWareHouse>(unWork);
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
        private static int VerifyDelNo(string deliveryNo)
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    var repository = new Repository<WareHouse>(unWork);
                    return repository.SelectAll(Query.SelectCountDepotDel)
                        .Where(x => x.DeliveryNo == deliveryNo)
                        .Select(x => x.DeliveryNo)
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
                    var repository = new Repository<WareHouse>(unWork);
                    return repository.SelectAll(Query.SelectCountDepotRet)
                        .Where(x => x.ReceiptNo == receiptNo)
                        .Select(x => x.ReceiptNo)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        private static Products ProductWareH(int productId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    return repository.FindBy(x => x.product_id == productId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static byte[] GetByImage(int imgId)
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
        private static string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewInventory>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllInventory)
                              orderby b.InventoryId descending
                              select b.Code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
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
        private static string GetBranchName(int branchId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_id == branchId);
                    return query.BranchDetails;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
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
        private static int GetProductImgId(string input)
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
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Image Id Error", "Product Details");
                    throw;
                }
            }
        }
        private static IEnumerable<ViewWareHouse> RebindInventory()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewWareHouse>(unWork);
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
        private static IEnumerable<ViewBranchDelivery> BindBranchDeliver(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewBranchDelivery>(unWork);
                    return repository.SelectAll(Query.SelectAllBranchDelivery)
                                     .Where(x => x.Branch == branch)
                                     .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = cmbNAM.Text.Length;
            if (len <= 0)
            {
                PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                cmbNAM.BackColor = Color.Yellow;
                cmbNAM.Focus();
            }
            else
            {
                cmbNAM.BackColor = Color.White;
                txtDEL.BackColor = Color.Yellow;
                txtDEL.Focus();
                txtBAR.Text = SearchBarcode(cmbNAM.Text).product_code;
                txtPRC.Text = SearchBarcode(cmbNAM.Text).retail_price.ToString(CultureInfo.InvariantCulture);
            }
        }
        private void cmbNAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNAM.Text.Length > 0)
            {
                var imgId = GetProductImgId(cmbNAM.Text);
                DisplayImage(imgId);
            }
        }
        private void cmbNAM_Leave(object sender, EventArgs e)
        {
            cmbNAM.Size = new Size(269, 29);
            if (txtBAR.Text.Length == 0)
            {
                txtBAR.Text = SearchBarcode(cmbNAM.Text).product_code;
                txtPRC.Text = SearchBarcode(cmbNAM.Text).retail_price.ToString(CultureInfo.InvariantCulture);
            }
        }
        private void cmbNAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbNAM.Size = new Size(422, 29);
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtDEL, txtREC, "Inventory Delivery No.",
                Messages.TitleInventory);
            }
        }
        private void txtREC_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtREC, txtQTY, "Inventory Receipt No.",
                Messages.TitleInventory);
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
                    cmbDIS.BackColor = Color.Yellow;
                    cmbDIS.Focus();
                }
                else
                {
                    txtQTY.Text = @"0";
                    txtQTY.BackColor = Color.White;
                    cmbDIS.BackColor = Color.Yellow;
                    cmbDIS.Focus();
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
        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbDIS, txtLST, "Branch Name",
                Messages.TitleInventory);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindBranch();
            }
        }
        private void txtLST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtLST.Text.Length;
                if (len > 0)
                {
                    txtLST.BackColor = Color.White;
                    txtORD.BackColor = Color.Yellow;
                    txtORD.Focus();
                }
                else
                {
                    txtLST.Text = @"0";
                    txtLST.BackColor = Color.White;
                    txtORD.BackColor = Color.Yellow;
                    txtORD.Focus();
                }


            }
        }
        private void txtLST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtLST.Focus();
                txtLST.BackColor = Color.Yellow;
            }
            else
            {
                txtLST.BackColor = Color.White;
            }
        }
        private void txtORD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                var len = txtORD.Text.Length;
                if (len > 0)
                {
                    txtORD.BackColor = Color.White;
                    dkpPUR.Focus();
                }
                else
                {
                    txtORD.Text = @"0";
                    txtORD.BackColor = Color.White;
                    dkpPUR.Focus();
                }

            }
        }
        private void txtORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtORD.Focus();
                txtORD.BackColor = Color.Yellow;
            }
            else
            {
                txtORD.BackColor = Color.White;
            }
        }
        private void dkpPUR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpDET.Focus();
            }
        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSAT.Focus();
            }
        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProductStatus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbSAT.Text.Length;
                if (len > 0)
                {
                    cmbSAT.BackColor = Color.White;
                    cmbWAR.Focus();
                }
            }
        }
        private void cmbWAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProductWarranty();
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbSAT, bntSAV, "Product Warranty",
                    Messages.TitleInventory);
            }
        }
        private void xCON_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xCON.SelectedTabPage == tabHIS)
            {
                gDEL.DataBindings.Clear();
                gDEL.DataSource = null;
                if (_userTyp == 1)
                {
                    var bra = new FirmPopBranches(_userId, _userTyp)
                    {
                        Main = this
                    };
                    bra.ShowDialog();
                }
                else
                {
                    PopupNotification.PopUpMessages(0, Messages.AdminPrivilege+"to access warehouse delivery!", Messages.GasulPos);
                    xCON.SelectedTabPage = tabINV;
                }
            }
        }
    }
}
