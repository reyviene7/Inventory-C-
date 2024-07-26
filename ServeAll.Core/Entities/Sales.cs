using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("sales")]
    public class Sales
    {
        [Key]
        public int sale_id { get; set; }
        public string invoice_id { get; set; }
        public decimal amount_due { get; set; }
        public decimal paid_amount { get; set; }
        public decimal discount { get; set; }
        public decimal net_sales { get; set; }
        public int customer_id { get; set; }
        public int branch_id { get; set; }
        public decimal gross { get; set; }
        public string receipt_number { get; set; }
        public DateTime sale_date { get; set; }

    }
}