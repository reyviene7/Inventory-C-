using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_product_id")]
    public class ViewProductId
    {
        [Key]
        public int product_id { get; set; }
    }
}
