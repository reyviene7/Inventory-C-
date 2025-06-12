using DevExpress.XtraGrid.Views.Grid;
using Inventory.Class;
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
        private IEnumerable<ViewWarehouseDelivery> listWarehouseProduct;
        private IEnumerable<ViewProducts> listProducts;
        private IEnumerable<ViewSalesPart> listSalesPart;
        private IEnumerable<ViewImageProduct> imgList;
        private int InventoryId;

        private bool _extInvent;
        public bool ExiInven
        {
            get { return _extInvent; }
            set
            {
                _extInvent = value;
                if (_extInvent)
                    Close();
                FirmMain main = new FirmMain(_userId, _usrTyp, _userName);
                main.Show();
            }
        }
        public int BranchId
        {
            get { return _branchId; }
            set
            {
                _branchId = value;

                _branch = FetchUtils.getBranchName(_branchId);
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
            _userName = userName;
            if (_usrTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);
                this.DialogResult = DialogResult.Cancel;

                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }
        private void FrmInventory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            RightOptions.Start();
            Options.Start();
            bindRefreshed();
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

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if (que <= 0) return;
            var log = new FirmLogin();
            log.Show();
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
            bindRefreshed();
            ButtonClr();
            InputDisb();
            InputWhit();
            InputWhitDel();
            InputWhitSales();
            InputClea();
            gCON.Enabled = true;
            cmbProductName.DataBindings.Clear();
            cmbBranchName.DataBindings.Clear();
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
            ImageProduct.DataBindings.Clear();
            ImageProduct.Image = null;
            ImageSales.DataBindings.Clear();
            ImageSales.Image = null;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputDimGDel();
            InputDimGSales();
            InputClea();
            gCON.Enabled = true;
            cmbProductName.DataBindings.Clear();
            imgPreview.DataBindings.Clear();
            imgPreview.Image = null;
            ImageProduct.DataBindings.Clear();
            ImageProduct.Image = null;
            ImageSales.DataBindings.Clear();
            ImageSales.Image = null;
        }
        #endregion
        private bool IsProductInInventory(string productName)
        {
            return listInventory.Any(x => x.product_name == productName);
        }
        private void BindFilteredProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();

                var productRepository = new Repository<ViewWarehouseDelivery>(unWork);

                // Fetch all records from view_warehouse_delivery
                var allProducts = productRepository.SelectAll(Query.AllWarehouseProduct)
                                                   .Where(x => !string.IsNullOrEmpty(x.product_name))
                                                   .Select(x => x.product_name)
                                                   .Distinct()
                                                   .OrderBy(name => name)
                                                   .ToList();

                unWork.Commit(); // Don't forget to commit if needed

                // Bind the results to the ComboBox
                cmbProductName.DataSource = null;
                cmbProductName.DataSource = allProducts;

                if (allProducts.Any())
                {
                    cmbProductName.SelectedIndex = 0;
                    cmbProductName.Focus();
                }
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
            catch(Exception ex)
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
            txtDeliveredQty.BackColor = Color.White;
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
            cmbProductStatus.Enabled = false;
            txtDelDeliveryID.Enabled = false;
            txtDelBarcode.Enabled = false;
            cmbDelProductName.Enabled = false;
            txtDelDeliveryNo.Enabled = false;
            txtDelDeliveryQty.Enabled = false;
            txtDelQty.Enabled = false;
            cmbDelBranch.Enabled = false;
            txtDelLastCost.Enabled = false;
            txtDelCostPerItem.Enabled = false;
            txtDelTotal.Enabled = false;
            cmbDelStatus.Enabled = false;
            txtDelReceiptNo.Enabled = false;
            txtDelRemarks.Enabled = false;
            cmbDelDeliveryStatus.Enabled = false;
            dkpDelDeliveryDate.Enabled = false;
            dkpDelUpdate.Enabled = false;
            txtSalesId.Enabled = false;
            txtSalesInvoice.Enabled = false;
            txtSalesBarcode.Enabled = false;
            cmbSalesProductName.Enabled = false;
            txtSalesQty.Enabled = false;
            txtSalesPrice.Enabled = false;
            txtSalesDiscount.Enabled = false;
            txtSalesGross.Enabled = false;
            txtSalesNet.Enabled = false;
            txtSalesCustomer.Enabled = false;
            cmbSalesBranch.Enabled = false;
            cmbSalesStatus.Enabled = false;
            dkpSalesDate.Enabled = false;
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
            txtDelDeliveryID.Clear();
            txtDelBarcode.Clear();
            cmbDelProductName.Text = "";
            txtDelDeliveryNo.Clear();
            txtDelDeliveryQty.Clear();
            txtDelQty.Clear();
            cmbDelBranch.Text = "";
            txtDelLastCost.Clear();
            txtDelCostPerItem.Clear();
            txtDelTotal.Clear();
            cmbDelStatus.Text = "";
            txtDelReceiptNo.Clear();
            txtDelRemarks.Clear();
            cmbDelDeliveryStatus.Text = "";
            dkpDelDeliveryDate.Value = DateTime.Now.Date;
            dkpDelUpdate.Value = DateTime.Now.Date;
            txtSalesId.Clear();
            txtSalesInvoice.Clear();
            txtSalesBarcode.Clear();
            cmbSalesProductName.Text = "";
            txtSalesQty.Clear();
            txtSalesPrice.Clear();
            txtSalesDiscount.Clear();
            txtSalesGross.Clear();
            txtSalesNet.Clear();
            txtSalesCustomer.Clear();
            cmbSalesBranch.Text = "";
            cmbSalesStatus.Text = "";
            dkpSalesDate.Value = DateTime.Now.Date;
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
        private void InputWhitDel()
        {
            txtDelDeliveryID.BackColor = Color.White;
            txtDelBarcode.BackColor = Color.White;
            cmbDelProductName.BackColor = Color.White;
            txtDelDeliveryNo.BackColor = Color.White;
            txtDelDeliveryQty.BackColor = Color.White;
            txtDelQty.BackColor = Color.White;
            cmbDelBranch.BackColor = Color.White;
            txtDelLastCost.BackColor = Color.White;
            txtDelCostPerItem.BackColor = Color.White;
            txtDelTotal.BackColor = Color.White;
            cmbDelStatus.BackColor = Color.White;
            txtDelReceiptNo.BackColor = Color.White;
            txtDelRemarks.BackColor = Color.White;
            cmbDelDeliveryStatus.BackColor = Color.White;
            dkpDelDeliveryDate.BackColor = Color.White;
            dkpDelUpdate.BackColor = Color.White;
        }
        private void InputDimGDel()
        {
            txtDelDeliveryID.BackColor = Color.DimGray;
            txtDelBarcode.BackColor = Color.DimGray;
            cmbDelProductName.BackColor = Color.DimGray;
            txtDelDeliveryNo.BackColor = Color.DimGray;
            txtDelDeliveryQty.BackColor = Color.DimGray;
            txtDelQty.BackColor = Color.DimGray;
            cmbDelBranch.BackColor = Color.DimGray;
            txtDelLastCost.BackColor = Color.DimGray;
            txtDelCostPerItem.BackColor = Color.DimGray;
            txtDelTotal.BackColor = Color.DimGray;
            cmbDelStatus.BackColor = Color.DimGray;
            txtDelReceiptNo.BackColor = Color.DimGray;
            txtDelRemarks.BackColor = Color.DimGray;
            cmbDelDeliveryStatus.BackColor = Color.DimGray;
            dkpDelDeliveryDate.BackColor = Color.DimGray;
            dkpDelUpdate.BackColor = Color.DimGray;
        }

        private void InputWhitSales()
        {
            txtSalesId.BackColor = Color.White;
            txtSalesInvoice.BackColor = Color.White;
            txtSalesBarcode.BackColor = Color.White;
            cmbSalesProductName.BackColor = Color.White;
            txtSalesQty.BackColor = Color.White;
            txtSalesPrice.BackColor = Color.White;
            txtSalesDiscount.BackColor = Color.White;
            txtSalesGross.BackColor = Color.White;
            txtSalesNet.BackColor = Color.White;
            txtSalesCustomer.BackColor = Color.White;
            cmbSalesBranch.BackColor = Color.White;
            cmbSalesStatus.BackColor = Color.White;
            dkpSalesDate.BackColor = Color.White;
        }
        private void InputDimGSales()
        {
            txtSalesId.BackColor = Color.DimGray;
            txtSalesInvoice.BackColor = Color.DimGray;
            txtSalesBarcode.BackColor = Color.DimGray;
            cmbSalesProductName.BackColor = Color.DimGray;
            txtSalesQty.BackColor = Color.DimGray;
            txtSalesPrice.BackColor = Color.DimGray;
            txtSalesDiscount.BackColor = Color.DimGray;
            txtSalesGross.BackColor = Color.DimGray;
            txtSalesNet.BackColor = Color.DimGray;
            txtSalesCustomer.BackColor = Color.DimGray;
            cmbSalesBranch.BackColor = Color.DimGray;
            cmbSalesStatus.BackColor = Color.DimGray;
            dkpSalesDate.BackColor = Color.DimGray;
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
                        product_id = FetchUtils.getProductId(cmbProductName.Text),
                        delivery_code = txtDeliveryNumber.Text,
                        quantity = int.Parse(txtQty.Text),
                        branch_id = FetchUtils.getBranchId(cmbBranchName.Text),
                        last_price_cost = Convert.ToDecimal(txtLastCost.Text),
                        inventory_date = dkpInventoryDate.Value.Date,
                        status_id = FetchUtils.getProductStatusId(cmbProductStatus.Text),
                        user_id = 3,
                        updatedOn = DateTime.Now
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
                    que.product_id = FetchUtils.getProductId(cmbProductName.Text);
                    que.delivery_code = txtDeliveryNumber.Text;
                    que.quantity = Convert.ToInt32(txtQty.Text);
                    que.branch_id = FetchUtils.getBranchId(cmbBranchName.Text);
                    que.last_price_cost = Convert.ToDecimal(txtLastCost.Text);
                    que.inventory_date = dkpInventoryDate.Value.Date;
                    que.status_id = FetchUtils.getProductStatusId(cmbProductStatus.Text);
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

        private void GridProducts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridProducts.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        int DeliveryId = Convert.ToInt32(id);
                        var ent = searchProductId(DeliveryId);
                        var barcode = ent.product_code;
                        txtDelDeliveryID.Text = ent.delivery_id.ToString();
                        txtDelBarcode.Text = barcode;
                        cmbDelProductName.Text = ent.product_name;
                        txtDelDeliveryNo.Text = ent.delivery_code;
                        txtDelDeliveryQty.Text = ent.delivery_qty.ToString(CultureInfo.InvariantCulture);
                        txtDelQty.Text = ent.quantity_in_stock.ToString(CultureInfo.InvariantCulture);
                        cmbDelBranch.Text = ent.branch_details;
                        txtDelLastCost.Text = ent.last_cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtDelCostPerItem.Text = ent.cost_per_unit.ToString(CultureInfo.InvariantCulture);
                        txtDelTotal.Text = ent.total_value.ToString(CultureInfo.InvariantCulture);
                        cmbDelStatus.Text = ent.status_details;
                        txtDelReceiptNo.Text = ent.receipt_number;
                        txtDelRemarks.Text = ent.remarks;
                        cmbDelDeliveryStatus.Text = ent.delivery_status;
                        dkpDelDeliveryDate.Value = ent.delivery_date;
                        dkpDelUpdate.Value = ent.update_on;

                        var img = searchProductImg(barcode);
                        var imgLocation = img?.img_location;
                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            ImageProduct.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            ImageProduct.ImageLocation = location;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void GridSales_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || view.RowCount == 0)
                return;

            try
            {
                var idValue = view.GetFocusedRowCellValue("ID");
                if (idValue == null || idValue == DBNull.Value)
                    return;

                int salesId = Convert.ToInt32(idValue);
                var salesPart = searchSalesId(salesId);
                var barcode = salesPart.barcode;
                var img = searchProductImg(barcode);
                var imgLocation = img?.img_location;

                if (img == null || string.IsNullOrEmpty(imgLocation))
                {
                    ImageSales.ImageLocation = ConstantUtils.defaultImgEmpty;
                }
                else
                {
                    var location = ConstantUtils.defaultImgLocation + imgLocation;
                    ImageSales.ImageLocation = location;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (gridProducts.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        int SalesId = Convert.ToInt32(id);
                        var ent = searchSalesId(SalesId);
                        var barcode = ent.barcode;
                        txtSalesId.Text = ent.id.ToString();
                        txtSalesInvoice.Text = ent.invoice;
                        txtSalesBarcode.Text = barcode;
                        cmbSalesProductName.Text = ent.item;
                        txtSalesQty.Text = ent.qty.ToString(CultureInfo.InvariantCulture);
                        txtSalesPrice.Text = ent.price.ToString(CultureInfo.InvariantCulture);
                        txtSalesDiscount.Text = ent.discount.ToString(CultureInfo.InvariantCulture);
                        txtSalesGross.Text = ent.gross.ToString(CultureInfo.InvariantCulture);
                        txtSalesNet.Text = ent.net.ToString(CultureInfo.InvariantCulture);
                        txtSalesCustomer.Text = ent.customer;
                        cmbSalesBranch.Text = ent.branch;
                        cmbSalesStatus.Text = ent.status;
                        dkpSalesDate.Value = ent.date;

                        var img = searchProductImg(barcode);
                        var imgLocation = img?.img_location;
                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            ImageSales.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;

                            ImageSales.ImageLocation = location;
                        }
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
        private ViewWarehouseDelivery searchProductId(int id)
        {
            return listWarehouseProduct.FirstOrDefault(Product => Product.delivery_id == id);
        }
        private ViewSalesPart searchSalesId(int id)
        {
            return listSalesPart.FirstOrDefault(Sales => Sales.id == id);
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return imgList.FirstOrDefault(img => img.image_code == param);
        }
        private void bindRefreshed ()
        {
            listInventory = EnumerableUtils.getInventory();
            listWarehouseProduct = EnumerableUtils.getWarehouseProduct();
            listProducts = EnumerableUtils.getProductList();
            listSalesPart = EnumerableUtils.getSalesParticular();
            imgList = EnumerableUtils.getImgProductList();
            BindInventory();
            BindWarehouseProduct();
            BindSalesPart();
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
        private void BindWarehouseProduct()
        {
            gridCtrlProducts.Update();
            try
            {
                var list = listWarehouseProduct.Select(x => new
                {
                    ID = x.delivery_id,
                    BARCODE = x.product_code,
                    PRODUCT = x.product_name,
                    TRADE = x.cost_per_unit,
                    RETAIL = x.last_cost_per_unit
                }).ToList();

                gridCtrlProducts.DataSource = null;
                gridCtrlProducts.DataSource = list;

                gridProducts.Columns[0].Width = 80;
                gridProducts.Columns[1].Width = 180;
                gridProducts.Columns[2].Width = 580;
                gridProducts.Columns[3].Width = 125;
                gridProducts.Columns[4].Width = 125;
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void BindSalesPart()
        {
            gridCtrlSales.Update();
            try
            {
                var list = listSalesPart.Select(x => new
                {
                    ID = x.id,
                    INVOICE = x.invoice,
                    BARCODE = x.barcode,
                    PRODUCT = x.item,
                    QUANTITY = x.qty,  
                    UNITPRICE = x.price,
                    DISCOUNT = x.discount,
                    GROSS = x.gross,
                    NET = x.net,
                    CUSTOMER = x.customer,
                    BRANCH = x.branch,
                    DATE = x.date,
                }).ToList();

                gridCtrlSales.DataSource = null; 
                gridCtrlSales.DataSource = list;

                gridSales.Columns[0].Width = 40;
                gridSales.Columns[1].Width = 50;
                gridSales.Columns[2].Width = 100;
                gridSales.Columns[3].Width = 340;
                gridSales.Columns[4].Width = 50;
                gridSales.Columns[5].Width = 50;
                gridSales.Columns[6].Width = 50;
                gridSales.Columns[7].Width = 50;
                gridSales.Columns[8].Width = 50;
                gridSales.Columns[9].Width = 110;
                gridSales.Columns[10].Width = 90;
                gridSales.Columns[11].Width = 100;
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
            }
        }
        private void gridInventory_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
            bntCancel.Enabled = true;
        }

        private void GridProducts_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhitDel();
            bntCancel.Enabled = true;
        }

        private void GridSales_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhitSales();
            bntCancel.Enabled = true;
        }

        private void gridInventory_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }

        private void GridProducts_LostFocus(object sender, EventArgs e)
        {
            InputDimGDel();
        }

        private void GridSales_LostFocus(object sender, EventArgs e)
        {
            InputDimGSales();
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }

        private void FrmInventory_MouseMove(object sender, MouseEventArgs e)
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

        private void CmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProductName = cmbProductName.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedProductName))
            {
                var matchedProduct = listWarehouseProduct
                    .FirstOrDefault(x => x.product_name == selectedProductName);

                if (matchedProduct != null)
                {
                    var barcode = matchedProduct.product_code;
                    var img = searchProductImg(barcode);

                    var imgLocation = img?.img_location;
                    if (string.IsNullOrEmpty(imgLocation))
                    {
                        imgPreview.ImageLocation = ConstantUtils.defaultImgEmpty;
                    }
                    else
                    {
                        imgPreview.ImageLocation = ConstantUtils.defaultImgLocation + imgLocation;
                    }

                    lblPrice.Text = matchedProduct.last_cost_per_unit.ToString("N2");

                    txtDeliveredQty.Text = matchedProduct.delivery_qty.ToString();
                }
                else
                {
                    imgPreview.ImageLocation = ConstantUtils.defaultImgEmpty;
                    lblPrice.Text = "0.00";
                    txtDeliveredQty.Text = "0";
                }
            }
        }

        private void txtLastCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbProductStatus.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                cmbBranchName.Focus();
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
                InputManipulation.InputCaseLeave(cmbProductStatus, txtBarcode, "Product Status",
                    Messages.TitleInventory);
            }
        }
    }
}
