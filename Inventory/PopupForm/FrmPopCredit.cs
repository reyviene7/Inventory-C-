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
    public partial class FrmPopCredit : Form
    {
        private FrmManagement _main;
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewSalesCredit _credit_sales;
        private IEnumerable<ViewImageProduct> _imgList;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopCredit(int userId, int userType, ViewSalesCredit credit)
        {
            _userId = userId;
            _userType = userType;
            _credit_sales = credit;
            InitializeComponent();
        }

        private void FrmPopCredit_Load(object sender, EventArgs e)
        {
            //_imgList = EnumerableUtils.getImgProductList();
            txtInvoice.Text = _credit_sales.invoice_id;
            txtCreditCode.Text = _credit_sales.credit_code;
            txtAmountDue.Text = _credit_sales.amount_due.ToString();
            txtAmountPaid.Text = _credit_sales.paid_amount.ToString();
            txtRemainBalance.Text = _credit_sales.remaining_balance.ToString();
            txtGross.Text = _credit_sales.gross.ToString();
            txtNetSales.Text = _credit_sales.net_sales.ToString();
            txtCustomer.Text = _credit_sales.customer;
            txtOperator.Text = _credit_sales.operators;
            cmbBranchName.Text = _credit_sales.branch;
            txtCreditBalance.Text = _credit_sales.credit_balance.ToString();
            txtCreditLimit.Text = _credit_sales.credit_limit.ToString();
            /*
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
            */
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

        private void txtAmountPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtAmountPaid.BackColor = Color.White;
                dkpDelivery.Focus();
                dkpDelivery.BackColor = Color.Yellow;
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
            /*
            if (string.IsNullOrWhiteSpace(txtAmountDue.Text))
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                return;
            }
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
                        warehouseDel.delivery_qty = int.Parse(txtAmountDue.Text);
                        warehouseDel.warehouse_id = FetchUtils.getWarehouseId(_accepted_list.warehouse_name);
                        warehouseDel.last_cost_per_unit = decimal.Parse(txtAmountPaid.Text);
                        warehouseDel.item_price = _accepted_list.item_price;
                        warehouseDel.retail_price = decimal.Parse(txtGross.Text);
                        warehouseDel.whole_sale = decimal.Parse(txtNetSales.Text);
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
            */
        }
    }
}
