using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Interface;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;


namespace Inventory.Services
{
   public class ServWareHouseDelivery: IWareHouseDelivery
    {
       public IEnumerable<WarehouseDelivery> DataSource(string branch, DateTime startDate, DateTime endDate)
       {
           using (var session = new DalSession())
           {
               var unWork = session.UnitofWrk;
               try
               {
                    var repository = new Repository<WarehouseDelivery>(unWork);
                   return repository.SelectAll(Query.SelectReportWareHouseDelr)
                       .Where(x => x.branch_details == branch)
                       .Where(x => x.delivery_date >= startDate)
                       .Where(x => x.delivery_date <= endDate)
                       .ToList();
               }
               catch (Exception e)
               {
                   Console.WriteLine(e.ToString());
                   return null;
               }
           }
       }
    }
}
