using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_inventory")]
    public class ViewInventory
    {
        [Key]
        public int inventory_id { get; set; }
        public string inventory_code { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string delivery_code { get; set; }
        public decimal quantity { get; set; }
        public string branch_details { get; set; }
        public decimal retail_price { get; set; }
        public int on_order { get; set; }
        public DateTime inventory_date { get; set; }
        public string   status          { get; set; }
    }
}