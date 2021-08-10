using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Models.Car
{
    class Gearbox : Part
    {
        public int GearCount { get; set; } = 8;
    }
}
