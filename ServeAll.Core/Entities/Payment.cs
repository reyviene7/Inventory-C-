using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("payment")]
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        public int credit_sale_id { get; set; }
        public decimal amount_paid { get; set; }
        public  int payment_method_id { get; set; }
        public string receipt_number { get; set; }
        public int user_id { get; set; }
        public int branch_id { get; set; }
        public decimal remaining_balance { get; set; }
        public DateTime payment_date { get; set; }
    }
}