using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("product_image")]
    public class ProductImages
    {
        [Key]
        public int image_id { get; set; }
        public string image_code { get; set; }
        public byte[] image { get; set; }
        public string title { get; set; }
        public string img_type { get; set; }
        public string img_location { get; set; }
        public int img_height { get; set; }
        public int img_width { get; set; }
    }
}