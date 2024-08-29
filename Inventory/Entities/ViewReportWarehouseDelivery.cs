 

using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("report_warehouse_delivery")]
    public class ViewReportWareHousetDelivery
    {
        [Key]
        public int      delivery_id          { get; set; }
        public string   product_name        { get; set; }
        public decimal quantity_in_stock { get; set; }
        public string delivery_code { get; set; }
        public string branch_details { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public decimal retail_price { get; set; }
        public DateTime delivery_date { get; set; }
        public string   status_details      { get; set; }
    }
}
