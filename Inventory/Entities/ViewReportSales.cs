using Dapper.Contrib.Extensions;
using System;

namespace Inventory.Entities
{
    [Table("report_sales")]
    public class ViewReportSales
    {
        [Key]
        public int sale_id { get; set; }
        public string customer_name { get; set; }
        public decimal amount_due { get; set; }
        public decimal paid_amount { get; set; }
        public decimal gross { get; set; }
        public decimal discount { get; set; }
        public decimal net_sales { get; set; }
        public string branch_details { get; set; }
        public string receipt_number { get; set; }
        public DateTime sale_date { get; set; }
    }
}
