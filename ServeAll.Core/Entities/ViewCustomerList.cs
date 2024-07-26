using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_customer_credit_list")]
    public class ViewCustomerList
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string customer { get; set; }
        public string c_limit { get; set; }
        public string used { get; set; }
        public string address { get; set; }
        public string client_type { get; set; }
    }
}