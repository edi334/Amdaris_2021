using MediatR;
using OnlineBookingStore.Application.DtoModels;
using OnlineBookingStore.Application.Interfaces;
using OnlineBookingStore.Application.Queries.Book;
using OnlineBookStore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookingStore.Application.QueryHandlers.BookQueryHandlers
{
	public class BookQueryHandler :
		IRequestHandler<GetAllBooksQuery, IList<BookDto>>,
		IRequestHandler<GetBookQuery, BookDto>
	{
		private readonly IRepository<Book> _repository;

		public BookQueryHandler(IRepository<Book> repository) 
		{
			_repository = repository;
		}
		public async Task<IList<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
		{
			var result = await _repository.Read().AsNoTracking().Include(b => b.Authors).ToListAsync();

			return result.Select(BookDto.From).ToList();
		}

		public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
		{
			var result = await _repository.Read().AsNoTracking()
								.Include(b => b.Authors)
								.Include(b => b.Reviews)
								.SingleOrDefaultAsync(b => b.Id == request.BookId);

			return BookDto.From(result);
		}
	}
}
