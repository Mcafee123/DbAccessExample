using NSubstitute;
using NUnit.Framework;
using RepositoryExample.Daten.Services;
using RepositoryExample.Daten.Test.Helpers;
using Util.Interfaces;

namespace RepositoryExample.Daten.Test.Repos
{
    [TestFixture]
    public class RepoTest
    {
        [Test]
        public void Transaction_für_Add_oeffnen_wenn_vorher_nicht_geschehen()
        {
            var sessionHandler = Substitute.For<ISqlSessionHandler>();
            var persistenceService = Substitute.For<IPersistenceService<ExampleDto>>();
            var repo = new RepoImplementation(sessionHandler, persistenceService);
            var entity = new ExampleEntity();

            var sqlSession = Substitute.For<ISqlSession>();
            sessionHandler.CreateSqlSession().Returns(sqlSession);
            var unitOfWork = Substitute.For<ISqlTransaction>();
            sqlSession.SqlTransaction.Returns(unitOfWork);

            repo.Add(entity);

            sessionHandler.Received(1).CreateSqlSession();
            unitOfWork.Received(1).Begin();
            unitOfWork.Received(1).Commit();
        }

        [Test]
        public void Transaction_für_Update_oeffnen_wenn_vorher_nicht_geschehen()
        {
            var sessionHandler = Substitute.For<ISqlSessionHandler>();
            var persistenceService = Substitute.For<IPersistenceService<ExampleDto>>();
            var repo = new RepoImplementation(sessionHandler, persistenceService);
            var entity = new ExampleEntity();

            var sqlSession = Substitute.For<ISqlSession>();
            sessionHandler.CreateSqlSession().Returns(sqlSession);
            var unitOfWork = Substitute.For<ISqlTransaction>();
            sqlSession.SqlTransaction.Returns(unitOfWork);

            repo.Update(entity);

            sessionHandler.Received(1).CreateSqlSession();
            unitOfWork.Received(1).Begin();
            unitOfWork.Received(1).Commit();
        }
    }
}