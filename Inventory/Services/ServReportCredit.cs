 

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
    public class ServReportCredit: ICreditItem
    {
        private IList<CreditList> _list;

        public IEnumerable<CreditList> DataSource()
        {
            _list = new List<CreditList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new CreditList()
                    {
                        Id = source.credit_id,
                        CustomerName = source.customer_name,
                        Credit = source.amount_credit,
                        Paid = source.paid_amount,
                        Discount = source.discount,
                        Net = source.net_sales,
                        Branch = source.branch_details,
                        Service = source.service_number,
                        Date = source.credit_date
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportCredit> CreditItem(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportCredit>(unWork);
                    return repository.SelectAll(Query.SelectReportCredit)
                        .Where(x => x.credit_date >= startDate)
                        .Where(x => x.credit_date <= endDate)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static IEnumerable<ViewReportCredit> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportCredit>(unWork);
                    return repository.SelectAll(Query.SelectReportCredit).ToList();
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
