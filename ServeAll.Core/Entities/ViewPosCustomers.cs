using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_poscustomers")]
    public class ViewPosCustomers
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_name { get; set; }
    }
}