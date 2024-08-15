using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("delivery_status")]
    public class DeliveryStatus
    {
        [Key]
        public int delivery_status_id { get; set; }

        public string delivery_status { get; set; }
    }
}
