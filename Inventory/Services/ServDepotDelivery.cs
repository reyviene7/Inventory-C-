using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Interface;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;

namespace Inventory.Services
{
    public class ServDepotDelivery: IDepotDelivery
    {
        public IEnumerable<DepotDelivery> DataSource(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<DepotDelivery>(unWork);
                    return repository.SelectAll(Query.SelectReportDepotDelivery)
                        .Where(x => x.Purchase >= startDate.Date)
                        .Where(x => x.Purchase <= endDate.Date).ToList();
                }
                catch (Exception e)
                {
                    Console.Write(e.ToString());
                    return null;

                }
            }
        }
    }
}
