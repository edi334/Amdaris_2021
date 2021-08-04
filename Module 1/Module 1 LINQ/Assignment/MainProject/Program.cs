using Classes;
using System;
using System.Collections.Generic;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Author> authors = new List<Author>
            {
                new Author {Id = 1, Name = "Mihai Eminescu", BirthDate = DateTime.Now.AddYears(-150)},
                new Author {Id = 2, Name = "Liviu Rebreanu", BirthDate = DateTime.Now.AddYears(-50)},
                new Author {Id = 3, Name = "Vladimir Colin", BirthDate = DateTime.Now.AddYears(-100)}
            };

            List<Book> books = new List<Book>
            {
                new Book {Id = 1, AuthorId = 1, Title = "Poesii", Categories = new List<string> {"poezie", "drama"}, PublishDate = DateTime.Now.AddYears(-50)},
                new Book {Id = 2, AuthorId = 1, Title = "Fat Frumos din Lacrima", Categories = new List<string> {"basme"}, PublishDate = DateTime.Now.AddYears(-70)},
                new Book {Id = 3, AuthorId = 1, Title = "Luceafarul", Categories = new List<string> {"science-fiction", "drama"}, PublishDate = DateTime.Now.AddYears(-40)},
                new Book {Id = 4, AuthorId = 2, Title = "Ion", Categories = new List<string> {"drama", "psihologic"}, PublishDate = DateTime.Now.AddYears(-20)},
                new Book {Id = 5, AuthorId = 2, Title = "Adam si Eva", Categories = new List<string> {"romantic", "spiritual"}, PublishDate = DateTime.Now.AddYears(-50)},
                new Book {Id = 6, AuthorId = 3, Title = "Babel", Categories = new List<string> {"science-fiction", "drama"}, PublishDate = DateTime.Now.AddYears(-75)},
                new Book {Id = 7, AuthorId = 3, Title = "Basmele Omului", Categories = new List<string> {"basme"}, PublishDate = DateTime.Now.AddYears(-82)},
                new Book {Id = 8, AuthorId = 3, Title = "Legendele Tarii lui Vam", Categories = new List<string> {"science-fiction", "basme"}, PublishDate = DateTime.Now.AddYears(-85)}
            };

            Book b = new Book {Id = 9, AuthorId = 2, Title = "Ciuleandra", Categories = new List<string> { "drama" }, PublishDate = DateTime.Now.AddYears(-60)};

            Library library = new Library(books, authors);
            library.Add(b);

            library.GetBooks().ForEach(b => Console.WriteLine(b));
            Console.WriteLine();
            library.GetBooksAfterYear(1980).ForEach(b => Console.WriteLine(b));
            Console.WriteLine();

            library.Remove(b);

            library.GetBooksByCategory("drama").ForEach(b => Console.WriteLine(b));
            Console.WriteLine();
            library.GetAuthorsByBookCount(3).ForEach(a => Console.WriteLine(a));
            Console.WriteLine();
            library.GetAuthorsByAgeAndBookCountOfCategory(1990, "science-fiction", 2).ForEach(a => Console.WriteLine(a));
            Console.WriteLine();
            foreach (var group in library.GetBooksByDecade())
            {
                Console.WriteLine(group.Key + ":");
                foreach (Book book in group)
                {
                    Console.WriteLine("\t" + book);
                }
            }
        }
    }
}
