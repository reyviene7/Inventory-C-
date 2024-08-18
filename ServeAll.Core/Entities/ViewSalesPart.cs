using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_sales_particular")]
    public class ViewSalesPart
    {
        [Key]
        public int id { get; set; }
        public string invoice { get; set; }
        public string barcode { get; set; }
        public string item { get; set; }
        public decimal qty { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public decimal  gross { get; set; }
        public  decimal net { get; set; }
        public string customer { get; set; }
        public string branch{ get; set; }
        public DateTime date { get; set; }
    }
}