using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities.request
{
    [Table("view_request_product")]
    public class RequestProducts
    {
        [Key]
        public int product_id { get; set; }
      
        public string product_name { get; set; }
    }
}
