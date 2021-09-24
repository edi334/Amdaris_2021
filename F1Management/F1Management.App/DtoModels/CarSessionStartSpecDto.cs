using F1Management.App.DtoModels.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels
{
    public class CarSessionStartSpecDto : BaseDto
    {
        public CarSessionDto CarSessionDto { get; set; }
        public ChassisDto ChassisDto { get; set; }
        public EngineDto EngineDto { get; set; }
        public GearboxDto GearboxDto { get; set; }
    }
}
