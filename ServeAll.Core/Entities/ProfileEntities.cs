using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_profile_entities")]
    public class ProfileEntities
    {
        [Key]
        public int profile_id { get; set; }
        public string name { get; set; }
    }
}
