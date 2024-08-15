

using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("service_status")]
    public class ServiceStatus
    {
        [Key]
        public int status_id { get; set; }
        public string status_name { get; set; }
    }
}
