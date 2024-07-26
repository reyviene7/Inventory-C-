using System.Data;
 
namespace ServeAll.Core.Repository
{
    public abstract class RepositoryBase
    {
      

        protected RepositoryBase(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        protected IDbTransaction Transaction { get; }
        public IDbConnection OConnection => Transaction.Connection;
    }
}