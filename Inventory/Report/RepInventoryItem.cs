using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepInventoryItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RepInventoryItem()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<InventoryList> productlist)
        {
            DataSource = productlist;
        }

    }
}
