using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.CarDtos
{
    public class ChassisDto : BaseDto
    {
        public double Wear { get; set; }
        public string FrontWing { get; set; }
        public string RearWing { get; set; }
        public string BodyWork { get; set; }
    }
}
