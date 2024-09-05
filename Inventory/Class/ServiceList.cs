 

using System;

namespace Inventory.Class
{
    public class ServiceList
    {
        public int      Id          { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDetails { get; set; }
        public decimal Charges { get; set; }
        public string CategoryDetails { get; set; }
        public decimal Commission { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
