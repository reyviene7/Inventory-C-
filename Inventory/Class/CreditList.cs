 

using System;

namespace Inventory.Class
{
    public class CreditList
    {
        public int      Id          { get; set; }
        public string CustomerName { get; set; }
        public decimal Credit { get; set; }
        public decimal Paid { get; set; }
        public decimal Discount { get; set; }
        public decimal Net { get; set; }
        public string Branch { get; set; }
        public string Service { get; set; }
        public DateTime Date { get; set; }
    }
}
