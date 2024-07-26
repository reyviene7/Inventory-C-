using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_user_profile")]
    public class UserProfile
    {
        [Key]
        public int user_id { get; set; }
        public string name { get; set; }

    }
}
