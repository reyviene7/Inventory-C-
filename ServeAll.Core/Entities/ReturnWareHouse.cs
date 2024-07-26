using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("ReturnWareHouse")]
    public class ReturnWareHouse
    {
        [Key]
        public int ReturnId         { get; set; }
        public string ReturnCode    { get; set; }
        public int ProductId        { get; set; }
        public string ReturnNo      { get; set; }
        public decimal ReturnQty    { get; set; }
        public int BranchId         { get; set; }
        public int Destination      { get; set; }
        public DateTime ReturnDelivery { get; set; }
        public DateTime RefDate     { get; set; }
        public int StatusId         { get; set; }
        public string Remarks       { get; set; }
        public int InventoryId      { get; set; }
    }
}