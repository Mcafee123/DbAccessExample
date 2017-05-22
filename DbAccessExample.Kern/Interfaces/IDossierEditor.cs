using System;
using DbAccessExample.Kern.Domain;

namespace DbAccessExample.Kern.Interfaces
{
    public interface IDossierEditor
    {
        Dossier LoadDossier(int id);
        Dossier Create(Dossier dossier);
        int DeleteAll();
    }
}