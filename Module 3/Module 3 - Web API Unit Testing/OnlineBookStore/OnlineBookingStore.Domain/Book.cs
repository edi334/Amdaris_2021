using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineBookStore.Domain
{
    public class Book: Entity<int>
    {
      
        public string Title { get; private set; }

        public string Description { get; set; }

        public DateTime PublishedOn { get; private set; }

        public string Publisher { get; private set; }

        public decimal Price { get; set; }

        public PriceOffer PriceOffer { get; set; }

        private readonly List<Author> _authors = new List<Author>();
        public IReadOnlyCollection<Author> Authors => _authors.AsReadOnly();

        private readonly List<Review> _reviews = new List<Review>();
        public IReadOnlyCollection<Review> Reviews => _reviews;

        public byte[] RowVersion { get; private set; }

        [Obsolete("Required for Entity Framework")]
        private Book() 
        {
        }

        public Book(string title, string description, DateTime publishedOn, string publisher, decimal price, List<Author> authors) 
        {
			if (string.IsNullOrWhiteSpace(title))
			{
				throw new ArgumentNullException(nameof(title));
			}			

			if (string.IsNullOrWhiteSpace(publisher))
			{
				throw new ArgumentNullException(nameof(publisher));
			}

			if (authors is null || !authors.Any())
			{
				throw new ArgumentNullException(nameof(authors));
			}

            Title = title;
            Description = description;
            PublishedOn = publishedOn;
            Publisher = publisher;
            Price = price;
                        
            authors.ForEach(a => _authors.Add(a));
		}

        public Review AddReview(string voterName, short numStars, string comment) 
        {
            var review = new Review(this, voterName, numStars, comment);
            _reviews.Add(review);
            return review;
		}

    }
}
