using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Class
{
    [Table("report_depot_delivery")]
   public class DepotDelivery
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Qty { get; set; }
        public string DeliveryNo { get; set; }
        public string Branch { get; set; }
        public decimal LastCost { get; set; }
        public decimal RetailPrice { get; set; }
        public DateTime Purchase { get; set; }
        public string Status { get; set; }
    }
}
