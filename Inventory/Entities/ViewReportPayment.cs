using Dapper.Contrib.Extensions;
using System;

namespace Inventory.Entities
{
    [Table("report_payment")]
    public class ViewReportPayment
    {
        [Key]
        public int payment_id { get; set; }
        public decimal amount_due { get; set; }
        public decimal amount_paid { get; set; }
        public decimal remaining_balance { get; set; }
        public string payment_method { get; set; }
        public string processed_by { get; set; }
        public string customer_name { get; set; }
        public string branch_details { get; set; }
        public string credit_code { get; set; }
        public string receipt_number { get; set; }
        public DateTime payment_date { get; set; }
    }
}
