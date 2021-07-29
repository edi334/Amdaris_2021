using Assignment.Classes;
using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle bus = new Automobile(20, "1.6");
            Console.WriteLine(bus.Action());

            Vehicle skoda = new Car("Rapid", "Skoda") { Engine = "1.2", PassengerNumber = 4, Price = 15000 };
            Console.WriteLine(skoda);
            Console.WriteLine(skoda.Action());

            Vehicle audi = new Car("A4", "Audi") { Engine = "1.4", PassengerNumber = 4, Price = 30000 };
            Console.WriteLine(audi);
            Console.WriteLine(audi.Action());

            Vehicle dacia = new Car("Logan", "Dacia") { Engine = "1.4", PassengerNumber = 4, Price = 9000 };
            Console.WriteLine(dacia);
            Console.WriteLine(dacia.Action());

            Person m = new Buyer(60000) { Name = "Adi", Gender = "Male" };
            m.Speak();
            Person f = new Buyer(70000) { Name = "Anca", Gender = "Female" };
            (f as Buyer).Speak(skoda as Car);

            Console.WriteLine((m as Buyer).TryToBuy(skoda as Car, audi as Car));
            Console.WriteLine(m);
            Console.WriteLine((m as Buyer).TryToBuy(audi as Car));
            Console.WriteLine(m);

            Console.WriteLine((f as Buyer).TryToBuy(skoda as Car, audi as Car, dacia as Car));
            Console.WriteLine(f);
        }
    }
}
