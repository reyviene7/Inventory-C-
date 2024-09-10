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
    public partial class FrmPopAccept : Form
    {
        private FrmManagement _main;
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewAcceptedDelivery _accepted_list;
        private IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<WarehouseStatus> _warehouseStatus;
        private IEnumerable<DeliveryStatus> _delivery_status;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopAccept(int userId, int userType, ViewAcceptedDelivery accept)
        {
            _userId = userId;
            _userType = userType;
            _accepted_list = accept;
            InitializeComponent();
        }

        private void FrmPopAccept_Load(object sender, EventArgs e)
        {
            _imgList = EnumerableUtils.getImgProductList();
            _warehouseStatus = EnumerableUtils.getStatusWarehouseList();
            _delivery_status = EnumerableUtils.getWarehouseDelivery();
            var barcode = _accepted_list.product_code;
            txtBarcode.Text = barcode;
            txtDeliveryCode.Text = _accepted_list.delivery_code;
            txtItemQty.Text = _accepted_list.delivery_qty.ToString();
            txtLastCost.Text = _accepted_list.last_cost_per_unit.ToString();
            txtCostPrice.Text = _accepted_list.item_price.ToString();
            txtRetailPrice.Text = _accepted_list.retail_price.ToString();
            txtWholePrice.Text = _accepted_list.whole_sale.ToString();
            txtTotalValue.Text = _accepted_list.total_value.ToString();
            txtReceiptNumber.Text = _accepted_list.receipt_number;
            cmbBranchName.Text = _accepted_list.branch_details;
            cmbItemStatus.Text = _accepted_list.status_details;
            cmbDeliveryStatus.Text = _accepted_list.delivery_status;

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
            receivedInventory();
        }

        private void txtItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemQty.Text) && e.KeyChar == (char)Keys.Enter)
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                txtItemQty.Focus();
                txtItemQty.BackColor = Color.Yellow;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtItemQty.Focus();
                txtItemQty.BackColor = Color.Yellow;
            }
            else
            {
                txtItemQty.BackColor = Color.White;
            }
        }

        private void txtItemQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter) {
                txtItemQty.BackColor = Color.White;
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
                dkpDelivery.Focus();
                dkpDelivery.BackColor = Color.Yellow;
            }

            if (e.KeyCode == Keys.F1)
            {
                cmbDeliveryStatus.DataBindings.Clear();
                cmbDeliveryStatus.DataSource = _delivery_status.Select(p => p.delivery_status).ToList();
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

        private void receivedInventory()
        {
            var receiveId = _accepted_list.received_id;
            if (receiveId > 0)
            {
                splashScreen.ShowWaitForm();
                try
                {
                    var result = RepositoryEntity.UpdateEntity<ReceivedInventory>(receiveId, warehouseDel =>
                    {
                        warehouseDel.product_id = FetchUtils.getProductIdBarcode(_accepted_list.product_code);
                        warehouseDel.delivery_code = _accepted_list.delivery_code;
                        warehouseDel.delivery_qty = int.Parse(txtItemQty.Text);
                        warehouseDel.warehouse_id = FetchUtils.getWarehouseId(_accepted_list.warehouse_name);
                        warehouseDel.last_cost_per_unit = decimal.Parse(txtLastCost.Text);
                        warehouseDel.item_price = _accepted_list.item_price;
                        warehouseDel.retail_price = decimal.Parse(txtRetailPrice.Text);
                        warehouseDel.whole_sale = decimal.Parse(txtWholePrice.Text);
                        warehouseDel.receipt_number = _accepted_list.receipt_number;
                        warehouseDel.user_id = _userId;
                        warehouseDel.branch_id = FetchUtils.getBranchId(_accepted_list.branch_details);
                        warehouseDel.status_id = FetchUtils.getStatusId(cmbItemStatus.Text);
                        warehouseDel.delivery_status_id = FetchUtils.getDeliveryStatus(cmbDeliveryStatus.Text);
                        warehouseDel.received_date = dkpDelivery.Value.Date;
                        warehouseDel.update_on = dkpDelivery.Value.Date;
                        warehouseDel.remarks = "";
                    });

                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1, "Delivery Code: " + _accepted_list.delivery_code + " Successfully Received/Completed!", Messages.InventorySystem);
                        _main.received = 1;
                        Close();
                        splashScreen.CloseWaitForm();
                    }
                    else
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(0, "Delivery Code: " + _accepted_list.delivery_code + " Failed to Receive/Complete Delivery!", Messages.InventorySystem);
                    }
                }
                catch (Exception ex)
                {
                    splashScreen.CloseWaitForm();
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Invalid Receive ID!", "Error");
            }
        }
    }
}
