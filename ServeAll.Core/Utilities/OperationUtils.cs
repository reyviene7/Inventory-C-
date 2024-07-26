using ServeAll.Core.Entities;
using ServeAll.Core.Helper;
using ServeAll.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeAll.Core.Utilities
{
    public static class OperationUtils
    {
        // integrate sales date
        public static decimal getTotalDiscountTempSales(int customerId, int branchId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<TempSales>(unWork);
                    return repository.ExecuteRetDiscount(StoredProcedure.UspTempDiscount, SqlVariables.CustomerId,
                        customerId, SqlVariables.BranchId, branchId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getCounterProductTemp(string invoiceId, string barcode, int branchId, int customerId, int userId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                var repository = new Repository<ViewTempSales>(unWork);
                try
                {
                    return repository.ExecCounterStored(StoredProcedure.UspSearchProducts,
                                                        SqlVariables.InvoicesId, invoiceId,
                                                        SqlVariables.BarCode, barcode,
                                                        SqlVariables.BranchId, branchId,
                                                        SqlVariables.CustomerId, customerId,
                                                        SqlVariables.UserId, userId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }

            }
        }

        public static int deleteFromSales(string invoiceId, string barcode, int branchId, int customerId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                var repository = new Repository<TempSales>(unWork);
                try
                {
                    var query = repository.ExecDeleteTemp(StoredProcedure.UspDeleteTempSales,
                        SqlVariables.InvoicesId, invoiceId,
                        SqlVariables.BarCode, barcode,
                        SqlVariables.BranchId, branchId,
                        SqlVariables.CustomerId, customerId,
                        SqlVariables.EmptyParam, 0);
                    return query;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return 0;

                }
            }
        }
    }
}
