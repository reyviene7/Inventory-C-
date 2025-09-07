using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("view_cash_breakdown")]
    public class ViewCashBreakdown
    {
        [Key]
        public int breakdown_id { get; set; }
        public int b1000 { get; set; }
        public int b500 { get; set; }
        public int b200 { get; set; }
        public int b100 { get; set; }
        public int b50 { get; set; }
        public int b20 { get; set; }
        public decimal coins { get; set; }
        public decimal total { get; set; }
        public string User { get; set; }
        public DateTime date_register { get; set; }
        public DateTime date_update { get; set; }
    }
}
