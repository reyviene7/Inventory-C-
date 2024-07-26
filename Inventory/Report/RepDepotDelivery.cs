using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepDepotDelivery : DevExpress.XtraReports.UI.XtraReport
    {
        public RepDepotDelivery()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<DepotDelivery> dSource)
        {
            DataSource = dSource;
        }

    }
}
