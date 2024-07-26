using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("manufacture")]
    public class Manufacturer
    {
        [Key]
        public int manufacturer_id { get; set; }
        public int profile_id { get; set; }
        public int contact_id { get; set; }
        public int adddress_id { get; set; }
        public int company_id { get; set; }
        public DateTime date_register { get; set; }
    }
}