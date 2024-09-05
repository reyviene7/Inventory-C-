using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepCreditParticular : DevExpress.XtraReports.UI.XtraReport
    {
        public RepCreditParticular()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<CreditParticularList> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
