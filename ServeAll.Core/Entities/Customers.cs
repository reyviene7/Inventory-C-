using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("customers")]
    public class Customers
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_code { get; set; }
        public string customer_name { get; set; }
        public string gender { get; set; }
        public int contact_id { get; set; }
        public int address_id { get; set; }
        public int type_id { get; set; }
        public DateTime date_register { get; set; }
    }
}