using Assignment.Classes;
using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Car.Prepare();

            Car c1 = new Car { Name = "Rapid", Brand = "Skoda" };
            Car.StartCar();
            Car.CarCount++;
            c1.Write();

            Car c2 = new Car { Name = "Passat", Brand = "Volkswagen" };
            Car.StartCar();
            Car.CarCount++;
            c2.Write();

            Console.WriteLine("There are " + Car.CarCount + " cars!");

            string name = "Octavia";
            bool areSame = true;
            bool areSameOut;

            //It's still true because the argument is passed by value
            c1.CheckNameNoRef(name, areSame);
            Console.WriteLine(areSame);

            //It's false because the argument is passed by reference
            c1.CheckNameRef(name, ref areSame);
            Console.WriteLine(areSame);

            //It's false because the argument is passed by reference
            c1.CheckNameOut(name, out areSameOut);
            Console.WriteLine(areSameOut);

            //It's false even though the parameter is not passed by value because areSameRef is a reference-type 
            bool? areSameRef = areSame;
            c1.CheckNameRefType(name, areSameRef);
            Console.WriteLine(areSameRef);

            areSameRef = null;
            //This is true
            Console.WriteLine(areSameRef == null);
            areSameRef = true;

            areSame = (bool)areSameRef;
            c1.CheckNameNoRef(name, areSame);
            //It's still true because areSame is a Value-Type
            Console.WriteLine(areSame);
        }
    }
}
