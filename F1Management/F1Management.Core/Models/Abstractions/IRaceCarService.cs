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
        public void Fix(string carId);
        public void FixPart(string carId, Part part);
        public void PitStop(string cardId, TireType tireType);
    } 
}
