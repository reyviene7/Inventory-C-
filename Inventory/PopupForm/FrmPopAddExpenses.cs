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
    public partial class FrmPopAddExpenses : Form
    {
        private FrmManagement _main;
        private readonly int _userId;
        private readonly int _userType;
        private readonly ViewDailyExpenses _daily_expenses;
        private IEnumerable<ViewImageProduct> _imgList;

        public FrmManagement main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmPopAddExpenses(int userId, int userType)
        {
            _userId = userId;
            _userType = userType;
            InitializeComponent();
        }

        private void FrmPopAddExpenses_Load(object sender, EventArgs e)
        {
            //_imgList = EnumerableUtils.getImgProductList();
            var expensesType = EnumerableUtils.getExpensesType();
            var relatedEntity = EnumerableUtils.getRelatedEntity();
            var viewEmployees = EnumerableUtils.getEmployees();
            var typeName = expensesType.Select(type => type.type_name).ToList();
            var entity = relatedEntity.Select(related => related.related_entity).ToList();
            var employees = viewEmployees.Select(fullName => fullName.full_name).ToList();
            cmbExpensesType.Items.AddRange(typeName.ToArray());
            cmbRelatedEntity.Items.AddRange(entity.ToArray());
            cmbEmployee.Items.AddRange((employees.ToArray()));
            if (typeName.Any())
            {
                cmbExpensesType.Text = typeName.First(); 
            }

            if (entity.Any())
            {
                cmbRelatedEntity.Text = entity.First();
            }
            if (employees.Any())
            {
                cmbEmployee.Text = employees.First();
            }
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
            expenseAdded();
        }

        private void txtAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text) && e.KeyChar == (char)Keys.Enter)
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                txtAmount.Focus();
                txtAmount.BackColor = Color.Yellow;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txtAmount.Focus();
                txtAmount.BackColor = Color.Yellow;
            }
            else
            {
                txtAmount.BackColor = Color.White;
            }
        }

        private void txtAmountPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                txtAmount.BackColor = Color.White;
                
                if (decimal.TryParse(txtAmount.Text, out decimal amountPaid) &&
                    decimal.TryParse(cmbRelatedEntity.Text, out decimal remainingBalance))
                {
                    // Subtract amountPaid from remainingBalance
                    decimal newBalance = remainingBalance - amountPaid;

                    // Update txtRemainBalance with the new balance
                    cmbRelatedEntity.Text = newBalance.ToString("F2"); // Format as a decimal with 2 decimal places
                }
                else
                {
                    // Display error message if inputs are invalid
                    PopupNotification.PopUpMessages(0, "Please enter valid numeric values!", "INVALID INPUT");
                    txtAmount.BackColor = Color.Yellow;
                    txtAmount.Focus();
                    return;
                }
            }
        }

        private void dkpDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Enter)
            {
                dkpExpensesDate.BackColor = Color.White;
                bntAccept.Focus();
            }
        }

        private void expenseAdded()
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                return;
            }
                splashScreen.ShowWaitForm();
                    var DailyExpenses = new DailyExpenses()
                    {
                        expense_type_id = FetchUtils.getExpensesType(cmbExpensesType.Text),
                        amount = decimal.Parse(txtAmount.Text),
                        entity_id = FetchUtils.getRelatedEntity(cmbRelatedEntity.Text),
                        employee_id = FetchUtils.getEmployee(cmbEmployee.Text),
                        description = txtDescription.Text,
                        expense_date = dkpExpensesDate.Value.Date
                    };
                    var result = RepositoryEntity.AddEntity<DailyExpenses>(DailyExpenses);
                    if (result > 0)
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,  "New Expense: " + " Added Successfully!", Messages.InventorySystem);
                        _main.received = 1;
                        Close();
                    }
                    else
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(0, "Expense: " + " Failed to Complete!", Messages.InventorySystem);
                    }
        }
    }
}
