using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ServeAll.Core.Queries;
using ServeAll.Core.Helper;

namespace ServeAll.Core.Utilities
{
    public static class EntityUtils
    {
        public static CustomerCredit getCustomerCredit(int customerId) {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<CustomerCredit>(unWork);
                    var parameter = new { customerId = customerId };
                    return repository.SearchBy(Query.getCustomerCurrentCredit, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    CustomerCredit credit = new CustomerCredit
                    {
                        customer_credit_id = 0,
                        credit_code = "",
                        customer_id = customerId,
                        credit_limit = 0,
                        credit_used = 0,
                        balance = 0
                    };
                    return credit;
                }
            }
        }

        public static WarehouseDelivery getWarehouseDelivery(int deliveryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<WarehouseDelivery>(unWork);
                    var parameter = new { deliveryId = deliveryId };
                    return repository.SearchBy(Query.getWarehouseDeliveryById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static ViewWarehouseDelivery getViewWarehouseDelivery(int deliveryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewWarehouseDelivery>(unWork);
                    var parameter = new { deliveryId = deliveryId };
                    return repository.SearchBy(Query.getViewWarehouseDeliveryById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static DeliveryDetails GetDeliveryDetails(int deliveryId)
        {
            var delivery = getWarehouseDelivery(deliveryId); // WarehouseDelivery
            var view = getViewWarehouseDelivery(deliveryId); // ViewWarehouseDelivery

            if (delivery == null || view == null) return null;

            return new DeliveryDetails
            {
                // From WarehouseDelivery
                delivery_id = delivery.delivery_id,
                product_id = delivery.product_id,
                delivery_code = delivery.delivery_code,
                last_cost_per_unit = delivery.last_cost_per_unit,
                receipt_number = delivery.receipt_number,
                branch_id = delivery.branch_id,
                delivery_qty = delivery.delivery_qty,
                status_id = delivery.status_id,
                delivery_status_id = delivery.delivery_status_id,

                // From ViewWarehouseDelivery
                product_code = view.product_code,
                product_name = view.product_name,
                branch_details = view.branch_details,
                status_details = view.status_details,
                cost_per_unit = view.cost_per_unit,
                delivery_status = view.delivery_status
            };
        }

        public static ViewWareHouseInventory getWarehouseInventory(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewWareHouseInventory>(unWork);
                    var parameter = new { inventoryId = inventoryId };
                    return repository.SearchBy(Query.getWarehouseInventoryById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static ViewAcceptedDelivery getAccepted(int receivedId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewAcceptedDelivery>(unWork);
                    var parameter = new { receivedId = receivedId };
                    return repository.SearchBy(Query.getAcceptedDeliveryById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static ViewReturnWarehouse getReturn(int returnId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewReturnWarehouse>(unWork);
                    var parameter = new { returnId = returnId };
                    return repository.SearchBy(Query.getReturnById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        public static ViewDailyExpenses getDailyExpenses(int expenseId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewDailyExpenses>(unWork);
                    var parameter = new { expenseId = expenseId };
                    return repository.SearchBy(Query.getExpenseById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static ViewInventory getInventory(int inventoryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewInventory>(unWork);
                    var parameter = new { inventoryId = inventoryId };
                    return repository.SearchBy(Query.getInventoryById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static ViewSalesCredit getCredit(int creditId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewSalesCredit>(unWork);
                    var parameter = new { creditId = creditId };
                    return repository.SearchBy(Query.getCreditById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static ViewPayment getPayment(int paymentId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewPayment>(unWork);
                    var parameter = new { paymentId = paymentId };
                    return repository.SearchBy(Query.getPaymentById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static PaymentMethod getPaymentMethod(int methodId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<PaymentMethod>(unWork);
                    var parameter = new { methodId = methodId };
                    return repository.SearchBy(Query.getMethodById, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        public static void addItemDiscount(int salesId, decimal discount)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<TempSales>(unWork);
                     repository.ExecAddItemDiscount(StoredProcedure.UspAddItemDiscount,
                                                          SqlVariables.SalesId, salesId,
                                                          SqlVariables.Discount, discount);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static ZReadingSummary GetZReadingSummary(DateTime selectedDate, int userId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repo = new Repository<ZReadingSummary>(unWork);
                    var parameter = new { selectedDate = selectedDate.Date, userId = userId };

                    return repo.SearchBy(Query.getZReadingSummary, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return new ZReadingSummary
                    {
                        Terminal = "N/A",
                        Cashier = "N/A",
                        Date = selectedDate,
                        NumberOfTransactions = 0,
                        GrossSales = 0,
                        Discount = 0,
                        VAT = 0,
                        NetSales = 0,
                        Cash = 0,
                        GCash = 0,
                        Credit = 0
                    };
                }
            }
        }


        public static AuthorizedMachine getMachineDetails(string machineKey, string machineName)
        {
            using (var session = new VultrSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<AuthorizedMachine>(unWork);
                    var parameter = new { 
                        machineKey = machineKey, 
                        machineName = machineName 
                    };
                    return repository.SearchBy(Query.getMachineByKey, parameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    DateTime defaultDateTime = new DateTime();
                    return new AuthorizedMachine {
                        authorized_id = 0,
                        machine_name = null,
                        machine_key = null,
                        date_register = defaultDateTime
                    };
                }
            }
        }
    }
}
