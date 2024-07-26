 

using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Class
{
    [Table("report_return_delivery_depot")]
    public class ReturnDepot
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Qty { get; set; }
        public string ReturnNo { get; set; }
        public decimal RetailPrice { get; set; }
        public DateTime Delivery { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
