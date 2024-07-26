using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("address")]
    public class Address
    {
        [Key]
        public int address_id { get; set; }
        public string street { get; set; }
        public string barangay { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
    }
}
