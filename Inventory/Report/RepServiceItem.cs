using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepServiceItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RepServiceItem()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ServiceList> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
