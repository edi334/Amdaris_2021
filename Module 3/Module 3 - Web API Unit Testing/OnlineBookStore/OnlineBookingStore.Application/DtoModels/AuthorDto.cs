using OnlineBookStore.Domain;

namespace OnlineBookingStore.Application.DtoModels
{
	public class AuthorDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public static AuthorDto From(Author author) => new() 
		{
			Id = author.Id,
			Name = author.Name
		};
	}
}
