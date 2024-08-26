using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("view_accepted_delivery")]
    public class ViewAcceptedDelivery
    {
        [Key]
        public int received_id { get; set; }
        public string product_code { get; set; }
        public string delivery_code { get; set; }
        public int delivery_qty { get; set; }
        public decimal last_cost_per_unit { get; set; }
        public decimal item_price { get; set; }
        public decimal retail_price { get; set; }
        public decimal whole_sale { get; set; }
        public decimal total_value { get; set; }
        public string receipt_number { get; set; }
        public string username { get; set; }
        public string warehouse_name { get; set; }
        public string branch_details { get; set; }
        public string status_details { get; set; }
        public string delivery_status { get; set; }
        public DateTime received_date { get; set; }
        public DateTime update_on { get; set; }
        public string remarks { get; set; }
    }
}
