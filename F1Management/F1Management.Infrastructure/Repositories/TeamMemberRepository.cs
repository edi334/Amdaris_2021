using F1Management.Core;
using F1Management.Core.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Infrastructure.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly AppDbContext _dbContext;

        public TeamMemberRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TeamMember teamMember)
        {
            _dbContext.TeamMembers.Add(teamMember);
            _dbContext.SaveChanges();
        }

        public void Delete(TeamMember teamMember)
        {
            _dbContext.TeamMembers.Remove(teamMember);
            _dbContext.SaveChanges();
        }

        public List<TeamMember> GetAll()
        {
            return _dbContext.TeamMembers.ToList();
        }

        public TeamMember GetById(Guid id)
        {
            return _dbContext.TeamMembers.FirstOrDefault(t => t.Id == id);
        }

        public List<TeamMember> GetByRole(string roleName)
        {
            return _dbContext.TeamMembers
                .Where(t => t.Role.Name == roleName)
                .ToList();
        }

        public TeamMember GetFirstByRole(string roleName)
        {
            return _dbContext.TeamMembers.FirstOrDefault(t => t.Role.Name == roleName);
        }
    }
}
