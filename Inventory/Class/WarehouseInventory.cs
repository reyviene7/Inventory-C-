
using System;

namespace Inventory.Class
{
    public class WarehouseInventory
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Qty { get; set; }
        public string SKU { get; set; }
        public string Warehouse { get; set; }
        public decimal ItemCost { get; set; }
        public decimal LastCost { get; set; }
        public DateTime Update { get; set; }
        public string Status { get; set; }
    }
}
