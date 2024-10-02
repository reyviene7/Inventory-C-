using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_daily_expenses")]
    public class ViewDailyExpenses
    {
        [Key]
        public int expense_id { get; set; }
        public string type_name { get; set; }
        public decimal amount { get; set; }
        public string related_entity { get; set; }
        public int entity_id { get; set; }
        public string description { get; set; }
        public DateTime expense_date { get; set; }
    }
}