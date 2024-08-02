using ServeAll.Core.Entities;
using ServeAll.Core.Queries;
using ServeAll.Core.Repository;
using System;
using System.Linq;
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
    }
}
