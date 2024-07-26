using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_payment")]
    public class ViewPayment
    {
        [Key]
        public int Id { get; set; }
        public string Invoice { get; set; }
        public string ServiceNo { get; set; }
        public decimal PayAmount { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public DateTime RefDate { get; set; }
    }
}