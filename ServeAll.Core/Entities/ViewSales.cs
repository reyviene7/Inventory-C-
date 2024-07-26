using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_sales")]
    public class ViewSales
    {
        [Key]
        public int Id { get; set; }
        public string Customer { get; set; }
        public string InvoiceId { get; set; }
        public decimal AmountDue { get; set; }
        public decimal PaidAmount { get; set; }
        public  decimal Discount { get; set; }
        public decimal NetSales { get; set; }
        public int BranchId { get; set; }
        public string Receipt { get; set; }
        public DateTime RefDate { get; set; }
    }
}