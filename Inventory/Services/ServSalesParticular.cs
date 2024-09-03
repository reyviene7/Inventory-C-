 

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
    public class ServSalesParticular: ISalesParticular
    {
        private IList<SalesParticularList> _list;

        public IEnumerable<SalesParticularList> DataSource()
        {
            _list = new List<SalesParticularList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new SalesParticularList()
                    {
                        Id = source.particular_id,
                        Item = source.product_name,
                        Price = source.unit_price,
                        Qty = source.quantity,
                        Gross = source.gross,
                        Net = source.net_sales,
                        Branch = source.branch_details,
                        Customer = source.customer_name,
                        Status = source.status_name,
                        Date = source.purchase_on
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportSalesParticular> SalesParticular(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportSalesParticular>(unWork);
                    return repository.SelectAll(Query.SelectReportSalesParticular)
                        .Where(x => x.purchase_on >= startDate)
                        .Where(x => x.purchase_on <= endDate)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static IEnumerable<ViewReportSalesParticular> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportSalesParticular>(unWork);
                    return repository.SelectAll(Query.SelectReportSalesParticular).ToList();
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
