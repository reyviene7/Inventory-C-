using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("Final")]
    public class Final
    {
        [Key]
        public int FinalId { get; set; }
        public string Details { get; set; }
    }
}
