using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class RaceCar : BaseEntity
    {
        public string Name { get; set; }
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public TireSet TireSet { get; set; }
        public Driver Driver { get; set; }
        public ICollection<CarSession> CarSessions { get; set; }
    }
}
