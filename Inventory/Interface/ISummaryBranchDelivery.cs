using System;
using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Interface
{
    public interface ISummaryBranchDelivery
    {
        IEnumerable<SummaryBranchDelivery> GetSummary(DateTime starDate, DateTime endn, int branchId);
    }
}