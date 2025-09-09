using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("services")]
    public class Services
    {
        [Key]
        public int service_id { get; set; }
        public string service_code { get; set; }
        public string service_name { get; set; }
        public string service_details { get; set; }
        public decimal service_charges { get; set; }
        public int category_id { get; set; }
        public decimal service_commission { get; set; }
        public int user_id { get; set; }
        public int profile_id { get; set; }
        public int status_id { get; set; }
        public DateTime service_date { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
    }
}
