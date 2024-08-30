using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("report_product_list")]
    public class ViewReportProductList
    {
        [Key]
        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public decimal trade_price { get; set; }
        public decimal retail_price { get; set; }
    }
}
