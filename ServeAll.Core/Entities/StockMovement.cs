using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("stock_movement")]
    public class StockMovement
    {
        [Key]
        public int      stock_movement_id {  get; set; }
        public string   movement_code { get; set; }
        public string   movement_type { get; set; }
        public DateTime date { get; set; }
        public int      source_warehouse_id { get; set; }
        public int      destination_warehouse_id { get; set; }
        public int      source_branch_id { get; set; }
        public int      destination_branch_id { get;set; }

    }
}
