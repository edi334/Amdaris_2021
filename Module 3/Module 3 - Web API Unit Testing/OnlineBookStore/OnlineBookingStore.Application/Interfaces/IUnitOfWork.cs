using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookingStore.Application.Interfaces
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
