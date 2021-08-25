using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RaceId { get; set; }
        public Race Race { get; set; }
        public Guid RaceCarId { get; set; }
        public RaceCar RaceCar { get; set; }
        public int Position { get; set; }
    }
}
