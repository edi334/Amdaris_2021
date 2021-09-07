using MediatR;
using OnlineBookingStore.Application.DtoModels;
using System.Collections.Generic;


namespace OnlineBookingStore.Application.Queries.Book
{
	public class GetAllBooksQuery : IRequest<IList<BookDto>>
	{
	}
}
