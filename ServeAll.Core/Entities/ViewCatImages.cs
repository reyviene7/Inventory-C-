using System.Security;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_categoryImage")]
    public class ViewCatImages
    {
        [Key]
        public int ImageId { get; set; }
        public string Code { get; set;}
    }
}