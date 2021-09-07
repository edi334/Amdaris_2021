using MediatR;
using OnlineBookingStore.Application.DtoModels;

namespace OnlineBookingStore.Application.Commands.Book
{
	public class AddReviewCommand : IRequest<ReviewDto>
	{
		public int BookId { get; set; }
		public string VoterName { get; set; }

		public short NumStars { get; set; }

		public string Comment { get; set; }
	}
}
