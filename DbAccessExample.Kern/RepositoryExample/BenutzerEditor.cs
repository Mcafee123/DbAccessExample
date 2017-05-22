using DbAccessExample.Kern.Domain;
using DbAccessExample.Kern.Interfaces;
using DbAccessExample.Kern.Interfaces.RepositoryExample.Navision;

namespace DbAccessExample.Kern.RepositoryExample
{
    public class BenutzerEditor: IBenutzerEditor
    {
        private readonly IBenutzerRepo _benutzerRepo;

        public BenutzerEditor(IBenutzerRepo benutzerRepo)
        {
            _benutzerRepo = benutzerRepo;
        }

        public Benutzer GetByFmhId(int id)
        {
            return _benutzerRepo.GetByFmhId(id);
        }

        public Benutzer Add(Benutzer benutzer)
        {
            return _benutzerRepo.Add(benutzer);
        }

        public bool Delete(Benutzer sachbearbeiterin)
        {
            return _benutzerRepo.Remove(sachbearbeiterin.Id);
        }
    }
}
