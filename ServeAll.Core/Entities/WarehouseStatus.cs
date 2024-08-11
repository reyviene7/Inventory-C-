using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("warehouse_status")]
    public class WarehouseStatus
    {
        [Key]
        public int status_id { get; set; }

        public string status_details { get; set; }
    }
}
