using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("view_inventorylist")]
    public class ViewReportInventoryList
    {
        [Key]
        public int inventory_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public int quantity { get; set; }
        public decimal trade_price { get; set; }
        public decimal retail_price { get; set; }
        public string status { get; set; }
    }
}