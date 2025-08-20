using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static string getDeliveryStatusName(int input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<DeliveryStatus>(unWork);
                    var query = repository.FindBy(x => x.delivery_status_id == input);
                    return query.delivery_status;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public static int getBranchId(string branchName)
        {
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

        public static int getDepartment(string departmentName)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.Department>(unWork);
                    var query = repository.FindBy(x => x.department_name == departmentName);
                    return query.department_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getPaymentMethod(string method)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.PaymentMethod>(unWork);
                    var query = repository.FindBy(x => x.method_name == method);
                    return query.payment_method_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getExpensesType(string type)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.ExpenseType>(unWork);
                    var query = repository.FindBy(x => x.type_name == type);
                    return query.expense_type_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getRelatedEntity(string related)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.RelatedEntity>(unWork);
                    var query = repository.FindBy(x => x.related_entity == related);
                    return query.entity_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getEmployee(string related)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.ViewEmployees>(unWork);
                    var query = repository.FindBy(x => x.full_name == related);
                    return query.employee_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getUserRole(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.Roles>(unWork);
                    var query = repository.FindBy(x => x.role_type == input);
                    return query.role_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public static int getProfileId(string input)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProfileEntities>(unWork);
                    var query = repository.FindBy(x => x.name == input);
                    return query.profile_id;
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

        public static int getLastCompanyId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewCompany>(unWork);
                    return repository.SelectAll(Query.getLastCompanyIdQuery)
                        .Select(x => x.company_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastDeliveryId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewWarehouseDelivery>(unWork);
                    return repository.SelectAll(Query.getLastDeliveryIdQuery)
                        .Select(x => x.delivery_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastInventoryId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    return repository.SelectAll(Query.getLastInventoryIdQuery)
                        .Select(x => x.inventory_id).FirstOrDefault();
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

        public static int getLastSupplierId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<Supplier>(unWork);
                    return repository.SelectAll(Query.getLastSupplierIdQuery)
                        .Select(x => x.supplier_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return 0;
                }
            }
        }

        public static int getLastWarehouseInventoryId()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<WarehouseInventory>(unWork);
                    return repository.SelectAll(Query.getLastWarehouseInventoryIdQuery)
                        .Select(x => x.inventory_id).FirstOrDefault();
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

        public static int getProductId(string productName) {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Products>(unWork);
                    var query = repository.FindBy(x => x.product_name.Equals(productName, StringComparison.OrdinalIgnoreCase));
                    if (query != null)
                        return query.product_id;

                    Console.WriteLine("Product not found: " + productName);

                    return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }


        public static int getImageId(string title)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductImages>(unWork);
                    var result = repository.FindBy(x => x.title.Trim().ToLower() == title.Trim().ToLower());

                    if (result == null)
                    {
                        Console.WriteLine($"No image found with title: '{title}'");
                        return 0;
                    }

                    return result.image_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("getImageId error: " + ex.Message);
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

        public static int getContactId(string mobileNumber)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<Contact>(unWork);
                    var query = repository.FindBy(x => x.mobile_number == mobileNumber);
                    return query.contact_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getCompanyId(string Company)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ViewCompany>(unWork);
                    var query = repository.FindBy(x => x.company_name == Company);
                    return query.company_id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public static int getAddressId(string fullAddress)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var parts = fullAddress.Split(',').Select(p => p.Trim()).ToArray();
                    if (parts.Length != 4)
                        throw new Exception("Invalid address format. Expected: 'Street, Barangay, City, Province'");

                    string street = parts[0];
                    string barangay = parts[1];
                    string city = parts[2];
                    string province = parts[3];

                    var repository = new Repository<Address>(unWork);
                    var query = repository.FindBy(x =>
                        x.street == street &&
                        x.barangay == barangay &&
                        x.city == city &&
                        x.province == province
                    );

                    return query != null ? query.address_id : 0;
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
                    var query = repository.FindBy(x => x.location_code.Equals(locationCode, StringComparison.OrdinalIgnoreCase));
                    if (query != null)
                        return query.location_id;

                    Console.WriteLine("Location not found for code: " + locationCode);
                    return 0;
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

        public static string getStatusName(int status)
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<WarehouseStatus>(unWork);
                    var query = repository.FindBy(x => x.status_id == status);
                    return query.status_details;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public static int getProductStatusId(string status)
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ProductStatus>(unWork);
                    var query = repository.FindBy(x => x.status == status);
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
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
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
        public static int GetLastReturnId()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    return repository.SelectAll(Query.getLastReturnQuery)
                        .Select(x => x.return_id).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
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
        public static string GetLastReturnDel()
        {

            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ReturnWareHouse>(unWork);
                    return repository.SelectAll(Query.getLastReturnDelQuery)
                        .Select(x => x.return_number).FirstOrDefault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return string.Empty;
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
