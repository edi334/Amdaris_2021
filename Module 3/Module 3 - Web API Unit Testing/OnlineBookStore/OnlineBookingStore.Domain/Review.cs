using System;

namespace OnlineBookStore.Domain
{
    public class Review: Entity<int>
    {
        public string VoterName { get; private set; }

        public short NumStars { get; private set; }

        public string Comment { get; private set; }       
        public Book Book { get; private set; }

        [Obsolete("Required for Entity Framework")]
        private Review() 
        {
        }

        internal Review(Book book, string voterName, short numStars, string comment) 
        {
			if (book is null)
			{
				throw new ArgumentNullException(nameof(book));
			}

			if (string.IsNullOrWhiteSpace(voterName))
			{
				throw new ArgumentNullException(nameof(voterName));
			}

            Book = book;
            VoterName = voterName;
            NumStars = numStars;
            Comment = comment;
		}
    }
}
