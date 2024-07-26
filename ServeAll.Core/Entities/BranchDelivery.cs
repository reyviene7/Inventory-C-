using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("BranchDelivery")]
    public class BranchDelivery
    {
        [Key]
        public int      BranchDeliveryId { get; set; }
        public string   Code             { get; set; }
        public int      ProductId        { get; set; }
        public int      WareHouseId      { get; set; }
        public decimal  QtyStock         { get; set; }
        public string   DeliveryNo       { get; set; }
        public string   ReceiptNo        { get; set; }
        public int      BranchId         { get; set; }
        public decimal  LastCost         { get; set; }
        public int      OnOrder          { get; set; }
        public int      WarrantyId       { get; set; }
        public int      StatusId         { get; set; }
        public DateTime DeliveryDate     { get; set; }
    }
}