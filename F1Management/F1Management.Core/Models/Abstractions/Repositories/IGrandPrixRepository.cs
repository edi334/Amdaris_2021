using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Abstractions.Repositories
{
    public interface IGrandPrixRepository
    {
        public Task<List<GrandPrix>> GetAllAsync();
        public Task<GrandPrix> GetByIdAsync(Guid id);
    }
}
