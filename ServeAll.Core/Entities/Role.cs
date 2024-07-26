using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("roles")]
    public class Roles
    {
        [Key]
        public int role_id { get; set; }
        public string role_type { get; set; }
        public string role_description { get; set; }
    }
}
