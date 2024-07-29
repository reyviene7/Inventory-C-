using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_image_product")]
    public class ViewImageProduct
    {
        [Key]
        public string image_code { get; set; }
        public string img_location { get; set; }
        public int branch_id { get; set; }
    }
}
