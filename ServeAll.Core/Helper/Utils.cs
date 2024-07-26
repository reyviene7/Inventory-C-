using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ServeAll.Core.Helper
{
    public static class Utils
    {
        public static bool IsAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }

        public static bool IsEntity<T>(this T data)
        {
            return data != null && data.ToString().Length > 0;
        }
    }
}