using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.RaceCarDtos
{
    public class TireSetDto
    {
        public TireType Type { get; set; }
        public string Brand { get; set; }
        public int FrontLeftWear { get; set; }
        public int FrontRightWear { get; set; }
        public int RearLeftWear { get; set; }
        public int RearRightWear { get; set; }
    }
}
