using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class RaceCar
    {
        public Guid Id { get; set; }
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public List<Tire> Tires { get; set; }
        public Driver Driver { get; set; }
        public List<Session> Sessions { get; set; }
        public double TotalWear => (Chassis.Wear + Engine.Wear + Gearbox.Wear) / 3;
    }
}
