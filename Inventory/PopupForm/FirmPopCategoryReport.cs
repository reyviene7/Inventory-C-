using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Inventory.Config;
using Inventory.MainForm;
using Inventory.Services;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.PopupForm
{
    public partial class FirmPopCategoryReport : Form
    {
        public FirmMain Main;
        private readonly string _fullName;
        private readonly int _reportType;
        public FirmPopCategoryReport(string fullName, int reportType)
        {
            _fullName = fullName;
            _reportType = reportType;
            InitializeComponent();
        }
        private void FirmPopCategoryReport_Load(object sender, EventArgs e)
        {
            BindBranch();
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            
            switch (_reportType)
            {
                case 3:
                    ShowWareHouseDelivery();
                    Close();
                    break;
                case 4: 
                    ShowReturnWarehouseDelivery();
                    Close();
                    break;
                case 6: 
                    ShowSummaryWarehouseDelivery();
                    Close();
                    break;
            }
        }

        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BindBranch()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                var repository = new Repository<Branch>(unWork);
                var query = repository.SelectAll(Query.AllBranch).Select(x => x.BranchDetails).Distinct().ToList();
                cmbDIS.DataBindings.Clear();
                cmbDIS.DataSource = query;
            }
        }

        private void ShowWareHouseDelivery()
        {
            var startDate = dkpSTR.Value.Date;
            var endngDate = dkpEND.Value.Date;
            var branchNam = cmbDIS.Text.Trim(' ');
            Config.ReportSetting.WareHouseDelivery(branchNam, startDate, endngDate, _fullName);
        }

        private void ShowReturnWarehouseDelivery()
        {
            var startDate = dkpSTR.Value.Date;
            var endngDate = dkpEND.Value.Date;
            var branchNam = cmbDIS.Text.Trim(' ');
            Config.ReportSetting.ReturnWareHouseDelivery(branchNam, startDate, endngDate, _fullName);
        }

        public void ShowSummaryWarehouseDelivery()
        {
            var startDate = dkpSTR.Value.Date;
            var endngDate = dkpEND.Value.Date;
            var branchNam = cmbDIS.Text.Trim(' ');
            ReportSetting.DailySummaryWareHouseDelivery(startDate, endngDate, _fullName, branchNam);
        }


        private void cmbDIS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = cmbDIS.Text.Length;
                if (len > 0)
                {
                    dkpSTR.Focus();
                }
            }
        }

        private void dkpSTR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dkpEND.Focus();
            }
        }

        private void dkpEND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bntSVA.Focus();
            }
        }
    }
}
