using OnlineBookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineBookingStore.Application.DtoModels
{
	public class BookDto
	{
		public int Id { get; set; }
		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime PublishedOn { get; set; }

		public string Publisher { get; set; }

		public decimal Price { get; set; }

		public List<AuthorDto> Authors { get; set; }
		public List<ReviewDto> Reviews { get; set; }

		public static BookDto From(Book book) => new() 
		{
			Id = book.Id,
			Title = book.Title,
			Description = book.Description,
			PublishedOn = book.PublishedOn,
			Publisher = book.Publisher,
			Price = book.Price,
			Authors = book.Authors.Select(AuthorDto.From).ToList(),
			Reviews = book.Reviews?.Select(ReviewDto.From).ToList()
		};
	}
}
