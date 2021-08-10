using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Models.Car
{
    class RaceCar
    {
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public List<Tire> Tires { get; set; }
        public double TotalWear { get; set; }
        public override string ToString()
        {
            return $"Chassis: {Chassis.Wing} with {Chassis.Wear}% wear.\nEngine: {Engine.HorsePower} horsepower with {Engine.Wear}% wear.\n" +
                $"Gearbox: {Gearbox.GearCount} gears + {Gearbox.Wear}% wear.\nTires: {Tires[0].Type}.\nTotal Wear: {TotalWear}%\n";
        }
    }
}
