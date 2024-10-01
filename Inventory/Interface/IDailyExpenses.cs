using System.Collections.Generic;
using Inventory.Class;
 

namespace Inventory.Interface
{
    public interface IDailyExpenses
    {
        IEnumerable<DailyExpenses> DataSource();
    }
}
