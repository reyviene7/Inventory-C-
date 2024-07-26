using System;
using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Interface
{
    public interface IDepotDelivery
    {
        IEnumerable<DepotDelivery> DataSource(DateTime startDate, DateTime endDate);
    }
}
