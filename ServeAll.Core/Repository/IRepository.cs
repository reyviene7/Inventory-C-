using System.Collections.Generic;

namespace ServeAll.Core.Repository
{
    public interface IRepository<in T>  where T: class 
    {
        long Add(T entity);
        long Add(IEnumerable<T> entity);  
        bool Update(T entity);
        bool Update(IEnumerable<T> entity);
        bool Delete(T entity);
    }
}