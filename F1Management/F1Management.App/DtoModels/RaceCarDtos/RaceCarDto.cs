using F1Management.Core.Models.Car;
using F1Management.Core.Models.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.RaceCarDtos
{
    public class RaceCarDto
    {
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public TireSet TireSet { get; set; }
        public Driver Driver { get; set; }
        public string Strategy { get; set; }
        public double TotalWear { get; set; }
    }
}
