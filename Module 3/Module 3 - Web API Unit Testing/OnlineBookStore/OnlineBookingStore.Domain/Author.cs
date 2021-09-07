using System.Collections.Generic;

namespace OnlineBookStore.Domain
{
    public class Author : Entity<int>
    {      
        public string Name { get; set; }

        private readonly List<Book> _books = new List<Book>();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

        private Author() 
        {
        }

        public Author(string name) 
        {
            Name = name;
        }
    }
}
