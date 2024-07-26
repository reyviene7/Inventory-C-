using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_customer_credit")]
    public class ViewCredit
    {
        [Key]
        public int id         { get; set; }
        public string credit_code { get; set; }
        public string name { get; set; }
        public decimal credit_limit  { get; set; }
        public decimal credit_used   { get; set; }
        public decimal balance      { get; set; }
    }
}