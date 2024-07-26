using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_employees")]
    public class ViewEmployees
    {
        [Key]
        public int employee_id { get; set; }
        public string employee_code { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public DateTime birthdate { get; set; }
        public string civil_status { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string sss_number { get; set; }
        public string philhealth { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public DateTime date_hired { get; set; }
        public DateTime date_registered { get; set; }
    }
}