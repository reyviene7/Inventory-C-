using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("view_service_images")]
    public class ViewServiceImages
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
