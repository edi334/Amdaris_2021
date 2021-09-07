using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = new Queries();

            queries.Query1();
            queries.Query2();
            queries.Query3();
            queries.NPlusOneProblem();
            queries.Query4();
            queries.Query5();
            queries.Query6(2, 2);
        }
    }
}
