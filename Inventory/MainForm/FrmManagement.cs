using DevExpress.XtraGrid.Views.Grid;
using ServeAll.Core.Entities;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Inventory.MainForm
{
    public partial class FrmManagement : Form
    {
        private FirmMain _main;
        private readonly IEnumerable<ViewWarehouseDelivery> _warehouse_delivery;
        private readonly IEnumerable<ViewImageProduct> _imgList;
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
            gridInventory.Columns.Clear();
        }

        private void bindDeliveryList()
        {
            ClearGrid();
            var list = _warehouse_delivery.Select(p => new
            {
                Id = p.delivery_id,
                Barcode = p.product_code,
                Delivery = p.delivery_code,
                Product = p.product_name,
                Destination = p.branch_details,
                Price = p.cost_per_unit,
                LastCost = p.last_cost_per_unit,
                Qty = p.delivery_qty,
                Status = p.status_details,
                DeliveryStatus = p.delivery_status,
                DeliveryDate = p.delivery_date
            });
            gridControl.DataSource = list;
            if (gridInventory.RowCount > 0)
            {
                gridInventory.Columns[0].Width = 65;
                gridInventory.Columns[1].Width = 130;
                gridInventory.Columns[2].Width = 95;
                gridInventory.Columns[3].Width = 320;
                gridInventory.Columns[4].Width = 100;
                gridInventory.Columns[5].Width = 100;
                gridInventory.Columns[6].Width = 100;
                gridInventory.Columns[7].Width = 65;
                gridInventory.Columns[8].Width = 100;
                gridInventory.Columns[9].Width = 140;
                gridInventory.Columns[10].Width = 120;
            }
            gridControl.Update();
        }

        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridInventory.RowCount > 0)
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
    }
}
