using F1Management.Core;
using F1Management.Core.Models;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Roles;
using F1Management.Core.Models.Roles.Mechanics;
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

            List<RaceCar> cars = new List<RaceCar>
            {
                new RaceCar
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
                ),
                new RaceCar
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
                )
            };

            List<Role> roles = new List<Role>
            {
                new Driver { Id = "1", CarId = "1", Number = 44, Points = 152 },
                new Driver { Id = "2", CarId = "2", Number = 77, Points = 84 },
                new TeamPrincipal() { Id = "3" },
                new RaceEngineer("1") { Id = "4" },
                new RaceEngineer("2") { Id = "5" },
                new PitStopMechanic() { Id = "6" },
                new CarMechanic() { Id = "7" }
            };

            List<TeamMember> teamMembers = new List<TeamMember>
            {
                new TeamMember {
                    Id = "1",
                    RoleId = "3",
                    TeamId = "1",
                    Name = "Toto Wolff"
                },
                new TeamMember
                {
                    Id = "2",
                    RoleId = "1",
                    TeamId = "1",
                    Name = "Lewis Hamilton"
                },
                new TeamMember
                {
                    Id = "3",
                    RoleId = "2",
                    TeamId = "1",
                    Name = "Valteri Bottas"
                },

                new TeamMember
                {
                    Id = "4",
                    RoleId = "4",
                    TeamId = "1",
                    Name = "Peter Bonnington"
                },
                new TeamMember
                {
                    Id = "5",
                    RoleId = "5",
                    TeamId = "1",
                    Name = "Jonathan Eddolls"
                },

                new TeamMember
                {
                    Id = "6",
                    RoleId = "6",
                    TeamId = "1",
                    Name = "Andrew Smith"
                },
                new TeamMember
                {
                    Id = "7",
                    RoleId = "7",
                    TeamId = "1",
                    Name = "Alexander Arnold"
                }
            };

        }
    }
     
