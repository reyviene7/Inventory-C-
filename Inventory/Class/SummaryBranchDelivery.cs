using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Class
{
    [Table("view_delivery_branch")]
    public class SummaryBranchDelivery
    {
        [Key]
    
        public int ProductId { get; set; }
        public string Item { get; set; }
        public decimal Quantity { get; set; }
        public int BranchId { get; set; }
        public decimal Total { get; set; }
        public DateTime RefDate { get; set; }
    }
}