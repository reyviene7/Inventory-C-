using System.Collections.Generic;
using Inventory.Class;
 

namespace Inventory.Interface
{
    public interface IInventoryList
    {
        IEnumerable<InventoryList> DataSource();
    }
}
