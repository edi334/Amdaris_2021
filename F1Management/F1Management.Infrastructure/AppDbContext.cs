using F1Management.Core;
using F1Management.Core.Models;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using F1Management.Core.Models.TeamMembers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<TireSet> TireSets { get; set; }
        public DbSet<RaceCar> RaceCars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<CarMechanic> CarMechanics { get; set; }
        public DbSet<PitStopMechanic> PitStopMechanics { get; set; }
        public DbSet<RaceEngineer> RaceEngineers { get; set; }
        public DbSet<PitStopCrew> PitStopCrews { get; set; }
        public DbSet<GrandPrix> GrandPrix { get; set; }
        public DbSet<CarSession> Sessions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PitStop> PitStops { get; set; }
    }
}
