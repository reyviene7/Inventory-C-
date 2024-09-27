using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepDailyExpenses : DevExpress.XtraReports.UI.XtraReport
    {
        public RepDailyExpenses()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<DailyExpenses> expenseslist)
        {
            DataSource = expenseslist;
        }

    }
}
