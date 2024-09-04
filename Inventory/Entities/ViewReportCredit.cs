using Dapper.Contrib.Extensions;
using System;

namespace Inventory.Entities
{
    [Table("report_credit")]
    public class ViewReportCredit
    {
        [Key]
        public int credit_id { get; set; }
        public string customer_name { get; set; }
        public decimal amount_credit { get; set; }
        public decimal paid_amount { get; set; }
        public decimal discount { get; set; }
        public decimal net_sales { get; set; }
        public string branch_details { get; set; }
        public string service_number { get; set; }
        public DateTime credit_date { get; set; }
    }
}
