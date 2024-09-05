 

using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("report_return_warehouse")]
    public class ViewReturnWarehouse
    {
        [Key]
        public int return_id { get; set; }
        public string   product_name        { get; set; }
        public int return_quantity { get; set; }
        public string return_number { get; set; }
        public string branch_details        { get; set; }
        public decimal retail_price  { get; set; }
        public DateTime return_date { get; set; }
        public string status        { get; set; }
        public string remarks       { get; set; }
    }
}
