 

using System;

namespace Inventory.Class
{
    public class ServiceParticularList
    {
        public int      Id          { get; set; }
        public string Name { get; set; }
        public decimal Charge { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Gross { get; set; }
        public decimal Net { get; set; }
        public string Customer { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
