using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_user")]
    public class ViewUser
    {
        [Key]
        public int user_id { get; set; }
        public string user_code { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string role_type { get; set; }
    }
}
