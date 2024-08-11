using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("warehouse_inventory")]
    public class WarehouseInventory
    {
        [Key]
        public int inventory_id { get; set; }
        public int product_id { get; set; }
        public string sku { get; set; }
        public int quantity_in_stock { get; set; }
        public int reorder_level { get; set; }
        public int location_id { get; set; }
        public int warehouse_id { get; set; }
        public int user_id { get; set; }
        public int supplier_id { get; set; }
        public DateTime last_stocked_date { get; set; }
        public DateTime last_ordered_date { get; set; }
        public DateTime expiration_date { get; set; }
        public decimal cost_per_unit { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public int status_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
