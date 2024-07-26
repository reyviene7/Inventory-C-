namespace ServeAll.Core.Repository
{
    public interface Sample<T> where T : class
    {
        T getVAlue(string query);
    }

     
}