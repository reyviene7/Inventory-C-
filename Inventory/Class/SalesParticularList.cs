 

using System;

namespace Inventory.Class
{
    public class SalesParticularList
    {
        public int      Id          { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Gross { get; set; }
        public decimal Net { get; set; }
        public string Branch { get; set; }
        public string Customer { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
