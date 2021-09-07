using MediatR;
using OnlineBookingStore.Application.DtoModels;

namespace OnlineBookingStore.Application.Queries.Book
{
	public class GetBookQuery : IRequest<BookDto>
	{
		public int BookId { get; set; }
	}
}
