using F1Management.App.DtoModels.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.Identity
{
    public class RegisterDto
    {
        public UserDto User { get; set; }
        public Guid TeamId { get; set; }
    }
}
