using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("CreditParticular")]
    public class CreditParticular
    {
        [Key]
        public int ParticularId { get; set; }
        public string InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Gross { get; set; }
        public decimal NetSales { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public DateTime PurchaseOn { get; set; }
    }
}