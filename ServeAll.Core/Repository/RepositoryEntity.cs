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

        public static int UpdateEntity<T>(int entityId, Action<T> updateAction) where T : class
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<T>(unWork);
                    var entity = repository.Id(entityId);
                    if (entity != null)
                    {
                        updateAction(entity);
                        var result = repository.Update(entity);
                        if (result)
                        {
                            unWork.Commit();
                            return 1; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    unWork.Rollback();
                }
                return 0; 
            }
        }

        public static int DeleteEntity<T>(int entityId, Action<T> updateAction) where T : class
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<T>(unWork);
                    var entity = repository.Id(entityId);
                    if (entity != null)
                    {
                        updateAction(entity);
                        var result = repository.Delete(entity);
                        if (result)
                        {
                            unWork.Commit();
                            return 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    unWork.Rollback();
                }
                return 0;
            }
        }

    }
}
