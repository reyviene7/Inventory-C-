using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_user_profile")]
    public class ViewUserEmployees
    {
        [Key]
        public int user_id { get; set; }
        public string name { get; set; }
    }
}