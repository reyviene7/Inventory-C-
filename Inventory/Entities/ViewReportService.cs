using Dapper.Contrib.Extensions;
using System;

namespace Inventory.Entities
{
    [Table("report_service")]
    public class ViewReportService
    {
        [Key]
        public int service_id { get; set; }
        public string service_name { get; set; }
        public string service_details { get; set; }
        public decimal service_charges { get; set; }
        public string category_details { get; set; }
        public decimal service_commission { get; set; }
        public string full_name { get; set; }
        public string status_name { get; set; }
        public DateTime service_date { get; set; }
    }
}
