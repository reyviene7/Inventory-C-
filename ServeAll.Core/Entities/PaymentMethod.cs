using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("payment_method")]
    public class PaymentMethod
    {
        [Key]
        public int payment_method_id { get; set; }
        public string method_name { get; set; }
    }
}