using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface ICarSessionRepository
    {
        public void AddPitStop(PitStop pitStop);
        public void UpdateSession(CarSession carSession);
        public TimeSpan GetFastestLapFromAllCarsInSession(CarSession carSession);
    }
}
