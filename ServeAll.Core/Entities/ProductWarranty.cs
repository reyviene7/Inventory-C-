using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("ProductWarranty")]
    public class ProductWarranty
    {
        [Key]
        public int WarProId { get; set; }
        public int ProductId { get; set; }
        public string SerailNumber { get; set; }
        public int WarrantyId { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceId { get; set; }
        public int BranchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
    }
}