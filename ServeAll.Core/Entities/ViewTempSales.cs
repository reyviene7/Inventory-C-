using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("view_temp_daily_sales")]
    public class ViewTempSales
    {
        [Key]
        public int particular_id { get; set; }
        public string invoice_id { get; set; }
        public string barcode { get; set; }
        public string item { get; set; }
        public decimal unit_price { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }    
        public decimal gross { get; set; }
        public decimal net_sales { get; set; }
        public string branch { get; set; }
        public string customer { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
    }
}