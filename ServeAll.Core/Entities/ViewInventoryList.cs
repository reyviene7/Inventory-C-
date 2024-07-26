using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_inventorylist")]
    public class ViewInventoryList
    {
        [Key]
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public string Warranty { get; set; }
        public string Status { get; set; }
        public string Branch { get; set; }
    }
}