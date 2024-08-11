using System;

namespace ServeAll.Core.Repository
{
    public class RepositoryEntity
    {
        public static long AddEntity<T>(T entity) where T : class
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
         
                    var repository = new Repository<T>(unWork);
                    var result = repository.Add(entity);
                    if (result > 0)
                    {
                        unWork.Commit();
                        return result;
                    }
          
                
            }
            return 0L;
        }
    }
}
