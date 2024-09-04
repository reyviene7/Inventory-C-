using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepCreditItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RepCreditItem()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<CreditList> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
