 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface IServiceItem
    {
        IEnumerable<ViewReportService> ServiceItem(DateTime startDate, DateTime endDate);
    }
}
