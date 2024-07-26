 

using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Class
{
    [Table("report_branch_delivery")]
    public class BranchDelivery
    {
        [Key]
        public int      Id          { get; set; }
        public string   Item        { get; set; }
        public decimal  Qty         { get; set; }
        public string   Delivery    { get; set; }
        public string   Branch      { get; set; }
        public decimal  LastCost    { get; set; }
        public decimal  RetailPrice { get; set; }
        public DateTime RefDate     { get; set; }
        public string   Warranty    { get; set; }
        public string   Status      { get; set; }
    }
}
