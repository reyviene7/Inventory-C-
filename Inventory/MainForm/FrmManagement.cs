using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.PopupForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Inventory.MainForm
{
    public partial class FrmManagement : Form
    {
        private FirmMain _main;
        private IEnumerable<ViewWarehouseDelivery> _warehouse_delivery;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;
        private readonly IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<ViewSalesPart> _sales_list;
        private readonly int _userId;
        private readonly int _userType;
        private readonly string _username;

        public FrmManagement management { protected get; set; }
        Image imgProcessing = Image.FromFile(ConstantUtils.imgProcessing);
        Image imgCancelled = Image.FromFile(ConstantUtils.imgCancelled);
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
            InitializeComponent();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            _sales_list = EnumerableUtils.getSalesParticular(branch);
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

        private void ClearGrid()
        {
            gridCtrlPending.DataSource = null;
            gridCtrlPending.DataSource = "";
            cardPending.Columns.Clear();
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
            });
            gridCtrlPending.DataSource = list;
            gridCtrlPending.Update();
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
            var pop = new FirmPopBranches(_userId, 1)
            {
                management = this,
                formManagement = true
            };
            pop.ShowDialog();
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

        private void cardPending_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridCardView(sender);
        }

        private void gridSales_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridSalesView(sender);
        }

        private void gridSalesView(object sender)
        {
            if(gridSales.RowCount > 0)
            {
                var barcode = ((GridView)sender).GetFocusedRowCellValue("Barcode")?.ToString();
                txtBarcode.Text = barcode;
                txtBranch.Text = ((GridView)sender).GetFocusedRowCellValue("Branch")?.ToString();
                txtItemName.Text = ((GridView)sender).GetFocusedRowCellValue("Item")?.ToString();
                txtControl.Text = ((GridView)sender).GetFocusedRowCellValue("Invoice")?.ToString();
                txtQuantity.Text = ((GridView)sender).GetFocusedRowCellValue("Quantity")?.ToString();
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
            if(cardPending.RowCount > 0)
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

        private void cardPending_DoubleClick(object sender, EventArgs e)
        {
            if (cardPending.RowCount > 0) {
                splashScreen.ShowWaitForm();
                var id = ((CardView)sender).GetFocusedRowCellValue("Id")?.ToString();
                var delivery = EntityUtils.getWarehouseDelivery(int.Parse(id));
                var pop = new FrmPopLauncher(_userId, 1, delivery);
                splashScreen.CloseWaitForm();
                pop.ShowDialog();
            }
        }
    }
}
