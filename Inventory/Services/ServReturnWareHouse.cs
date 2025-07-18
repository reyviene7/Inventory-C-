 

using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Entities;
using Inventory.Interface;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;

namespace Inventory.Services
{
   public class ServReturnWareHouse: IReturnWarehouse
   {
        private IList<ReturnWarehouse> _list;

        public IEnumerable<ReturnWarehouse> DataSource(string branch, DateTime startDate, DateTime endDate)
        {
            _list = new List<ReturnWarehouse>();
            var sources = ReturnWarehouse(branch, startDate, endDate);
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new ReturnWarehouse()
                    {
                        Id = source.return_id,
                        Item = source.product_name,
                        Qty = source.return_quantity,
                        Delivery = source.return_number,
                        Origin = source.branch_details,
                        RetailPrice = source.retail_price,
                        RetDate = source.return_date,
                        Status = source.status,
                        Remarks = source.remarks
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReturnWarehouse> ReturnWarehouse(string branch, DateTime startDate, DateTime endDate)
        {
           using (var session = new DalSession())
           {
               var unWork = session.UnitofWrk;
               try
               {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                   return repository.SelectAll(Query.SelectReportReturnWarehos)
                        .Where(x=> x.branch_details == branch)
                        .Where(x => x.return_date >= startDate)
                        .Where(x=>x.return_date <= endDate)
                        .ToList();
               }
               catch (Exception e)
               {
                    Console.WriteLine(e.ToString());
                   return null;
               }
           }
        }
        private static IEnumerable<ViewReturnWarehouse> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.SelectAll(Query.SelectReportReturnWarehos).ToList();
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
