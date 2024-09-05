using Dapper.Contrib.Extensions;
using System;

namespace Inventory.Entities
{
    [Table("report_credit_particular")]
    public class ViewReportCreditParticular
    {
        [Key]
        public int particular_id { get; set; }
        public string product_name { get; set; }
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
        public decimal gross { get; set; }
        public decimal net_sales { get; set; }
        public string branch_details { get; set; }
        public string customer_name { get; set; }
        public DateTime purchase_on { get; set; }
    }
}
