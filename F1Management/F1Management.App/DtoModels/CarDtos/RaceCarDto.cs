using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.CarDtos
{
    public class RaceCarDto : BaseDto
    {
        public string Name { get; set; }
        public ChassisDto Chassis { get; set; }
        public EngineDto Engine { get; set; }
        public GearboxDto Gearbox { get; set; }
        public TireSetDto TireSet { get; set; }
    }
}
