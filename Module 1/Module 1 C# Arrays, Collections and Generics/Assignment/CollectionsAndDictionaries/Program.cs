using Classes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsAndDictionaries
{
    class Program
    {
        static void PutAllHaresToSleep(IEnumerable<Hare> hares)
        {
            foreach (Hare hare in hares)
            {
                hare.GoToSleep();
            }
        }
        static void Main(string[] args)
        {
            List<Hare> hares = new List<Hare>
            {
                new Hare { Name = "Thumper", FurColor = "Brown" },
                new Hare { Name = "Peter", FurColor = "Gray", IsSleeping = true },
                new ArcticHare { Name = "Rosie" },
                new ArcticHare { Name = "Archie", IsSleeping = true }
            };

            ArcticHare[] onlyArcticHares = new ArcticHare[3]
            {
                 new ArcticHare { Name = "Harry" },
                 new ArcticHare { Name = "Oliver", IsSleeping = true },
                 new ArcticHare { Name = "Tulip", }
            };

            ArcticHare h = hares[3] as ArcticHare;

            foreach (Hare hare in hares)
            {
                Console.WriteLine(hare);
            }
            Console.Write("\n");

            PutAllHaresToSleep(hares);
            PutAllHaresToSleep(onlyArcticHares);
            Console.Write("\n");

            Console.WriteLine($"There are {hares.Count + 3} hares. It is {hares.Contains(h).ToString().ToLower()} that {h.Name} is one of them.\n");

            Dictionary<Hare, string> favoriteFood = new Dictionary<Hare, string>
            {
                {hares[0], "carrots"},
                {hares[1], "tomatoes"},
                {hares[2], "salad"},
                {hares[3], "lichens"}
            };

            foreach (KeyValuePair<Hare, string> hf in favoriteFood)
            {
                Console.WriteLine($"{hf.Key.Name} likes to eat {hf.Value}.");
            }
        }
    }
}
