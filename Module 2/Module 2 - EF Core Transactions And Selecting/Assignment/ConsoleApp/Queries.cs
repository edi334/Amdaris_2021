using Assignment.Infrastructure;
using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Queries
    {
        private string connString = "Server = (LocalDb)\\MSSQLLocalDB; Database = EFTransactionsDb; Trusted_Connection = True;";
        public void Query1()
        {
            using(var context = new AppDbContext(connString))
            {
                using(var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var countries = context.Countries.Where(c => c.Population > 10000).ToList();
                        countries.ForEach(c => c.Population += 5000);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
        public void Query2()
        {
            using (var context = new AppDbContext(connString))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    var countries = context.Countries.Where(c => c.Population <= 10000).ToList();
                    countries.ForEach(c => c.Population += 10000);
                    context.SaveChanges();
                    dbContextTransaction.Rollback();
                }
            }
        }
        public void Query3()
        {
            using (var context = new AppDbContext(connString))
            {
                var participants = context.Participants
                    .Include(p => p.Country)
                    .ToList();
                participants.ForEach(p => Console.WriteLine(p + $". Comes from {p.Country.Name}"));

                var participants2 = context.Participants
                    .Include(p => p.Country)
                    .Include(p => p.WorkshopParticipants)
                        .ThenInclude(w => w.Workshop)
                    .ToList();
                participants2.ForEach(p =>
                { 
                    string workshops = "";
                    foreach(var workshopParticipant in p.WorkshopParticipants)
                    {
                        workshops = workshops + workshopParticipant.Workshop.Name + " ";
                    }
                    Console.WriteLine($"{p.FirstName} comes from {p.Country.Name} and attends the {workshops}workshops");
                });
            }
        }
        public void NPlusOneProblem()
        {
            using (var context = new AppDbContext(connString))
            {
                foreach(var participant in context.Participants.Include(p => p.WorkshopParticipants))
                {
                    foreach(var workshopParticipant in participant.WorkshopParticipants)
                    {
                        Console.WriteLine($"Participant id: {workshopParticipant.ParticipantId} - Workshop id: {workshopParticipant.WorkshopId}");
                    }
                }
            }
        }
        public void Query4()
        {
            using (var context = new AppDbContext(connString))
            {
                var participantCountries =
                    from participant in context.Participants
                    join country in context.Countries
                    on participant.CountryId equals country.Id
                    select new { ParticipantName = participant.FirstName + " " + participant.LastName, CountryName = country.Name };

                participantCountries.ToList().ForEach(p => Console.WriteLine(p.ParticipantName + ": " + p.CountryName));

                context.Countries.Add(new Country { Name = "Spain", Capital = "Madrid", Population = 40000 });
                context.SaveChanges();

                var countryParticipants = 
                    from country in context.Countries
                    join participant in context.Participants
                    on country.Id equals participant.CountryId into participants
                    from participant in participants.DefaultIfEmpty()
                    select new { ParticipantName = participant.FirstName + " " + participant.LastName, CountryName = country.Name };

                countryParticipants.ToList().ForEach(c => Console.WriteLine(c.ParticipantName + ": " + c.CountryName));
            }
        }

        public void Query5()
        {
            using (var context = new AppDbContext(connString))
            {
                context.Countries.Add(new Country { Name = "Germany", Capital = "Berlin", Population = 45000 });
                context.SaveChanges();

                var avgPopulation = context
                    .Countries
                    .GroupBy(c => c.Population)
                    .Select(x => new
                    {
                        Name = "Average population",
                        Avg = x.Average(y => y.Population)
                    });

                var countriesWithBCapitals = context
                    .Countries
                    .GroupBy(c => c.Capital)
                    .Where(c => c.Key.StartsWith('B'));

                var workshops1 = context
                    .Workshops
                    .Where(x => x.WorkshopParticipants.All(y => y.Participant.Country.Population > 10000));

                var workshops2 = context
                    .Workshops
                    .Where(x => x.WorkshopParticipants.Any(y => y.Participant.Country.Population > 10000));
            }
        }

        public void Query6(int page, int pageSize)
        {
            using (var context = new AppDbContext(connString))
            {
                context
                    .Workshops
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }
        }
    }
}
