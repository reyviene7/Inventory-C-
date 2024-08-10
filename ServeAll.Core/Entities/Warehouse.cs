using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("warehouse")]
    public class Warehouse
    {
        [Key]
        public int warehouse_Id { get; set; }
        public string warehouse_name { get; set; }
        public int contact_id { get; set; }
        public int address_id { get; set; }
        public DateTime date_added { get; set; }
        public string warehouse_code { get; set; }
    }
}