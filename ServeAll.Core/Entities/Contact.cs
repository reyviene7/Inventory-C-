using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("contact")]
    public class Contact
    {
        [Key]
        public int contact_id { get; set; }
        public string contact_code { get; set; }
        public string contact_name { get; set; }
        public string position { get; set; }
        public string telephone_number { get; set; }
        public string mobile_number { get; set; }
        public string mobile_secondary { get; set; }
        public string email_address { get; set; }
        public string web_url { get; set; }
        public string fax_number { get; set; }
        public DateTime date_register { get; set; }
    }
}
