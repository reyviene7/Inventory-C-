
using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Interface;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
namespace Inventory.Services
{
    public class ServReturnDepot: IReturnDepot
    {
        public IEnumerable<ReturnDepot> DataSource(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ReturnDepot>(unWork);
                    return repository.SelectAll(Query.SelectReportReturnDepotDl)
                        .Where(x=> x.Delivery>=startDate)
                        .Where(x=> x.Delivery <= endDate)
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
