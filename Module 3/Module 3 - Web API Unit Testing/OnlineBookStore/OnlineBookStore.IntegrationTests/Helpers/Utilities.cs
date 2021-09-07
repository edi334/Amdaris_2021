using OnlineBookStore.Domain;
using OnlineBookStore.Infrastructure;
using System;
using System.Collections.Generic;


namespace OnlineBookStore.IntegrationTests.Helpers
{
	public static class Utilities
	{
		public static void InitializeDbForTests(BookingStoreDbContext db)
		{
			var author1 = new Author("John Smith");
			var author2 = new Author("Dan Brown");
			var author3 = new Author("Laura Palmer");

			db.Authors.AddRange(author1, author2, author3);

			var book = new Book("Learning C#", "Learn C# Programming Language", DateTime.Today.AddDays(-100), "Cool Publisher", 200, new List<Author> { author1, author3 });

			db.Books.Add(book);
			db.SaveChanges();

			var book2 = new Book("Learning OOP", "Learn OO Principles", DateTime.Today.AddDays(-200), "Cool Publisher", 150, new List<Author> { author1 });

			db.Books.Add(book2);
			db.SaveChanges();

			var book3 = new Book("Learning SQL", "Learn SQL Server", DateTime.Today.AddDays(-150), "Cool Publisher", 250, new List<Author> { author2 });

			db.Books.Add(book3);
			db.SaveChanges();
		}
	}
}
