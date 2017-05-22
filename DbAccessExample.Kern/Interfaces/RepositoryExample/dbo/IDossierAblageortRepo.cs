using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces.RepositoryExample.dbo
{
    public interface IDossierAblageortRepo : IRepo<DossierAblageort>
    {
        void DoSomeTransactionStuff();
    }
}