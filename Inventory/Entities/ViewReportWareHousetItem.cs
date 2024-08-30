

using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("report_warehouse_item")]
    public class ViewReportWareHousetItem
    {
        [Key]
        public int inventory_id { get; set; }
        public string product_name { get; set; }
        public decimal quantity_in_stock { get; set; }
        public string sku { get; set; }
        public string warehouse_name { get; set; }
        public decimal cost_per_unit { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public DateTime updated_at { get; set; }
        public string status_details { get; set; }
    }
}
