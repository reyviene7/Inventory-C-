using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_inventory")]
    public class ViewInventory
    {
        [Key]
        public int    InventoryId       { get; set; }
        public string Code              { get; set; }
        public string Barcode           { get; set; }
        public string Product           { get; set; }
        public string DeliveryNo        { get; set; }
        public string ReceiptNo         { get; set; }
        public decimal QtyStock         { get; set; }
        public string Branch            { get; set; }
        public decimal  RetailPrice     { get; set; }
        public int      OnOrder         { get; set; }
        public DateTime PurDate         { get; set; }
        public DateTime InvDate         { get; set; }
        public string Warranty          { get; set; }
        public string   Status          { get; set; }
    }
}