using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.TeamMemberDtos
{
    public class RaceEngineerDto
    {
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public Guid TeamId { get; set; }
    }
}
