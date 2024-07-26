using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_SalesPart")]
    public class ViewSalesPart
    {
        [Key]
        public int      Id { get; set; }
        public string   InvoiceId { get; set; }
        public string   Barcode { get; set; }
        public string   Name { get; set; }
        public decimal  Qty { get; set; }
        public decimal  UnitPrice { get; set; }
        public decimal  Discount { get; set; }
        public decimal  Gross { get; set; }
        public  decimal NetSales { get; set; }
        public string   CustomerId { get; set; }
        public int      BranchId { get; set; }
        public DateTime RefDate { get; set; }
    }
}