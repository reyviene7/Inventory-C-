using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("user_image")]
    public class UserImage
    {
        [Key]
        public int image_id { get; set; }
        public string image_code { get; set; }
        public string title { get; set; }
        public string img_type { get; set; }
        public string img_location { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
    }
}
