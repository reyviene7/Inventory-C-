namespace ServeAll.Core.Helper
{
    public static class ParamQuery
    {
        public static string Execute(string table, string param, string par1M, string condition1, string condition2)
        {
            return "SELECT * FROM " + table + "WHERE " + condition1 + "="+param+" AND "+condition2+"="+par1M;
        }
    }
}