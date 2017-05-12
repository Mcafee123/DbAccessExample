using System;

namespace Util.Interfaces
{
    public interface ISqlSession : IDisposable
    {
        UnitOfWork UnitOfWork { get; }
    }
}