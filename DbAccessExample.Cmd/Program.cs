using System;

namespace DbAccessExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var impl = new RepositoryImplementation();
                var dossierEditor = impl.GetDossierEditor();
                var dossier = dossierEditor.LoadDossier(12);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}