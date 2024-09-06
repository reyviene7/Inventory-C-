 

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
    public class ServServiceParticular: IServiceParticular
    {
        private IList<ServiceParticularList> _list;

        public IEnumerable<ServiceParticularList> DataSource()
        {
            _list = new List<ServiceParticularList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new ServiceParticularList()
                    {
                        Id = source.particular_id,
                        Name = source.service_name,
                        Charge = source.service_charge,
                        Tax = source.tax,
                        Discount = source.discount,
                        Gross = source.gross,
                        Net = source.net_sales,
                        Customer = source.customer_name,
                        Status = source.status_name,
                        Date = source.service_on
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportServiceParticular> ServiceParticular(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportServiceParticular>(unWork);
                    return repository.SelectAll(Query.SelectReportServiceParticular)
                        .Where(x => x.service_on >= startDate)
                        .Where(x => x.service_on <= endDate)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static IEnumerable<ViewReportServiceParticular> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportServiceParticular>(unWork);
                    return repository.SelectAll(Query.SelectReportServiceParticular).ToList();
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
