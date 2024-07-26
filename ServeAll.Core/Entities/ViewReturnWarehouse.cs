using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_return_warehouse")]
    public class ViewReturnWarehouse
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Item { get; set; }
        public string ReturnNo { get; set; }
        public decimal ReturnQty { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime RetDate { get; set; }
        public DateTime RefDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int InventoryId { get; set; }
    }
}