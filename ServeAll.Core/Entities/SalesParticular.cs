using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("sales_particular")]
    public class SalesParticular
    {
        [Key]
        public int      particular_id{ get; set; }
        public string   sale_id   { get; set; }
        public int      product_id   { get; set; }
        public string   barcode     { get; set; }
        public decimal  quantity    { get; set; }
        public decimal  unit_price   { get; set; }
        public decimal  tax         { get; set; }
        public decimal  discount    { get; set; }
        public decimal  gross       { get; set; }
        public decimal  net_sales    { get; set; }
        public int      customer_id  { get; set; }
        public int      user_id      { get; set; }
        public int      branch_id    { get; set; }
        public DateTime purchase_date  { get; set; }
    }
}