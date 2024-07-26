using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("viewproducts")]
    public class ProductViews
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Serial { get; set; }
        public decimal TradePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public string Status { get; set; }
       
    }
}