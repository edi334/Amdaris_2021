using F1Management.Core;
using F1Management.Core.Models;
using F1Management.Core.Models.Car;
using F1Management.Core.Models.Roles;
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
        private readonly string _connString;

        public AppDbContext(string connString)
        {
            _connString = connString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RaceCar> RaceCars { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
