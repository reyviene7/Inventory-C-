 
using System;
using System.Collections.Generic;
using Inventory.Class;


namespace Inventory.Interface
{
   public interface IWareHouseDelivery
   {
       IEnumerable<WarehouseDelivery> DataSource(string branch, DateTime startDate, DateTime endDate);
   }
}
