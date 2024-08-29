using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepWareHouseDelivery : DevExpress.XtraReports.UI.XtraReport
    {
        public RepWareHouseDelivery()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<WarehouseDelivery> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
