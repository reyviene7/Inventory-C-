 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface ICreditParticular
    {
        IEnumerable<ViewReportCreditParticular> CreditParticular(DateTime startDate, DateTime endDate);
    }
}
