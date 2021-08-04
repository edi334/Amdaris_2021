using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    // In the class Author, we don't need to have a list of books because the books are already associated with the Author
    // We also avoid to make a List<Book> property here to avoid a possible circular dependency.
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
