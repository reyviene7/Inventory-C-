 

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
    public class ServWarehouseItem: IWareHouseItem
    {
        private IList<WarehouseInventory> _list;

        public IEnumerable<WarehouseInventory> DataSource(DateTime startDate, DateTime endDate)
        {
            _list = new List<WarehouseInventory>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new WarehouseInventory()
                    {
                        Id = source.delivery_id,
                        Item = source.product_name,
                        Qty = source.quantity_in_stock,
                        Delivery = source.delivery_code,
                        Branch = source.branch_details,
                        LastCost = source.last_cost_per_unit,
                        RetailPrice = source.retail_price,
                        Purchase = source.delivery_date,
                        Status = source.status_details
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportWareHousetItem> WareHouseItem(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportWareHousetItem>(unWork);
                    return repository.SelectAll(Query.SelectReportWareHouseItem)
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
        private static IEnumerable<ViewReportWareHousetItem> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportWareHousetItem>(unWork);
                    return repository.SelectAll(Query.SelectReportWareHouseItem).ToList();
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
