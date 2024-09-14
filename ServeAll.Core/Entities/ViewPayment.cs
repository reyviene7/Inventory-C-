using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_payment")]
    public class ViewPayment
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