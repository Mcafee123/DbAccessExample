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
                var impl = new CommandQueryImplementation();
                impl.AddInitialData();
                impl.AddInitialDataTransaction();
                impl.TestException();
                impl.TestRollback(false, 13579, 2468);
                impl.TestRollback(true, 97531, 8642);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--- PRESS ANY KEY ---");
            Console.ReadKey();
        }
    }
}