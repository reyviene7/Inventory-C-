 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface ICreditItem
    {
        IEnumerable<ViewReportCredit> CreditItem(DateTime startDate, DateTime endDate);
    }
}
