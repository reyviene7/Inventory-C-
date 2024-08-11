using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_productlist")]
    public class ViewProductList
    {
        [Key]
        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public decimal trade_price { get; set; }
        public decimal retail_price { get; set; }
    }
}