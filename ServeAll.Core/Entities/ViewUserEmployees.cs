using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_user_employee")]
    public class ViewUserEmployees
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}