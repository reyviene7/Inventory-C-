using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("view_warehouse")]
    public class ViewWareHouse
    {
        [Key]
        public int Id           { get; set; }
        public string Code      { get; set; }
        public string Item      { get; set; }
        public decimal Qty      { get; set; }
        public string Delivery  { get; set; }
        public string Receipt   { get; set; }
        public string Branch    { get; set; }
        public decimal LastCost { get; set; }
        public int OnOrder      { get; set; }
        public DateTime Purchase{ get; set; }
        public DateTime RefDate { get; set; }
        public string Warranty  { get; set; }
        public string Status    { get; set; }
        public int    DepotId   { get; set; }
    }
}