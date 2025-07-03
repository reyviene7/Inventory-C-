using ServeAll.Core.Entities;
using ServeAll.Core.Entities.request;
using ServeAll.Core.Helper;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using ServeAll.Entities;
using System;
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

        public static IEnumerable<ViewCategory> getCategoryList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewCategory>(unWork);
                    return repository.SelectAll(Query.AllViewCategory).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewCategory>();
                }
            }
        }
        public static IEnumerable<ViewSupplier> getSupplierList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewSupplier>(unWork);
                    return repository.SelectAll(Query.AllViewSupplier).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewSupplier>();
                }
            }
        }

        public static IEnumerable<ViewAcceptedDelivery> getAcceptedDelivery(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewAcceptedDelivery>(unWork);
                    var param = new { branch = branch };
                    return repository.SelectAll(Query.getAcceptedDelivery, param).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewAcceptedDelivery>();
                }
            }
        }

        public static IEnumerable<ViewSalesCredit> getCreditSales(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewSalesCredit>(unWork);
                    var param = new { branch = branch };
                    return repository.SelectAll(Query.getCreditSales, param).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewSalesCredit>();
                }
            }
        }
        public static IEnumerable<ViewDailyExpenses> getDailyExpenses()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewDailyExpenses>(unWork);
                    return repository.SelectAll(Query.getDailyExpenses).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewDailyExpenses>();
                }
            }
        }
        public static IEnumerable<ViewInventory> getLowQuantity()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.SelectAll(Query.getLowQuantity).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewInventory>();
                }
            }
        }

        public static IEnumerable<ViewServiceImages> getServiceImgList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewServiceImages>(unWork);
                    return repository.SelectAll(Query.AllViewServiceImages).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewServiceImages>();
                }
            }
        }

        public static IEnumerable<ProfileImages> getProfileImgList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProfileImages>(unWork);
                    return repository.SelectAll(Query.AllViewProfileImages).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ProfileImages>();
                }
            }
        }

        public static IEnumerable<ViewProfile> getProfileList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProfile>(unWork);
                    return repository.SelectAll(Query.viewProfile).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Enumerable.Empty<ViewProfile>();
                }
            }
        }

        public static IEnumerable<Contact> getContactList(int contactId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Contact>(unWork);
                    var parameter = new { contact = contactId };
                    return repository.SelectAll(Query.getContactById, parameter).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Enumerable.Empty<Contact>();
                }
            }
        }

        public static IEnumerable<Address> getAddressList(int addressId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var parameter = new { address = addressId };
                    var repository = new Repository<Address>(unWork);
                    return repository.SelectAll(Query.getAddressById, parameter).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Enumerable.Empty<Address>();
                }
            }
        }

        public static IEnumerable<ViewReportProductList> getProductWarehouseList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewReportProductList>(unWork);
                    return repository.SelectAll(Query.AllProductWarehouse).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewReportProductList>();
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
                    return repository.SelectAll(Query.AllUsers).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<users>();
                }
            }
        }

        public static IEnumerable<ViewUser> getUserList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewUser>(unWork);
                    return repository.SelectAll(Query.getViewUser).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewUser>();
                }
            }
        }
        public static IEnumerable<UserImage> getUserImage()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<UserImage>(unWork);
                    return repository.SelectAll(Query.AllUserImage)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<UserImage>();
                }
            }
        }

        public static IEnumerable<ViewUserImage> getViewUserImage()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewUserImage>(unWork);
                    return repository.SelectAll(Query.AllViewUserImage)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewUserImage>();
                }
            }
        }

        public static IEnumerable<ViewRequestStaff> getStaffList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewRequestStaff>(unWork);
                    return repository.SelectAll(Query.AllStaff).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewRequestStaff>();
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

        public static IEnumerable<Warehouse> getWarehouse()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Warehouse>(unWork);
                    return repository.SelectAll(Query.AllWarehouseList).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<Warehouse>();
                }
            }
        }

        public static IEnumerable<DeliveryStatus> getWarehouseDelivery()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<DeliveryStatus>(unWork);
                    return repository.SelectAll(Query.AllDeliveryStatus).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<DeliveryStatus>();
                }
            }
        }
        public static IEnumerable<PaymentMethod> getPayment()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<PaymentMethod>(unWork);
                    return repository.SelectAll(Query.AllPaymentMethod).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<PaymentMethod>();
                }
            }
        }
        public static IEnumerable<ExpenseType> getExpensesType()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ExpenseType>(unWork);
                    return repository.SelectAll(Query.AllExpenseType).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ExpenseType>();
                }
            }
        }
        public static IEnumerable<RelatedEntity> getRelatedEntity()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<RelatedEntity>(unWork);
                    return repository.SelectAll(Query.AllRelatedEntity).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<RelatedEntity>();
                }
            }
        }
        public static IEnumerable<ViewEmployees> getEmployees()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewEmployees>(unWork);
                    return repository.SelectAll(Query.AllViewEmployees).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewEmployees>();
                }
            }
        }

        public static IEnumerable<Roles> getRoleType()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Roles>(unWork);
                    return repository.SelectAll(Query.AllRoleTypes).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<Roles>();
                }
            }
        }
        public static IEnumerable<ViewProfile> getProfileNames()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProfile>(unWork);
                    return repository.SelectAll(Query.getProfileName).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewProfile>();
                }
            }
        }
        public static IEnumerable<ProductStatus> getProductStatus()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductStatus>(unWork);
                    return repository.SelectAll(Query.AllProductStatus).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ProductStatus>();
                }
            }
        }
        public static IEnumerable<Branch> getBranchDetails()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Branch>(unWork);
                    return repository.SelectAll(Query.SelectAllBranchExcWareH).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<Branch>();
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
        public static IEnumerable<ViewInventory> getInventoryList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.SelectAll(Query.AllInventoryList)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewInventory>();
                }
            }
        }
        public static IEnumerable<ViewWarehouseDelivery> getWarehouseProduct()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewWarehouseDelivery>(unWork);
                    return repository.SelectAll(Query.AllWarehouseProduct)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewWarehouseDelivery>();
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

        public static IEnumerable<ViewSalesPart> getSalesParticular(string branchName)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewSalesPart>(unWork);
                    var param = new { branchName = branchName };
                    return repository.SelectAll(Query.AllSalesParticularByBranch, param)
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
        public static IEnumerable<ViewReturnWarehouse> getWareHouseReturnList()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.SelectAll(Query.getWarehouseReturn).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewReturnWarehouse>();
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

        public static IEnumerable<Branch> getBranches()
        {
            using (var session = new DalSession())
            {
                try {
                    var unWork = session.UnitofWrk;
                    unWork.Begin();
                    var repository = new Repository<Branch>(unWork);
                    return repository.SelectAll(Query.AllBranch).ToList();
                } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<Branch>();
                }
            }
        }

        public static IEnumerable<T> GetEmptyList<T>()
        {
            return Enumerable.Empty<T>();
        }
        public static IEnumerable<ViewReturnWarehouse> getEnumerableWareHouse(string branch)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.SelectAll(Query.SelectAllReturnWareHs)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewReturnWarehouse>();
                }
            }
        }
        public static IEnumerable<ViewReturnWarehouse> getWareHouseReturn()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.SelectAll(Query.SelectAllReturnWareHs)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return GetEmptyList<ViewReturnWarehouse>();
                }
            }
        }
        public static IEnumerable<Inventory> CheckInventoryQuantities(Action<int, string> alertCallback)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Inventory>(unWork);

                    // Fetch all inventory items
                    var inventoryList = repository.SelectAll(Query.AllInventoryL).ToList();
                    var lowStockItems = inventoryList
                        .Where(i => !i.snooze) // Only check non-snoozed items
                        .Where(i => i.quantity <= 5) // Check for low stock or zero quantity
                        .ToList();

                    foreach (var item in lowStockItems)
                    {
                        if (item.quantity == 0)
                        {
                            alertCallback(item.inventory_id, "Out of Stock");
                        }
                        else if (item.quantity <= 5)
                        {
                            alertCallback(item.inventory_id, "In Minimum Quantity");
                        }
                    }

                    return lowStockItems;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error checking inventory quantities: {ex.Message}");
                    return Enumerable.Empty<Inventory>();
                }
            }
        }

    }
}
