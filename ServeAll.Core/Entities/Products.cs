using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("products")]
    public class Products
    {
        [Key]
        public int          product_id   { get; set; }
        public string       product_code        { get; set; }
        public string       product_name        { get; set; }
        public int          category_id  { get; set; }
        public int          supplier_id  { get; set; }
        public string       stock_code   { get; set; }
        public string       brand       { get; set; }
        public string       model       { get; set; }
        public string       made        { get; set; }
        public string       serial_number      { get; set; }
        public decimal      tare_weight  { get; set; }
        public decimal      net_weight   { get; set; }
        public decimal      trade_price       { get; set; }
        public decimal      retail_price { get; set; }
        public decimal      wholesale { get; set; }
        public int          status_id{ get; set; }
        public DateTime     date_register    { get; set; }

    }
}