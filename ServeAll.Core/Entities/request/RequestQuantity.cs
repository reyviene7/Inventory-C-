using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities.request
{
    [Table("view_request_quantity")]
    public class RequestQuantity
    {
        [Key]
        public int inventory_id { get; set; }
        public int quantity_in_stock { get; set; }
    }
}
