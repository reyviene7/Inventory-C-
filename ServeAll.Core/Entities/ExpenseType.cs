using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("expense_type")]
    public class ExpenseType
    {
        [Key]
        public int expense_type_id { get; set; }
        public string type_name { get; set; }
        public string description { get; set; }
    }
}