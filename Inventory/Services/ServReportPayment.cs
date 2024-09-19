 

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
    public class ServReportPayment: IPaymentItem
    {
        private IList<PaymentList> _list;

        public IEnumerable<PaymentList> DataSource()
        {
            _list = new List<PaymentList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new PaymentList()
                    {
                        Id = source.payment_id,
                        Customer = source.customer_name,
                        Due = source.amount_due,
                        Paid = source.amount_paid,
                        Balance = source.remaining_balance,
                        PaymentMethod = source.payment_method,
                        Branch = source.branch_details,
                        CreditCode = source.credit_code,
                        RefNum = source.receipt_number,
                        Date = source.payment_date
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportPayment> PaymentItem(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportPayment>(unWork);
                    return repository.SelectAll(Query.SelectReportPayment)
                        .Where(x => x.payment_date >= startDate)
                        .Where(x => x.payment_date <= endDate)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static IEnumerable<ViewReportPayment> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportPayment>(unWork);
                    return repository.SelectAll(Query.SelectReportPayment).ToList();
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
