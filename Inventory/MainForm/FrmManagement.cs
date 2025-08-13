using DevExpress.Xpo.Logger.Transport;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraReports.UI;
using Inventory.Config;
using Inventory.PopupForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using ServeAll.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inventory.MainForm
{
    public partial class FrmManagement : Form
    {
        private FirmMain _main;
        private bool _isCanceled;
        private IEnumerable<ViewWarehouseDelivery> _warehouse_delivery;
        private IEnumerable<ViewWarehouseDelivery> _viewDeliveries;
        private IEnumerable<WarehouseDelivery> _delivery;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;
        private IEnumerable<ViewReturnWarehouse> _return_list;
        private IEnumerable<ViewReturnWarehouse> warehouse_return;
        private readonly IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<ViewSalesPart> _sales_list;
        private IEnumerable<ViewAcceptedDelivery> _accepted_list;
        private IEnumerable<ViewSalesCredit> _credit_sales;
        private IEnumerable<ViewDailyExpenses> _daily_expenses;
        private IEnumerable<ViewInventory> _inventory_list;
        private IEnumerable<ViewProducts> _products;
        private Dictionary<int, ViewProducts> _productDict;
        private Dictionary<int, string> _statusDict;
        private Dictionary<int, string> _deliveryStatusDict;
        private readonly int _userId;
        private readonly int _userType;
        private readonly string _username;
        private int _received;
        public FrmManagement management { protected get; set; }
        Image imgProcessing = Image.FromFile(ConstantUtils.imgProcessing);
        Image imgCancelled = Image.FromFile(ConstantUtils.imgCancelled);
        Image imgCompleted = Image.FromFile(ConstantUtils.imgCompleted);
        public int received
        {
            get { return _received; }
            set
            {
                _received = value;
                if (_received == 1)
                {
                    splashScreen.ShowWaitForm();
                    _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
                    bindCardViewList();
                    splashScreen.CloseWaitForm();
                }
            }
        }
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public int branchId { get; set; }
        public string branch { get; set; }
        public FrmManagement(int userId, int userType, string username)
        {
            _userId = userId;
            _userType = userType;
            _username = username;
            if (_userType != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            _delivery = EnumerableUtils.getWarehouseDeliveries();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            _return_list = EnumerableUtils.getWareHouseReturnList();
            _sales_list = EnumerableUtils.getSalesParticular(branch);
            _accepted_list = EnumerableUtils.getAcceptedDelivery(branch);
            _credit_sales = EnumerableUtils.getCreditSales(branch);
            _daily_expenses = EnumerableUtils.getDailyExpenses();
            _inventory_list = EnumerableUtils.getLowQuantity();
            _imgList = EnumerableUtils.getImgProductList();
            _products = EnumerableUtils.getProductList();
            _viewDeliveries = EnumerableUtils.getViewWarehouseDeliveries();
            _productDict = _products.ToDictionary(p => p.product_id);
            _statusDict = EnumerableUtils.getAllStatuses().ToDictionary(s => s.status_id, s => s.status_details);
            _deliveryStatusDict = EnumerableUtils.getAllDeliveryStatuses().ToDictionary(s => s.delivery_status_id, s => s.delivery_status);
        }
        private void FrmManagement_Load(object sender, System.EventArgs e)
        {
            ShowBranch();
            bindCardViewList();
            barUser.EditValue = _username;
            barSoftware.EditValue = "Inventory System V1.0";
            barBranch.EditValue = branch;
            barDate.EditValue = DateTime.Now.Date.ToString();
            xInventory.SelectedTabPage = null;

            // Make the form fullscreen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None; // Optional: remove title bar and borders

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        private void barMainMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Main.Show();
            Close();
        }
        private ViewImageProduct searchProductImg(string param)
        {
            return _imgList.FirstOrDefault(img => img.image_code == param);
        }

        private void FrmManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                barWarehouse_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                barItemDelivery_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                barReturn_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F4)
            {
                barDailyExpenses_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                barSalesItem_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F6)
            {
                barCreditLine_ItemClick(sender, null);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.X)
            {
                barMainMenu_ItemClick(sender, null);
                e.Handled = true;
            }
        }

        private void ClearGrid()
        {
            gridCtrlPending.DataSource = null;
            gridCtrlPending.DataSource = "";
            cardPending.Columns.Clear();
        }

        private void clearAcceptedDelivery()
        {
            gridCtrlAccepted.DataSource = null;
            gridCtrlAccepted.DataSource = "";
            gridAccepted.Columns.Clear();
        }

        private void clearGridView()
        {
            gridCtrlPending.DataSource = null;
            gridCtrlPending.DataSource = "";
            grid.Columns.Clear();
        }

        private void clearGridSales()
        {
            gridCtrlSales.DataSource = null;
            gridCtrlSales.DataSource = "";
            gridSales.Columns.Clear();
        }
        private void clearGridReturn()
        {
            gridCtrlReturn.DataSource = null;
            gridCtrlReturn.DataSource = "";
            gridReturn.Columns.Clear();
        }
        private void clearGridCreditSales()
        {
            gridCtrlCredits.DataSource = null;
            gridCtrlCredits.DataSource = "";
            gridCredits.Columns.Clear();
        }
        private void clearGridDailyExpenses()
        {
            gridCtrlDaily.DataSource = null;
            gridCtrlDaily.DataSource = "";
            gridDaily.Columns.Clear();
        }
        private void clearGridLowQuantity()
        {
            gridCtrlQuantity.DataSource = null;
            gridCtrlQuantity.DataSource = "";
            gridQty.Columns.Clear();
        }

        private void bindDeliveryList(string branch)
        {
            clearAcceptedDelivery();
            int branchId = FetchUtils.getBranchId(branch);

            var list = _delivery
                .Where(p => p.branch_id == branchId)
                .Select(p =>
                {
                    var product = _products.FirstOrDefault(prod => prod.product_id == p.product_id);

                    return new
                    {
                        Id = p.delivery_id.ToString(),
                        Barcode = product?.product_code,   
                        Code = p.delivery_code,
                        Item = product?.product_name,
                        Branch = branch,
                        Price = "P" + p.item_price,
                        LastCost = "P" + p.last_cost_per_unit,
                        Quantity = p.delivery_qty.ToString(),
                        Status = FetchUtils.getStatusName(p.status_id),
                        Date = p.delivery_date,
                        Update = p.update_on,
                        Delivery = FetchUtils.getDeliveryStatusName(p.delivery_status_id)
                    };
                })
                .ToList();

            gridCtrlAccepted.DataSource = list;
            gridCtrlAccepted.Update();
        }

        private void bindCardViewList()
        {
            ClearGrid();
            var list = _warehouse_list.Select(p => new {
                    ID = p.inventory_id,
                    BARCODE = p.product_code,
                    SKU = p.sku,
                    QTY = p.quantity_in_stock,
                    LOCATION = p.location_code,
                    SUPPLIER = p.supplier_name,
                    COST = p.cost_per_unit,
                    PRICE = p.last_cost_per_unit,
                    TOTAL = p.total_value.ToString("N2"),
                    EXPIRE = p.expiration_date,
                    DATE = p.created_at,
                    STATUS = p.status_details
                });
            gridCtrlPending.DataSource = list;
            gridCtrlPending.Update();
        }

        private void bindWharehouseList()
        {
            clearGridView();
            var list = _warehouse_list.Select(p => new {
                Id = p.inventory_id,
                Barcode = p.product_code,
                SKU = p.sku,
                Qty = p.quantity_in_stock,
                ReQty = p.reorder_level,
                Location = p.location_code,
                Supplier = p.supplier_name,
                LStocked = p.last_stocked_date,
                LOrder = p.last_ordered_date,
                Expire = p.expiration_date,
                Price = p.cost_per_unit,
                LastCost = p.last_cost_per_unit,
                Total = p.total_value,
                Status = p.status_details,
                Created = p.created_at,
                Updated = p.updated_at
            }).ToList();
            gridCtrlWarehouse.DataSource = list;
            gridCtrlWarehouse.Update();

            if (gridWarehouseInventory.RowCount > 0)
                gridWarehouseInventory.Columns[0].Width = 40;
            gridWarehouseInventory.Columns[1].Width = 90;
            gridWarehouseInventory.Columns[2].Width = 65;
            gridWarehouseInventory.Columns[3].Width = 40;
            gridWarehouseInventory.Columns[4].Width = 40;
            gridWarehouseInventory.Columns[6].Width = 180;
        }

        private void bindSalesParticular()
        {
            try
            {
                clearGridSales();
                var list = _sales_list.Select(x => new
                {
                    Id = x.id,
                    Invoice = x.invoice,
                    Barcode = x.barcode,
                    Item = x.item,
                    Qty = x.qty,
                    UnitPrice = x.price,
                    Discount = x.discount,
                    Gross = x.gross,
                    NetSales = x.net,
                    Customer = x.customer,
                    Branch = x.branch,
                    Date = x.date,
                }).ToList();
                gridCtrlSales.DataSource = list;
                gridCtrlSales.Update();
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
                PopupNotification.PopUpMessages(0, ex.ToString(), "Sales Particular");
            }
        }
        private void bindReturnRefresh()
        {
            warehouse_return = EnumerableUtils.getEnumerableWareHouse(branch);
            bindReturnList();
        }
        private void bindReturnList()
        {
            clearGridReturn();
            var list = warehouse_return.Select(p => new {
                Id = p.return_id,
                Code = p.return_code,
                Barcode = p.product_code,
                Item = p.product_name,
                Quantity = p.return_quantity,
                Delivery = p.return_number,
                Branch = p.branch_details,  
                Destination = p.destination,
                Status = p.status,
                Remarks = p.remarks,
                UpdateOn = p.update_on
            }).ToList();
            gridCtrlReturn.DataSource = list;
            gridCtrlReturn.Update();
            gridReturn.Columns[0].Width = 40;
            gridReturn.Columns[1].Width = 70;
            gridReturn.Columns[2].Width = 120;
            gridReturn.Columns[3].Width = 400;
            gridReturn.Columns[4].Width = 40;
            gridReturn.Columns[5].Width = 70;
            gridReturn.Columns[6].Width = 80;
            gridReturn.Columns[7].Width = 80;
            gridReturn.Columns[8].Width = 100;
            gridReturn.Columns[9].Width = 100;
            gridReturn.Columns[10].Width = 100;
        }

        private void bindCreditSales()
        {
            clearGridCreditSales();
            var list = _credit_sales.Select(p => new {
                Id = "" + p.id,
                Invoice = p.invoice_id,
                Due = "P" + p.amount_due,
                AmountPaid = "P" + p.paid_amount,
                Balance = "P" + p.remaining_balance,
                Gross = "P" + p.gross,
                NetSales = "P" + p.net_sales,
                Customer = p.customer,
                Branch = p.branch,
                User = p.operators,
                Code = p.credit_code,
                CreditBalance = p.credit_balance,
                CreditLimit = p.credit_limit,
                Receipt = p.receipt,
                Date = p.credit_date
            }).ToList();
            gridCtrlCredits.DataSource = list;
            gridCtrlCredits.Update();
        }

        private void bindDailyExpenses()
        {
            try
            {
                clearGridDailyExpenses();
                var list = _daily_expenses.Select(x => new
                {
                    Id = x.expense_id,
                    Type = x.type_name,
                    Description = x.description,
                    Employee = x.full_name,
                    Amount = x.amount,
                    RelatedEntity = x.related_entity,
                    EntityId = x.entity_id,
                    Date = x.expense_date,
                }).ToList();
                gridCtrlDaily.DataSource = list;
                gridCtrlDaily.Update();
                gridDaily.Columns[0].Width = 40;
                gridDaily.Columns[1].Width = 150;
                gridDaily.Columns[2].Width = 400;
                gridDaily.Columns[3].Width = 200;
                gridDaily.Columns[4].Width = 100;
                gridDaily.Columns[5].Width = 200;
                gridDaily.Columns[6].Width = 50;
                gridDaily.Columns[7].Width = 100;
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.ToString(), "Daily Expenses");
            }
        }

        private void bindLowQuantity()
        {
            try
            {
                clearGridLowQuantity();
                var list = _inventory_list.Select(x => new
                {
                    Id = x.inventory_id,
                    Code = x.inventory_code,
                    Barcode = x.product_code,
                    Product = x.product_name,
                    Quantity = x.quantity,
                    Delivery = x.delivery_code,
                    Retail = x.retail_price,
                    Trade = x.trade_price,
                    Wholesale = x.wholesale,
                    LastPrice = x.last_price_cost,
                    Status = x.status,
                    Date = x.inventory_date
                }).ToList();
                gridCtrlQuantity.DataSource = list;
                gridCtrlQuantity.Update();
                gridQty.Columns[0].Width = 80;
                gridQty.Columns[1].Width = 100;
                gridQty.Columns[2].Width = 200;
                gridQty.Columns[3].Width = 400;
                gridQty.Columns[4].Width = 100;
                gridQty.Columns[5].Width = 100;
                gridQty.Columns[6].Width = 100;
                gridQty.Columns[7].Width = 100;
                gridQty.Columns[8].Width = 100;
                gridQty.Columns[9].Width = 100;
                gridQty.Columns[10].Width = 150;
                gridQty.Columns[11].Width = 150;
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.ToString(), "Daily Expenses");
            }
        }

        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (cardPending.RowCount > 0)
                try
                {
                    var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode").ToString();
                    var deliveryId = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (barcode.Length > 0)
                    {
                        /** dkpDelDeliveryDate.Text = w.delivery_date.ToString(CultureInfo.InvariantCulture);
                         txtDelRemarks.Text = w.remarks; */
                        txtBarcode.Text = barcode;
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
                            imgPreview.Refresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        /** Bar Nav button ***/
        private void barBackToMain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridInventory_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs e)
        {

        }

        private void cardInventory_CustomDrawCardField(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void cardInventory_CustomDrawCardFieldValue(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Delivery")
            {
                string status = e.CellValue?.ToString();
                Image imageToDraw = null;

                if (status == "Cancelled")
                {
                    imageToDraw = imgCancelled;
                }
                else if (status == "Processing")
                {
                    imageToDraw = imgProcessing;
                }
                else if (status == "Completed")
                {
                    imageToDraw = imgCompleted;
                }

                if (imageToDraw != null)
                {
                    int imageSize = 18;
                    Rectangle imageRect = new Rectangle(e.Bounds.X, e.Bounds.Y, imageSize, imageSize);
                    e.Graphics.DrawImage(imageToDraw, imageRect);
                    e.Handled = true;
                }
            }
        }

        private void ShowBranch()
        {
            var pop = new FirmPopBranches(_userId, _userType)
            {
                management = this,
                formManagement = true
            };
            pop.ShowDialog();
            _isCanceled = pop.DialogResult == DialogResult.Cancel;

            if (_isCanceled)
            {
                MessageBox.Show("Operation canceled by the user.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
                Close();
            }
        }

        private void barWarehouse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            bindWharehouseList();
            xInventory.SelectedTabPage = xtraInventory;
            splashScreen.CloseWaitForm();
        }

        private void barItemDelivery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            bindCardViewList();
            xInventory.SelectedTabPage = xtraPending;
            splashScreen.CloseWaitForm();
        }
        private void barSalesItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _sales_list = Enumerable.Empty<ViewSalesPart>();
            _sales_list = EnumerableUtils.getSalesParticular(branch);
            bindSalesParticular();
            xInventory.SelectedTabPage = xtraSales;
            splashScreen.CloseWaitForm();
        }
        private void barCreditLine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _delivery = Enumerable.Empty<WarehouseDelivery>();
            _delivery = EnumerableUtils.getWarehouseDeliveries();
            bindDeliveryList(branch);
            xInventory.SelectedTabPage = xtraAccepted;
            splashScreen.CloseWaitForm();
        }
        private void barReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _return_list = Enumerable.Empty<ViewReturnWarehouse>();
            bindReturnRefresh();
            xInventory.SelectedTabPage = xtraReturn;
            splashScreen.CloseWaitForm();
        }

        private void barCreditSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _credit_sales = Enumerable.Empty<ViewSalesCredit>();
            _credit_sales = EnumerableUtils.getCreditSales(branch);
            bindCreditSales();
            xInventory.SelectedTabPage = xtraCredits;
            splashScreen.CloseWaitForm();
        }

        private void barDailyExpenses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _daily_expenses = Enumerable.Empty<ViewDailyExpenses>();
            _daily_expenses = EnumerableUtils.getDailyExpenses();
            bindDailyExpenses();
            xInventory.SelectedTabPage = xtraDaily;
            splashScreen.CloseWaitForm();
        }

        private void barLowQuantity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _inventory_list = Enumerable.Empty<ViewInventory>();
            _inventory_list = EnumerableUtils.getLowQuantity();
            bindLowQuantity();
            xInventory.SelectedTabPage = xtraQuantity;
            splashScreen.CloseWaitForm();
        }

        private void cardPending_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridCardView(sender);
        }

        private void GridAccepted_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridAcceptView(sender);
        }

        private void gridSales_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridSalesView(sender);
        }
        private void gridReturn_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridReturnView(sender);
        }

        private void gridQty_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridLowQuantityView(sender);
        }

        private void GridWarehouseInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridWarehouseView(sender);
        }
        private void gridWarehouseView(object sender)
        {
            if (gridWarehouseInventory.RowCount > 0)
            {
                var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtControl.Text = ((GridView)sender).GetFocusedRowCellValue("SKU")?.ToString();
                txtQuantity.Text = ((GridView)sender).GetFocusedRowCellValue("Qty")?.ToString();
                txtStockStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status")?.ToString();
                txtCostPrice.Text = ((GridView)sender).GetFocusedRowCellValue("Price")?.ToString();
                txtLastCost.Text = ((GridView)sender).GetFocusedRowCellValue("LastCost")?.ToString();
                dkpDeliveryDate.Value = Convert.ToDateTime(((GridView)sender).GetFocusedRowCellValue("Created")?.ToString());
                dpkUpdated.Value = Convert.ToDateTime(((GridView)sender).GetFocusedRowCellValue("Updated")?.ToString());
                if (barcode != null)
                {
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
                        imgPreview.Refresh();
                    }
                }
            }
        }
        private void gridSalesView(object sender)
        {
            if (gridSales.RowCount > 0)
            {
                var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtBranch.Text = ((GridView)sender).GetFocusedRowCellValue("Branch")?.ToString();
                txtItemName.Text = ((GridView)sender).GetFocusedRowCellValue("Item")?.ToString();
                txtControl.Text = ((GridView)sender).GetFocusedRowCellValue("Invoice")?.ToString();
                txtQuantity.Text = ((GridView)sender).GetFocusedRowCellValue("Qty")?.ToString();
                txtRetail.Text = ((GridView)sender).GetFocusedRowCellValue("UnitPrice")?.ToString();
                if (barcode != null)
                {
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
                        imgPreview.Refresh();
                    }
                }
            }
        }
        private void gridCardView(object sender)
        {
            try
            {
                if (cardPending.RowCount <= 0)
                    return;

                var view = sender as CardView;
                if (view == null)
                    return;

                var barcode = view.GetFocusedRowCellValue("BARCODE")?.ToString();
                var product = (_products != null && _products.Any())
                    ? _products.FirstOrDefault(p => p.product_code == barcode)
                    : null;

                txtBarcode.Text = barcode ?? "";
                txtItemName.Text = product?.product_name ?? "";
                txtControl.Text = view.GetFocusedRowCellValue("SKU")?.ToString() ?? "";
                txtQuantity.Text = view.GetFocusedRowCellValue("QTY")?.ToString() ?? "";
                txtStockStatus.Text = view.GetFocusedRowCellValue("STATUS")?.ToString() ?? "";
                txtCostPrice.Text = view.GetFocusedRowCellValue("COST")?.ToString() ?? "";
                txtLastCost.Text = view.GetFocusedRowCellValue("PRICE")?.ToString() ?? "";

                txtRetail.Text = product?.retail_price.ToString("0.00") ?? "";
                txtWholeSale.Text = product?.wholesale.ToString("0.00") ?? "";

                if (!string.IsNullOrEmpty(barcode))
                {
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

                    imgPreview.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridAcceptView(object sender)
        {
            if (gridAccepted.RowCount > 0)
            {
                var barcode = ((LayoutView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtItemName.Text = ((LayoutView)sender).GetFocusedRowCellValue("Item")?.ToString();
                txtControl.Text = ((LayoutView)sender).GetFocusedRowCellValue("Code")?.ToString();
                txtQuantity.Text = ((LayoutView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
                txtDeliveryStatus.Text = ((LayoutView)sender).GetFocusedRowCellValue("Delivery")?.ToString();
                txtStockStatus.Text = ((LayoutView)sender).GetFocusedRowCellValue("Status")?.ToString();
                txtCostPrice.Text = ((LayoutView)sender).GetFocusedRowCellValue("Price")?.ToString();
                txtLastCost.Text = ((LayoutView)sender).GetFocusedRowCellValue("LastCost")?.ToString();
                txtBranch.Text = ((LayoutView)sender).GetFocusedRowCellValue("Branch")?.ToString();
                dkpDeliveryDate.Value = Convert.ToDateTime(((LayoutView)sender).GetFocusedRowCellValue("Date")?.ToString());
                dpkUpdated.Value = Convert.ToDateTime(((LayoutView)sender).GetFocusedRowCellValue("Update")?.ToString());
                if (barcode != null)
                {
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
                        imgPreview.Refresh();
                    }
                }
            }
        }

        private void gridReturnView(object sender)
        {
            if (gridReturn.RowCount > 0)
            {
                var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtItemName.Text = ((GridView)sender).GetFocusedRowCellValue("Item")?.ToString();
                txtQuantity.Text = ((GridView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
                txtControl.Text = ((GridView)sender).GetFocusedRowCellValue("Delivery")?.ToString();
                txtStockStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status")?.ToString();
                txtBranch.Text = ((GridView)sender).GetFocusedRowCellValue("Branch")?.ToString();
                if (barcode != null)
                {
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
                        imgPreview.Refresh();
                    }
                }
            }
        }
        private void gridLowQuantityView(object sender)
        {
            if (gridQty.RowCount > 0)
            {
                var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtItemName.Text = ((GridView)sender).GetFocusedRowCellValue("Product")?.ToString();
                txtQuantity.Text = ((GridView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
                txtControl.Text = ((GridView)sender).GetFocusedRowCellValue("Delivery")?.ToString();
                txtStockStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status")?.ToString();
                txtRetail.Text = ((GridView)sender).GetFocusedRowCellValue("Retail")?.ToString();
                txtWholeSale.Text = ((GridView)sender).GetFocusedRowCellValue("Wholesale")?.ToString();
                txtLastCost.Text = ((GridView)sender).GetFocusedRowCellValue("LastPrice")?.ToString();
                txtCostPrice.Text = ((GridView)sender).GetFocusedRowCellValue("Trade")?.ToString();
                dkpDeliveryDate.Value = Convert.ToDateTime(((GridView)sender).GetFocusedRowCellValue("Date")?.ToString());
                if (barcode != null)
                {
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
                        imgPreview.Refresh();
                    }
                }
            }
        }

        private void cardPending_DoubleClick(object sender, EventArgs e)
        {
            // Make sure the sender is a CardView
            var cardView = sender as CardView;
            if (cardView == null)
                return;

            // Ensure there are rows
            if (cardView.RowCount <= 0)
                return;

            try
            {
                splashScreen.ShowWaitForm();

                // Get the focused row's ID
                string idValue = cardView.GetFocusedRowCellValue("ID")?.ToString();
                if (!string.IsNullOrWhiteSpace(idValue))
                {
                    int id;
                    if (int.TryParse(idValue, out id))
                    {
                        var inventory = EntityUtils.getWarehouseInventory(id);
                        var pop = new FrmPopLauncher(_userId, 1, inventory)
                        {
                            main = this
                        };
                        splashScreen.CloseWaitForm();
                        pop.ShowDialog();
                    }
                    else
                    {
                        splashScreen.CloseWaitForm();
                        return; // Invalid ID format
                    }
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    return; // No ID found
                }

                // Populate fields from the card's focused row
                txtBarcode.Text = cardView.GetFocusedRowCellValue("BARCODE")?.ToString() ?? "";
                txtControl.Text = cardView.GetFocusedRowCellValue("SKU")?.ToString() ?? "";
                txtQuantity.Text = cardView.GetFocusedRowCellValue("QTY")?.ToString() ?? "";
                txtStockStatus.Text = cardView.GetFocusedRowCellValue("STATUS")?.ToString() ?? "";
                txtCostPrice.Text = cardView.GetFocusedRowCellValue("COST")?.ToString() ?? "";
                txtLastCost.Text = cardView.GetFocusedRowCellValue("PRICE")?.ToString() ?? "";

                // Dates
                DateTime deliveryDate;
                if (DateTime.TryParse(cardView.GetFocusedRowCellValue("DATE")?.ToString(), out deliveryDate))
                {
                    dkpDeliveryDate.Value = deliveryDate;
                }
                dpkUpdated.Value = DateTime.Now;

                // Load product image if barcode exists
                var barcode = txtBarcode.Text;
                if (!string.IsNullOrWhiteSpace(barcode))
                {
                    var img = searchProductImg(barcode);
                    string imgLocation = img?.img_location;

                    if (string.IsNullOrEmpty(imgLocation))
                    {
                        imgPreview.ImageLocation = ConstantUtils.defaultImgEmpty;
                    }
                    else
                    {
                        imgPreview.ImageLocation = Path.Combine(ConstantUtils.defaultImgLocation, imgLocation);
                    }

                    imgPreview.Refresh();
                }
            }
            catch (Exception ex)
            {
                splashScreen.CloseWaitForm();
                MessageBox.Show("Error processing card double-click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridAccepted_DoubleClick(object sender, EventArgs e)
        {
            if (gridAccepted.RowCount == 0) return;

            splashScreen.ShowWaitForm();

            var idValue = ((LayoutView)sender).GetFocusedRowCellValue("Id")?.ToString();
            splashScreen.CloseWaitForm();
            if (string.IsNullOrEmpty(idValue)) return;

            int deliveryId = int.Parse(idValue);

            var details = EntityUtils.GetDeliveryDetails(deliveryId);
            if (details == null) return;

            var pop = new FrmPopAccept(_userId, 1, details) { main = this };
            if (pop.ShowDialog() == DialogResult.OK)
            {
                var updated = _delivery.FirstOrDefault(d => d.delivery_id == deliveryId);
                if (updated != null)
                {
                    updated.delivery_qty = details.delivery_qty;
                    updated.delivery_status_id = details.delivery_status_id;
                }

                // Remove if completed or no quantity left
                _delivery = _delivery
                    .Where(d => !(d.delivery_id == deliveryId &&
                                 (details.delivery_status_id == 10 || details.delivery_qty <= 0)))
                    .ToList();

                // Refresh grid
                bindDeliveryList(branch);
            }
        }

        private void gridReturn_DoubleClick(object sender, EventArgs e)
        {
            if (gridReturn.RowCount > 0)
            {
                splashScreen.ShowWaitForm();
                var id = ((GridView)sender).GetFocusedRowCellValue("Id")?.ToString();
                var ReturnList = EntityUtils.getReturn(int.Parse(id));
                var pop = new FrmPopReturn(_userId, 1, ReturnList)
                {
                    main = this
                };
                splashScreen.CloseWaitForm();
                pop.ShowDialog();
                bindReturnRefresh();
            }
            var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
            txtBarcode.Text = barcode;
            txtItemName.Text = ((GridView)sender).GetFocusedRowCellValue("Item")?.ToString();
            txtQuantity.Text = ((GridView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
            txtControl.Text = ((GridView)sender).GetFocusedRowCellValue("Delivery")?.ToString();
            txtStockStatus.Text = ((GridView)sender).GetFocusedRowCellValue("Status")?.ToString();
            txtBranch.Text = ((GridView)sender).GetFocusedRowCellValue("Branch")?.ToString();
            if (barcode != null)
            {
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
                    imgPreview.Refresh();
                }
            }
        }

        private void gridCredits_DoubleClick(object sender, EventArgs e)
        {
            if (gridCredits.RowCount > 0)
            {
                splashScreen.ShowWaitForm();
                var id = ((LayoutView)sender).GetFocusedRowCellValue("Id")?.ToString();
                var CreditList = EntityUtils.getCredit(int.Parse(id));
                var PaymentList = EntityUtils.getPayment(int.Parse(id));
                var pop = new FrmPopCredit(_userId, 1, CreditList, PaymentList)
                {
                    main = this
                };
                splashScreen.CloseWaitForm();
                pop.ShowDialog();
                _credit_sales = EnumerableUtils.getCreditSales(branch);
                bindCreditSales();
            }
        }

        private void gridDaily_DoubleClick(object sender, EventArgs e)
        {
            if (gridDaily.RowCount > 0)
            {
                splashScreen.ShowWaitForm();
                var id = ((GridView)sender).GetFocusedRowCellValue("Id")?.ToString();
                var dailyExpenses = EntityUtils.getDailyExpenses(int.Parse(id));
                var pop = new FrmPopUpdateExpenses(_userId, 1, dailyExpenses)
                {
                    main = this
                };
                splashScreen.CloseWaitForm();
                pop.ShowDialog();
                _daily_expenses = EnumerableUtils.getDailyExpenses();
                bindDailyExpenses();
            }
        }

        private void gridQty_DoubleClick(object sender, EventArgs e)
        {
            if (gridQty.RowCount > 0)
            {
                splashScreen.ShowWaitForm();
                var id = ((GridView)sender).GetFocusedRowCellValue("Id")?.ToString();
                var lowInventory = EntityUtils.getInventory(int.Parse(id));
                var pop = new FrmPopLowQuantity(_userId, 1, lowInventory)
                {
                    main = this
                };
                splashScreen.CloseWaitForm();
                pop.ShowDialog();
                _inventory_list = EnumerableUtils.getLowQuantity();
                bindLowQuantity();
            }
        }

        private void barReportDailyExpenses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofDailyExpenses(name);
        }
        private void barReportProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofProductItem(name);
        }

        private void barReportInventory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofInventoryProducts(name);
        }

        private void barReportWarehouseInv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);

            var view = new FirmPopDateEntries(name, 1)
            {
                main = this
            };
            view.ShowDialog();
        }

        private void barReportWarehouseDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);

            var view = new FirmPopCategoryReport(name, 1)
            {
                main = this
            };
            view.ShowDialog();
        }

        private void barReportReturnWare_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            var view = new FirmPopCategoryReport(name, 2)
            {
                main = this
            };
            view.ShowDialog();
        }

        private void barReportSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);

            var view = new FirmPopCategoryReport(name, 6)
            {
                main = this
            };
            view.ShowDialog();
        }
        private void barReportSalesPart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofSalesParticular(name);
        }
        private void barReportCreditItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofCreditItem(name);
        }
        private void barReportCreditPart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofCreditParticular(name);
        }
        private void barReportListServices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofServiceItem(name);
        }
        private void barReportServicesParticular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofServiceParticular(name);
        }
        private void barPaymentList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofPayment(name);
        }

        private void barAddExpenses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            var pop = new FrmPopAddExpenses(_userId, 1)
            {
                main = this
            };
            splashScreen.CloseWaitForm();
            pop.ShowDialog();
        }

        private string GetUseFullName(int userId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewUserEmployees>(unWork);
                    return repository.FindBy(x => x.user_id == userId).name;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
    }
}