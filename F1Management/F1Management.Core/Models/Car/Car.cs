using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    class Car
    {
        public Car()
        {
            TotalWear = Chassis.Wear * Engine.Wear * Gearbox.Wear / 1000000;
        }
        public string Id { get; set; }
        public string TeamId { get; set; }
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public List<Tire> Tires { get; set; }
        public double TotalWear { get; }
    }
}
