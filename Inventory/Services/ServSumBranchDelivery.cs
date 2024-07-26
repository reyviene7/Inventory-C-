using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Class;
using Inventory.Interface;
using ServeAll.Core.Helper;
using ServeAll.Core.Repository;

namespace Inventory.Services
{
    public class ServSumBranchDelivery: ISummaryBranchDelivery
    {
        public IEnumerable<SummaryBranchDelivery> GetSummary(DateTime starDate, DateTime endDate, int branchId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<SummaryBranchDelivery>(unWork);
                    return repository.ExecuteSummaryParticular(StoredProcedure.UspSummaryItemBranch,
                        SqlVariables.StarDate,
                                     starDate,
                        SqlVariables.EndDate,
                                     endDate,
                        SqlVariables.BranchId,
                                     branchId).ToList();
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