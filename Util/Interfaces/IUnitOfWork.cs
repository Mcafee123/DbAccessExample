using System;
using System.Data;

namespace Util.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}