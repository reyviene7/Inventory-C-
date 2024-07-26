using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_posEntity")]
    public class ViewPosEntity
    {
        [Key]
        public string Code { get; set; }
        public DateTime PurDate { get; set; }
    }
}
