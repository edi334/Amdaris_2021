using F1Management.Core.Models.Car;
using F1Management.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.TeamMembers
{
    public class CarMechanic : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public void FixCar(RaceCar raceCar)
        {
            raceCar.Chassis.Wear = 0;
            raceCar.Engine.Wear = 0;
            raceCar.Gearbox.Wear = 0;
        }
        public void FixChassis(RaceCar raceCar)
        {
            raceCar.Chassis.Wear = 0;
        }
        public void FixEngine(RaceCar raceCar)
        {
            raceCar.Engine.Wear = 0;
        }
        public void FixGearBox(RaceCar raceCar)
        {
            raceCar.Gearbox.Wear = 0;
        }
    }
}
