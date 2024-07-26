using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("EmployeeImages")]
    public class EmployeeImage
    {
        [Key]
        public int ImageId              { get; set; }
        public int EmployeeId           { get; set; }
        public string ImageCode         { get; set; }
        public byte[] Image             { get; set; }
        public string Title             { get; set; }
        public string ImgType           { get; set; }
        public string ImgLocation       { get; set; }
        public int ImgHeight            { get; set; }
        public int ImgWidth             { get; set; }
    }
}