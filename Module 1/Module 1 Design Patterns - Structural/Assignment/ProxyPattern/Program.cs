using ProxyPattern.Models;
using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver
            {
                Name = "Leclerc",
                Points = 128,
                Position = "P1",
            };
            Console.WriteLine($"{driver.Strategy}");

            RaceEngineer engineer = new RaceEngineer(driver, "Jeff");

            Strategist strategist = new Strategist(driver)
            {
                Engineer = engineer,
                Name = "Binotto",
                PreferedStrategy = "2 stop",
            };

            strategist.Talk();

            Console.WriteLine($"Strategy is {driver.Strategy}");
        }
    }
}
