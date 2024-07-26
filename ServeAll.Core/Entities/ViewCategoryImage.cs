using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_category_image")]
    public class ViewCategoryImage
    {
        [Key]
        public int CategoryId           { get; set; }
        public string CategoryCode      { get; set; }
        public string CategoryDetails   { get; set; }
        public string Title             { get; set; }
        public DateTime DateRegister    { get; set; }
    }
}