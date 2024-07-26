using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("customer_type")]
    public class CustomerType
    {
        [Key]
        public int type_Id { get; set; }
        public string client_type { get; set; }
    }
}