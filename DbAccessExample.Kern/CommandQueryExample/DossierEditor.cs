using System;
using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.CommandQueryExample;

namespace DbAccessExample.Kern.CommandQueryExample
{
    public class DossierEditor : IDossierEditor
    {
        private readonly IDossierService _dossierService;

        public DossierEditor(IDossierService dossierService)
        {
            _dossierService = dossierService;
        }

        public Dossier LoadDossier(int id)
        {
            throw new NotImplementedException();
        }

        public Dossier Create(Dossier dossier)
        {
            return _dossierService.Create(dossier);
        }

        public int DeleteAll()
        {
            return _dossierService.DeleteAll();
        }
    }
}