using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels
{
    public class CarSessionDto : BaseDto
    {
        public string Name { get; set; }
        public Guid GrandPrixId { get; set; }
        public Guid RaceCarId { get; set; }
        public int Position { get; set; }
        public string SessionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan FastestLap { get; set; }
    }
}
