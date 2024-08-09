using Inventory.Config;
using Inventory.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventory.MainForm;

namespace Inventory.PopupForm
{
    public partial class FirmPopWarehouses : Form
    {

        public FirmWareHouseDelivery ReturnWarehouse { protected get; set; }
        private readonly int _userId;
        private readonly int _userTy;
        private bool _return;

        public bool Return
        {
            get { return _return; }
            set { _return = value; }
        }
        public FirmPopWarehouses(int userId, int userTy)
        {
            _userId = userId;
            _userTy = userTy;
            InitializeComponent();
        }

        private void FirmPopWarehouses_Load(object sender, EventArgs e)
        {
             if (_userId != 0 && _userTy == 1)
            {
                BindWarehouse();
                cmbWarehouses.Focus();
            }
            else
            {
                PopupNotification.PopUpMessages(0, "It requires administrator privillege to access warehouse delivery to branches!", Messages.GasulPos);
                Close();
            }
        }

        private int GetWarehouseId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Warehouse>(unWork);
                    var query = repository.FindBy(x => x.warehouse_name == input);
                    return query.warehouse_Id;
                }
                catch (Exception ex)
                {
                    PopupNotification.PopUpMessages(0, "Warehouse Id Error", "Warehouse Inventory Details");
                    throw;
                }
            }
        }

        private void BindWarehouse()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Warehouse>(unWork);
                var query = repository.SelectAll(ServeAll.Core.Queries.Query.AllWarehouse).Select(x => x.warehouse_name).Distinct().ToList();
                cmbWarehouses.DataBindings.Clear();
                cmbWarehouses.DataSource = query;
            }
        }

        private void bntSAVE_Click(object sender, EventArgs e)
        {
            var length = cmbWarehouses.Text.Length;
            if (length > 0)
            {
                var val = cmbWarehouses.Text.Trim(' ');
                if (_return)
                {
                    var warehouseId = GetWarehouseId(val);
                    ReturnWarehouse.Warehouse = warehouseId;
                }
                else 
                {
                    _return = false;
                }
                Close();
            }
        }
    }
}
