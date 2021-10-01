using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Management.App.DtoModels.IdentityDtos
{
    public class LoginResultDto
    {
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }
    }
}
