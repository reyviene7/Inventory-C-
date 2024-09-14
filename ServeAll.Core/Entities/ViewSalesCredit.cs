using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_credit_sales")]
    public class ViewSalesCredit
    {
        [Key]
        public int      id              { get; set; }
        public string invoice_id { get; set; }
        public string amount_due { get; set; }
        public decimal paid_amount { get; set; }
        public decimal remaining_balance { get; set; }
        public decimal gross { get; set; }
        public decimal net_sales { get; set; }
        public string customer { get; set; }
        public string branch { get; set; }
        public string operators { get; set; }
        public string credit_code { get; set; }
        public decimal credit_balance { get; set; }
        public decimal credit_limit { get; set; }
        public string receipt { get; set; }
        public DateTime credit_date { get; set; }
    }
}