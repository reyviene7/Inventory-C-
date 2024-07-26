using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public int role_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime created_date { get; set; }
        public DateTime modified_date { get; set; }
        public Boolean is_active { get; set; } 
    }
}
