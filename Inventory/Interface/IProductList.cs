using System.Collections.Generic;
using Inventory.Class;
 

namespace Inventory.Interface
{
    public interface IProductList
    {
        IEnumerable<ProductList> DataSource();
    }
}
