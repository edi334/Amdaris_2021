using Decorator.Models;
using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            F1Driver d1 = new F1Driver { Name = "Hamilton", Team = "Mercedes" };
            F1Driver d2 = new F1Driver { Name = "Ocon", Team = "Alpine" };

            F1Winner w1 = new F1Winner(d2) { RaceWon = "Hungaroring 2021" };
            F1WorldChampion w2 = new F1WorldChampion(d1) { Year = 2020 };

            w1.GetDescription();
            Console.WriteLine();
            w2.GetDescription();
        }
    }
}
