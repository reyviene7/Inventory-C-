using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_warehouse_delivery")]
    public class ViewWarehouseDelivery
    {
        [Key]
        public int delivery_id {  get; set; }
        public string product_code { get; set; }
        public string delivery_code { get; set; }
        public string warehouse_name { get; set; }
        public string product_name { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public string receipt_number { get; set; }
        public string username { get; set; }
        public int quantity_in_stock { get; set; }
        public string branch_details { get;set; }
        public DateTime delivery_date { get; set; }
        public DateTime update_on { get; set; }
        public string status_details { get; set; }
        public decimal cost_per_unit { get; set; }
        public int delivery_qty { get; set; }
        public decimal total_value { get; set; }
        public string delivery_status { get; set; }
        public string remarks { get; set; }
    }
}
