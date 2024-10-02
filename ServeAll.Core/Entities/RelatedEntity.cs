using System;
using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("related_entity")]
    public class RelatedEntity
    {
        [Key]
        public int entity_id { get; set; }
        public string related_entity { get; set; }
    }
}