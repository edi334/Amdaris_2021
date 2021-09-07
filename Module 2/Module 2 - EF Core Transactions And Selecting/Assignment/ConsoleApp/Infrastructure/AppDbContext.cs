using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly string _connString;
        public AppDbContext(string connString) : base()
        {
            _connString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(_connString);

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<WorkshopParticipant> WorkshopParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Romania", Capital = "Bucharest", Population = 20000 },
                new Country { Id = 2, Name = "Hungary", Capital = "Budapest", Population = 10000 },
                new Country { Id = 3, Name = "France", Capital = "Paris", Population = 50000 }
                );

            modelBuilder.Entity<WorkshopParticipant>().HasData(
                new { Id = 1, ParticipantId = 1, WorkshopId = 1 },
                new { Id = 2, ParticipantId = 1, WorkshopId = 2 },
                new { Id = 3, ParticipantId = 2, WorkshopId = 1 },
                new { Id = 4, ParticipantId = 3, WorkshopId = 1 }
                );

            modelBuilder.Entity<Participant>().HasData(
                new Participant { Id = 1, CountryId = 1, FirstName = "Andrei", LastName = "Popescu", Email = "andrei.popescu@gmail.com"},
                new Participant { Id = 2, CountryId = 3, FirstName = "Jean", LastName = "Monet", Email = "jean.monet@gmail.com" },
                new Participant { Id = 3, CountryId = 2, FirstName = "Istvan", LastName = "Seres", Email = "istvan.seres@gmail.com" }
                );

            modelBuilder.Entity<Workshop>().HasData(
                new Workshop { Id = 1, Name = "Breakdance Workshop", Theme = "Dancing", ShortDescription = "We will learn to breakdance!"},
                new Workshop { Id = 2, Name = "Painting Workshop", Theme = "Painting", ShortDescription = "We will learn to paint!" }
                );
        }
    }
}
