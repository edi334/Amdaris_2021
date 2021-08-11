using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class Tire : Part
    {
        public string Brand { get; set; }
        public TireType Type { get; set; }
    }
}
