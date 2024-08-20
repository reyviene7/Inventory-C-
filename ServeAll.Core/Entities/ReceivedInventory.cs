using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("received_inventory")]
    public class ReceivedInventory
    {
        [Key]
        public int received_id { get; set; }
        public int product_id { get; set; }
        public int delivery_id { get; set; }
        public string delivery_code { get; set; }
        public int warehouse_id { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public decimal item_price { get; set; }
        public decimal retail_price { get; set; }
        public decimal whole_sale { get; set; }
        public string receipt_number { get; set; }
        public int user_id { get; set; }
        public int branch_id { get; set; }
        public int status_id { get; set; }
        public int delivery_qty { get; set; }
        public int delivery_status_id { get; set; }
        public DateTime received_date { get; set; }
        public DateTime update_on { get; set; }
        public string remarks { get; set; }
    }
}
