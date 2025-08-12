using DevExpress.XtraReports.UI;
using Inventory.Config;
using Inventory.MainForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using ServeAll.Entities;
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
        private IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<WarehouseStatus> _warehouseStatus;
        private IEnumerable<DeliveryStatus> _delivery_status;
        private IEnumerable<ViewWareHouseInventory> _warehouse_list;
        private ViewWareHouseInventory _warehouse;
        private IEnumerable<ViewProducts> _products;
        private IEnumerable<Branch> branch;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopLauncher(int userId, int userType, ViewWareHouseInventory inventory)
        {
            _userId = userId;
            _userType = userType;
            _warehouse = inventory;
            InitializeComponent();
        }

        private void FrmPopLauncher_Load(object sender, EventArgs e)
        {
            _imgList = EnumerableUtils.getImgProductList();
            _warehouseStatus = EnumerableUtils.getStatusWarehouseList();
            _delivery_status = EnumerableUtils.getWarehouseDelivery();
            branch = EnumerableUtils.getBranchDetails();
            _warehouse_list = EnumerableUtils.getWareHouseInventoryList();
            _products = EnumerableUtils.getProductList();
            var barcode = _warehouse.product_code;
            txtBarcode.Text = barcode;
            txtCostPrice.Text = _warehouse.cost_per_unit.ToString();
            txtLastCost.Text = _warehouse.last_cost_per_unit.ToString();
            cmbItemStatus.Text = _warehouse.status_details;
            txtItemName.Text = _products.FirstOrDefault(p => p.product_code == barcode).product_name;
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
            txtQuantity.Focus();
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
            InsertData();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text) && e.KeyChar == (char)Keys.Enter)
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                txtQuantity.Focus();
                txtQuantity.BackColor = Color.Yellow;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtQuantity.Focus();
                txtQuantity.BackColor = Color.Yellow;
            }
            else
            {
                txtQuantity.BackColor = Color.White;
            }
        }

        private void cmbItemStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
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

        private void cmbBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                cmbBranchName.BackColor = Color.White;
                cmbItemStatus.Focus();
                cmbItemStatus.BackColor = Color.Yellow;
            }
            if (e.KeyCode == Keys.F1)
            {
                cmbBranchName.DataBindings.Clear();
                cmbBranchName.DataSource = branch.Select(p => p.branch_details).ToList();
            }
        }

        private void cmbDeliveryStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
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
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                txtQuantity.BackColor = Color.White;
                txtRemarks.Focus();
            }
        }
        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                txtRemarks.BackColor = Color.White;
                dkpDelivery.Focus();
            }
        }

        private void dkpDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                dkpDelivery.BackColor = Color.White;
                bntAccept.Focus();
            }
        }

        private string GenerateWareHouseCode()
        {
            var lastWarehouseDeliveryId = FetchUtils.getLastDeliveryId();
            var alphaNumeric = new GenerateAlpaNum("DC", 3, lastWarehouseDeliveryId);
            alphaNumeric.Increment();
            return alphaNumeric.ToString();
        }
        private string GenerateReceiptCode()
        {
            var lastReceiptCode = FetchUtils.getLastDeliveryId();
            var alphaNumeric = new GenerateAlpaNum("RCPT", 3, lastReceiptCode);
            alphaNumeric.Increment();
            return alphaNumeric.ToString();
        }

        private void InsertData()
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int deliveryQty) || deliveryQty <= 0)
            {
                PopupNotification.PopUpMessages(0, "Invalid quantity value!", "INVALID INPUT");
                return;
            }

            if (_warehouse == null)
            {
                PopupNotification.PopUpMessages(0, "No warehouse item selected!", "ERROR");
                return;
            }

            splashScreen.ShowWaitForm();

            // 3️⃣ Prepare the entity
            WarehouseDelivery warehouseDel = new WarehouseDelivery
            {
                product_id = FetchUtils.getProductIdBarcode(_warehouse.product_code),
                delivery_code = GenerateWareHouseCode(),
                warehouse_id = FetchUtils.getWarehouseId(_warehouse.warehouse_name),
                last_cost_per_unit = _warehouse.last_cost_per_unit,
                item_price = _warehouse.cost_per_unit,
                receipt_number = GenerateReceiptCode(),
                user_id = _userId,
                branch_id = FetchUtils.getBranchId(cmbBranchName.Text),
                status_id = FetchUtils.getStatusId(cmbItemStatus.Text),
                delivery_status_id = FetchUtils.getDeliveryStatus(cmbDeliveryStatus.Text),
                inventory_id = _warehouse.inventory_id,
                delivery_qty = deliveryQty,
                remarks = txtRemarks.Text.Trim(),
                delivery_date = dkpDelivery.Value.Date,
                update_on = DateTime.Now
            };

            var result = RepositoryEntity.AddEntity<WarehouseDelivery>(warehouseDel);

            splashScreen.CloseWaitForm();

            if (result > 0)
            {
                PopupNotification.PopUpMessages(1, $"Product: {txtItemName.Text.Trim()} Successfully Delivered!", Messages.InventorySystem);
                _main.received = 1;
                Close();
            }
            else
            {
                PopupNotification.PopUpMessages(0, $"Product: {txtItemName.Text.Trim()} Failed to Add!", Messages.InventorySystem);
            }
        }

    }
}
