using System;
using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Report
{
    public partial class RepReturnDepot : DevExpress.XtraReports.UI.XtraReport
    {
        public RepReturnDepot()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ReturnDepot> dataSource)
        {
            DataSource = dataSource;
        }

    }
}
