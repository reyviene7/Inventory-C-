 

using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Config;
using Inventory.Interface;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.Services
{
    public class ServProductsLpg: IProductList
    {
        private IList<ProductList> _productLists;
        public IEnumerable<ProductList> DataSource()
        {
            _productLists = new List<ProductList>();
            foreach (var product in ProductLpg())
            {
                _productLists.Add(new ProductList
                {
                    Id = product.inventory_id,
                    Code = product.product_code,
                    Name = product.product_name,
                    Qty = product.quantity,
                    TradePrice = product.trade_price,
                    RetailPrice = product.retail_price,
                    Status = product.status
                });
            }
            return _productLists;
        }
        private static IEnumerable<ViewInventoryList> ProductLpg()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewInventoryList>(unWork);
                    return repository.SelectAll(Query.SelectReportAllItem)
                        .Where(x => x.product_name.Contains(Constant.AddFilterLpg))
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
