 

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
                        Id = source.inventory_id,
                        Item = source.product_name,
                        Qty = source.quantity_in_stock,
                        SKU = source.sku,
                        Warehouse = source.warehouse_name,
                        ItemCost = source.cost_per_unit,
                        LastCost = source.last_cost_per_unit,
                        Update = source.updated_at,
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
                        .Where(x => x.updated_at >= startDate)
                        .Where(x => x.updated_at <= endDate)
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
