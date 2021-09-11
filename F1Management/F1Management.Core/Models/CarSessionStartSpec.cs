using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models
{
    public class CarSessionStartSpec
    {
        public CarSession CarSession { get; set; }
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
    }
}
