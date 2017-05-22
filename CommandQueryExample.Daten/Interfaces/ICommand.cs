using System.Data;
using Util.Interfaces;

namespace CommandQueryExample.Daten.Interfaces
{
    public interface ICommand
    {
        void Execute(ISqlSessionHandler sessionHandler);
    }
}