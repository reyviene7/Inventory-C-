using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.PopupForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Layout;

namespace Inventory.MainForm
{
    public partial class FrmManagement : Form
    {
        private FirmMain _main;
        private bool _isCanceled;
        private IEnumerable<ViewWarehouseDelivery> _warehouse_delivery;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;
        private IEnumerable<ViewReturnWarehouse> _return_list;
        private IEnumerable<ViewReturnWarehouse> warehouse_return;
        private readonly IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<ViewSalesPart> _sales_list;
        private IEnumerable<ViewAcceptedDelivery> _accepted_list;
        private IEnumerable<ViewSalesCredit> _credit_sales;
        private IEnumerable<ViewDailyExpenses> _daily_expenses;
        private IEnumerable<ViewInventory> _inventory_list;
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
                    _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
                    bindDeliveryList(branch);
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
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            _return_list = EnumerableUtils.getWareHouseReturnList();
            _sales_list = EnumerableUtils.getSalesParticular(branch);
            _accepted_list = EnumerableUtils.getAcceptedDelivery(branch);
            _credit_sales = EnumerableUtils.getCreditSales(branch);
            _daily_expenses = EnumerableUtils.getDailyExpenses();
            _inventory_list = EnumerableUtils.getLowQuantity();
            _imgList = EnumerableUtils.getImgProductList();
        }
        private void FrmManagement_Load(object sender, System.EventArgs e)
        {
            ShowBranch();
            bindDeliveryList(branch);
            barUser.EditValue = _username;
            barSoftware.EditValue = "Inventory System V1.0";
            barBranch.EditValue = branch;
            barDate.EditValue = DateTime.Now.Date.ToString();
            xInventory.SelectedTabPage = null;

            // Make the form fullscreen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None; // Optional: remove title bar and borders
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
            ClearGrid();
            var list = _warehouse_delivery
                .Where(p => p.branch_details == branch)
                .Select(p => new
                {
                    Id = "" + p.delivery_id,
                    Barcode = p.product_code,
                    Code = p.delivery_code,
                    Item = p.product_name,
                    Branch = p.branch_details,
                    Price = "P" + p.cost_per_unit,
                    LastCost = "P" + p.last_cost_per_unit,
                    Quantity = "" + p.delivery_qty,
                    Status = p.status_details,
                    Date = p.delivery_date,
                    Delivery = p.delivery_status
                }).ToList();
            gridCtrlPending.DataSource = list;
            gridCtrlPending.Update();
        }

        private void bindAcceptedDelivery()
        {
            clearAcceptedDelivery();
            var list = _accepted_list.Select(p => new {
                Id = "" + p.received_id,
                Barcode = p.product_code,
                Delivery = p.delivery_code,
                Quantity = "" + p.delivery_qty,
                LastCost = "P" + p.last_cost_per_unit,
                ItemPrice = "P" + p.item_price,
                RetailPrice = "P" + p.retail_price,
                WholeSale = "P" + p.whole_sale,
                Totaled = "P" + p.total_value,
                ReceiptNo = p.receipt_number,
                User = p.username,
                Warehouse = p.warehouse_name,
                Branch = p.branch_details,
                Status = p.status_details,
                DeliverySta = p.delivery_status,
                Received = p.received_date,
                UpdateOn = p.update_on,
                Remarks = p.remarks
            }).ToList();
            gridCtrlAccepted.DataSource = list;
            gridCtrlAccepted.Update();
        }

        private void bindCardViewList(string branch)
        {
            ClearGrid();
            var list = _warehouse_delivery
                .Where(p => p.branch_details == branch)
                .Select(p => new
                {
                    Id = "" + p.delivery_id,
                    Barcode = p.product_code,
                    Code = p.delivery_code,
                    Item = p.product_name,
                    Branch = p.branch_details,
                    Price = "P" + p.cost_per_unit,
                    LastCost = "P" + p.last_cost_per_unit,
                    Quantity = "" + p.delivery_qty,
                    Status = p.status_details,
                    Date = p.delivery_date,
                    Delivery = p.delivery_status
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
            _warehouse_list = Enumerable.Empty<ViewWareHouseInventory>();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            bindCardViewList(branch);
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
            _accepted_list = Enumerable.Empty<ViewAcceptedDelivery>();
            _accepted_list = EnumerableUtils.getAcceptedDelivery(branch);
            bindAcceptedDelivery();
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
                    var imgLocation = img.img_location;
                    if (imgLocation.Length > 0)
                    {
                        var location = ConstantUtils.defaultImgLocation + imgLocation;
                        imgPreview.ImageLocation = location;
                        imgPreview.Refresh();
                    }
                    else
                    {
                        imgPreview.Image = null;
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
                    var imgLocation = img.img_location;
                    if (imgLocation.Length > 0)
                    {
                        var location = ConstantUtils.defaultImgLocation + imgLocation;
                        imgPreview.ImageLocation = location;
                        imgPreview.Refresh();
                    }
                    else
                    {
                        imgPreview.Image = null;
                    }
                }
            }
        }
        private void gridCardView(object sender)
        {
            if (cardPending.RowCount > 0)
            {
                var barcode = ((CardView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtItemName.Text = ((CardView)sender).GetFocusedRowCellValue("Item")?.ToString();
                txtControl.Text = ((CardView)sender).GetFocusedRowCellValue("Code")?.ToString();
                txtQuantity.Text = ((CardView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
                txtDeliveryStatus.Text = ((CardView)sender).GetFocusedRowCellValue("Delivery")?.ToString();
                txtStockStatus.Text = ((CardView)sender).GetFocusedRowCellValue("Status")?.ToString();
                txtCostPrice.Text = ((CardView)sender).GetFocusedRowCellValue("Price")?.ToString();
                txtLastCost.Text = ((CardView)sender).GetFocusedRowCellValue("LastCost")?.ToString();
                txtBranch.Text = ((CardView)sender).GetFocusedRowCellValue("Branch")?.ToString();
                if (barcode != null)
                {
                    var img = searchProductImg(barcode);
                    var imgLocation = img.img_location;
                    if (imgLocation.Length > 0)
                    {
                        var location = ConstantUtils.defaultImgLocation + imgLocation;
                        imgPreview.ImageLocation = location;
                        imgPreview.Refresh();
                    }
                    else
                    {
                        imgPreview.Image = null;
                    }
                }
            }
        }

        private void gridAcceptView(object sender)
        {
            if (gridAccepted.RowCount > 0)
            {
                var barcode = ((LayoutView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtItemName.Text = ((LayoutView)sender).GetFocusedRowCellValue("Item")?.ToString();
                txtControl.Text = ((LayoutView)sender).GetFocusedRowCellValue("Delivery")?.ToString();
                txtQuantity.Text = ((LayoutView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
                txtDeliveryStatus.Text = ((LayoutView)sender).GetFocusedRowCellValue("DeliverySta")?.ToString();
                txtStockStatus.Text = ((LayoutView)sender).GetFocusedRowCellValue("Status")?.ToString();
                txtRetail.Text = ((LayoutView)sender).GetFocusedRowCellValue("RetailPrice")?.ToString();
                txtWholeSale.Text = ((LayoutView)sender).GetFocusedRowCellValue("WholeSale")?.ToString();
                txtCostPrice.Text = ((LayoutView)sender).GetFocusedRowCellValue("ItemPrice")?.ToString();
                txtLastCost.Text = ((LayoutView)sender).GetFocusedRowCellValue("LastCost")?.ToString();
                txtBranch.Text = ((LayoutView)sender).GetFocusedRowCellValue("Branch")?.ToString();
                dkpDeliveryDate.Value = Convert.ToDateTime(((LayoutView)sender).GetFocusedRowCellValue("Received")?.ToString());
                dpkUpdated.Value = Convert.ToDateTime(((LayoutView)sender).GetFocusedRowCellValue("UpdateOn")?.ToString());
                if (barcode != null)
                {
                    var img = searchProductImg(barcode);
                    var imgLocation = img.img_location;
                    if (imgLocation.Length > 0)
                    {
                        var location = ConstantUtils.defaultImgLocation + imgLocation;
                        imgPreview.ImageLocation = location;
                        imgPreview.Refresh();
                    }
                    else
                    {
                        imgPreview.Image = null;
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
                    var imgLocation = img.img_location;
                    if (imgLocation.Length > 0)
                    {
                        var location = ConstantUtils.defaultImgLocation + imgLocation;
                        imgPreview.ImageLocation = location;
                        imgPreview.Refresh();
                    }
                    else
                    {
                        imgPreview.Image = null;
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
                    var imgLocation = img.img_location;
                    if (imgLocation.Length > 0)
                    {
                        var location = ConstantUtils.defaultImgLocation + imgLocation;
                        imgPreview.ImageLocation = location;
                        imgPreview.Refresh();
                    }
                    else
                    {
                        imgPreview.Image = null;
                    }
                }
            }
        }

        private void cardPending_DoubleClick(object sender, EventArgs e)
        {
            if (cardPending.RowCount > 0)
            {
                splashScreen.ShowWaitForm();
                var id = ((CardView)sender).GetFocusedRowCellValue("Id")?.ToString();
                var delivery = EntityUtils.getWarehouseDelivery(int.Parse(id));
                var pop = new FrmPopLauncher(_userId, 1, delivery)
                {
                    main = this
                };
                splashScreen.CloseWaitForm();
                pop.ShowDialog();
            }
            var barcode = ((CardView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
            txtBarcode.Text = barcode;
            txtItemName.Text = ((CardView)sender).GetFocusedRowCellValue("Item")?.ToString();
            txtControl.Text = ((CardView)sender).GetFocusedRowCellValue("Code")?.ToString();
            txtQuantity.Text = ((CardView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
            txtDeliveryStatus.Text = ((CardView)sender).GetFocusedRowCellValue("Delivery")?.ToString();
            txtStockStatus.Text = ((CardView)sender).GetFocusedRowCellValue("Status")?.ToString();
            txtCostPrice.Text = ((CardView)sender).GetFocusedRowCellValue("Price")?.ToString();
            txtLastCost.Text = ((CardView)sender).GetFocusedRowCellValue("LastCost")?.ToString();
            txtBranch.Text = ((CardView)sender).GetFocusedRowCellValue("Branch")?.ToString();
            if (barcode != null)
            {
                var img = searchProductImg(barcode);
                var imgLocation = img.img_location;
                if (imgLocation.Length > 0)
                {
                    var location = ConstantUtils.defaultImgLocation + imgLocation;
                    imgPreview.ImageLocation = location;
                    imgPreview.Refresh();
                }
                else
                {
                    imgPreview.Image = null;
                }
            }
        }

        private void gridAccepted_DoubleClick(object sender, EventArgs e)
        {
            if (gridAccepted.RowCount > 0)
            {
                splashScreen.ShowWaitForm();
                var id = ((LayoutView)sender).GetFocusedRowCellValue("Id")?.ToString();
                var Received = EntityUtils.getAccepted(int.Parse(id));
                var pop = new FrmPopAccept(_userId, 1, Received)
                {
                    main = this
                };
                splashScreen.CloseWaitForm();
                pop.ShowDialog();
                _accepted_list = EnumerableUtils.getAcceptedDelivery(branch);
                bindAcceptedDelivery();
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
                var imgLocation = img.img_location;
                if (imgLocation.Length > 0)
                {
                    var location = ConstantUtils.defaultImgLocation + imgLocation;
                    imgPreview.ImageLocation = location;
                    imgPreview.Refresh();
                }
                else
                {
                    imgPreview.Image = null;
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
            ReportSetting.ListofSalesItem(name);
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