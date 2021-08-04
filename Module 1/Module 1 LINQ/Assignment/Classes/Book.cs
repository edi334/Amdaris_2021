using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; } // for every book I do not need the whole Author, just the id.
        //In a database, the Book table would have a foreign key to the Author table.
        public List<string> Categories { get; set; }
        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
