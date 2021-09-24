using F1Management.App.DtoModels.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels
{
    public class PitStopDto : BaseDto
    {
        public TireSetDto OldTires { get; set; }
        public TireSetDto NewTires { get; set; }
        public TimeSpan StationaryTime { get; set; }
        public Guid CarSessionId { get; set; }
    }
}
