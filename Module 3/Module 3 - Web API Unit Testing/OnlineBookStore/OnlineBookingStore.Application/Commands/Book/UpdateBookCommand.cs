using MediatR;
using OnlineBookingStore.Application.DtoModels;

namespace OnlineBookingStore.Application.Commands.Book
{
	public class UpdateBookCommand : IRequest<BookDto>
	{
		public int BookId { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}
