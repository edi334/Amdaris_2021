using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class Engine : BaseEntity
    {
        public double Wear { get; set; }
        public string Brand { get; set; }
        public int HorsePower { get; set; }
        public Guid RaceCarId { get; set; }
        public RaceCar RaceCar { get; set; }
    }
}
