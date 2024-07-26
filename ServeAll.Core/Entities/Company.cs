using System;
using Dapper.Contrib.Extensions;


namespace ServeAll.Core.Entities
{
    [Table("view_company")]
    public class Company
    {
        [Key]
        public int company_id { get; set; }
        public string company_code { get; set; }
        public string company_name { get; set; }
        public string barangay { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string zip_code { get; set; }
        public string telephone_number { get; set; }
        public string mobile_number { get; set; }
        public string email_address { get; set; }
        public string web_url { get; set; }
        public string fax_number { get; set; }
        public string company_type { get; set; }
        public DateTime date_register { get; set; }
    }
}