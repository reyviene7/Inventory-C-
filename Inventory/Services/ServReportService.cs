 

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
    public class ServReportService: IServiceItem
    {
        private IList<ServiceList> _list;

        public IEnumerable<ServiceList> DataSource()
        {
            _list = new List<ServiceList>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new ServiceList()
                    {
                        Id = source.service_id,
                        ServiceName = source.service_name,
                        ServiceDetails = source.service_details,
                        Charges = source.service_charges,
                        CategoryDetails = source.category_details,
                        Commission = source.service_commission,
                        FullName = source.full_name,
                        Status = source.status_name,
                        Date = source.service_date
                    });
                }
            }
            return _list;
        }
        public IEnumerable<ViewReportService> ServiceItem(DateTime startDate, DateTime endDate)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportService>(unWork);
                    return repository.SelectAll(Query.SelectReportService)
                        .Where(x => x.service_date >= startDate)
                        .Where(x => x.service_date <= endDate)
                        .ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private static IEnumerable<ViewReportService> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportService>(unWork);
                    return repository.SelectAll(Query.SelectReportService).ToList();
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
