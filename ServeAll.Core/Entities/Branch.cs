using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("branch")]
    public class Branch
    {
        [Key]
        public int branch_id { get; set; }
        public string branch_code { get; set; } 
        public string branch_details { get; set; }
        public int address_id { get; set; }
        public int contact_id { get; set; }
        public readonly string BranchDetails;
        public DateTime date_register { get; set; }
    }
}