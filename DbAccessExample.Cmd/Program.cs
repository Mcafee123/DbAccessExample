using System;

namespace DbAccessExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var impl = new RepositoryImplementation();
            var dossierEditor = impl.GetDossierEditor();
            var dossier = dossierEditor.LoadDossier(12);
            Console.ReadKey();
        }
    }
}