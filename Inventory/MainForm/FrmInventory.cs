using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Query = ServeAll.Core.Queries.Query;


namespace Inventory.MainForm
{
    public partial class FrmInventory : Form
    {

        private int _branchId;
        private string _branch;
        private readonly int _userId;
        private readonly int _usrTyp;
        private readonly string _userName;
        private IEnumerable<ViewInventory> listInventory;
        private IEnumerable<ViewImageProduct> imgList;
        private int InventoryId = 0;

        private bool _extInvent;
        public bool ExiInven
        {
            get { return _extInvent; }
            set
            {
                _extInvent = value;
                if (_extInvent)
                    Close();
                var main = new FirmMain(_userId, _usrTyp, _userName);
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
                cmbBranchName.Text = _branch;
                BindProductList(_branch);
            }
        }
        public string DeliveryBranch
        {
            get { return _branch; }
            set
            {
                _branch = value;
                if (_branch.Length > 0)
                {
                    BindProductList(_branch);
                }
            }
        }

        private bool _add, _edt, _del;
        public FirmMain Main { get; set; }
        public FrmInventory(int userId, int usrTyp, string userName)
        {
            _userId = userId;
            _usrTyp = usrTyp;
            InitializeComponent();
            _userName = userName;   
        }
        private void FrmInventory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            RightOptions.Start();
            listInventory = EnumerableUtils.getInventory();
            imgList = EnumerableUtils.getImgProductList();
            BindInventory();
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
            ButClr();
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
                    "Are you sure you want to Delete Inventory: " + cmbProductName.Text.Trim(' ') + " " + "?", "Inventory Details");
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
        #region ButtonCRUD
        private void ButAdd()
        {
            ButtonAdd();
            InputEnab();
            InputWhit();
            InputClea();
            GenerateInventoryId();
            CreateNewInventoryRecord();
            BindInventory();
            BindProducts();
            BindBranch();
            BindProductStatus();
            BindFilteredProducts();

            _add = true;
            _edt = false;
            _del = false;
            gCON.Enabled = false;
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
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
                if (IsProductInInventory(cmbProductName.Text))
                {
                    PopupNotification.PopUpMessages(0, "Product Name: " + cmbProductName.Text.Trim() + " already exists in the inventory.", Messages.TitleFailedInsert);
                }
                DataInsert();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList(_branch);
                BindInventory();
            }
            if (_add == false && _edt && _del == false)
            {

                DataUpdate();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList(_branch);
                BindInventory();
            }
            if (_add == false && _edt == false && _del)
            {

                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
                BindProductList(_branch);
                BindInventory();

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
        private bool IsProductInInventory(string productName)
        {
            return listInventory.Any(x => x.product_name == productName);
        }
        private void BindFilteredProducts()
        {
            List<string> productNames;
            List<string> inventoryProductNames;

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var productRepository = new Repository<Products>(unWork);
                productNames = productRepository.SelectAll(Query.AllViewProducts)
                                                .Select(x => x.product_name)
                                                .Distinct()
                                                .ToList();
            }

            inventoryProductNames = listInventory.Select(x => x.product_name).Distinct().ToList();
            var filteredProductNames = productNames.Except(inventoryProductNames).ToList();
            cmbProductName.DataBindings.Clear();
            cmbProductName.DataSource = filteredProductNames;

            if (filteredProductNames.Any())
            {
                cmbProductName.Focus();
            }
        }

        private void BindProductList(string branchId)
        {
            gCON.Update();
            try
            {
                gCON.DataBindings.Clear();
                gCON.DataSource = null;
                gCON.DataSource = RebindInventory(branchId);
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
        private void BindProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Products>(unWork);
                var query = repository.SelectAll(Query.AllViewProducts)
                                      .Select(x => x.product_name)
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
                var query = repository.SelectAll(Query.AllBranch).Select(x => x.branch_details).Distinct().ToList();
                cmbBranchName.DataBindings.Clear();
                cmbBranchName.DataSource = query;
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
                    return query.branch_details;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Inventory Details");
                    return null;
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
        /*private static int GetWarrantyId(string input)
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
        }*/
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
        private static IEnumerable<ViewInventory> RebindInventory(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.SelectAll(Query.AllInventory)
                        .Where(x => x.branch_details == branch)
                        .ToList();
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, Messages.ErrorInternal, Messages.TitleInventory);
                    throw;
                }
            }
        }
        private void InputWhit()
        {
            txtInventoryId.BackColor = Color.White;
            txtInventoryCode.BackColor = Color.White;
            cmbProductName.BackColor = Color.White;
            txtDeliveryNumber.BackColor = Color.White;
            txtQty.BackColor = Color.White;
            cmbBranchName.BackColor = Color.White;
            txtLastCost.BackColor = Color.White;
            dkpInventoryDate.BackColor = Color.White;
            cmbProductStatus.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtInventoryId.Enabled = false;
            txtInventoryCode.Enabled = true;
            cmbProductName.Enabled = true;
            txtDeliveryNumber.Enabled = true;
            txtQty.Enabled = true;
            cmbBranchName.Enabled = true;
            txtLastCost.Enabled = true;
            dkpInventoryDate.Enabled = true;
            cmbProductStatus.Enabled = true;
            txtInventoryCode.Focus();
        }
        private void InputDisb()
        {
            txtInventoryId.Enabled = false;
            txtInventoryCode.Enabled = false;
            cmbProductName.Enabled = false;
            txtDeliveryNumber.Enabled = false;
            txtQty.Enabled = false;
            cmbBranchName.Enabled = false;
            txtLastCost.Enabled = false;
            dkpInventoryDate.Enabled = false;
            cmbProductStatus.Enabled = false;
        }
        private void InputClea()
        {
            txtInventoryId.Clear();
            txtInventoryCode.Clear();
            cmbProductName.Text = "";
            txtDeliveryNumber.Clear();
            txtQty.Clear();
            cmbBranchName.Text = "";
            txtLastCost.Clear();
            dkpInventoryDate.Value = DateTime.Now.Date;
            cmbProductStatus.Text = "";
        }
        private void InputDimG()
        {
            txtInventoryId.BackColor = Color.DimGray;
            txtInventoryCode.BackColor = Color.DimGray;
            cmbProductName.BackColor = Color.DimGray;
            txtDeliveryNumber.BackColor = Color.DimGray;
            txtQty.BackColor = Color.DimGray;
            cmbBranchName.BackColor = Color.DimGray;
            txtLastCost.BackColor = Color.DimGray;
            dkpInventoryDate.BackColor = Color.DimGray;
            cmbProductStatus.BackColor = Color.DimGray;
        }

        /* private void GenerateCode()
        {
            var lastProductId = FetchUtils.GetLastId();
            var alphaNumeric = new GenerateAlpaNum("INV", 3, lastProductId);
            alphaNumeric.Increment();
            txtInventoryCode.Text = alphaNumeric.ToString();
        }*/
        private void GenerateInventoryId()
        {
            int lastInventoryId = listInventory.Any() ? listInventory.Max(x => x.inventory_id) : 0;
            int newInventoryId = lastInventoryId + 1;

            txtInventoryId.Text = newInventoryId.ToString();
            txtInventoryId.Focus();
        }
        private void GenerateInventoryCode()
        {
            var lastInventoryCode = FetchUtils.GetLastInventoryCode();
            int lastInventoryNumber;

            if (string.IsNullOrEmpty(lastInventoryCode) || !int.TryParse(lastInventoryCode.Replace("INV", ""), out lastInventoryNumber))
            {
                lastInventoryNumber = 0;
            }

            var alphaNumeric = new GenerateAlpaInv("INV", 3, lastInventoryNumber);
            alphaNumeric.Increment();
            txtInventoryCode.Text = alphaNumeric.ToString();
            txtInventoryCode.Focus();
        }

        private void GenerateDeliveryCode()
        {
            var lastDeliveryCode = FetchUtils.GetLastDeliveryCode();
            int lastDeliveryNumber;

            if (string.IsNullOrEmpty(lastDeliveryCode) || !int.TryParse(lastDeliveryCode.Replace("DC", ""), out lastDeliveryNumber))
            {
                lastDeliveryNumber = 0;
            }

            var alphaNumeric = new GenerateAlpaNum("DC", 3, lastDeliveryNumber);
            alphaNumeric.Increment();
            txtDeliveryNumber.Text = alphaNumeric.ToString();
            txtDeliveryNumber.Focus();
        }
        private void CreateNewInventoryRecord()
        {
            GenerateInventoryCode();
            GenerateDeliveryCode();
        }
        private void DataInsert()
        {
            if (string.IsNullOrWhiteSpace(txtInventoryCode.Text) ||
            string.IsNullOrWhiteSpace(cmbProductName.Text) ||
            string.IsNullOrWhiteSpace(txtDeliveryNumber.Text) ||
            string.IsNullOrWhiteSpace(txtQty.Text) ||
            string.IsNullOrWhiteSpace(cmbBranchName.Text) ||
            string.IsNullOrWhiteSpace(txtLastCost.Text) ||
            string.IsNullOrWhiteSpace(cmbProductStatus.Text))
            {
                PopupNotification.PopUpMessages(0, "Please fill in all required fields.", "Incomplete Input");
                return;
            }
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    posWET.ShowWaitForm();
                    var repository = new Repository<ServeAll.Core.Entities.Inventory>(unWork);
                  
                    ServeAll.Core.Entities.Inventory inventory = new ServeAll.Core.Entities.Inventory
                    {
                        inventory_code = txtInventoryCode.Text,
                        product_id = GetProductId(cmbProductName.Text),
                        delivery_code = txtDeliveryNumber.Text,
                        quantity = Convert.ToInt32(txtQty.Text),
                        branch_id = GetBranchId(cmbBranchName.Text),
                        last_price_cost = Convert.ToDecimal(txtLastCost.Text),
                        inventory_date = dkpInventoryDate.Value.Date,
                        status_id = GetProductStatus(cmbProductStatus.Text),
                        user_id = 3
                    };
                    var result = repository.Add(inventory);
                    if (result > 0)
                    {
                        posWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                        unWork.Commit();
                        listInventory = EnumerableUtils.getInventory(); 
                        BindInventory();
                    }
                }
                catch (Exception ex)
                {
                    posWET.CloseWaitForm();
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
                    posWET.ShowWaitForm();
                    var proId = Convert.ToInt32(txtInventoryId.Text);
                    var repository = new Repository<ServeAll.Core.Entities.Inventory>(unWork);
                    var que = repository.Id(proId);
                    que.inventory_code = txtInventoryCode.Text;
                    que.product_id = GetProductId(cmbProductName.Text);
                    que.delivery_code = txtDeliveryNumber.Text;
                    que.quantity = Convert.ToInt32(txtQty.Text);
                    que.branch_id = GetBranchId(cmbBranchName.Text);
                    que.last_price_cost = Convert.ToDecimal(txtLastCost.Text);
                    que.inventory_date = dkpInventoryDate.Value.Date;
                    que.status_id = GetProductStatus(cmbProductStatus.Text);
                    var result = repository.Update(que);
                    if (result)
                    {
                        posWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                            Messages.TitleSuccessUpdate);
                        unWork.Commit();
                        listInventory = EnumerableUtils.getInventory();
                        BindInventory();
                    }
                    else
                    {
                        posWET.CloseWaitForm();
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
                    posWET.ShowWaitForm();
                    var proId = Convert.ToInt32(txtInventoryId.Text);
                    var repository = new Repository<ServeAll.Core.Entities.Inventory>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        posWET.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,
                            "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessDelete,
                            Messages.TitleSuccessDelete);
                        unWork.Commit();
                        listInventory = EnumerableUtils.getInventory();
                        BindInventory();
                    }
                    else
                    {
                        posWET.CloseWaitForm();
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
            if (cmbProductName.Text.Length <= 0) return;
            var imgId = GetProductImgId(cmbProductName.Text);

        }
        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridInventory.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        InventoryId = int.Parse(id);
                        var ent = searchInventoryId(InventoryId);
                        var barcode = ent.product_code;
                        txtInventoryId.Text = ent.inventory_id.ToString();
                        txtInventoryCode.Text = ent.inventory_code;
                        cmbProductName.Text = ent.product_name;
                        txtDeliveryNumber.Text = ent.delivery_code;
                        txtQty.Text = ent.quantity.ToString(CultureInfo.InvariantCulture);
                        cmbBranchName.Text = ent.branch_details;
                        txtLastCost.Text = ent.retail_price.ToString(CultureInfo.InvariantCulture);
                        dkpInventoryDate.Value = ent.inventory_date;
                        cmbProductStatus.Text = ent.status;
                        txtBarcode.Text = barcode;
                        lblPrice.Text = ent.retail_price.ToString(CultureInfo.InvariantCulture);

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        private ViewInventory searchInventoryId(int id)
        {
            return listInventory.FirstOrDefault(Inventory => Inventory.inventory_id == id);
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }

        private void BindInventory()
        {
            gCON.Update();
            try
            {
                var list = listInventory.Select(x => new
                {
                    Id = x.inventory_id,
                    InveCode = x.inventory_code,
                    Item = x.product_name,
                    DelCode = x.delivery_code,
                    Qty = x.quantity,
                    Branch = x.branch_details,
                    Retail = x.retail_price,
                    InveDate = x.inventory_date,
                    Status = x.status
                });

                gCON.DataBindings.Clear();
                gCON.DataSource = list;


                gridInventory.Columns[0].Width = 40;
                gridInventory.Columns[1].Width = 90;
                gridInventory.Columns[2].Width = 290;
                gridInventory.Columns[3].Width = 100;
                gridInventory.Columns[4].Width = 100;
            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void gridInventory_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
        }
        private void gridInventory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }
        //Verify Numeric
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
        private void cmbSAT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }
        private void txtQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtQty.Focus();
                txtQty.BackColor = Color.Yellow;
            }
            else
            {
                txtQty.BackColor = Color.White;
            }
        }
        private void cmbNAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = cmbProductName.Text.Length;
            if (len > 0)
            {
                cmbProductName.BackColor = Color.White;
                txtDeliveryNumber.BackColor = Color.Yellow;
                txtDeliveryNumber.Focus();

                txtBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
                lblPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Product Name in inventory must not be empty!", Messages.GasulPos);
                cmbProductName.BackColor = Color.Yellow;
                cmbProductName.Focus();
            }
        }
        private void txtDEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputBoxLeave(txtDeliveryNumber, txtQty, "Inventory Delivery No.",
                Messages.TitleInventory);
            }
        }
        private void txtQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtQty.Text.Length;
            if (len > 0)
            {
                txtQty.BackColor = Color.White;
                cmbBranchName.BackColor = Color.Yellow;
                cmbBranchName.Focus();
            }
            else
            {
                txtQty.Text = @"0";
                txtQty.BackColor = Color.White;
                cmbBranchName.BackColor = Color.Yellow;
                cmbBranchName.Focus();
            }
        }
        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
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
        private void txtLST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var len = txtLastCost.Text.Length;
            if (len > 0)
            {
                txtLastCost.BackColor = Color.White;
                dkpInventoryDate.BackColor = Color.Yellow;
                dkpInventoryDate.Focus();
            }
            else
            {
                txtLastCost.Text = @"0";
                txtLastCost.BackColor = Color.White;
                dkpInventoryDate.BackColor = Color.Yellow;
                dkpInventoryDate.Focus();
            }
        }
        private void GbPersonal_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cmbNAM_Leave(object sender, EventArgs e)
        {
            cmbProductName.Size = new Size(269, 29);
            if (txtBarcode.Text.Length != 0) return;
            txtBarcode.Text = SearchBarcode(cmbProductName.Text).product_code;
            lblPrice.Text = SearchBarcode(cmbProductName.Text).retail_price.ToString(CultureInfo.InvariantCulture);
        }
        private void dkpDET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            cmbProductStatus.Focus();
        }
        private void cmbNAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbProductName.Size = new Size(422, 29);
        }

        private void FrmInventory_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void txtInventoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProductName.Focus();
            }
        }

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDeliveryNumber.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtInventoryCode.Focus();
            }
        }

        private void txtDeliveryNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbProductName.Focus();
            }
        }

        private void txtQty_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbBranchName.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtDeliveryNumber.Focus();
            }
        }

        private void cmbBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLastCost.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtQty.Focus();
            }
        }

        private void txtLastCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                cmbBranchName.Focus();
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
                InputManipulation.InputCaseLeave(cmbProductStatus, txtBarcode, "Product Status",
                Messages.TitleInventory);
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
    }
}
