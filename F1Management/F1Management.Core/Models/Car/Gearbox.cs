using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class Gearbox : BaseEntity
    {
        public double Wear { get; set; }
        public int GearCount { get; set; } = 8;
        public Guid RaceCarId { get; set; }
        public RaceCar RaceCar { get; set; }
    }
}
