using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string InvoiceId { get; set; }
        public decimal PayAmount { get; set; }
        public  int CustomerId { get; set; }
        public int BranchId { get; set; }
        public string ServiceNumber { get; set; }
        public DateTime RefDate { get; set; }
    }
}