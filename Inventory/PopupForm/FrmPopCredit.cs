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
using Constant = Inventory.Config.Constant;

namespace Inventory.PopupForm
{
    public partial class FrmPopCredit : Form
    {
        private FrmManagement _main;
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewSalesCredit _credit_sales;
        private readonly ViewPayment _payment;
        private IEnumerable<ViewImageProduct> _imgList;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopCredit(int userId, int userType, ViewSalesCredit credit, ViewPayment payment)
        {
            _userId = userId;
            _userType = userType;
            _credit_sales = credit;
            _payment = payment;
            InitializeComponent();
        }

        private void FrmPopCredit_Load(object sender, EventArgs e)
        {
            var paymentMethods = EnumerableUtils.getPayment();
            var methodNames = paymentMethods.Select(method => method.method_name).ToList();
            cmbPaymentMethod.Items.AddRange(methodNames.ToArray());

            // Optionally set the default selected method
            if (methodNames.Any())
            {
                cmbPaymentMethod.Text = methodNames.First(); // Set the first method as default
            }
            //_imgList = EnumerableUtils.getImgProductList();
            txtInvoice.Text = _credit_sales.invoice_id;
            txtCreditCode.Text = _credit_sales.credit_code;
            txtAmountDue.Text = _credit_sales.amount_due.ToString();
            txtAmountPaid.Text = _credit_sales.paid_amount.ToString();
            txtRemainBalance.Text = _credit_sales.remaining_balance.ToString();
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
        /*
        private PaymentMethod searchPaymentId(int id)
        {
            return _payment_method.FirstOrDefault(Return => Return.return_id == id);
        }
        */
        private void bntExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntAccept_Click(object sender, EventArgs e)
        {
            paymentCredit();
        }

        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmountPaid.Text) && e.KeyChar == (char)Keys.Enter)
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                txtAmountPaid.Focus();
                txtAmountPaid.BackColor = Color.Yellow;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtAmountPaid.Focus();
                txtAmountPaid.BackColor = Color.Yellow;
            }
            else
            {
                txtAmountPaid.BackColor = Color.White;
            }
        }

        private void txtAmountPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtAmountPaid.BackColor = Color.White;
                
                if (decimal.TryParse(txtAmountPaid.Text, out decimal amountPaid) &&
                    decimal.TryParse(txtRemainBalance.Text, out decimal remainingBalance))
                {
                    // Subtract amountPaid from remainingBalance
                    decimal newBalance = remainingBalance - amountPaid;

                    // Update txtRemainBalance with the new balance
                    txtRemainBalance.Text = newBalance.ToString("F2"); // Format as a decimal with 2 decimal places
                }
                else
                {
                    // Display error message if inputs are invalid
                    PopupNotification.PopUpMessages(0, "Please enter valid numeric values!", "INVALID INPUT");
                    txtAmountPaid.BackColor = Color.Yellow;
                    txtAmountPaid.Focus();
                    return;
                }
                
                cmbPaymentMethod.Focus();
                cmbPaymentMethod.BackColor = Color.Yellow;
            }
        }

        private void cmbPaymentMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                cmbPaymentMethod.BackColor = Color.White;
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

        private void paymentCredit()
        {
            if (string.IsNullOrWhiteSpace(txtAmountPaid.Text))
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                return;
            }
                splashScreen.ShowWaitForm();
                    var CreditSales = new Payment
                    {
                        credit_sale_id = _credit_sales.id,
                        amount_paid = decimal.Parse(txtAmountPaid.Text),
                        payment_method_id = FetchUtils.getPaymentMethod(cmbPaymentMethod.Text),
                        receipt_number = _credit_sales.receipt,
                        user_id = _userId,
                        branch_id = FetchUtils.getBranchId(cmbBranchName.Text),
                        remaining_balance = decimal.Parse(txtRemainBalance.Text),
                        payment_date = dkpDelivery.Value.Date
                    };
                    var result = RepositoryEntity.AddEntity<Payment>(CreditSales);
                    if (result > 0)
                    {
                        PopupNotification.PopUpMessages(1, "Customer: " + _credit_sales.customer + " Payment Successfully!", Messages.InventorySystem);
                        _main.received = 1;
                        Close();
                        splashScreen.CloseWaitForm();
                    }
                    else
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(0, "Customer: " + _credit_sales.customer + " Failed to Complete Payment!", Messages.InventorySystem);
                    }
        }
    }
}
