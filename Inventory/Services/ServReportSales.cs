 

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
    public class ServReportSales: ISalesItem
    {
        private IList<SalesList> _list;

        public IEnumerable<SalesList> DataSource()
        {
            _list = new List<SalesList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new SalesList()
                    {
                        Id = source.sale_id,
                        CustomerName = source.customer_name,
                        Due = source.amount_due,
                        Paid = source.paid_amount,
                        Gross = source.gross,
                        Discount = source.discount,
                        Net = source.net_sales,
                        Branch = source.branch_details,
                        Receipt = source.receipt_number,
                        Date = source.sale_date
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportSales> SalesItem(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportSales>(unWork);
                    return repository.SelectAll(Query.SelectReportSales)
                        .Where(x => x.sale_date >= startDate)
                        .Where(x => x.sale_date <= endDate)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static IEnumerable<ViewReportSales> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportSales>(unWork);
                    return repository.SelectAll(Query.SelectReportSales).ToList();
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
