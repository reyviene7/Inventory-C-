using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_store")]
    public class ViewStore
    {
        public readonly string StoreDetails;

        [Key]
        public int store_id { get; set; }
        public string store_name { get; set; }
        public string contact_person { get; set; }
        public string store_tin { get; set; }
        public string barangay { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public int zip_code { get; set; }
        public string country { get; set; }
        public string telephone_number { get; set; }
        public string mobile_number { get; set; }
        public string email_address { get; set; }
        public string web_url { get; set; }
    }
}