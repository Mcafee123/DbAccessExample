namespace Util.Interfaces
{
    public interface ISessionFactory
    {
        ISqlSession CreateSqlSession();
    }
}