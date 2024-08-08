using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_branch")]
    public class ViewBranch
    {
        public readonly string BranchDetails;

        [Key]
        public int branch_id { get; set; }
        public string branch_code { get; set; }
        public string branch_details { get; set; }
        public string barangay { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public int zip_code { get; set; }
        public string country { get; set; }
        public string telephone_number { get; set; }
        public string mobile_number { get; set; }
        public string email_address { get; set; }
        public string fax_number { get; set; }
        public DateTime date_register { get; set; }
    }
}