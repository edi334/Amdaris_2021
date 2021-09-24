using F1Management.App.DtoModels.CarDtos;
using F1Management.App.DtoModels.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.TeamMemberDtos
{
    public class DriverDto : BaseDto
    {
        public UserDto User { get; set; }
        public Guid TeamId { get; set; }
        public int Number { get; set; }
        public int Points { get; set; }
        public Guid RaceCarId { get; set; }
    }
}
