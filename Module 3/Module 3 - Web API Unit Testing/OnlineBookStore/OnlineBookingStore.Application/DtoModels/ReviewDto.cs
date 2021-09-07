using OnlineBookStore.Domain;

namespace OnlineBookingStore.Application.DtoModels
{
	public class ReviewDto
	{
		public int Id { get; set; }
		public string VoterName { get; set; }

		public short NumStars { get; set; }

		public string Comment { get; set; }

		public static ReviewDto From(Review review) => new()
		{
			Id = review.Id,
			VoterName = review.VoterName,
			NumStars = review.NumStars,
			Comment = review.Comment
		};
	}
}
