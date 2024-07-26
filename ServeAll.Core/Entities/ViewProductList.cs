using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_productlist")]
    public class ViewProductList
    {
        [Key]
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal RetailPrice { get; set; }
        public string Status { get; set; }
    }
}