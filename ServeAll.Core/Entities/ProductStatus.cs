using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("ProductStatus")]
    public class ProductStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}