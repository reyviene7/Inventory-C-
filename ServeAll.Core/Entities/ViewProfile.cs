using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_profile")]
    public class ViewProfile
    {
        [Key]
        public int profile_id { get; set; }
        public int contact_id { get; set; }
        public int address_id { get; set; }
        public string profile_code { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_initial { get; set; }
        public string gender { get; set; }
        public DateTime birthdate { get; set; }
        public string civil_status { get; set; }
        public string telephone_number { get; set; }
        public string mobile_number { get; set; }
        public string email_address { get; set; }
        public string barangay { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public int zip_code { get; set; }
        public string country { get; set; }
        public string user_id { get; set; }
        public string sss_number { get; set; }
        public string phil_health { get; set; }
        public string position { get; set; }
        public int department_id { get; set; }
        public string department_name { get; set; }
        public DateTime hire_date { get; set; }
        public DateTime date_register { get; set; }
    }
}
