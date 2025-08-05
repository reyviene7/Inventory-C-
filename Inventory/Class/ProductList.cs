 

namespace Inventory.Class
{
   public class ProductList
   {
        public int Id      { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Wholesale { get; set; }
        public decimal TradePrice { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
