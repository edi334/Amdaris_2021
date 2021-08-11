using F1Management.Core;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;

namespace F1Management.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Team merc = new Team
            {
                Id = "1",
                Name = "Mercedes AMG Petronas",
                Points = 236,
                Ranking = 1
            };

            RaceCar car1 = new RaceCar
            (
                "1",
                "1",
                new Chassis { FrontWing = "small", RearWing = "small", BodyWork = "Aerodynamical", Wear = 20 },
                new Engine { Brand = "Mercedes", HorsePower = 1000, Wear = 15 },
                new Gearbox { Wear = 25 },
                new List<Tire>
                {
                    new Tire {Brand = "Pirelli", Type = TireType.Medium, Wear = 15 },
                    new Tire {Brand = "Pirelli", Type = TireType.Medium, Wear = 13 },
                    new Tire {Brand = "Pirelli", Type = TireType.Medium, Wear = 10 },
                    new Tire {Brand = "Pirelli", Type = TireType.Medium, Wear = 14 }
                }
            );
        }
    }
}
