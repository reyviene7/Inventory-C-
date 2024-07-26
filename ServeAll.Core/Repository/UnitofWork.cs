using System;
using System.Data;

namespace ServeAll.Core.Repository
{
    public sealed class UnitofWork
    {
        private readonly IDbConnection _connection = null;
        private IDbTransaction _transaction = null;
        internal UnitofWork(IDbConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;
        }


        readonly Guid _id = Guid.Empty;

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        public Guid Id => _id;
        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;
        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            //_transaction.Rollback();
            Dispose();
        }
    }
}