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
       public IEnumerable<BranchDelivery> DataSource(string branch, DateTime startDate, DateTime endDate)
       {
           using (var session = new DalSession())
           {
               var unWork = session.UnitofWrk;
               try
               {
                    var repository = new Repository<BranchDelivery>(unWork);
                   return repository.SelectAll(Query.SelectReportWareHouseDelr)
                       .Where(x => x.Branch == branch)
                       .Where(x => x.RefDate >= startDate)
                       .Where(x => x.RefDate <= endDate)
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
