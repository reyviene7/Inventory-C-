 

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
                    Id = product.ProductId, 
                    Code = product.Code, 
                    Name = product.Name,
                    TradePrice = product.TradePrice, 
                    RetailPrice = product.RetailPrice
                });
            }
            return _productLists;
        }
        private static IEnumerable<Products> ProductLpg()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    return repository.SelectAll(Query.SelectReportAllItem)
                        .Where(x => x.Name.Contains(Constant.AddFilterLpg))
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
