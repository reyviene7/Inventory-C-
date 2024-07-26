using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("Finger")]
    public class Finger
    {
        [Key]
        public int FingerId { get; set; }
        public int EmployeeId { get; set; }
        public int FingerIndex { get; set; }
        public string FingerBytes { get; set; }
    }
}