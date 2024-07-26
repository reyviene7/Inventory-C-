using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_customers")]
    public class ViewCustomers
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string gender { get; set; }
        public string email_address { get; set; }
        public string telephone_number { get; set; }
        public string mobile_number { get; set; }
        public string fax_number { get; set; }
        public string barangay { get; set; }
        public string street { get; set; }
        public string province { get; set; }

        public string city { get; set; }

        public string zip_code { get; set; }
        public string client_type { get; set; }
        public DateTime date_register { get; set; }
    }
}