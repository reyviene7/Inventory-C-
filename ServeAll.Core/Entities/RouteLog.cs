using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("route_log")]
    public class RouteLog
    {
        [Key]
        public int route_log_id { get; set; }
        public int user_id { get; set; }
        public DateTime time_in { get; set; }
        public DateTime time_out { get; set; }
    }
}