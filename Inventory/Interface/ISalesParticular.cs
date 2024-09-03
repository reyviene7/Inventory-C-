 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface ISalesParticular
    {
        IEnumerable<ViewReportSalesParticular> SalesParticular(DateTime startDate, DateTime endDate);
    }
}
