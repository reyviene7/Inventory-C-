using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepSalesParticular : DevExpress.XtraReports.UI.XtraReport
    {
        public RepSalesParticular()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<SalesParticularList> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
