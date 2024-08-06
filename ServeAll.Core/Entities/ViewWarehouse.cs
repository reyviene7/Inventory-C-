using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{

    [Table("view_warehouse")]
    public class ViewWarehouse
    {
        public string warehouse_code { get; set; }
        public string warehouse_name {  get; set; }
        public string full_address {  get; set; }
        public string contact_name {  get; set; }
        public string telephone_number {  get; set; }
        public string mobile_number {  get; set; }
        public string mobile_secondary {  get; set; }
        public string email_address {  get; set; }
        public string web_url {  get; set; }
        public string fax_number {  get; set; }
    }
}
