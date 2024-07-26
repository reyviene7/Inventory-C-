 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface IWareHouseItem
    {
        IEnumerable<ViewReportWareHousetItem> WareHouseItem(DateTime startDate, DateTime endDate);
    }
}
