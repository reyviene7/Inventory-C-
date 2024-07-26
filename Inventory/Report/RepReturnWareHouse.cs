using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepReturnWareHouse : DevExpress.XtraReports.UI.XtraReport
    {
        public RepReturnWareHouse()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ReturnWarehouse> dataSource)
        {
            DataSource = dataSource;
        }
    }
}
