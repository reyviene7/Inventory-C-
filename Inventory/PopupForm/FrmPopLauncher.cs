using Inventory.Config;
using Inventory.MainForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Inventory.PopupForm
{
    public partial class FrmPopLauncher : Form
    {
        private FrmManagement _main;
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewWarehouseDelivery _delivery;
        private IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<WarehouseStatus> _warehouseStatus;
        private IEnumerable<DeliveryStatus> _delivery_status;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopLauncher(int userId, int userType, ViewWarehouseDelivery delivery)
        {
            _userId = userId;
            _userType = userType;
            _delivery = delivery;
            InitializeComponent();
        }

        private void FrmPopLauncher_Load(object sender, EventArgs e)
        {
            _imgList = EnumerableUtils.getImgProductList();
            _warehouseStatus = EnumerableUtils.getStatusWarehouseList();
            _delivery_status = EnumerableUtils.getWarehouseDelivery();
            var barcode = _delivery.product_code;
            txtBarcode.Text = barcode;
            txtItemName.Text = _delivery.product_name;
            cmbBranchName.Text = _delivery.branch_details;
            txtLastCost.Text = _delivery.last_cost_per_unit.ToString();
            txtCostPrice.Text = _delivery.cost_per_unit.ToString();
            txtQuantity.Text = _delivery.delivery_qty.ToString();
            cmbItemStatus.Text = _delivery.status_details;
            cmbDeliveryStatus.Text = _delivery.delivery_status;

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

        private ViewImageProduct searchProductImg(string param)
        {
            return _imgList.FirstOrDefault(img => img.image_code == param);
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntAccept_Click(object sender, EventArgs e)
        {
            recievedDelivery();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtRetailPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter) {
                txtRetailPrice.BackColor = Color.White;
                txtWholePrice.Focus();
                txtWholePrice.BackColor = Color.Yellow;
            }
        }

        private void txtWholePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtWholePrice.BackColor = Color.White;
                cmbItemStatus.Focus();
                cmbItemStatus.BackColor = Color.Yellow;
            }
        }

        private void cmbItemStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                cmbItemStatus.BackColor = Color.White;
                cmbDeliveryStatus.Focus();
                cmbDeliveryStatus.BackColor = Color.Yellow;
            }
            if (e.KeyCode == Keys.F1)
            {
                cmbItemStatus.DataBindings.Clear();
                cmbItemStatus.DataSource = _warehouseStatus.Select(p => p.status_details).ToList();
            }
        }

        private void cmbDeliveryStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                cmbDeliveryStatus.BackColor = Color.White;
                txtQuantity.Focus();
                txtQuantity.BackColor = Color.Yellow;
            }

            if (e.KeyCode == Keys.F1)
            {
                cmbDeliveryStatus.DataBindings.Clear();
                cmbDeliveryStatus.DataSource = _delivery_status.Select(p => p.delivery_status).ToList();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtQuantity.BackColor = Color.White;
                dkpDelivery.Focus();
            }
        }

        private void dkpDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                dkpDelivery.BackColor = Color.White;
                bntAccept.Focus();
            }
        }

        private void recievedDelivery()
        {
            decimal costPrice = decimal.Parse(txtCostPrice.Text);
            decimal retailPrice = decimal.Parse(txtRetailPrice.Text);
            if (retailPrice < costPrice)
            {
                PopupNotification.PopUpMessages(0, "Retail Price must be greater than the Cost Price!", "Invalid Input");
                return;
            }
            if (retailPrice > 0)
            {
                splashScreen.ShowWaitForm();
                var deliveryId = _delivery.delivery_id;
                ReceivedInventory warehouseDel = new ReceivedInventory
                {
                    product_id = FetchUtils.getProductIdBarcode(_delivery.product_code),
                    delivery_id = deliveryId,
                    delivery_code = _delivery.delivery_code,
                    warehouse_id = FetchUtils.getWarehouseId(_delivery.warehouse_name),
                    last_cost_per_unit = decimal.Parse(txtLastCost.Text),
                    item_price = _delivery.cost_per_unit,
                    retail_price = decimal.Parse(txtRetailPrice.Text),
                    whole_sale = decimal.Parse(txtWholePrice.Text),
                    receipt_number = _delivery.receipt_number,
                    user_id = _userId,
                    branch_id = FetchUtils.getBranchId(_delivery.branch_details),
                    status_id = FetchUtils.getStatusId(cmbItemStatus.Text),
                    delivery_qty = int.Parse(txtQuantity.Text),
                    delivery_status_id = FetchUtils.getDeliveryStatus(cmbDeliveryStatus.Text),
                    received_date = dkpDelivery.Value.Date,
                    update_on = dkpDelivery.Value.Date,
                    remarks = ""
                };
                var result = RepositoryEntity.AddEntity<ReceivedInventory>(warehouseDel);
                if (result > 0)
                {
                    int deliveryResult = RepositoryEntity.UpdateEntity<WarehouseDelivery>(deliveryId, entity => {
                        entity.delivery_status_id = FetchUtils.getDeliveryStatus(cmbDeliveryStatus.Text.Trim());
                    });
                    if (deliveryResult > 0) {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Delivery Code: " + _delivery.delivery_code + " Successfully Received/Completed!", Messages.InventorySystem);
                        _main.received = 1;
                        Close();
                    }
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Delivery Code: " + _delivery.delivery_code + " Failed to Received/Complete Delivery!", Messages.InventorySystem);
                }
            }
        }
    }
}
