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
    public partial class FrmPopLowQuantity : Form
    {
        private FrmManagement _main;
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewInventory _inventory;
        private IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<ViewInventory> _inventory_list;
        private IEnumerable<ProductStatus> _productStatus;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopLowQuantity(int userId, int userType, ViewInventory inventory)
        {
            _userId = userId;
            _userType = userType;
            _inventory = inventory;
            InitializeComponent();
            txtQuantity.Focus();
        }

        private void FrmPopLowQuantity_Load(object sender, EventArgs e)
        {
            _productStatus = EnumerableUtils.getProductStatus();
            _imgList = EnumerableUtils.getImgProductList();
            _inventory_list = EnumerableUtils.getLowQuantity();
            var barcode = _inventory.product_code;
            txtBarcode.Text = barcode;
            txtItemName.Text = _inventory.product_name;
            cmbBranchName.Text = _inventory.branch_details;
            txtLastCost.Text = _inventory.last_price_cost.ToString();
            txtCostPrice.Text = _inventory.trade_price.ToString();
            txtRetailPrice.Text = _inventory.retail_price.ToString();
            txtWholePrice.Text = _inventory.wholesale.ToString();
            txtQuantity.Text = _inventory.quantity.ToString();
            cmbItemStatus.Text = _inventory.status;
            dkpInventory.Value = _inventory.inventory_date;

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
            UpdateInventory();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {

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
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                cmbItemStatus.BackColor = Color.White;
                txtQuantity.Focus();
                txtQuantity.BackColor = Color.Yellow;
            }
            if (e.KeyCode == Keys.F1)
            {
                cmbItemStatus.DataBindings.Clear();
                cmbItemStatus.DataSource = _productStatus.Select(p => p.status).ToList();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtQuantity.BackColor = Color.White;
                dkpInventory.Focus();
            }
        }

        private void dkpDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                dkpInventory.BackColor = Color.White;
                bntAccept.Focus();
            }
        }

        private void UpdateInventory()
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                return;
            }
            var inventoryId = _inventory.inventory_id;

            if (inventoryId > 0)
            {
                splashScreen.ShowWaitForm();
                try
                {
                    var result = RepositoryEntity.UpdateEntity<ServeAll.Core.Entities.Inventory>(inventoryId, inventoryLow =>
                    {
                        inventoryLow.quantity = int.Parse(txtQuantity.Text);
                        inventoryLow.status_id = FetchUtils.getProductStatusId(cmbItemStatus.Text);
                        inventoryLow.last_price_cost = decimal.Parse(txtLastCost.Text);
                        inventoryLow.updatedOn = dkpInventory.Value.Date;
                    });
                    if (result > 0)
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Inventory Code: " + _inventory.inventory_code + " Successfully Updated!", Messages.InventorySystem);
                        Close();
                    }
                    else
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(0, "Inventory Code: " + _inventory.inventory_code + " Failed to Update Inventory!", Messages.InventorySystem);
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Error: " + ex.Message, Messages.InventorySystem);
                }
            }
        }
    }
}
