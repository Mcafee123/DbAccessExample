using RepositoryExample.Daten.Repos;
using RepositoryExample.Daten.Services;
using Util.Interfaces;

namespace RepositoryExample.Daten.Test.Helpers
{
    public class RepoImplementation : Repo<ExampleEntity, ExampleDto>
    {
        public RepoImplementation(ISqlSessionHandler sqlSessionHandler,
            IPersistenceService<ExampleDto> persistenceService) : base(sqlSessionHandler, persistenceService)
        {}

        protected override ExampleEntity Map(ExampleDto dto)
        {
            return new ExampleEntity();
        }

        protected override ExampleDto Map(ExampleEntity entity)
        {
            return new ExampleDto();
        }
    }
}