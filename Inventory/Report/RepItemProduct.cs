 
using System.Collections.Generic;
 
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepItemProduct : DevExpress.XtraReports.UI.XtraReport
    {
        public RepItemProduct()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ProductList> source)
        {
            DataSource = source;
        }
    }
}
