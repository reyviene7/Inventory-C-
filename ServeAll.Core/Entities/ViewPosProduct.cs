using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_product_inventory")]
    public class ViewPosProduct
    {
        [Key]
        public string code { get; set; }
        public string item { get; set; }
        public decimal qty { get; set; }
        public decimal retail_price { get; set; }
        public decimal wholesale { get; set; }
        public string status { get; set; }
        public string branch {  get; set; }
    }
}