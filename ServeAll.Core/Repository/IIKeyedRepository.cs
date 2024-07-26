namespace ServeAll.Core.Repository
{
    public interface IIKeyedRepository<out T> where T: class 
    {
        T Id(int id);
        T SearchBy(string code);
    }
}