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
        private void bntExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntAccept_Click(object sender, EventArgs e)
        {
            expenseAdded();
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
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
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
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
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
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
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
                        profile_id = FetchUtils.getProfileId(cmbEmployee.Text),
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
