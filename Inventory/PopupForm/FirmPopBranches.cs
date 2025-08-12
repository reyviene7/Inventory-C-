using System;
using System.Linq;
using System.Windows.Forms;
using Inventory.MainForm;
using ServeAll.Core.Entities;
using Inventory.Config;
using ServeAll.Core.Utilities;
using System.Collections.Generic;

namespace Inventory.PopupForm
{
    public partial class FirmPopBranches : Form
    {
        public FirmWarehouse Main { protected get; set; }
        public FirmWareHouseReturn ReturnBranch { protected get; set; }
        public FrmManagement management { protected get; set; }
        private IEnumerable<Branch> _branches;
        private readonly int _userId;
        private readonly int _userTy;
        private bool _return;
        private bool _management;

        public bool Return
        {
            get { return _return; }
            set { _return = value; }
        }

        public bool formManagement
        {
            get { return _management; }
            set { _management = value; }
        }
        public FirmPopBranches(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            InitializeComponent();
        }
        private void FirmPopBranches_Load(object sender, EventArgs e)
        {
            if (_userId != 0 && _userTy == 1)
            {
                _branches = EnumerableUtils.getBranches();
                cmbBranchName.DataBindings.Clear();
                cmbBranchName.DataSource = _branches.Select(x => x.branch_details).Distinct().ToList();
                cmbBranchName.Focus();
            }
            else
            {
                PopupNotification.PopUpMessages(0, "It requires administrator privillege to access warehouse delivery to branches!", Messages.InventorySystem);
                Close();
            }
        }

        private void bntGoBranch_Click(object sender, EventArgs e)
        {
            var branch = cmbBranchName.Text.Trim(' ');
            if (branch.Length > 0)
            {
                var branchId = FetchUtils.getBranchId(branch);
                if (_return)
                {
                    ReturnBranch.BranchId = branchId;
                    ReturnBranch.branch = branch;
                }
                if (_management)
                {
                    management.branch = branch;
                    management.branchId = branchId;
                }
                DialogResult = DialogResult.OK;
                Close();
            }

        }
        private void bntClose_Click(object sender, EventArgs e)
        {
            if (_return == true)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            if (_management == true)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void cmbBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bntGoBranch.Focus();
            }
        }
    }
}