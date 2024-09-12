using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepPaymentItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RepPaymentItem()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<PaymentList> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
