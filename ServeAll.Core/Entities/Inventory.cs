using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("inventory")]
    public class Inventory
    {
        [Key]
        public int inventory_id { get; set; }
        public string inventory_code { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public string delivery_code { get; set; }
        public int status_id { get; set; }
        public int user_id { get; set; }
        public int branch_id { get; set; }
        public DateTime inventory_date { get; set; }
        public decimal last_price_cost { get; set; }
        public DateTime updatedOn { get; set; }
    }
}