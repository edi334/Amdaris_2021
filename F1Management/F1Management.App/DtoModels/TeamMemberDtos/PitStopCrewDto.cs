using F1Management.App.DtoModels.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.TeamMemberDtos
{
    public class PitStopCrewDto : BaseDto
    {
        public Guid TeamId { get; set; }
    }
}
