using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_inventorylist")]
    public class ViewInventoryList
    {
        [Key]
        public int inventory_id { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public decimal quantity { get; set; }
        public string status { get; set; }
        public string branch_details { get; set; }
    }
}