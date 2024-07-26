using System.Text.RegularExpressions;

namespace Inventory.Config
{
   public static class StringExtension
    {
       public static string TrimReduced(this string input)
       {
           return ConvertToWhiteSpaces(input).Trim();
       }

       public static string ConvertToWhiteSpaces(this string value)
       {
           return Regex.Replace(value, @"\s+", " ");
       }
    }
}
