using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_stock_movement")]
    public class ViewStockMovement
    {
        [Key]
        public int stock_movement_id { get; set; }
        public string movement_code { get; set; }
        public string movement_type {  get; set; } 
        public DateTime delivery_date {  get; set; }
        public int distinct_product_count {  get; set; }

        public string destination {  get; set; }
    }
}
