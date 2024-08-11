using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("view_warehouse_inventory")]
    public class ViewWareHouseInventory
    {
        [Key]
        public int inventory_id { get; set; }
        public string product_code { get; set; }
        public string sku { get; set; }
        public int quantity_in_stock { get; set; }
        public int reorder_level { get; set; }
        public string location_code { get; set; }
        public string warehouse_name { get; set; }
        public int user_id { get; set; }
        public string supplier_name { get; set; }
        public DateTime last_stocked_date { get; set; }
        public DateTime last_ordered_date { get; set; }
        public DateTime expiration_date { get; set; }
        public decimal cost_per_unit { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public decimal total_value { get; set; }
        public string status_details { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
