using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepSummaryBranchDelivery : DevExpress.XtraReports.UI.XtraReport
    {
        public RepSummaryBranchDelivery()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<SummaryBranchDelivery> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
