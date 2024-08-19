using DevExpress.XtraGrid.Views.Grid;
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
        Image imgProcessing = Image.FromFile(ConstantUtils.imgProcessing);
        Image imgCancelled = Image.FromFile(ConstantUtils.imgCancelled);
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }
        public FrmManagement()
        {
            InitializeComponent();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            _imgList = EnumerableUtils.getImgProductList();
        }
        private void FrmManagement_Load(object sender, System.EventArgs e)
        {
            bindDeliveryList();
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
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            cardInventory.Columns.Clear();
        }

        private void clearGridView()
        {
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            gridInventory.Columns.Clear();
        }

        private void bindDeliveryList()
        {
            ClearGrid();
            var list = _warehouse_delivery.Select(p => new
            {
                Id = "" + p.delivery_id,
                Barcode = p.product_code,
                Code = p.delivery_code,
                Item = p.product_name,
                Branch = p.branch_details,
                Price = "P" + p.cost_per_unit,
                LastCost = "P" + p.last_cost_per_unit,
                Qty = "" + p.delivery_qty,
                Status = p.status_details,
                Date = p.delivery_date,
                Delivery = p.delivery_status
            });
            gridControl.DataSource = list;
            gridControl.Update();
            if (cardInventory.RowCount > 0)
            {
                /* cardInventory.Columns[0].Width = 65;
                 cardInventory.Columns[1].Width = 130;
                 cardInventory.Columns[2].Width = 95;
                 cardInventory.Columns[3].Width = 320;
                 cardInventory.Columns[4].Width = 100;
                 cardInventory.Columns[5].Width = 100;
                 cardInventory.Columns[6].Width = 100;
                 cardInventory.Columns[7].Width = 65;
                 cardInventory.Columns[8].Width = 100;
                 cardInventory.Columns[9].Width = 140;
                 cardInventory.Columns[10].Width = 120; */
            }
            gridControl.Update();
        }

        private void bindCardViewList(DevExpress.XtraGrid.Views.Card.CardView cardview)
        {
            ClearGrid();
            var list = _warehouse_delivery.Select(p => new
            {
                Id = "" + p.delivery_id,
                Barcode = p.product_code,
                Code = p.delivery_code,
                Item = p.product_name,
                Branch = p.branch_details,
                Price = "P" + p.cost_per_unit,
                LastCost = "P" + p.last_cost_per_unit,
                Qty = "" + p.delivery_qty,
                Status = p.status_details,
                Date = p.delivery_date,
                Delivery = p.delivery_status
            });
            gridControl.DataSource = list;
            gridControl.Update();
            gridControl.MainView = cardview;
        }

        private void bindWharehouseList(GridView gridView)
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
            gridControl.DataSource = list;
            gridControl.Update();
            gridControl.MainView = gridView;
            /*   if (gridView.RowCount > 0)
                   gridView.Columns[0].Width = 40;
               gridView.Columns[1].Width = 90;
               gridView.Columns[2].Width = 65;
               gridView.Columns[3].Width = 40;
               gridView.Columns[4].Width = 40;
               gridView.Columns[6].Width = 180; */
        }

        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (cardInventory.RowCount > 0)
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

        private void barWarehouse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            GridView gridView = new GridView(gridControl);
            bindWharehouseList(gridView);
            gridView.PopulateColumns();
            splashScreen.CloseWaitForm();
        }

        private void barItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreen.ShowWaitForm();
            _warehouse_list = Enumerable.Empty<ViewWareHouseInventory>();
            _warehouse_delivery = EnumerableUtils.getWareHouseDeliveryList();
            DevExpress.XtraGrid.Views.Card.CardView gridView = new DevExpress.XtraGrid.Views.Card.CardView(gridControl);
            bindCardViewList(gridView);
            gridView.PopulateColumns();
            splashScreen.CloseWaitForm();
        }
    }
}
