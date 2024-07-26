using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_SalesWarranty")]
    public class ViewSalesWarranty
    {
        [Key]
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public string ReceiptNo { get; set; }
        public string ItemName { get; set; }
        public string SerailNumber { get; set; }
        public string Warranty { get; set; }
        public string Customer { get; set; }
        public int BranchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

    }
}