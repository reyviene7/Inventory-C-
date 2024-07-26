using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("supplier")]
    public class Supplier
    {
        [Key]
        public int supplier_id { get; set; }
        public string supplier_code { get; set; }
        public string supplier_name { get; set; }
        public string gender { get; set; }
        public int contact_id { get; set; }
        public int address_id { get; set; }
        public int company_id { get; set; }
        public DateTime date_register { get; set; }
    }
} 