using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("receive_return")]
    public class ReceivedReturn
    {
        [Key]
        public int receive_return_id { get; set; }
        public string return_code    { get; set; }
        public int product_id        { get; set; }
        public string return_number      { get; set; }
        public int return_quantity { get; set; }
        public int branch_id         { get; set; }
        public string destination      { get; set; }
        public DateTime return_date { get; set; }
        public int status_id         { get; set; }
        public string remarks       { get; set; }
        public int inventory_id      { get; set; }
        public DateTime update_on { get; set; }
        public DateTime received_date { get; set; }
    }
}