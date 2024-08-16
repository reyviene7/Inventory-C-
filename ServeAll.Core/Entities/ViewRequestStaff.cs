using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_request_staff")]
    public class ViewRequestStaff
    {
        [Key]
        public int employee_id { get; set; }
        public string employee_code { get; set; }
        public string staff { get; set; }
    }
}
