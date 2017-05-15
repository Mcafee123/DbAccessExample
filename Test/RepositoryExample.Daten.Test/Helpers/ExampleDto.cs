using Dto;

namespace RepositoryExample.Daten.Test.Helpers
{
    public class ExampleDto : IDto
    {
        public int Id { get; set; }

        public string GetInsertCommand()
        {
            return string.Empty;
        }

        public string GetUpdateCommand()
        {
            return string.Empty;
        }
    }
}