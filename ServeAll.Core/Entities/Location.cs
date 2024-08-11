using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("location")]
    public class Location
    {
        [Key]
        public int location_id { get; set; }
        public string location_code { get; set; }
        public string location_details { get; set; }
    }
}
