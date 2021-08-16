using Assignment.Classes;
using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var driverFactory = new DriverFactory();
            var carFactory = new CarFactory(driverFactory);
            Car car1 = carFactory.CreateNewCar("SF2000", "Ferrari", 1000, "High Downforce",
                "Vettel", 130, 20);
            Car car2 = carFactory.CreateNewCar("SF21", "Ferrari", 1000, "Low Downforce",
                "Leclerc", 164, 2);
            Car car3 = carFactory.CreateNewCar("W11", "Mercedes", 1000, "High Downforce",
                "Hamilton", 200, 100);

            Garage.Instance.AddCar(car1);
            Garage.Instance.AddCar(car2);
            Garage.Instance.AddCar(car3);

            Garage.Instance.ShowCars();
            Console.WriteLine();

            Garage.Instance.GetAllFromTeam("Ferrari").ForEach(c => Console.WriteLine(c.Name));
            Console.WriteLine();
            Console.WriteLine(Garage.Instance.GetByName("SF21"));
            Console.WriteLine(Garage.Instance.GetByDriver("Hamilton"));
            Console.WriteLine();

            Garage.Instance.RemoveCar(car2);
            Garage.Instance.ShowCars();
        }
    }
}
