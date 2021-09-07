using OnlineBookStore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookingStore.Application.Interfaces
{
	public interface IRepository<T> where T: Entity<int>
	{
        IUnitOfWork UnitOfWork { get; }
        IQueryable<T> Read();
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);        
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);       
    }
}
