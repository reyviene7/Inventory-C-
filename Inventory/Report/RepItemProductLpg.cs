 
using System.Collections.Generic;
 
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepItemProductLpg : DevExpress.XtraReports.UI.XtraReport
    {
        public RepItemProductLpg()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ProductList> source)
        {
            DataSource = source;
        }
    }
}
