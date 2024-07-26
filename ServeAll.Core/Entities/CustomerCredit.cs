using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("customer_credit")]
    public class CustomerCredit
    {
        [Key]
        public int customer_credit_id { get; set; }
        public string credit_code { get; set; }
        public int customer_id { get; set; }
        public decimal credit_limit { get; set; }
        public decimal credit_used { get; set; }
        public decimal balance { get; set; }
    }
}