using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("ReturnDepot")]
    public class ReturnDepot
    {
        [Key]
        public int ReturnId     { get; set; }
        public string ReturnCode { get; set; }
        public int ProductId    { get; set; }
        public string ReturnNo  { get; set; }
        public decimal ReturnQty { get; set; }
        public int Origin       { get; set; }
        public int ToDepot      { get; set; }
        public DateTime Delivery { get; set; }
        public DateTime RefDate { get; set; }
        public int StatusId     { get; set; }
        public string Remarks   { get; set; }
        public int WareHouseId  { get; set; }
    }
}