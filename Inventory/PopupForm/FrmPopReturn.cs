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
        private readonly ViewReturnWarehouse _return_list;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopReturn(int userId, int userType, ViewReturnWarehouse ReturnList)
        {
            _userId = userId;
            _userType = userType;
            _return_list = ReturnList;
            InitializeComponent();
            GenerateReturn();
        }

        private void FrmPopLauncher_Load(object sender, EventArgs e)
        {
            _imgList = EnumerableUtils.getImgProductList();
            _productStatus = EnumerableUtils.getProductStatus();
            _delivery_status = EnumerableUtils.getWarehouseDelivery();
            var barcode = _return_list.product_code;
            txtReturnBarcode.Text = barcode;
            txtReturnItem.Text = _return_list.product_name;
            cmbReturnBranch.Text = _return_list.branch_details;
            txtReturnNumber.Text = _return_list.return_number;
            txtReturnQuantity.Text = _return_list.return_quantity.ToString();
            cmbReturnItemStatus.Text = _return_list.status;
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
            receivedDelivery();
        }
        private void txtReturnQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtReturnQuantity.BackColor = Color.White;
                txtReturnRemarks.Focus();
                txtReturnRemarks.BackColor = Color.Yellow;
            }
        }
        private void txtReturnRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtReturnRemarks.BackColor = Color.White;
                bntAccept.Focus();
            }
        }

        private string GenerateReturn()
        {
            var lastReturnGenCode = FetchUtils.getLastReturnId();
            int lastReturnGenNumber;

            if (string.IsNullOrEmpty(lastReturnGenCode) || !int.TryParse(lastReturnGenCode.Replace("R", ""), out lastReturnGenNumber))
            {
                lastReturnGenNumber = 0;
            }
            var alphaNumeric = new GenerateAlpaNum("R", 3, lastReturnGenNumber);
            alphaNumeric.Increment();
            var returnCode = alphaNumeric.ToString();
            return returnCode;
        }
        private void receivedDelivery()
        {
            var ReturnId = _return_list.return_id;
            if (ReturnId > 0)
            {
                splashScreen.ShowWaitForm();
                try
                {
                    var returnQty = int.Parse(txtReturnQuantity.Text);
                    var remarks = txtReturnRemarks.Text.Trim(' ');
                    var update = DateTime.Now.Date;

                    var result = RepositoryEntity.UpdateEntity<ReturnWareHouse>(ReturnId, WarehouseReturn =>
                    {
                        WarehouseReturn.return_quantity = returnQty;
                        WarehouseReturn.remarks = remarks;
                        WarehouseReturn.update_on = update;
                    });
                    if (result > 0)
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Item Return:" + txtReturnItem.Text.Trim(' ') + " successfully updated!", "UPDATE RETURN");
                        Close();
                    }
                    else
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(0, "Item Return:" + txtReturnItem.Text.Trim(' ') + " was not updated to return warehouse!", "UPDATE FAILED");
                        Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
