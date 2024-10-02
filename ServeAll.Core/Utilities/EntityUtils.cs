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

        public static ViewWarehouseDelivery getWarehouseDelivery(int deliveryId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewWarehouseDelivery>(unWork);
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
    }
}
