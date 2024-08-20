using System;
using System.Linq;
using System.Windows.Forms;
using Inventory.MainForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using Inventory.Config;
using ServeAll.Core.Utilities;

namespace Inventory.PopupForm
{
    public partial class FirmPopBranches : Form
    {
        public FirmWarehouse WarehouseMain { protected get; set; }
        public FirmWareHouseReturn ReturnBranch { protected get; set; }
        private readonly int _userId;
        private readonly int _userTy;
        private bool _return;

        public bool Return
        {
            get { return _return; }
            set { _return = value; }
        }

        public bool formManagement { get; internal set; }
        public FrmManagement management { get; internal set; }

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
                BindBranch();
                cmbDIS.Focus();
            }
            else
            {
                PopupNotification.PopUpMessages(0, "It requires administrator privillege to access warehouse delivery to branches!", Messages.InventorySystem);
                Close();
            }
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            var branch = cmbDIS.Text.Trim(' ');
            if (branch.Length > 0)
            {

                if (_return)
                {
                    var branchId = FetchUtils.getBranchId(branch);
                    ReturnBranch.BranchId = branchId;
                    ReturnBranch.branch = branch;
                }
                else
                {
                    WarehouseMain.DeliveryBranches = branch;
                }
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void bntCAN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void BindBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Branch>(unWork);
                var query = repository.SelectAll(ServeAll.Core.Queries.Query.AllBranch).Select(x => x.branch_details).Distinct().ToList();
                cmbDIS.DataBindings.Clear();
                cmbDIS.DataSource = query;
            }
        }
    }
}