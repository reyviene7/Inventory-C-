using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Inventory.Entities;

namespace Inventory.Report
{
    public partial class RepItemWareHouse : DevExpress.XtraReports.UI.XtraReport
    {
        public RepItemWareHouse()
        {
            InitializeComponent();
        }

        public void Load(IEnumerable<ViewReportWareHousetItem> dataSource)
        {
            DataSource = dataSource;
        }
    }
}
