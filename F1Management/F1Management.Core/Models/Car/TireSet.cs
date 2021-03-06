using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class TireSet : BaseEntity
    {
        public TireType Type { get; set; }
        public string Brand { get; set; }
        public int FrontLeftWear { get; set; }
        public int FrontRightWear { get; set; }
        public int RearLeftWear { get; set; }
        public int RearRightWear { get; set; }
        public Guid RaceCarId { get; set; }
        public RaceCar RaceCar { get; set; }
    }
}
