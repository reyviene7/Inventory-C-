 

using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("view_return_warehouse_depot")]
   public class ViewReturnWareHouseDepot
    {
        [Key]
        public int Id               { get; set; }
        public string Code          { get; set; }
        public string Item          { get; set; }
        public string DeliveryNo    { get; set; }
        public decimal WareHouse    { get; set; }
        public string Origin        { get; set; }
        public DateTime Delivery    { get; set; }
        public DateTime Ref         { get; set; }
        public string Status        { get; set; }
        public string Remarks       { get; set; }
    }
}
