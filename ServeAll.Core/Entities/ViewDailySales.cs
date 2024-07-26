using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_daily_sales")]
   public class ViewDailySales
    {
        [Key]
        public int Id { get; set; }
        public string Invoice { get; set; }
        public string ReceiptNo { get; set; }
        public string Customer { get; set; }
        public decimal DueAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Gross { get; set; }
        public decimal NetSales { get; set; }
        public string Branch { get; set; }
        public DateTime RefDate { get; set; }         
    }
}
