using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepServiceParticular : DevExpress.XtraReports.UI.XtraReport
    {
        public RepServiceParticular()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ServiceParticularList> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
