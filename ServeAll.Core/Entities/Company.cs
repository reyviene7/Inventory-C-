using System;
using Dapper.Contrib.Extensions;


namespace ServeAll.Core.Entities
{
    [Table("company")]
    public class Company
    {
        [Key]
        public int company_id { get; set; }
        public string company_code { get; set; }
        public string company_name { get; set; }
        public DateTime date_register { get; set; }
        public int contact_id { get; set; }
        public int address_id { get; set; }
        public string company_type { get; set; }
    }
}