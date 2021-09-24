using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.CarDtos
{
    public class EngineDto : BaseDto
    {
        public double Wear { get; set; }
        public string Brand { get; set; }
        public int HorsePower { get; set; }
    }
}
