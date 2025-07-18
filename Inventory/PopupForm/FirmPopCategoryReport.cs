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
        public FirmMain Main { get; set; }
        public FrmManagement main { get; set; }
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
        private void ShowWareHouseDelivery()
        {
            var startDate = dkpSTR.Value.Date;
            var endngDate = dkpEND.Value.Date;
            var branchNam = cmbDIS.Text.Trim(' ');
            ReportSetting.WareHouseDelivery(branchNam, startDate, endngDate, _fullName);
        }

        private void ShowReturnWarehouseDelivery()
        {
            var startDate = dkpSTR.Value.Date;
            var endngDate = dkpEND.Value.Date;
            var branchNam = cmbDIS.Text.Trim(' ');
            ReportSetting.ReturnWareHouseDelivery(branchNam, startDate, endngDate, _fullName);
        }

        public void ShowSummaryWarehouseDelivery()
        {
            var startDate = dkpSTR.Value.Date;
            var endngDate = dkpEND.Value.Date;
            var branchNam = cmbDIS.Text.Trim(' ');
            ReportSetting.DailySummaryWareHouseDelivery(startDate, endngDate, _fullName, branchNam);
        }

        public void ShowSalesReport()
        {
            var startDate = dkpSTR.Value.Date;
            var endngDate = dkpEND.Value.Date;
            var branchNam = cmbDIS.Text.Trim(' ');
            ReportSetting.ListofSalesItem(branchNam, startDate, endngDate, _fullName);
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_reportType)
                {
                    case 1:
                        ShowWareHouseDelivery();
                        break;
                    case 2:
                        ShowReturnWarehouseDelivery();
                        break;
                    case 5:
                        ShowSummaryWarehouseDelivery();
                        break;
                    case 6:
                        ShowSalesReport();
                        break;
                    default:
                        MessageBox.Show("Invalid report type.");
                        return;
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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
                var query = repository.SelectAll(Query.AllBranch).Select(x => x.branch_details).Distinct().ToList();
                cmbDIS.DataBindings.Clear();
                cmbDIS.DataSource = query;
            }
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
