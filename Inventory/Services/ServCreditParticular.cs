 

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
    public class ServCreditParticular: ICreditParticular
    {
        private IList<CreditParticularList> _list;

        public IEnumerable<CreditParticularList> DataSource()
        {
            _list = new List<CreditParticularList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new CreditParticularList()
                    {
                        Id = source.particular_id,
                        Item = source.product_name,
                        Qty = source.quantity,
                        Price = source.unit_price,
                        Gross = source.gross,
                        Net = source.net_sales,
                        Branch = source.branch_details,
                        Customer = source.customer_name,
                        Date = source.purchase_on
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportCreditParticular> CreditParticular(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportCreditParticular>(unWork);
                    return repository.SelectAll(Query.SelectReportCreditParticular)
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
        private static IEnumerable<ViewReportCreditParticular> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportCreditParticular>(unWork);
                    return repository.SelectAll(Query.SelectReportCreditParticular).ToList();
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
