using System;
using NSubstitute;
using NUnit.Framework;
using Util.Interfaces;

namespace Util.Test
{
    [TestFixture]
    public class SqlSessionHandlerTest
    {
        private ISqlSessionHandler GetSessionHandler(bool hasTransaction, out ISqlSessionFactory sqlSessionFactory,
            out ISqlSession sqlSession)
        {
            sqlSessionFactory = Substitute.For<ISqlSessionFactory>();
            var sessionHandler = new SqlSessionHandler(sqlSessionFactory);
            sqlSession = Substitute.For<ISqlSession>();
            sqlSessionFactory.CreateSqlSession().Returns(sqlSession);
            sqlSession.HasTransaction.Returns(hasTransaction);
            return sessionHandler;
        }

        [Test]
        public void Default_Read_oeffnet_neue_Connection()
        {
            ISqlSessionFactory sqlSessionFactory;
            ISqlSession sqlSession;
            var sessionHandler = GetSessionHandler(false, out sqlSessionFactory, out sqlSession);

            sessionHandler.Read(() => "hallo");

            sqlSessionFactory.Received(1).CreateSqlSession();
            sqlSession.DidNotReceive().Begin();
            sqlSession.DidNotReceive().Commit();
            sqlSession.Received(1).Dispose();
        }

        [Test]
        public void Default_Write_mit_Action_oeffnet_neue_Connection_und_neue_Transaction()
        {
            ISqlSessionFactory sqlSessionFactory;
            ISqlSession sqlSession;
            var sessionHandler = GetSessionHandler(false, out sqlSessionFactory, out sqlSession);

            sessionHandler.Write(() => Console.WriteLine("hallo"));

            sqlSessionFactory.Received(1).CreateSqlSession();
            sqlSession.Received(1).Begin();
            sqlSession.Received(1).Commit();
            sqlSession.Received(1).Dispose();
        }

        [Test]
        public void Default_Write_mit_Func_oeffnet_neue_Connection_und_neue_Transaction()
        {
            ISqlSessionFactory sqlSessionFactory;
            ISqlSession sqlSession;
            var sessionHandler = GetSessionHandler(false, out sqlSessionFactory, out sqlSession);

            sessionHandler.Write(() => "hallo");

            sqlSessionFactory.Received(1).CreateSqlSession();
            sqlSession.Received(1).Begin();
            sqlSession.Received(1).Commit();
            sqlSession.Received(1).Dispose();
        }

        [Test]
        public void Read_benutzt_bestehende_Connection()
        {
            ISqlSessionFactory sqlSessionFactory;
            ISqlSession sqlSession;
            var sessionHandler = GetSessionHandler(true, out sqlSessionFactory, out sqlSession);

            using (var session = sessionHandler.CreateSqlSession())
            {
                session.Begin();

                sqlSessionFactory.ClearReceivedCalls();
                session.ClearReceivedCalls();

                sessionHandler.Read(() => "hallo");

                sqlSessionFactory.DidNotReceive().CreateSqlSession();
                sqlSession.DidNotReceive().Begin();
                sqlSession.DidNotReceive().Commit();
                sqlSession.DidNotReceive().Dispose();
            }
        }

        [Test]
        public void Write_mit_Action_benutzt_bestehende_Connection()
        {
            ISqlSessionFactory sqlSessionFactory;
            ISqlSession sqlSession;
            var sessionHandler = GetSessionHandler(true, out sqlSessionFactory, out sqlSession);

            using (var session = sessionHandler.CreateSqlSession())
            {
                session.Begin();

                sqlSessionFactory.ClearReceivedCalls();
                session.ClearReceivedCalls();

                sessionHandler.Write(() => Console.WriteLine("hallo"));

                sqlSessionFactory.DidNotReceive().CreateSqlSession();
                sqlSession.DidNotReceive().Begin();
                sqlSession.DidNotReceive().Commit();
                sqlSession.DidNotReceive().Dispose();
            }
        }

        [Test]
        public void Write_mit_Func_benutzt_bestehende_Connection()
        {
            ISqlSessionFactory sqlSessionFactory;
            ISqlSession sqlSession;
            var sessionHandler = GetSessionHandler(true, out sqlSessionFactory, out sqlSession);

            using (var session = sessionHandler.CreateSqlSession())
            {
                session.Begin();

                sqlSessionFactory.ClearReceivedCalls();
                session.ClearReceivedCalls();

                sessionHandler.Write(() => "hallo");

                sqlSessionFactory.DidNotReceive().CreateSqlSession();
                sqlSession.DidNotReceive().Begin();
                sqlSession.DidNotReceive().Commit();
                sqlSession.DidNotReceive().Dispose();
            }
        }
    }
}