using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeAll.Core.Repository
{
   public interface TargetClass<T> where T: class
    {
        T getValue(string query);
    }
}
