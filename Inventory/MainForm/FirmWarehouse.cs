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
                cmbWarehouseBranch.Text = _branch;
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
                //ShowValue(invId);
                txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                txtItemPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                bntClear.Enabled = true;
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
                bntClear.Enabled = true;
        }
        private void InputWhit()
        {
            txtWarehouseId.BackColor = Color.White;
            txtWarehouseCode.BackColor = Color.White;
            cmbProductName.BackColor = Color.White;
            txtDeliveryNo.BackColor = Color.White;
            txtReceiptNo.BackColor = Color.White;
            txtWarehouseQty.BackColor = Color.White;
            cmbWarehouseBranch.BackColor = Color.White;
            cmbProductWarranty.BackColor = Color.White;
            txtLastCost.BackColor = Color.White;
            txtOnOrder.BackColor = Color.White;
            dkpDepotDelivery.BackColor = Color.White;
            dkpInputDate.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtWarehouseId.Enabled = true;
            txtWarehouseCode.Enabled = true;
            cmbProductName.Enabled = true;
            txtDeliveryNo.Enabled = true;
            txtReceiptNo.Enabled = true;
            txtWarehouseQty.Enabled = true;
            cmbWarehouseBranch.Enabled = true;
            cmbProductWarranty.Enabled = true;
            txtLastCost.Enabled = true;
            txtOnOrder.Enabled = true;
            dkpDepotDelivery.Enabled = true;
            dkpInputDate.Enabled = true;
            cmbProductStatus.Enabled = true;
        }
        private void InputDisb()
        {
            txtWarehouseId.Enabled = false;
            txtWarehouseCode.Enabled = false;
            cmbProductName.Enabled = false;
            txtDeliveryNo.Enabled = false;
            txtReceiptNo.Enabled = false;
            txtWarehouseQty.Enabled = false;
            cmbWarehouseBranch.Enabled = false;
            cmbProductWarranty.Enabled = false;
            txtLastCost.Enabled = false;
            txtOnOrder.Enabled = false;
            dkpDepotDelivery.Enabled = false;
            dkpInputDate.Enabled = false;
            cmbProductStatus.Enabled = false;
        }
        private void InputClea()
        {
            txtWarehouseId.Clear();
            txtWarehouseCode.Clear();
            cmbProductName.Text = "";
            txtDeliveryNo.Clear();
            txtReceiptNo.Clear();
            txtWarehouseQty.Clear();
            cmbWarehouseBranch.Text = "";
            cmbProductWarranty.Text = @"NO WARRANTY";
            txtLastCost.Clear();
            txtOnOrder.Clear();
            dkpDepotDelivery.Value = DateTime.Now.Date;
            dkpInputDate.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
        }
        private void InputDimG()
        {
            txtWarehouseId.BackColor = Color.DimGray;
            txtWarehouseCode.BackColor = Color.DimGray;
            cmbProductName.BackColor = Color.DimGray;
            txtDeliveryNo.BackColor = Color.DimGray;
            txtReceiptNo.BackColor = Color.DimGray;
            txtWarehouseQty.BackColor = Color.DimGray;
            cmbWarehouseBranch.BackColor = Color.DimGray;
            cmbProductWarranty.BackColor = Color.DimGray;
            txtLastCost.BackColor = Color.DimGray;
            txtOnOrder.BackColor = Color.DimGray;
            dkpDepotDelivery.BackColor = Color.DimGray;
            dkpInputDate.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
        }
        private void GenerateCode()
        {
            var lastCode = GetLastId();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum("PR", 3, lastId);
            alphaNumeric.Increment();
            txtWarehouseCode.Text = alphaNumeric.ToString();
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
                        Code        = txtWarehouseCode.Text,
                        ProductId   = GetProductId(cmbProductName.Text.TrimReduced()),
                        DeliveryNo  = txtDeliveryNo.Text.TrimReduced(),
                        ReceiptNo   = txtReceiptNo.Text.TrimReduced(),
                        QtyStock    = Convert.ToInt32(txtWarehouseQty.Text),
                        BranchId    = GetBranchId(cmbWarehouseBranch.Text),
                        LastCost    = Convert.ToDecimal(txtLastCost.Text.TrimReduced()),
                        OnOrder     = Convert.ToInt32(txtOnOrder.Text.TrimReduced()),
                        PurDate     = dkpDepotDelivery.Value.Date,
                        InvDate     = dkpInputDate.Value.Date,
                        WarrantyId  = GetWarrantyId(cmbProductWarranty.Text.TrimReduced()),
                        StatusId    = GetProductStatus(cmbProductStatus.Text.TrimReduced()), 
                        DepotId     = Constant.DefaultZero
                    };
                    var result = repository.Add(product);
                    if (result <= 0) return;
                    PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessInsert,
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
                    var proId       = Convert.ToInt32(txtWarehouseId.Text);
                    var repository  = new Repository<WareHouse>(unWork);
                    var que         = repository.Id(proId);
                    que.Code        = txtWarehouseCode.Text;
                    que.ProductId   = GetProductId(cmbProductName.Text);
                    que.DeliveryNo  = txtDeliveryNo.Text;
                    que.ReceiptNo   = txtReceiptNo.Text;
                    que.QtyStock    = Convert.ToDecimal(txtWarehouseQty.Text);
                    que.BranchId    = GetBranchId(cmbWarehouseBranch.Text);
                    que.LastCost    = Convert.ToDecimal(txtLastCost.Text);
                    que.OnOrder     = Convert.ToInt32(txtOnOrder.Text);
                    que.PurDate     = dkpDepotDelivery.Value.Date;
                    que.InvDate     = dkpInputDate.Value.Date;
                    que.WarrantyId  = GetWarrantyId(cmbProductWarranty.Text);
                    que.StatusId    = GetProductStatus(cmbProductStatus.Text);
                    que.DepotId     = int.Parse(txtDepotControl.Text);
                    var result      = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
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
                    var proId = Convert.ToInt32(txtWarehouseId.Text);
                    var repository = new Repository<WareHouse>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessDelete,
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
            cmbWarehouseBranch.Text = Constant.DefaultSource;
            BindProductStatus();
            BindProductWarranty();
            cmbProductName.Focus();
            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
            cmbProductName.Size = new Size(422, 29);
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
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            gCON.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
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
                cmbProductName.DataBindings.Clear();
                cmbProductName.DataSource = query;
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
        }/*
        private void ShowValue(int inventoryId)
        {
            var ent = ShowEntity(inventoryId);
            txtWarehouseId.Text = ent.Id.ToString();
            txtWarehouseCode.Text = ent.Code;
            cmbProductName.Text = ent.Item;
            txtDeliveryNo.Text = ent.Delivery;
            txtReceiptNo.Text = ent.Receipt;
            txtWarehouseQty.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbWarehouseBranch.Text = ent.Branch;
            txtLastCost.Text = ent.LastCost.ToString(CultureInfo.InvariantCulture);
            txtOnOrder.Text = ent.OnOrder.ToString();
            dkpDepotDelivery.Value = ent.Purchase;
            dkpInputDate.Value = ent.RefDate;
            cmbProductWarranty.Text = ent.Warranty;
            cmbProductStatus.Text = ent.Status;
            txtDepotControl.Text = ent.DepotId.ToString();
        }
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
        private static string GetLastId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewInventory>(unitWork);
                var result = (from b in repository.SelectAll(Query.AllInventory)
                              orderby b.inventory_id descending
                              select b.inventory_code).Take(1).SingleOrDefault();
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
        private static IEnumerable<ViewWarehouse> RebindInventory()
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

        }
        private void cmbNAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.Text.Length > 0)
            {
                var imgId = GetProductImgId(cmbProductName.Text);
            }
        }
        private void cmbNAM_Leave(object sender, EventArgs e)
        {
            cmbProductName.Size = new Size(269, 29);
            if (txtProductBarcode.Text.Length == 0)
            {
                txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                txtItemPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
            }
        }
        private void cmbNAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbProductName.Size = new Size(422, 29);
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtREC_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtLST_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtLST_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtORD_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtORD_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void dkpPUR_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
        {

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
            var len = txtWarehouseId.Text.Length;
            if (len > 0)
            {

                var wareHouseId = int.Parse(txtWarehouseId.Text);
                var wareHousCod = txtWarehouseCode.Text.Trim(' ');
                var wareHousQty = decimal.Parse(txtWarehouseQty.Text);
                var proLastCost = decimal.Parse(txtLastCost.Text);
                var productIdWh = GetProductId(cmbProductName.Text);
                var productName = cmbProductName.Text.Trim(' ');
                var productCode = ProductWareH(productIdWh).product_code;
                var itemOnOrder = int.Parse(txtOnOrder.Text);
                var delivery = new FirmPopDeliveryInvBranch(_userId, _userTyp, wareHouseId, wareHousCod, proLastCost, productIdWh, productName, productCode, wareHousQty, itemOnOrder)
                {
                    Main = this
                };
                delivery.ShowDialog();
            }
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
                    "Are you sure you want to Delete Inventory: " + cmbProductName.Text.Trim(' ') + " " + "?", "Inventory Details");
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
                InputManipulation.InputBoxLeave(txtDeliveryNo, txtReceiptNo, "Inventory Delivery No.",
                Messages.TitleInventory);
            }
        }

        private void txtDeliveryNo_Leave(object sender, EventArgs e)
        {
            var capz = string.Format(txtDeliveryNo.Text).ToUpper();
            var len = txtDeliveryNo.Text.Length;
            txtDeliveryNo.Text = capz;
            if (len <= 0) return;
            var verify = VerifyDelNo(capz);
            if (verify <= 0) return;
            if (_add) return;
            PopupNotification.PopUpMessages(0, "Delivery No: " + capz + " already exist!",
                "Delivery Number");
            txtDeliveryNo.Focus();
            txtDeliveryNo.BackColor = Color.Yellow;
            txtReceiptNo.BackColor = Color.White;
        }

        private void txtReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtReceiptNo, txtWarehouseQty, "Inventory Receipt No.",
                Messages.TitleInventory);
            }
        }

        private void txtWarehouseQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtWarehouseQty.Text.Length;
                if (len > 0)
                {
                    txtWarehouseQty.BackColor = Color.White;
                    cmbWarehouseBranch.BackColor = Color.Yellow;
                    cmbWarehouseBranch.Focus();
                }
                else
                {
                    txtWarehouseQty.Text = @"0";
                    txtWarehouseQty.BackColor = Color.White;
                    cmbWarehouseBranch.BackColor = Color.Yellow;
                    cmbWarehouseBranch.Focus();
                }
            }
        }

        private void txtWarehouseQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbWarehouseBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbWarehouseBranch, txtLastCost, "Branch Name",
                Messages.TitleInventory);
            }
            if (e.KeyCode == Keys.F1)
            {
                BindBranch();
            }
        }

        private void txtLastCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtLastCost.Text.Length;
                if (len > 0)
                {
                    txtLastCost.BackColor = Color.White;
                    txtOnOrder.BackColor = Color.Yellow;
                    txtOnOrder.Focus();
                }
                else
                {
                    txtLastCost.Text = @"0";
                    txtLastCost.BackColor = Color.White;
                    txtOnOrder.BackColor = Color.Yellow;
                    txtOnOrder.Focus();
                }
            }
        }

        private void txtLastCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOnOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtOnOrder.Text.Length;
                if (len > 0)
                {
                    txtOnOrder.BackColor = Color.White;
                    dkpDepotDelivery.Focus();
                }
                else
                {
                    txtOnOrder.Text = @"0";
                    txtOnOrder.BackColor = Color.White;
                    dkpDepotDelivery.Focus();
                }
            }
        }

        private void txtOnOrder_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dkpDepotDelivery_KeyDown(object sender, KeyEventArgs e)
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
            }
        }

        private void cmbProductStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProductStatus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbProductStatus.Text.Length;
                if (len > 0)
                {
                    cmbProductStatus.BackColor = Color.White;
                    cmbProductWarranty.Focus();
                }
            }
        }

        private void cmbProductWarranty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                BindProductWarranty();
            }
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbProductStatus, bntSave, "Product Warranty",
                    Messages.TitleInventory);
            }
        }

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = cmbProductName.Text.Length;
            if (len <= 0)
            {
                PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                cmbProductName.BackColor = Color.Yellow;
                cmbProductName.Focus();
            }
            else
            {
                cmbProductName.BackColor = Color.White;
                txtDeliveryNo.BackColor = Color.Yellow;
                txtDeliveryNo.Focus();
                txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                txtItemPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cmbWAR_KeyDown(object sender, KeyEventArgs e)
        {

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
