using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Entities;
using Inventory.Interface;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.Services
{
    public class ServInventoryList : IInventoryList
    {
        private IList<InventoryList> _list;

        public IEnumerable<InventoryList> DataSource()
        {
            _list = new List<InventoryList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new InventoryList()
                    {
                        Id = source.inventory_id,
                        Code = source.product_code,
                        Name = source.product_name,
                        Qty = source.quantity,
                        TradePrice = source.trade_price,
                        RetailPrice = source.retail_price,
                        Status = source.status
                    });
                }
            }
            return _list;
        }

        public IEnumerable<InventoryList> DataSourceProduct()
        {
            _list = new List<InventoryList>();
            var sources = SourceProduct();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new InventoryList()
                    {
                        Id = source.inventory_id,
                        Code = source.product_code,
                        Name = source.product_name,
                        Qty = source.quantity,
                        TradePrice = source.trade_price,
                        RetailPrice = source.retail_price,
                        Status = source.status
                    });
                }
            }
            return _list;
        }

        private static IEnumerable<ViewReportInventoryList> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportInventoryList>(unWork);
                    return repository.SelectAll(Query.SelectReportAllItem).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        private static IEnumerable<ViewReportInventoryList> SourceProduct()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportInventoryList>(unWork);
                    return repository.SelectAll(Query.SelectReportAllItem).ToList();
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
