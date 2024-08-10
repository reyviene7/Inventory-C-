using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("delivery")]
    public class Delivery
    {
        [Key]
        public int delivery_id {  get; set; } 
        public string delivery_code { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public int user_id { get; set; }
        public int warehouse_id { get; set; }
        public int branch_id  { get; set; }
        public DateTime delivery_date { get; set; }
        public decimal last_price_cost { get; set; }
        public int delivery_status_id { get; set; }
        public string remarks { get; set; }
    }
}