 

using System;
using System.Collections.Generic;
using Inventory.Entities;

namespace Inventory.Interface
{
    public interface IPaymentItem
    {
        IEnumerable<ViewReportPayment> PaymentItem(DateTime startDate, DateTime endDate);
    }
}
