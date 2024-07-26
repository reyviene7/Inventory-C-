using System;
using System.Windows.Forms;
using Inventory.Config;
using Inventory.MainForm;

namespace Inventory.PopupForm
{
    public partial class FirmPopDateEntries : Form
    {
        public FirmMain Main { get; set; }
        private readonly string _fullname;
        private readonly int _reportType;
        public FirmPopDateEntries(string fullname, int reportType)
        {
            _fullname = fullname;
            _reportType = reportType;
            InitializeComponent();
        }
        private void DepotDeliveries()
        {
            ReportSetting.DepotDeliver(dkpSTR.Value.Date, dkpEND.Value.Date, _fullname);
        }
        private void WareHouseItem()
        {
            ReportSetting.WareHouseItem(dkpSTR.Value.Date, dkpEND.Value.Date, _fullname);
        }
        private void ReturnDeliveryDepot()
        {
            ReportSetting.ReturnDepot(dkpSTR.Value.Date, dkpEND.Value.Date, _fullname);
        }
        private void bntSVA_Click(object sender, EventArgs e)
        {
            switch (_reportType)
            {
                case 1:
                    DepotDeliveries();
                    Close();
                    break;
                case 2:
                    WareHouseItem();
                    Close();
                    break;
                case 5: 
                    ReturnDeliveryDepot();
                    Close();
                    break;
            }
            
        }
        private void bntCAN_Click(object sender, EventArgs e)
        {
            Close();
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
