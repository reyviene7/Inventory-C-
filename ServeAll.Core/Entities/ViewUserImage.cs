using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_user_image")]
    public class ViewUserImage
    {
        [Key]
        public string image_code { get; set; }
        public string img_location { get; set; }
        public string created_on { get; set; }
        public string updated_on { get; set; }
    }
}
