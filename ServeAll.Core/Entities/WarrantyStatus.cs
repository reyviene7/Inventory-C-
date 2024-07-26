using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("WarrantyStatus")]
    public class WarrantyStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string Details { get; set; }
    }
}