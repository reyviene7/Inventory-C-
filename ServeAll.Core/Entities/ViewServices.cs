using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("view_services")]
    public class ViewServices
    {
        [Key]
        public int service_id { get; set; }
        public string service_code { get; set; }
        public string service_name { get; set; }
        public string service_details { get; set; }
        public decimal service_charges { get; set; }
        public string category { get; set; }
        public decimal service_commission { get; set; }
        public string username { get; set; }
        public string staff { get; set; }
        public string status { get; set; }
        public DateTime service_date { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
    }
}
