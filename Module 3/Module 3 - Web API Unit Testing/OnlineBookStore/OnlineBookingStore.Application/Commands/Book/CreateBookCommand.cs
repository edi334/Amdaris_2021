using MediatR;
using OnlineBookingStore.Application.DtoModels;
using System;
using System.Collections.Generic;

namespace OnlineBookingStore.Application.Commands.Book
{
	public class CreateBookCommand : IRequest<BookDto> 
	{
		public IList<int> AuthorIds { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime PublishedOn { get; set; }

		public string Publisher { get; set; }

		public decimal Price { get; set; }
	}
	
}
