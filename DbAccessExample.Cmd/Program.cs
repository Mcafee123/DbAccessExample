using System;

namespace DbAccessExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //var impl = new RepositoryImplementation();
                //impl.AddInitialData();
                //impl.TestException();
                //impl.TestRollback();



                var impl = new CommandQueryImplementation();
                impl.AddInitialData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}