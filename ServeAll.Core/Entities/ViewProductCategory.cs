using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_product_category")]
    public class ViewProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDetails { get; set; }
        public int ImageId{ get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SupplierId{ get; set; }
        public string StockCode { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Made { get; set; }
        public string Serial{ get; set; }
        public decimal TareWeight { get; set; }
        public decimal NetWeight{ get; set; }
        public decimal TradePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholeSale { get; set; }
        public int StatusId{ get; set; }
        public string Status        { get; set; }
        public DateTime  DateRegister{ get; set; }
  
    }
}