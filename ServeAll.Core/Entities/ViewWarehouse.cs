using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{

    [Table("view_warehouse")]
    public class ViewWarehouse
    {
        [Key]
        public int warehouse_id { get; set; }
        public string warehouse_code { get; set; }
        public string warehouse_name {  get; set; } 
        public string street { get; set; }
        public string barangay { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
        public string contact_name {  get; set; }
        public string telephone_number {  get; set; }
        public string mobile_number {  get; set; }
        public string mobile_secondary {  get; set; }
        public string email_address {  get; set; }
        public string web_url {  get; set; }
        public string fax_number {  get; set; }
        public DateTime date_added { get; set; }

    }
}
