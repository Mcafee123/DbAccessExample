using System;

namespace Util.Interfaces
{
    public interface ISqlSession : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}