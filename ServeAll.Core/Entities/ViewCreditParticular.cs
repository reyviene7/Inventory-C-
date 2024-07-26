 

using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_credit_particular")]
    public class ViewCreditParticular
    {
        [Key]
        public int Id { get; set; }
        public string Invoice { get; set; }
        public string Customer { get; set; }
        public string ItemName { get; set; }
        public string Code { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Gross { get; set; }
        public decimal NetSales { get; set; }
        public string Branch { get; set; }
        public DateTime RefDate { get; set; }
    }

}
