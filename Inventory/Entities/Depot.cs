using System;
using Dapper.Contrib.Extensions;
 

namespace Inventory.Entities
{
    [Table("Depot")]
    public class Depot
    {
        [Key]
        public int DepotId { get; set; }
        public string Code { get; set; }
        public int ProductId { get; set; }
        public string DeliveryNo { get; set; }
        public string ReceiptNo { get; set; }
        public decimal QtyStock { get; set; }
        public int BranchId { get; set; }
        public decimal LastCost { get; set; }
        public int OnOrder { get; set; }
        public DateTime PurDate { get; set; }
        public DateTime InvDate { get; set; }
        public int WarrantyId { get; set; }
        public int StatusId { get; set; }
    }
}