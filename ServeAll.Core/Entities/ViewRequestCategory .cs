using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_request_category")]
    public class ViewRequestCategory
    {
        [Key]
        public int category_id { get; set; }
        public string category_details { get; set; }
    }
}
