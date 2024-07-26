 

using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Entities;
using Inventory.Interface;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;

namespace Inventory.Services
{
    public class ServWarehouseItem: IWareHouseItem
    {
        public IEnumerable<ViewReportWareHousetItem> WareHouseItem(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportWareHousetItem>(unWork);
                    return repository.SelectAll(Query.SelectReportWareHouseItem)
                        .Where(x => x.Purchase >= startDate)
                        .Where(x=> x.Purchase <= endDate)
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
