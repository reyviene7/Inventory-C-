using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("Warranty")]
    public class Warranty
    {
        [Key]
        public int WarrantyId { get; set; }
        public string Name { get; set; }
        public int NoDays { get; set; }
    }
}