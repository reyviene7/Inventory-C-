using Dapper.Contrib.Extensions;
using System;

namespace Inventory.Entities
{
    [Table("report_service_particular")]
    public class ViewReportServiceParticular
    {
        [Key]
        public int particular_id { get; set; }
        public string service_name { get; set; }
        public decimal service_charge { get; set; }
        public decimal tax { get; set; }
        public decimal discount { get; set; }
        public decimal gross { get; set; }
        public decimal net_sales { get; set; }
        public string customer_name { get; set; }
        public string status_name { get; set; }
        public DateTime service_on { get; set; }
    }
}
