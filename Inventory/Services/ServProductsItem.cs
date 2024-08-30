 

using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Entities;
using Inventory.Config;
using Inventory.Interface;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.Services
{
    public class ServProductsItem: IProductList
    {
        private IList<ProductList> _productLists;
        public IEnumerable<ProductList> DataSource()
        {
            _productLists = new List<ProductList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _productLists.Add(new ProductList
                    {
                        Id = source.product_id,
                        Barcode = source.product_code,
                        Name = source.product_name,
                        TradePrice = source.trade_price,
                        RetailPrice = source.retail_price,
                    });
                }
            }
            return _productLists;
        }
        private static IEnumerable<ViewReportProductList> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportProductList>(unWork);
                    return repository.SelectAll(Query.SelectReportProduct).ToList();
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
