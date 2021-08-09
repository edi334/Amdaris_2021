using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    class Chassis : Part
    {
        public string FrontWing { get; set; }
        public string RearWing { get; set; }
        public string BodyWork { get; set; }
    }
}
