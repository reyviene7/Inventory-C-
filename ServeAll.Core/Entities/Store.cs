using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("store")]
    public class Store
    {
        [Key]
        public int store_id { get; set; }
        public string store_name { get; set; }
        public string store_tin { get; set; }
        public int contact_id { get; set; }
        public int address_id { get; set; }

        [Write(false)]
        public Address Address { get; set; }

        [Write(false)]
        public Contact Contact { get; set; }

        [Write(false)]
        public Company Company { get; set; }
    }
} 