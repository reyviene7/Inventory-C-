using System;
using System.Data;

namespace ServeAll.Core.Repository
{
    public interface IUnitofWorks: IDisposable  
    {
        Guid Id { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}