using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("warehouse_delivery")]
    public class WarehouseDelivery
    {
        [Key]
        public int delivery_id {  get; set; }
        public int product_id { get; set; }
        public string delivery_code { get; set; }
        public int warehouse_id { get; set; }
        public int inventory_id { get; set; }
        public string receipt_number { get; set; }
        public int branch_id { get;set; }
        public DateTime delivery_date { get; set; }
        public int status_id { get; set; }
        public int delivery_qty { get; set; }
        public int delivery_status_id { get; set; }
        public string remarks { get; set; }
    }
}
