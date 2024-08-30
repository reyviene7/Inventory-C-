 

namespace Inventory.Class
{
   public class InventoryList
   {
        public int Id      { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal TradePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public string Status { get; set; }
    }
}
