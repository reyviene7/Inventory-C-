 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface IServiceParticular
    {
        IEnumerable<ViewReportServiceParticular> ServiceParticular(DateTime startDate, DateTime endDate);
    }
}
