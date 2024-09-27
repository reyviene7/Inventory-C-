using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Entities;
using Inventory.Interface;
using ServeAll.Core.Repository;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.Services
{
    public class ServDailyExpenses : IDailyExpenses
    {
        private IList<DailyExpenses> _list;

        public IEnumerable<DailyExpenses> DataSource()
        {
            _list = new List<DailyExpenses>();
            var sources = Source();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new DailyExpenses()
                    {
                        Id = source.expense_id,
                        Type = source.type_name,
                        Description = source.description,
                        Amount = source.amount,
                        RelatedEntity = source.related_entity,
                        EntityId = source.entity_id,
                        Date = source.expenses_date
                    });
                }
            }
            return _list;
        }

        public IEnumerable<DailyExpenses> DataSourceExpenses()
        {
            _list = new List<DailyExpenses>();
            var sources = SourceExpenses();
            if (sources != null)
            {
                foreach (var source in sources)
                {
                    _list.Add(new DailyExpenses()
                    {
                        Id = source.expense_id,
                        Type = source.type_name,
                        Description = source.description,
                        Amount = source.amount,
                        RelatedEntity = source.related_entity,
                        EntityId = source.entity_id,
                        Date = source.expenses_date
                    });
                }
            }
            return _list;
        }

        private static IEnumerable<ViewReportDailyExpenses> Source()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportDailyExpenses>(unWork);
                    return repository.SelectAll(Query.SelectReportDailyExpenses).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        private static IEnumerable<ViewReportDailyExpenses> SourceExpenses()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReportDailyExpenses>(unWork);
                    return repository.SelectAll(Query.SelectReportDailyExpenses).ToList();
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
