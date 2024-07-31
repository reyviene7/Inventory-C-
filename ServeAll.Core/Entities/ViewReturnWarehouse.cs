using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_return_warehouse")]
    public class ViewReturnWarehouse
    {
        [Key]
        public int return_id { get; set; }
        public string return_code { get; set; }
        public string product_code { get; set; }
        public string return_number { get; set; }
        public decimal return_quantity { get; set; }
        public string branch_code { get; set; }
        public string destination { get; set; }
        public DateTime return_date { get; set; }
        public string status_id { get; set; }
        public string remarks { get; set; }
        public int inventory_code { get; set; }
    }
}