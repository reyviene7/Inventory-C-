using System;
using System.Linq;
using System.Windows.Forms;
using Inventory.MainForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using Inventory.Config;

namespace Inventory.PopupForm
{
    public partial class FirmPopInventoryBranch : Form
    {
        public FrmInventory Main { protected get;  set; }
        private readonly int _userId;
        private readonly int _userTy;
        private bool _return;
       
        public bool Return
        {
            get { return _return; }
            set { _return = value; }
        }

     

        public FirmPopInventoryBranch(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            InitializeComponent();
        }
        private void FirmPopInventoryBranch_Load(object sender, EventArgs e)
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
            var len = cmbDIS.Text.Length;
            if (len > 0)
            {
                var val = cmbDIS.Text.Trim(' ');
                if (_return)
                {
                    Main.DeliveryBranch = val;
                }
                Close();
            }

        }

        private void bntCAN_Click(object sender, EventArgs e)
        {
            if (_return == false)
            {
                //Main.Close = 1;
                Close();
            }
           
        }
        private int GetBranchId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_details == input);
                    return query.branch_id;
                }
                catch (Exception)
                {
                    PopupNotification.PopUpMessages(0, "Branch Id Error", "Branch Inventory Details");
                    throw;
                }
            }
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
