using Dapper.Contrib.Extensions;
using System;

namespace ServeAll.Core.Entities
{
    [Table("authorized_machine")]
    public class AuthorizedMachine
    {
        [Key]
        public int authorized_id { get; set; }
        public string machine_name { get; set; }
        public string machine_key { get; set; }
        public DateTime date_register { get; set; }
    }
}
