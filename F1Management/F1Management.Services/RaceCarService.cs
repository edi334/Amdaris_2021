using F1Management.Core;
using F1Management.Core.Models.Abstractions;
using F1Management.Core.Models.Car;
using F1Management.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Services
{
    class RaceCarService : IRaceCarService
    {
        public void Fix(RaceCar car)
        {
        }

        public void FixPart(RaceCar car, Part part)
        {
            throw new NotImplementedException();
        }

        public void PitStop(RaceCar car, TireType tireType)
        {
            throw new NotImplementedException();
        }
    }
}
