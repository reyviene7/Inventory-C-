using Dapper.Contrib.Extensions;

namespace ServeAll.Core.Entities
{
    [Table("view_lpg_gasul")]
    public class ViewLpgGasul
    {
        [Key]
        public int ProductId { get; set; }
    }
}
