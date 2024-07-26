using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("Credit")]
    public class Credit
    {
        [Key]
        public int      CreditId     { get; set; }
        public string   InvoiceId    { get; set; }
        public decimal  AmountCredit { get; set; }
        public decimal  PaidAmount   { get; set; }
        public decimal  Discount     { get; set; }
        public decimal  NetSales     { get; set; }
        public int      CustomerId   { get; set; }
        public int      BranchId     { get; set; }
        public string   ServiceNumber { get; set; }
        public DateTime RefDate      { get; set; }
    }
}