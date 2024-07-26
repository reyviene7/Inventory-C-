using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_product_warranty")]
    public class ViewProductWarranty
    {
        [Key]
        public int Id { get; set; }
        public  string Invoice { get; set; }
        public  string Barcode { get; set; }
        public  string Product { get; set; }
        public  decimal Quantity { get; set; }
        public  decimal Price { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public DateTime WarrantyOn { get; set; }
        public DateTime Expiration { get; set; }
        public int NoDays { get; set; }

    }
}