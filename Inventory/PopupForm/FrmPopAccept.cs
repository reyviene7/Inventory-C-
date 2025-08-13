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
        private readonly DeliveryDetails _delivery;
        private IEnumerable<ViewImageProduct> _imgList;
        private IEnumerable<WarehouseStatus> _warehouseStatus;
        private IEnumerable<DeliveryStatus> _delivery_status;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopAccept(int userId, int userType, DeliveryDetails delivery)
        {
            _userId = userId;
            _userType = userType;
            _delivery = delivery;
            InitializeComponent();
        }

        private void FrmPopAccept_Load(object sender, EventArgs e)
        {
            _imgList = EnumerableUtils.getImgProductList();
            _warehouseStatus = EnumerableUtils.getStatusWarehouseList();
            var barcode = _delivery.product_code;
            txtBarcode.Text = barcode;
            txtProductName.Text = _delivery.product_name;
            txtDeliveryQty.Text = _delivery.delivery_qty.ToString();
            txtDeliveryCode.Text = _delivery.delivery_code;
            txtItemQty.Text = _delivery.delivery_qty.ToString();
            txtLastCost.Text = _delivery.last_cost_per_unit.ToString();
            txtCostPrice.Text = _delivery.cost_per_unit.ToString();
            txtInventoryCode.Text = _delivery.receipt_number;
            cmbBranchName.Text = _delivery.branch_details;
            cmbItemStatus.Text = _delivery.status_details;

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
            DataInsert();
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
                dkpDelivery.Focus();
                dkpDelivery.BackColor = Color.Yellow;
            }
            if (e.KeyCode == Keys.F1)
            {
                cmbItemStatus.DataBindings.Clear();
                cmbItemStatus.DataSource = _warehouseStatus.Select(p => p.status_details).ToList();
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
        private void DataInsert()
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtInventoryCode.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtDeliveryCode.Text) ||
                string.IsNullOrWhiteSpace(txtItemQty.Text) ||
                string.IsNullOrWhiteSpace(cmbBranchName.Text) ||
                string.IsNullOrWhiteSpace(txtLastCost.Text) ||
                string.IsNullOrWhiteSpace(cmbItemStatus.Text))
            {
                PopupNotification.PopUpMessages(0, "Please fill in all required fields.", "Incomplete Input");
                return;
            }

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();

                try
                {
                    splashScreen.ShowWaitForm();

                    var inventoryRepo = new Repository<ServeAll.Core.Entities.Inventory>(unWork);
                    var deliveryRepo = new Repository<ServeAll.Core.Entities.WarehouseDelivery>(unWork);

                    int quantity = int.Parse(txtItemQty.Text);
                    string deliveryCode = txtDeliveryCode.Text;

                    // Use product ID from _delivery, not just name lookup
                    int productId = _delivery.product_id;
                    int branchId = FetchUtils.getBranchId(cmbBranchName.Text);

                    // Get existing inventory for this product & branch
                    var existingInventory = inventoryRepo
                        .FindBy(x => x.product_id == productId && x.branch_id == branchId);

                    if (existingInventory != null)
                    {
                        existingInventory.quantity += quantity;
                        existingInventory.updatedOn = DateTime.Now;
                        inventoryRepo.Update(existingInventory);
                    }
                    else
                    {
                        var newInventory = new ServeAll.Core.Entities.Inventory
                        {
                            inventory_code = txtInventoryCode.Text,
                            product_id = productId,
                            delivery_code = deliveryCode,
                            quantity = quantity,
                            branch_id = branchId,
                            last_price_cost = Convert.ToDecimal(txtLastCost.Text),
                            inventory_date = dkpDelivery.Value.Date,
                            status_id = FetchUtils.getProductStatusId(cmbItemStatus.Text),
                            user_id = _userId, // Use actual user ID
                            updatedOn = DateTime.Now,
                            snooze = false
                        };
                        inventoryRepo.Add(newInventory);
                    }

                    // Update or delete delivery record
                    var delivery = deliveryRepo.Id(_delivery.delivery_id);
                    if (delivery != null)
                    {
                        if (quantity == delivery.delivery_qty)
                        {
                            deliveryRepo.Delete(delivery);
                        }
                        else if (quantity < delivery.delivery_qty)
                        {
                            delivery.delivery_qty -= quantity;
                            deliveryRepo.Update(delivery);
                        }
                        else
                        {
                            splashScreen.CloseWaitForm();
                            PopupNotification.PopUpMessages(0,
                                "Inventory quantity exceeds the delivery quantity.",
                                "Invalid Quantity");
                            unWork.Rollback();
                            return;
                        }
                    }

                    unWork.Commit();
                    splashScreen.CloseWaitForm();

                    PopupNotification.PopUpMessages(1,
                        "Product Name: " + txtProductName.Text.Trim() + " " + Messages.SuccessInsert,
                        Messages.TitleSuccessInsert);
                    _delivery.delivery_qty -= quantity;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFailedInsert);
                }
            }
        }
    }
}
