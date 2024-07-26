 

using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Interface;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;

namespace Inventory.Services
{
   public class ServReturnWareHouse: IReturnWarehouse
    {
       public IEnumerable<ReturnWarehouse> DataSource(string branch, DateTime startDate, DateTime endDate)
       {
           using (var session = new DalSession())
           {
               var unWork = session.UnitofWrk;
               try
               {
                    var repository = new Repository<ReturnWarehouse>(unWork);
                   return repository.SelectAll(Query.SelectReportReturnWarehos)
                        .Where(x=> x.Origin == branch)
                        .Where(x => x.RetDate >= startDate)
                        .Where(x=>x.RetDate<=endDate)
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
