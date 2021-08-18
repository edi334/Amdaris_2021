using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions
{
    public interface IRaceCarService
    {
        public void Fix(RaceCar car);
        public void FixPart(RaceCar car, Part part);
        public void PitStop(RaceCar car, TireType tireType);
    } 
}
