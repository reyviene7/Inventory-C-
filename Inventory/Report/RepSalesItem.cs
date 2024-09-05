using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepSalesItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RepSalesItem()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<SalesList> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
