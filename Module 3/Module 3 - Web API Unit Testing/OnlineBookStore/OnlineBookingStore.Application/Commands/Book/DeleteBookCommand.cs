using MediatR;


namespace OnlineBookingStore.Application.Commands.Book
{
	public class DeleteBookCommand : IRequest
	{
		public int Id { get; set; }
	}
}
