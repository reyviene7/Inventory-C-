using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("users")]
    public class users
    {
        [Key]
        public int user_id { get; set; }
        public string user_code { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
        public int profile_id { get; set; }
    }
}