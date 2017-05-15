using System;
using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.RepositoryExample.dbo
{
    public interface IDossierAblageortRepo : IRepo<DossierAblageort>
    {
        void DoSomeTransactionStuff();
    }
}