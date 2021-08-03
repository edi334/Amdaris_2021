using Assignment.Collections;
using Classes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment
{
    class Program
    {
        static void PutAllHaresToSleep(GenericCollection<Hare> h)
        {
            int i = 0;
            while (h.GetItem(i) != null)
            {
                h.GetItem(i).GoToSleep();
                i++;
            }
        }
        static void Main(string[] args)
        {
            var q = new MyQueue<Animal>();

            q.Push(new Cat { Name = "Winston", Breed = "Persian" });
            q.Push(new Hare { Name = "Bugs", FurColor = "Brown" });
            q.Push(new ArcticHare { Name = "Baxter", IsSleeping = true });

            Console.WriteLine(q);

            q.Pop();

            Console.WriteLine(q);

            var hares = new GenericCollection<Hare>();

            hares.Add(new Hare { Name = "Thumper", FurColor = "Brown" });
            hares.Add(new Hare { Name = "Peter", FurColor = "Gray", IsSleeping = true });
            hares.Add(new ArcticHare { Name = "Rosie" });
            ArcticHare h = new ArcticHare { Name = "Archie", IsSleeping = true };
            hares.SetItem(3, h);

            Console.WriteLine(hares);

            Console.WriteLine(hares.GetItem(2) + "\n");

            hares.Delete(2);
            Console.WriteLine(hares);

            hares.Swap(1, 2);
            Console.WriteLine(hares);

            hares.Swap(h, hares.GetItem(0));
            Console.WriteLine(hares);

            PutAllHaresToSleep(hares);

        }
    }
}
