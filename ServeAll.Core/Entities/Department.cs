using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("department")]
    public class Department
    {
        [Key]
        public int department_id { get; set; }
        public string department_name { get; set; }
        public int address_id { get; set; }
        public int contact_id { get; set; }
    }
}
