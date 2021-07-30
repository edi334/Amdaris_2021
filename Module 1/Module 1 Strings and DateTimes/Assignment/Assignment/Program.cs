using Assignment.Classes;
using System;
using System.Text;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("The glorious StringBuilder Poem... ", 100);
            PoetBot p1 = new PoetBot { Name = "Gary", Material = "Steel", FavoriteAuthor = "Eminescu" };
            PoetBot p2 = new PoetBot(DateTime.Now.AddDays(3)) { Name = "Bill", Material = "Aluminium", FavoriteAuthor = "Eminescu" };

            p2.FavoritePoem =
            @"Somnoroase pasarele
            Pe la cuiburi se aduna,
            Se ascund in ramurele -
            Noapte buna!";

            p1.Name = p1.Name.PadLeft(10);
            Console.WriteLine(p1);
            p1.Name = p1.Name.Trim();
            Console.WriteLine(p1);

            Console.WriteLine(p1.Sing());
            Console.WriteLine(p2.Sing(p2.FavoritePoem));

            Console.WriteLine(p1.FavoriteAuthor.Equals(p2.FavoriteAuthor) ? $"{p1.Name} and {p2.Name}'s favorite author is {p1.FavoriteAuthor}!"
                : "The robots have a different favorite author!");

            sb.AppendLine("is a special poem,");
            sb.AppendFormat("Because it was made today: {0:dd-mm-yyyy}", DateTime.Now);
            sb.Insert(66, "by me ");
            sb.Remove(3, 9);
            sb.Replace("special", "gorgeous");
            Console.WriteLine(p1.Sing(sb.ToString()));

            DateTimeOffset o1 = p1.CreationDate;
            DateTimeOffset o2 = p2.CreationDate;

            TimeSpan difference = o2 - o1;
            TimeSpan p1OneYear = DateTime.Now.AddYears(1) - o1;
            TimeSpan p2OneYear = p1OneYear - difference;

            Console.WriteLine(
                string.Format(@$"This program has 2 robots.
                   They are called {p1.Name} and {p2.Name}.
                   One is born at {o1} and the other at {o2}.
                   In Utc time, those would be {o1.UtcDateTime} and {o2.UtcDateTime}
                   The difference in age between the is {{0}}
                   In {{1}} {p2.Name} will have a ""technical inspection""
                   After exactly one year from now {p1.Name} will have the age in days: {p1OneYear}
                   and {p2.Name} will have the age in days: {p2OneYear}", difference, DateTime.Now.AddMonths(3) + difference));

            string finalPoem = $"This#is#the#final#poem#that#our#robots#will#sing.\n{p2.Name}#will#sing#it#in#a#weird#fashion.\nBut#{p1.Name}#will#sing#it#normally.";
            string[] words = finalPoem.Split('#');
            string finalPoemNormal = string.Join(' ', words);

            Console.WriteLine(p1.Sing(finalPoemNormal.ToLower()));
            Console.WriteLine(p2.Sing(finalPoem.ToUpper()));
        }
    }
}
