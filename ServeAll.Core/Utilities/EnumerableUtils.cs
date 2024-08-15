using ServeAll.Core.Entities;
using ServeAll.Core.Entities.request;
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

        public static IEnumerable<ViewStockMovement> getStockMovementList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewStockMovement>(unWork);
                    return repository.SelectAll(Query.SelectStockMovementList)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewStockMovement>();
                }
            }
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

        public static IEnumerable<RequestProducts> getProductWarehouseList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<RequestProducts>(unWork);
                    return repository.SelectAll(Query.AllProductWarehouse).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<RequestProducts>();
                }
            }
        }

        public static IEnumerable<RequestQuantity> getProductWarehouseQuantity()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<RequestQuantity>(unWork);
                    return repository.SelectAll(Query.AllQuantityWarehouse).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<RequestQuantity>();
                }
            }
        }

        public static IEnumerable<RequestSupplier> getSupplierWarehouseList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<RequestSupplier>(unWork);
                    return repository.SelectAll(Query.AllSupplierWarehouse).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<RequestSupplier>();
                }
            }
        }

        public static IEnumerable<ViewRequestCategory> getRequestCategoryList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewRequestCategory>(unWork);
                    return repository.SelectAll(Query.AllRequestCategory).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewRequestCategory>();
                }
            }
        }

        public static IEnumerable<WarehouseStatus> getStatusWarehouseList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<WarehouseStatus>(unWork);
                    return repository.SelectAll(Query.AllWarehouseStatus).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<WarehouseStatus>();
                }
            }
        }

        public static IEnumerable<users> getUserNameList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<users>(unWork);
                    return repository.SelectAll(Query.AllUserNames).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<users>();
                }
            }
        }

        public static IEnumerable<Location> getLocationWarehouseList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Location>(unWork);
                    return repository.SelectAll(Query.AllWarehouseLocation).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<Location>();
                }
            }
        }

        public static IEnumerable<ServiceStatus> getServiceStatusList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServiceStatus>(unWork);
                    return repository.SelectAll(Query.AllServiceStatus).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ServiceStatus>();
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

        public static IEnumerable<ProductImages> getProductImage()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    return repository.SelectAll(Query.AllProductImage).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ProductImages>();
                }
            }
        }
        public static IEnumerable<ViewInventoryList> EnumerableBranches()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewInventoryList>(unWork);
                    return repository.SelectAll(Query.AllInventoryList)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewInventoryList>();
                }
            }
        }
        public static IEnumerable<ViewInventory> getInventory()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.SelectAll(Query.AllInventory)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewInventory>();
                }
            }
        }
        public static IEnumerable<ViewProductList> getWarehouseProduct()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProductList>(unWork);
                    return repository.SelectAll(Query.AllWarehouseProduct)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewProductList>();
                }
            }
        }
        public static IEnumerable<ViewSalesPart> getSalesParticular()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewSalesPart>(unWork);
                    return repository.SelectAll(Query.AllSalesPart)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewSalesPart>();
                }
            }
        }
        public static IEnumerable<ViewWareHouseInventory> getWareHouseInventoryList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewWareHouseInventory>(unWork);
                    return repository.SelectAll(Query.getWarehouseInventory).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewWareHouseInventory>();
                }
            }
        }

        public static IEnumerable<ViewServices> getServicesList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewServices>(unWork);
                    return repository.SelectAll(Query.getServices).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewServices>();
                }
            }
        }

        public static IEnumerable<ViewWarehouseDelivery> getWareHouseDeliveryList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewWarehouseDelivery>(unWork);
                    return repository.SelectAll(Query.getWarehouseDelivery).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewWarehouseDelivery>();
                }
            }
        }

        public static IEnumerable<ViewBranch> GetBranchList()
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    unWork.Begin();
                    var repository = new Repository<ViewBranch>(unWork);
                    return repository.SelectAll(Query.AllBranch).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewBranch>();
                }
            }
        }

        public static IEnumerable<ViewWarehouse> getWarehouseList()
        {
            using (var session = new DalSession())
            {
                try
                {
                    var unWork = session.UnitofWrk;
                    unWork.Begin();
                    var repository = new Repository<ViewWarehouse>(unWork);
                    return repository.SelectAll(Query.AllWarehouse).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewWarehouse>();
                }
            }
        }

        public static IEnumerable<T> GetEmptyList<T>()
        {
            return Enumerable.Empty<T>();
        }
    }
}
