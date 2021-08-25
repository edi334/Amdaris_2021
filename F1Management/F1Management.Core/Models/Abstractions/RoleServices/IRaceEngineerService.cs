using F1Management.Core.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.RoleServices
{
    public interface IRaceEngineerService : IAdminService
    {
        public void SetStrategy(Driver driver);
        public void TalkToDriver(Driver driver);
    }
}
