 

using System;

namespace Inventory.Class
{
    public class SalesList
    {
        public int      Id          { get; set; }
        public string CustomerName { get; set; }
        public decimal Due { get; set; }
        public decimal Paid { get; set; }
        public decimal Gross { get; set; }
        public decimal Discount { get; set; }
        public decimal Net { get; set; }
        public string Branch { get; set; }
        public string Receipt { get; set; }
        public DateTime Date { get; set; }
    }
}
