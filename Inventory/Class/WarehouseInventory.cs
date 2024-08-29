
using System;

namespace Inventory.Class
{
    public class WarehouseInventory
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Qty { get; set; }
        public string Delivery { get; set; }
        public string Branch { get; set; }
        public decimal LastCost { get; set; }
        public decimal RetailPrice { get; set; }
        public DateTime Purchase { get; set; }
        public string Status { get; set; }
    }
}
