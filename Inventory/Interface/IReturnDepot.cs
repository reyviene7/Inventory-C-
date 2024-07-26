using System;
using System.Collections.Generic;
using Inventory.Class;

namespace Inventory.Interface
{
   public interface IReturnDepot
   {
       IEnumerable<ReturnDepot> DataSource(DateTime startDate, DateTime endDate);
   }
}
