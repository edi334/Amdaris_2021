using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.RaceCarDtos
{
    public class GearboxDto
    {
        public double Wear { get; set; }
        public int GearCount { get; set; } = 8;
    }
}
