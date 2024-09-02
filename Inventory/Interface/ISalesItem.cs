 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface ISalesItem
    {
        IEnumerable<ViewReportSales> SalesItem(DateTime startDate, DateTime endDate);
    }
}
