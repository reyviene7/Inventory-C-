using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("daily_expenses")]
    public class DailyExpenses
    {
        [Key]
        public int expense_id { get; set; }
        public int expense_type_id { get; set; }
        public int employee_id { get; set; }
        public decimal amount { get; set; }
        public  int entity_id { get; set; }
        public string description { get; set; }
        public DateTime expense_date { get; set; }
    }
}