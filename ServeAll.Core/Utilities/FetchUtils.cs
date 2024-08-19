using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace ServeAll.Core.Utilities
{
    public static class FetchUtils
    {
        public static int getCustomerId(string customerName) {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                try
                {
                    var repository = new Repository<Customers>(unitWork);
                    var query = repository.FindBy(x => x.customer_name == customerName);
                    return query.customer_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getWarehouseId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Warehouse>(unWork);
                    var query = repository.FindBy(x => x.warehouse_name == input);
                    return query.warehouse_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getDeliveryStatus(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<DeliveryStatus>(unWork);
                    var query = repository.FindBy(x => x.delivery_status == input);
                    return query.delivery_status_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getBranchId(string branchName) {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_details == branchName);
                    return query.branch_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getLastProductId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    return repository.SelectAll(Query.getLastProductIdQuery)
                        .Select(x => x.product_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastProfileId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Profile>(unWork);
                    return repository.SelectAll(Query.getLastProfileIdQuery)
                        .Select(x => x.profile_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastProfileImageId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ProfileImages>(unWork);
                    return repository.SelectAll(Query.getLastProfileImgQuery)
                        .Select(x => x.image_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastContactId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Contact>(unWork);
                    return repository.SelectAll(Query.getLastContactIdQuery)
                        .Select(x => x.contact_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastAddressId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Address>(unWork);
                    return repository.SelectAll(Query.getLastAddressIdQuery)
                        .Select(x => x.address_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastServiceId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Services>(unWork);
                    return repository.SelectAll(Query.getLastServiceIdQuery)
                        .Select(x => x.service_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastServiceImgId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ServiceImages>(unWork);
                    return repository.SelectAll(Query.getLastServiceImgQuery)
                        .Select(x => x.image_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }
        public static int getProductImgId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewProductCategory>(unWork);
                    var query = repository.FindBy(x => x.product_name == input);
                    return query.image_id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastCategoryId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Category>(unWork);
                    return repository.SelectAll(Query.getLastCategoryIdQuery)
                        .Select(x => x.category_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastImageId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    return repository.SelectAll(Query.getLastImageIdQuery)
                        .Select(x => x.image_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getNumberOfWarehouses()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Warehouse>(unWork);
                    return repository.SelectAll(Query.CountAllWarehouses)
                        .Select(x => x.warehouse_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastWarehousId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Warehouse>(unWork);
                    return repository.SelectAll(Query.getLastWarehousId)
                        .Select(x => x.warehouse_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getProductId(string productName) {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.FindBy(x => x.product_name == productName);
                    return query.product_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getSupplierId(string supplier)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Supplier>(unWork);
                    var query = repository.FindBy(x => x.supplier_name == supplier);
                    return query.supplier_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getCategoryId(string categoryName)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Category>(unWork);
                    var query = repository.FindBy(x => x.category_details == categoryName);
                    return query.category_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getUserId(string userName)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<users>(unWork);
                    var query = repository.FindBy(x => x.username == userName);
                    return query.user_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getStaffId(string name)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewRequestStaff>(unWork);
                    var query = repository.FindBy(x => x.staff == name);
                    return query.employee_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getServiceStatusId(string status)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServiceStatus>(unWork);
                    var query = repository.FindBy(x => x.status_name == status);
                    return query.status_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getLocationId(string locationCode)
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Location>(unWork);
                    var query = repository.FindBy(x => x.location_code == locationCode);
                    return query.location_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getProductStatus(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductStatus>(unWork);
                    var query = repository.FindBy(x => x.status == input);
                    return query.status_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getStatusId(string status)
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<WarehouseStatus>(unWork);
                    var query = repository.FindBy(x => x.status_details == status);
                    return query.status_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getCustomerCreditId(int customerId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<CustomerCredit>(unWork);
                    var query = repository.FindBy(x => x.customer_id == customerId);
                    return query.customer_credit_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }

            }
        }

        public static int getProductIdBarcode(string barcode)
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                
                    var repository = new Repository<ViewProducts>(unWork);
                    var query = repository.FindBy(x => x.product_code == barcode);
                    return query.product_id;
                 
            }
        }
        public static int getSearchProduct(int productId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewProductId>(unWork);
                    return repository
                        .SelectAll(Query.SelectAllProductId)
                        .Count(x => x.product_id == productId);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static int counterCredit(int customerId)
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<CustomerCredit>(unWork);
                    return repository.SelectAll(Query.CountAllCreditCustomer)
                        .Select(x => x.customer_credit_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int counterTempSales(string invoiceId, string barcode, int customerId, int userId, int branchId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<TempSales>(unWork);
                    var parameters = new { 
                        invoiceId = invoiceId,
                        barcode = barcode,
                        customerId = customerId,
                        userId = userId,
                        branchId = branchId 
                    };
                    return repository.SearchBy(Query.CountAllCreditCustomer, parameters).particular_id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getVerifiyUserId(string name)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewUser>(unWork);
                    var query = repository.FindBy(x => x.name == name);
                    return query.user_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getLastInvoiceId()
        {
            using (var session = new DalSession())
            {
                try {
                    var unitWork = session.UnitofWrk;
                    unitWork.Begin();
                    var repository = new Repository<SalesParticular>(unitWork);
                    var result = repository.SearchBy(Query.getLastInvoiceId);
                    return result.particular_id;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        /* ################### String ############################## */
        public static string getUsername(int userId) {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                try
                {
                    var repository = new Repository<users>(unitWork);
                    var query = repository.FindBy(x => x.user_id == userId);
                    return query.username;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }
        }

        public static string getProfileName(int userId)
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                try
                {
                    var repository = new Repository<UserProfile>(unitWork);
                    var query = repository.FindBy(x => x.user_id == userId);
                    return query.name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }
        }

        public static string getBranchName(int branchId) {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.Branch>(unWork);
                    var query = repository.FindBy(x => x.branch_id == branchId);
                    return query.branch_details;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }
        }
        public static string getCustomerName(int customerId) {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewCustomers>(unWork);
                    var query = repository.FindBy(x => x.customer_id == customerId);
                    return query.customer_name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }
        }

        public static string getUserCompleteName(int userId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewUser>(unWork);
                    var query = repository.FindBy(x => x.user_id == userId);
                    return query.name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return "";
                }
            }
        }
        public static ViewReturnWarehouse getShowReturn(int returnId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    return repository.FindBy(x => x.return_id == returnId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null; 
                }
            }
        }
        public static string getLastReturnId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<ViewReturnWarehouse>(unitWork);
                var result = (from b in repository.SelectAll(Query.SelectAllReturnWareHs)
                              orderby b.return_id descending
                              select b.return_code).Take(1).SingleOrDefault();
                if (result != null)
                {
                    return result;
                }
                result = Query.DefaultCode;
                return result;
            }
        }
        public static ViewInventory getShowEntity(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.FindBy(x => x.inventory_id == inventoryId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }

            }
        }
        public static int GetLastId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Inventory>(unWork);
                    return repository.SelectAll(Query.getLastInventoryQuery)
                        .Select(x => x.product_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }
        public static string GetLastInventoryCode()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Inventory>(unWork);
                    return repository.SelectAll(Query.getLastInventoryCodeQuery)
                        .Select(x => x.inventory_code).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return string.Empty;
                }
            }
        }
        public static string GetLastDeliveryCode()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Inventory>(unWork);
                    return repository.SelectAll(Query.getLastInventoryDeliveryQuery)
                        .Select(x => x.delivery_code).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return string.Empty;
                }
            }
        }
        public static string GetLastWarehouseDeliveryCode()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<WarehouseDelivery>(unWork);
                    return repository.SelectAll(Query.getLastWarehouseDeliveryQuery)
                        .Select(x => x.delivery_code).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return string.Empty;
                }
            }
        }
        public static string GetLastReceiptCode()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<WarehouseDelivery>(unWork);
                    return repository.SelectAll(Query.getLastReceiptQuery)
                        .Select(x => x.receipt_number).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return string.Empty;
                }
            }
        }

        public static void getProducts()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.SelectAll(Query.AllBindProduct).Select(x => x.product_name).Distinct().ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static string GetLastBarcode()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.Branch>(unWork);
                    return repository.SelectAll(Query.getLastBranchCodeQuery)
                        .Select(x => x.branch_code).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return string.Empty;
                }
            }
        }
    }
}
