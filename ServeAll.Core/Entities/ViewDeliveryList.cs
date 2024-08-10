using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_delivery_list")]
    public class ViewDeliveryList
    {
        [Key]
        public int delivery_id { get; set; }
        public string delivery_code { get; set; }
        public string delivery_status {  get; set; } 
        public DateTime delivery_date {  get; set; }
        public int distinct_product_count {  get; set; }
        public string destination {  get; set; }
    }
}
