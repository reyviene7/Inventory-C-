 

using System;

namespace Inventory.Class
{
    public class PaymentList
    {
        public int      Id          { get; set; }
        public decimal Due { get; set; }
        public decimal Paid { get; set; }
        public decimal Balance { get; set; }
        public string PaymentMethod { get; set; }
        public string Processed { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public string CreditCode { get; set; }
        public string RefNum { get; set; }
        public DateTime Date { get; set; }
    }
}
