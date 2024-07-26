using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("merchandise_status")]
    public class MerchandiseStatus
    {
        [Key]
        public int status_id { get; set; }
        public string status_details { get; set; }
    }
}