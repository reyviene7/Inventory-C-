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
   public class ServWareHouseDelivery: IWareHouseDelivery
   {
        private IList<WarehouseDelivery> _list;

        public IEnumerable<WarehouseDelivery> DataSource(string branch, DateTime startDate, DateTime endDate)
        {
            _list = new List<WarehouseDelivery>();
            var sources = WarehouseDelivery(branch, startDate, endDate);
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new WarehouseDelivery()
                    {
                        Id = source.delivery_id,
                        Item = source.product_name,
                        Qty = source.quantity_in_stock,
                        Delivery = source.delivery_code,
                        Branch = source.branch_details,
                        LastCost = source.last_cost_per_unit,
                        RetailPrice = source.retail_price,
                        DeliveryDate = source.delivery_date,
                        Status = source.status_details
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportWareHousetDelivery> WarehouseDelivery(string branch, DateTime startDate, DateTime endDate)
        {
           using (var session = new DalSession())
           {
               var unWork = session.UnitofWrk;
               try
               {
                    var repository = new Repository<ViewReportWareHousetDelivery>(unWork);
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
        private static IEnumerable<ViewReportWareHousetDelivery> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportWareHousetDelivery>(unWork);
                    return repository.SelectAll(Query.SelectReportWareHouseDelr).ToList();
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
