using F1Management.Core;
using F1Management.Core.Models.Abstractions;
using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Services
{
    class RaceCarService : IRaceCarService
    {
        private List<RaceCar> _raceCars;
        private List<TeamMember> _teamMembers;
        public RaceCarService(List<RaceCar> raceCars, List<TeamMember> teamMembers)
        {
            _raceCars = raceCars;
            _teamMembers = teamMembers;
        }
        public void Fix(string carId)
        {
            var car = _raceCars.Find(c => c.Id == carId);
        }

        public void FixPart(string carId, Part part)
        {
            throw new NotImplementedException();
        }

        public void PitStop(string cardId, TireType tireType)
        {
            throw new NotImplementedException();
        }
    }
}
