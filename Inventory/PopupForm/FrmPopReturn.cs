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
    public partial class FrmPopReturn : Form
    {
        private FrmManagement _main;
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewInventory _inventory;
        private IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<ProductStatus> _productStatus;
        private IEnumerable<DeliveryStatus> _delivery_status;
        private string returnCode;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopReturn(int userId, int userType, ViewInventory Inventory)
        {
            _userId = userId;
            _userType = userType;
            _inventory = Inventory;
            InitializeComponent();
            GenerateReturn();
        }

        private void FrmPopLauncher_Load(object sender, EventArgs e)
        {
            _imgList = EnumerableUtils.getImgProductList();
            _productStatus = EnumerableUtils.getProductStatus();
            _delivery_status = EnumerableUtils.getWarehouseDelivery();
            var barcode = _inventory.product_code;
            txtReturnBarcode.Text = barcode;
            txtReturnItem.Text = _inventory.product_name;
            cmbReturnBranch.Text = _inventory.branch_details;
            txtInventoryQuantity.Text = _inventory.quantity.ToString();
            cmbReturnItemStatus.Text = _inventory.status;
            cmbReturnDestination.Text = Constant.DefaultWareHouse;
            txtReturnRemarks.Text = "N/A";
            txtReturnQuantity.Focus();

            if (barcode != null)
            {
                var img = searchProductImg(barcode);
                var imgLocation = img.img_location;
                if (imgLocation.Length > 0)
                {
                    var location = ConstantUtils.defaultImgLocation + imgLocation;
                    ImageReturnPreview.ImageLocation = location;
                    ImageReturnPreview.Refresh();
                }
                else
                {
                    ImageReturnPreview.Image = null;
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
        private void txtReturnQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtReturnQuantity.BackColor = Color.White;
                cmbReturnItemStatus.Focus();
                cmbReturnItemStatus.BackColor = Color.Yellow;
            }
        }
        private void cmbItemStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                cmbReturnItemStatus.BackColor = Color.White;
                txtReturnRemarks.Focus();
                txtReturnRemarks.BackColor = Color.Yellow;
            }
            if (e.KeyCode == Keys.F1)
            {
                cmbReturnItemStatus.DataBindings.Clear();
                cmbReturnItemStatus.DataSource = _productStatus.Select(p => p.status).ToList();
            }
        }
        private void txtReturnRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtReturnRemarks.BackColor = Color.White;
                dkpReturnDate.Focus();
                dkpReturnDate.BackColor = Color.Yellow;
            }
        }

        private void dkpDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                dkpReturnDate.BackColor = Color.White;
                bntAccept.Focus();
            }
        }
        private string GenerateReturn()
        {
            var lastReturnCode = FetchUtils.getLastReturnId();
            int lastReturnNumber;

            if (string.IsNullOrEmpty(lastReturnCode) || !int.TryParse(lastReturnCode.Replace("R", ""), out lastReturnNumber))
            {
                lastReturnNumber = 0;
            }
            var alphaNumeric = new GenerateAlpaNum("R", 3, lastReturnNumber);
            alphaNumeric.Increment();
            var returnCode = alphaNumeric.ToString();
            return returnCode;
        }
        private void recievedDelivery()
        {
            
                splashScreen.ShowWaitForm();
                ReceivedReturn WarehouseReturn = new ReceivedReturn
                {
                    return_code = returnCode,
                    product_id = FetchUtils.getProductIdBarcode(txtReturnBarcode.Text),
                    return_number = _inventory.delivery_code,
                    return_quantity = int.Parse(txtReturnQuantity.Text),
                    branch_id = FetchUtils.getBranchId(cmbReturnBranch.Text),
                    destination = cmbReturnDestination.Text.Trim(' '),
                    return_date = dkpReturnDate.Value.Date,
                    status_id = FetchUtils.getProductStatusId(cmbReturnItemStatus.Text),
                    remarks = txtReturnRemarks.Text.Trim(' '),
                    inventory_id = _inventory.inventory_id,
                    update_on = dkpReturnDate.Value.Date,
                    received_date = dkpReturnDate.Value.Date
                };
                var returnResult = RepositoryEntity.AddEntity<ReceivedReturn>(WarehouseReturn);
                if (returnResult > 0)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Return Delivery No: " + _inventory.delivery_code + " successfully return to Warehouse!", Messages.InventorySystem);
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Return Delivery Code: " + _inventory.delivery_code + " Failed to Received/Complete Delivery!", Messages.InventorySystem);
            }
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
