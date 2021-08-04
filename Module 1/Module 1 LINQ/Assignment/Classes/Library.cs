using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    //In the library class we need to pass the Authors as well to get the information about them
    public class Library
    {
        private List<Book> books;
        private List<Author> authors;
        public Library(List<Book> books, List<Author> authors)
        {
            this.books = books;
            this.authors = authors;
        }
        public void Add(Book b)
        {
            books.Add(b);
        }
        public void Remove(Book b)
        {
            books.Remove(b);
        }
        public List<Book> GetBooks()
        {
            return books;
        }
        public List<Book> GetBooksAfterYear(int year)
        {
            return books
                .Where(b => b.PublishDate.Year > year)
                .ToList();
        }
        public List<Book> GetBooksByCategory(string category)
        {
            return books
                .Where(b => b.Categories.Find(c => c == category) != null)
                .ToList();
        }
        public List<string> GetAuthorsByBookCount(int booksCount)
        {
            return authors
                .Where(a => books.Where(b => b.AuthorId == a.Id).Count() >= booksCount) //We have to First filter the books to get only the ones writen by the current author
                .Select(a => a.Name)
                .ToList();
        }
        public List<string> GetAuthorsByAgeAndBookCountOfCategory(int year, string category, int booksCount)
        {
            return authors
                .Where(a => a.BirthDate.Year < year && GetBooksByCategory(category).Where(b => b.AuthorId == a.Id).Count() >= booksCount)
                .Select(a => a.Name)
                .ToList();
        }
        public IEnumerable<IGrouping<string, Book>> GetBooksByDecade()
        {
            return books
                .GroupBy(b => (b.PublishDate.Year - b.PublishDate.Year % 10).ToString() + "'s");
        }
    }
}
