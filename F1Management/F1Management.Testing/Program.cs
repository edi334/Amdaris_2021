using F1Management.Core;
using F1Management.Core.Models;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Roles;
using F1Management.Core.Models.Roles.Mechanics;
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

            Session session = new Session("1")
            {
                Id = "1",
                Name = "Race",
                Position = 1,
            };

            Race race = new Race
            { 
                Id = "1",
                Name = "2021 Italian Grand Prix",
                CircuitName = "Autodromo Internazzionale Monza"
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

            RaceCar car2 = new RaceCar
            (
                "2",
                "1",
                new Chassis { FrontWing = "small", RearWing = "small", BodyWork = "Aerodynamical", Wear = 30 },
                new Engine { Brand = "Mercedes", HorsePower = 1000, Wear = 20 },
                new Gearbox { Wear = 40 },
                new List<Tire>
                {
                    new Tire {Brand = "Pirelli", Type = TireType.Soft, Wear = 8 },
                    new Tire {Brand = "Pirelli", Type = TireType.Soft, Wear = 5 },
                    new Tire {Brand = "Pirelli", Type = TireType.Soft, Wear = 5 },
                    new Tire {Brand = "Pirelli", Type = TireType.Soft, Wear = 7 }
                }
            );

            TeamPrincipal principal = new TeamPrincipal() { Id = "3" };

            Driver driver1 = new Driver { Id = "1", CarId = "1", Number = 44, Points = 152 };
            Driver driver2 = new Driver { Id = "2", CarId = "2", Number = 77, Points = 84 };

            RaceEngineer engineer1 = new RaceEngineer("1") { Id = "4" };
            RaceEngineer engineer2 = new RaceEngineer("2") { Id = "5" };

            PitStopMechanic pitStopMechanic = new PitStopMechanic() { Id = "6" };
            CarMechanic carMechanic = new CarMechanic() { Id = "7" };

            TeamMember toto = new TeamMember
            {
                Id = "1",
                RoleId = "3",
                TeamId = "1",
                Name = "Toto Wolff"
            };

            TeamMember lewis = new TeamMember
            {
                Id = "2",
                RoleId = "1",
                TeamId = "1",
                Name = "Lewis Hamilton"
            };

            TeamMember bottas = new TeamMember
            {
                Id = "3",
                RoleId = "2",
                TeamId = "1",
                Name = "Valteri Bottas"
            };

            TeamMember bono = new TeamMember
            {
                Id = "4",
                RoleId = "4",
                TeamId = "1",
                Name = "Peter Bonnington"
            };

            TeamMember jon = new TeamMember
            {
                Id = "5",
                RoleId = "5",
                TeamId = "1",
                Name = "Jonathan Eddolls"
            };

            TeamMember ps = new TeamMember
            {
                Id = "6",
                RoleId = "6",
                TeamId = "1",
                Name = "Andrew Smith"
            };

            TeamMember cm = new TeamMember
            {
                Id = "7",
                RoleId = "7",
                TeamId = "1",
                Name = "Alexander Arnold"
            };

        }
    }
}
