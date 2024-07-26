using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("userType")]
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }
        public string UserDetails { get; set; }
    }
}