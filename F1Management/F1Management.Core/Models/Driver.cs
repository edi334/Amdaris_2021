using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Roles
{
    public class Driver : TeamMember
    {
        public int Number { get; set; }
        public int Points { get; set; }
        public RaceCar RaceCar { get; set; }
        public Guid RaceCarId { get; set; }
    }
}
