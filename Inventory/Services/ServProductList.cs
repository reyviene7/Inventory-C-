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
    public class ServProductList: IProductList
    {
        private IList<ProductList> _list;
        public IEnumerable<ProductList> DataSource()
        {
            _list = new List<ProductList>();
            foreach (var source in Source())
            {
                _list.Add(new ProductList()
                 {
                     Id = source.ProductId, 
                     Code = source.Code,
                     Name = source.Name,
                     TradePrice = source.TradePrice,
                     RetailPrice = source.RetailPrice
                 });
            }
            return _list;
        }
        public IEnumerable<ProductList> DataSourceLpg()
        {
            _list = new List<ProductList>();
            foreach (var source in SourceLpg())
            {
                _list.Add(new ProductList()
                {
                    Id = source.ProductId,
                    Code = source.Code,
                    Name = source.Name,
                    TradePrice = source.TradePrice,
                    RetailPrice = source.RetailPrice
                });
            }
            return _list;
        }
        private static IEnumerable<Products> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    return repository.SelectAll(Query.SelectReportAllItem).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static IEnumerable<Products> SourceLpg()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    return repository.SelectAll(Query.SelectReportAllItem)
                        
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
