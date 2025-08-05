 
 
using Inventory.Class;
using System.Collections.Generic;
using System.Linq;

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
            int recordCount = source != null ? source.Count() : 0;
            System.Diagnostics.Debug.WriteLine($"Record Count: {recordCount}"); // Log count for debugging
            xrLabel8.Text = $"Total: {recordCount}";
        }
    }
}
