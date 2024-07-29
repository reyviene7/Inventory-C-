using ServeAll.Core.Entities;
using ServeAll.Core.Helper;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ServeAll.Core.Utilities
{
    public static class EnumerableUtils
    {
        public static IEnumerable<ViewPosCustomers> getCustomerList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewPosCustomers>(unWork);
                    return repository.SelectAll(Query.getCustomerList).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewPosCustomers>();
                }
            }
        }

        public static IEnumerable<ViewPosProduct> getProductList(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewPosProduct>(unWork);
                    return repository.SelectAll(Query.PosProducts)
                        .Where(x => x.branch == branch).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewPosProduct>();
                }
            }
        }

        public static IEnumerable<ViewPosCustomers> getCustomerCreditList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewPosCustomers>(unWork);
                    return repository.SelectAll(Query.PosCustomer).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewPosCustomers>();
                }
            }
        }

        public static IEnumerable<ViewTempSales> getTempSalesList(int _branchId, int _customerId)
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewTempSales>(unitWork);
                    return repository.ExecSelectAll(StoredProcedure.UspTempSales, SqlVariables.BranchId, _branchId, SqlVariables.CustomerId, _customerId).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewTempSales>();
                }
            }
        }

        public static IEnumerable<T> GetEmptyList<T>()
        {
            return Enumerable.Empty<T>();
        }

        public static IEnumerable<ViewProducts> getProductList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProducts>(unWork);
                    return repository.SelectAll(Query.AllViewProducts).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewProducts>();
                }
            }
        }

        public static IEnumerable<ViewImageProduct> getImgProductList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewImageProduct>(unWork);
                    return repository.SelectAll(Query.AllViewImageProduct).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewImageProduct>();
                }
            }
        }
    }
}
