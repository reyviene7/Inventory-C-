using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_category")]
    public class ViewCategory
    {
        [Key]
        public int category_id           { get; set; }
        public string category_code      { get; set; }
        public string category_details   { get; set; }
        public DateTime date_register    { get; set; }
    }
}