using System;
using Dapper.Contrib.Extensions;

namespace Inventory.Entities
{
    [Table("view_return_depot")]
    public class ViewReturnDepot
    {
        [Key]
        public int      Id          { get; set; }
        public string   Code        { get; set; }
        public string   Item        { get; set; }
        public string   DeliveryNo  { get; set; }
        public decimal QtyStock     { get; set; }
        public decimal  Qty         { get; set; }
        public string   Origin      { get; set; }
        public string   ToDepot     { get; set; }
        public DateTime Delivery    { get; set; }
        public DateTime RefDate     { get; set; }
        public string   Status      { get; set; }
        public string   Remarks     { get; set; }
        public int      WareHouse   { get; set; }

    }
}
