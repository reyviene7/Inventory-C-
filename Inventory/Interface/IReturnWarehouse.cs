 
using System;
using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Interface
{
    public interface IReturnWarehouse
    {
        IEnumerable<ReturnWarehouse> DataSource(string branch, DateTime startDate, DateTime endDate);
    }
}
