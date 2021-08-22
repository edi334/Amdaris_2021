using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes
{
    public class Chassis : Part
    {
        private readonly IChassisBuilder _chassisBuilder;

        public Chassis()
        {
            
        }

        public Chassis(IChassisBuilder chassisBuilder)
        {
            _chassisBuilder = chassisBuilder;
        }

        public bool BuildChassis(Chassis chassis)
        {
            return _chassisBuilder.BuildChassis(chassis);
        }
        public string FrontWing { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} {FrontWing}";
        }
    }
}
