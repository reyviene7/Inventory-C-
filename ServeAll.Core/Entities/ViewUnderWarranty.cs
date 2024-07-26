using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_under_warranty")]
    public class ViewUnderWarranty
    {
        [Key]
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public decimal Retail { get; set; }
        public decimal LastCost { get; set; }
        public string Branch { get; set; }
        public string Warranty { get; set; }
        public string Status { get; set; }
    }
}