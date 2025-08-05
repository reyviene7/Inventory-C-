using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_supplier")]
    public class ViewSupplier
    {
        [Key]
        public int supplier_id { get; set; }
        public string supplier_code { get; set; }
        public string supplier_name{ get; set; }
        public string gender { get; set; }
        public string contact_name {  get; set; }
        public string email_address { get; set; }
        public string telephone_number { get; set; }
        public string fax_number { get; set; }
        public string mobile_number { get; set; }
        public string web { get; set; }
        public string barangay { get; set; }
        public string street { get; set; }
        public string province { get; set; }
        public int zip_code { get; set; }
        public string company_name { get; set; }
        public string company_type { get; set; }
        public DateTime date_register { get; set; }
    }
}