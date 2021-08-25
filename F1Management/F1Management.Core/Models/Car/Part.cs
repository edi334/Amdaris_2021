using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class Part
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public RaceCar RaceCar { get; set; }
        public double Wear { get; set; }
    }
}
