using FacadePattern.Models;
using FacadePattern.Models.Car;
using System;
using System.Collections.Generic;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceCar car = new RaceCar
            {
                Chassis = new Chassis
                {
                    Wear = 20,
                    Wing = "Front and Rear"
                },
                Engine = new Engine
                {
                    Wear = 30,
                    HorsePower = 1000
                },
                Gearbox = new Gearbox
                {
                    Wear = 45
                },
                Tires = new List<Tire>
                {
                    new Tire {Wear = 20, Type = "Soft"},
                    new Tire {Wear = 23, Type = "Soft"},
                    new Tire {Wear = 21, Type = "Soft"},
                    new Tire {Wear = 22, Type = "Soft"}
                },
            };

            car.TotalWear = car.Chassis.Wear * car.Engine.Wear * car.Gearbox.Wear / 1000;
          
            Console.WriteLine(car);

            CarFixer carFixer = new CarFixer(car);

            carFixer.FixCar();
            carFixer.ChangeTyres("Hard");

            Console.WriteLine(car);
        }
    }
}
