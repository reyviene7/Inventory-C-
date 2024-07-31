using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("product_status")]
    public class ProductStatus
    {
        [Key]
        public int status_id { get; set; }
        public string status { get; set; }
    }
}