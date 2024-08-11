using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities.request
{
    [Table("view_request_supplier")]
    public class RequestSupplier
    {
        [Key]
        public int supplier_id { get; set; }

        public string supplier_name { get; set; }
    }
}