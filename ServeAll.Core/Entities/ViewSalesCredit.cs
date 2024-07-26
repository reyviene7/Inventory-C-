using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_salescredit")]
    public class ViewSalesCredit
    {
        [Key]
        public int      Id              { get; set; }
        public string   Invoice         { get; set; }
        public string   ServiceNo       { get; set; }
        public string   Customer        { get; set; }
        public decimal  AmountCredit    { get; set; }
        public decimal  PaidAmount      { get; set; }
        public string   Branch          { get; set; }
        public DateTime RefDate         { get; set; }
    }
}