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
    public partial class FirmDepot : Form
    {
        private int _branchId;
        private string _branch;
        private readonly int _userId;
        private readonly int _usrTyp;
        private bool _extInvent;
        public bool ExiInven
        {
            get{ return _extInvent; }
            set
            {
                _extInvent = value; 
                if(_extInvent)
                Close();
               var main = new FirmMain(_userId, _usrTyp);
                main.Show();
            }
        }
        public int BranchId
        {
            get { return _branchId; }
            set
            {
                _branchId = value;
                
                 _branch   = GetBranchName(_branchId);
                cmbBranchName.Text = _branch;
                BindDepotList();
            }
        }
        private bool _add, _edt, _del;
        public FirmMain Main { get; set; }
        public FirmDepot(int userId, int usrTyp)
        {
            _userId = userId;
            _usrTyp = usrTyp;
            InitializeComponent();
        }
        private void FrmInventory_Load(object sender, EventArgs e)
        {
            BindDepotList();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        #region ButtonCRUD
        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            InputClea();
            GenerateCode();
            BindProducts();
            BindBranch();
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
            txtDeliveryNo.Text = GetLastDeliveryNo();
            txtRecepitNo.Text = GetLastDeliveryNo();
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
        private void ButtonClr()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = false;
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
        private void ButClr()
        {
            ButtonClr();
            InputEnab();
            InputWhit();
            InputClea();
            gCON.Enabled = true;
           cmbProductName.DataBindings.Clear();
    
        }
        private void ButSav()
        {

            if (_add && _edt == false && _del == false)
            {
               
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindDepotList();
                
            }
            if (_add == false && _edt && _del == false)
            {
              
                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindDepotList();
            
            }
            if (_add == false && _edt == false && _del)
            {
              
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindDepotList();
             
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
        #endregion
        private void DisplayImage(int imgId)
        {

            imgPreview.DataBindings.Clear();
            var img = GetByImage(imgId);
            if (img != null)
            {
                MemoryStream memoryStream = new MemoryStream(img);
                imgPreview.Image = Image.FromStream(memoryStream);
             
            }
            else
            {

                imgPreview.Image = null;
            }
        }
        private void BindDepotList()
        {
            gCON.Update();
            var refDate = DateTime.Now.Date;
                gCON.DataBindings.Clear();
                gCON.DataSource = null;
                gCON.DataSource = RebindInventory(refDate);
            if (gridInventory.RowCount <= 0) return;
                gridInventory.Columns[0].Width = 40;
                gridInventory.Columns[1].Width = 90;
                gridInventory.Columns[2].Width = 280;
                gridInventory.Columns[3].Width = 100;
                gridInventory.Columns[3].Width = 120;
        }
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = repository.SelectAll(Query.AllProducts)
                    .Where(x => x.product_name.Contains(Constant.AddFilterLpg))
                    .Select(x => x.product_name)
                    .Distinct()
                    .ToList();
                cmbProductName.DataBindings.Clear();
                cmbProductName.DataSource = query;
            }
        }
        private void BindBranch()
        {
            cmbBranchName.Text = Constant.DefaultWareHouse;
        }
        private void BindProductStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<ProductStatus>(unWork);
                var query = repository.SelectAll(Query.AllProductStatus).Select(x => x.Status).Distinct().ToList();
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
        }
        private void InputWhit()
        {
            txtInventoryId.BackColor = Color.White;
            txtInventoryCode.BackColor = Color.White;
            cmbProductName.BackColor = Color.White;
            txtDeliveryNo.BackColor = Color.White;
            txtRecepitNo.BackColor = Color.White;
            txtQtyStock.BackColor = Color.White;
            cmbBranchName.BackColor = Color.White;
            cmbProductWarranty.BackColor = Color.White;
            txtLastCost.BackColor = Color.White;
            txtOnOrder.BackColor = Color.White;
            dkpDeliveryDate.BackColor = Color.White;
            dkpPurchaseDate.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtInventoryId.Enabled = true;
            txtInventoryCode.Enabled = true;
            cmbProductName.Enabled = true;
            txtDeliveryNo.Enabled = true;
            txtRecepitNo.Enabled = true;
            txtQtyStock.Enabled = true;
            cmbBranchName.Enabled = true;
            cmbProductWarranty.Enabled = true;
            txtLastCost.Enabled = true;
            txtOnOrder.Enabled = true;
            dkpDeliveryDate.Enabled = true;
            dkpPurchaseDate.Enabled = true;
            cmbProductStatus.Enabled = true;
        }
        private void InputDisb()
        {
            txtInventoryId.Enabled = false;
            txtInventoryCode.Enabled = false;
            cmbProductName.Enabled = false;
            txtDeliveryNo.Enabled = false;
            txtRecepitNo.Enabled = false;
            txtQtyStock.Enabled = false;
            cmbBranchName.Enabled = false;
            cmbProductWarranty.Enabled = false;
            txtLastCost.Enabled = false;
            txtOnOrder.Enabled = false;
            dkpDeliveryDate.Enabled = false;
            dkpPurchaseDate.Enabled = false;
            cmbProductStatus.Enabled = false;
        }
        private void InputClea() {
            
            txtInventoryId.Clear();
            txtInventoryCode.Clear();
            cmbProductName.Text = "";
            cmbBranchName.Text = "";
            cmbProductWarranty.Text = @"NO WARRANTY";
            txtLastCost.Clear();
            txtOnOrder.Clear();
            dkpDeliveryDate.Value = DateTime.Now.Date;
            dkpPurchaseDate.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
            if(_add)return;
            txtDeliveryNo.Clear();
            txtRecepitNo.Clear();
        }
        private void InputDimG()
        {
            txtInventoryId.BackColor = Color.DimGray;
            txtInventoryCode.BackColor = Color.DimGray;
            cmbProductName.BackColor = Color.DimGray;
            txtDeliveryNo.BackColor = Color.DimGray;
            txtRecepitNo.BackColor = Color.DimGray;
            txtQtyStock.BackColor = Color.DimGray;
            cmbBranchName.BackColor = Color.DimGray;
            cmbProductWarranty.BackColor = Color.DimGray;
            txtLastCost.BackColor = Color.DimGray;
            txtOnOrder.BackColor = Color.DimGray;
            dkpDeliveryDate.BackColor = Color.DimGray;
            dkpPurchaseDate.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
        }
        private void GenerateCode()
        {
            var lastCode = GetLastCode();
            var lastId = GetSettings.GetLastBarcode(lastCode);
            var alphaNumeric = new GenerateAlpaNum(3, 2, lastId, "D");
            alphaNumeric.Increment();
            txtInventoryCode.Text = alphaNumeric.ToString();
        }
        private void DataInsert()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                  
                    var repository = new Repository<Depot>(unWork);
                    var product = new Depot()
                    {
                        Code        = txtInventoryCode.Text,
                        ProductId   = GetProductId(cmbProductName.Text),
                        DeliveryNo  = txtDeliveryNo.Text,
                        ReceiptNo   = txtRecepitNo.Text,
                        QtyStock    = Convert.ToInt32(txtQtyStock.Text),
                        BranchId    = GetBranchId(cmbBranchName.Text),
                        LastCost    = Convert.ToDecimal(txtLastCost.Text),
                        OnOrder     = Convert.ToInt32(txtOnOrder.Text),
                        PurDate     = dkpDeliveryDate.Value.Date,
                        InvDate     = dkpPurchaseDate.Value.Date,
                        WarrantyId  = GetWarrantyId(cmbProductWarranty.Text),
                        StatusId    = GetProductStatus(cmbProductStatus.Text)
                    };
                    var result = repository.Add(product);
                    if (result > 0)
                    {
                      
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                    }

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
                    var proId           = Convert.ToInt32(txtInventoryId.Text);
                    var repository      = new Repository<Depot>(unWork);
                    var que             = repository.Id(proId);
                        que.Code        = txtInventoryCode.Text;
                        que.ProductId   = GetProductId(cmbProductName.Text);
                        que.DeliveryNo  = txtDeliveryNo.Text;
                        que.ReceiptNo   = txtRecepitNo.Text;
                        que.QtyStock    = Convert.ToDecimal(txtQtyStock.Text);
                        que.BranchId    = GetBranchId(cmbBranchName.Text);
                        que.LastCost    = Convert.ToDecimal(txtLastCost.Text);
                        que.OnOrder     = Convert.ToInt32(txtOnOrder.Text);
                        que.PurDate     = dkpDeliveryDate.Value.Date;
                        que.InvDate     = dkpPurchaseDate.Value.Date;
                        que.WarrantyId  = GetWarrantyId(cmbProductWarranty.Text);
                        que.StatusId    = GetProductStatus(cmbProductStatus.Text);
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
                    var proId = Convert.ToInt32(txtInventoryId.Text);
                    var repository = new Repository<Depot>(unWork);
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
        private void cmbNAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductName.Text.Length > 0)
            {
                var imgId = GetProductImgId(cmbProductName.Text);
                DisplayImage(imgId);
            }
        }
        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridInventory.RowCount > 0)
            {
                try
                {
                    var invId = (int)((GridView)sender).GetFocusedRowCellValue("Id");
                    ShowValue(invId);
                    var imgId = GetProductImgId(cmbProductName.Text);
                    DisplayImage(imgId);
                    txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                    lblPRZ.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
               
            }
        }
        private void ShowValue(int inventoryId)
        {
            var ent = ShowEntity(inventoryId);
            txtInventoryId.Text = ent.Id.ToString();
            txtInventoryCode.Text = ent.Code;
            cmbProductName.Text = ent.Item;
            txtDeliveryNo.Text = ent.DeliveryNo;
            txtRecepitNo.Text = ent.ReceiptNo;
            txtQtyStock.Text = ent.Qty.ToString(CultureInfo.InvariantCulture);
            cmbBranchName.Text = ent.Branch;
            txtLastCost.Text = ent.LastCost.ToString(CultureInfo.InvariantCulture);
            txtOnOrder.Text = ent.OnOrder.ToString();
            dkpDeliveryDate.Value = ent.Purchase;
            dkpPurchaseDate.Value = ent.RefDate;
            cmbProductWarranty.Text = ent.Warranty;
            cmbProductStatus.Text = ent.Status;
        }
        private void gridInventory_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
        }
        private void gridInventory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        private void cmbSAT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }
        private void GbPersonal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbSAT_KeyDown(object sender, KeyEventArgs e)
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
                    cmbProductWarranty.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product status must not be empty!", Messages.GasulPos);
                    cmbProductStatus.Focus();
                    cmbProductStatus.BackColor = Color.Yellow;
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
                    var repository = new Repository<Depot>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.DeliveryNo == deliveryNo)
                        .Select(x => x.DepotId)
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
                    var repository = new Repository<Depot>(unWork);
                    return repository.SelectAll(Query.SelectAllDepot)
                        .Where(x => x.ReceiptNo == receiptNo)
                        .Select(x => x.DepotId)
                        .Count();
                }
                catch (Exception)
                {
                    return 0;
                }

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
        private static ViewDepot ShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewDepot>(unWork);
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
        private static IEnumerable<ViewDepot> RebindInventory(DateTime refDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewDepot>(unWork);
                    return repository.SelectAll(Config.Query.SelectAllDepot)
                        .Where(x => x.RefDate==refDate)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }

        private static string GetLastDeliveryNo()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewDepot>(unWork);
                    return repository.SelectAll(Config.Query.SelectAllDeliv)
                           .Select(x => x.DeliveryNo).FirstOrDefault();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    return null;
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

        private void txtDEL_Leave(object sender, EventArgs e)
        {

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

                    txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                    lblPRZ.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                    cmbProductName.BackColor = Color.Yellow;
                    cmbProductName.Focus();
                }
            }
        }

        private void cmbProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbProductName.Size = new Size(422, 29);
        }

        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            cmbProductName.Size = new Size(269, 29);
            if (txtProductBarcode.Text.Length > 0)
            {
                txtProductBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                lblPRZ.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);

            }
        }

        private void txtDeliveryNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtDeliveryNo.Text.Length;
                if (len > 0)
                {
                    var inpt = string.Format(txtDeliveryNo.Text).ToUpper();
                    txtDeliveryNo.BackColor = Color.White;
                    txtRecepitNo.Focus();
                    txtRecepitNo.BackColor = Color.Yellow;
                    txtDeliveryNo.Text = inpt;
                }
                else
                {
                    txtDeliveryNo.BackColor = Color.White;
                    txtDeliveryNo.Text = Constant.DefaultNone;
                    txtRecepitNo.BackColor = Color.Yellow;
                    txtRecepitNo.Focus();
                }

            }
        }

        private void txtDeliveryNo_Leave(object sender, EventArgs e)
        {
            var len = txtDeliveryNo.Text.Length;
            if (len <= 0) return;
            txtRecepitNo.Text = txtDeliveryNo.Text.Trim(' ');
        }

        private void txtReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtRecepitNo.Text.Length;
                if (len > 0)
                {
                    var inpt = string.Format(txtRecepitNo.Text).ToUpper();
                    txtRecepitNo.Text = inpt;
                    txtRecepitNo.BackColor = Color.White;
                    txtQtyStock.BackColor = Color.Yellow;
                    txtQtyStock.Focus();
                }
                else
                {
                    txtRecepitNo.Text = Constant.DefaultNone;
                    txtRecepitNo.BackColor = Color.White;
                    txtQtyStock.BackColor = Color.Yellow;
                    txtQtyStock.Focus();
                }
            }
        }

        private void txtQtyStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtQtyStock.Text.Length;
                if (len > 0)
                {
                    txtQtyStock.BackColor = Color.White;
                    cmbBranchName.BackColor = Color.Yellow;
                    cmbBranchName.Focus();
                }
                else
                {
                    txtQtyStock.Text = @"0";
                    txtQtyStock.BackColor = Color.White;
                    cmbBranchName.BackColor = Color.Yellow;
                    cmbBranchName.Focus();
                }
            }
        }

        private void txtQtyStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtQtyStock.Focus();
                txtQtyStock.BackColor = Color.Yellow;
            }
            else
            {
                txtQtyStock.BackColor = Color.White;
            }
        }

        private void cmbBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputCaseLeave(cmbBranchName, txtLastCost, "Branch Name",
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
                    dkpDeliveryDate.Focus();
                }
                else
                {
                    txtOnOrder.Text = @"0";
                    txtOnOrder.BackColor = Color.White;
                    dkpDeliveryDate.Focus();
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

        private void dkpDeliveryDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpPurchaseDate.Focus();
            }
        }

        private void dkpPurchaseDate_KeyDown(object sender, KeyEventArgs e)
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
                    cmbProductWarranty.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Product status must not be empty!", Messages.GasulPos);
                    cmbProductStatus.Focus();
                    cmbProductStatus.BackColor = Color.Yellow;
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
                InputManipulation.InputCaseLeave(cmbProductWarranty, txtProductBarcode, "Product Warranty",
                    Messages.TitleInventory);
            }
        }

        private void txtProductBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtProductBarcode.Text.Length;
                if (len > 0)
                {
                    txtProductBarcode.BackColor = Color.White;
                    bntSave.Focus();
                }
                else
                {
                    txtProductBarcode.BackColor = Color.Yellow;
                    txtProductBarcode.Focus();
                    PopupNotification.PopUpMessages(0, "Product Barcode must not be empty!", Messages.GasulPos);
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
            ButClr();
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

        private static string GetLastCode()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewDepot>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllDepot)
                              orderby b.Id descending
                              select b.Code).Take(1).SingleOrDefault();
                if (result != null) return result;
                result = Query.DefaultCode;
                return result;
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
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }
    }
}
