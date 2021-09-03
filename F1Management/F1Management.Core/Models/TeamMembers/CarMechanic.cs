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
        public void FixCar(RaceCar car)
        {
            car.Chassis.Wear = 0;
            car.Engine.Wear = 0;
            car.Gearbox.Wear = 0;
        }
        public void FixChassis(RaceCar car)
        {
            car.Chassis.Wear = 0;
        }
        public void FixEngine(RaceCar car)
        {
            car.Engine.Wear = 0;
        }
        public void FixGearBox(RaceCar car)
        {
            car.Gearbox.Wear = 0;
        }
    }
}
