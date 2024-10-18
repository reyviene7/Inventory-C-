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
    public partial class FrmPopUpdateExpenses : Form
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

        public FrmPopUpdateExpenses(int userId, int userType, ViewDailyExpenses dailyExpenses)
        {
            _userId = userId;
            _userType = userType;
            _daily_expenses = dailyExpenses;
            InitializeComponent();
        }

        private void FrmPopUpdateExpenses_Load(object sender, EventArgs e)
        {
            cmbExpensesType.Text = _daily_expenses.type_name;
            txtAmount.Text = _daily_expenses.amount.ToString();
            cmbRelatedEntity.Text = _daily_expenses.related_entity;
            txtDescription.Text = _daily_expenses.description;
            cmbEmployee.Text = _daily_expenses.full_name;
            dkpExpensesDate.Value = _daily_expenses.expense_date;

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
            expenseUpdate();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbExpensesType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrWhiteSpace(cmbExpensesType.Text))
                {
                    PopupNotification.PopUpMessages(0, "Expense Type must not be empty!", Messages.InventorySystem);
                    cmbExpensesType.BackColor = Color.Yellow;
                    cmbExpensesType.Focus();
                }
                else
                {
                    cmbExpensesType.BackColor = Color.White;
                    txtAmount.Focus();
                    txtAmount.BackColor = Color.Yellow;
                }
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    PopupNotification.PopUpMessages(0, "Amount must not be empty!", Messages.InventorySystem);
                    txtAmount.BackColor = Color.Yellow;
                    txtAmount.Focus();
                }
                else
                {
                    txtAmount.BackColor = Color.White;
                    cmbRelatedEntity.Focus();
                    cmbRelatedEntity.BackColor = Color.Yellow;
                }
            }
        }

        private void cmbRelatedEntity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrWhiteSpace(cmbRelatedEntity.Text))
                {
                    PopupNotification.PopUpMessages(0, "Related Entity must not be empty!", Messages.InventorySystem);
                    cmbRelatedEntity.BackColor = Color.Yellow;
                    cmbRelatedEntity.Focus();
                }
                else
                {
                    cmbRelatedEntity.BackColor = Color.White;
                    txtDescription.Focus();
                    txtDescription.BackColor = Color.Yellow;
                }
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    PopupNotification.PopUpMessages(0, "Description must not be empty!", Messages.InventorySystem);
                    txtDescription.BackColor = Color.Yellow;
                    txtDescription.Focus();
                }
                else
                {
                    txtDescription.BackColor = Color.White;
                    cmbEmployee.Focus();
                    cmbEmployee.BackColor = Color.Yellow;
                }
            }
        }

        private void cmbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrWhiteSpace(cmbEmployee.Text))
                {
                    PopupNotification.PopUpMessages(0, "Description must not be empty!", Messages.InventorySystem);
                    cmbEmployee.BackColor = Color.Yellow;
                    cmbEmployee.Focus();
                }
                else
                {
                    cmbEmployee.BackColor = Color.White;
                    dkpExpensesDate.Focus();
                    dkpExpensesDate.BackColor = Color.Yellow;
                }
            }
        }

        private void dkpExpensesDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Enter)
            {
                dkpExpensesDate.BackColor = Color.White;
                bntAccept.Focus();
            }
        }

        private void expenseUpdate()
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                PopupNotification.PopUpMessages(0, "Please enter a numeric value!", "EMPTY INPUT");
                return;
            }

            var expenseId = _daily_expenses.expense_id;
            if (expenseId > 0)
            {
                splashScreen.ShowWaitForm();
                try
                {
                    var result = RepositoryEntity.UpdateEntity<DailyExpenses>(expenseId, DailyExpenses =>
                    {
                        DailyExpenses.expense_type_id = FetchUtils.getExpensesType(cmbExpensesType.Text);
                        DailyExpenses.amount = decimal.Parse(txtAmount.Text);
                        DailyExpenses.employee_id = FetchUtils.getEmployee(cmbEmployee.Text);
                        DailyExpenses.entity_id = FetchUtils.getRelatedEntity(cmbRelatedEntity.Text);
                        DailyExpenses.description = txtDescription.Text;
                        DailyExpenses.expense_date = DateTime.Now.Date;
                    });
                    if (result > 0)
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Update Expense: " + " Successfully Complete!",
                            Messages.InventorySystem);
                        _main.received = 1;
                        Close();
                    }
                    else
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(0, "Update Expense: " + " Failed to Complete!", Messages.InventorySystem);
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
