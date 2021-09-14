using F1Management.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.TeamMembers
{
    public class PitStopCrew : BaseEntity
    {
        [MaxLength(12)]
        public ICollection<PitStopMechanic> PitStopMechanics { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public void ChangeTires(RaceCar car, TireSet tireSet)
        {
            car.TireSet = tireSet;
        }
        public bool isAvailable { get; set; } = true;
    }
}
