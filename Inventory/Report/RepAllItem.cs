using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepAllItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RepAllItem()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ProductList> productlist)
        {
            DataSource = productlist;
        }

    }
}
