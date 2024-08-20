using ServeAll.Core.Entities;
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
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewWarehouseDelivery _delivery;
        private IEnumerable<ViewImageProduct> _imgList;
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

        }

        private void bntCancel_Click(object sender, EventArgs e)
        {

        }

        private void cmbItemStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbDeliveryStatus_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
