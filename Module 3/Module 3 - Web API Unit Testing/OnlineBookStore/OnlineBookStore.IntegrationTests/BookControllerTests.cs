using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineBookingStore.Api;
using OnlineBookingStore.Application.DtoModels;
using OnlineBookStore.IntegrationTests.SocialMedia.Host.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using OnlineBookingStore.Application.Commands.Book;

namespace OnlineBookStore.IntegrationTests
{
	[TestClass]
	public class BookControllerTests
	{
        private static TestContext _testContext;
        private static WebApplicationFactory<Startup> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Startup>();
        }

        [TestMethod]
        public async Task Get_All_Books_ShouldReturnOkResponse() 
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/book");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task Get_All_Books_ShouldReturnExistingBook()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/book");

            var result = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookDto>>(result);

            var book = books.FirstOrDefault(b => b.Id == 1);
			BookAsserts(book);
        }
       
        [TestMethod]
        public async Task Get_Book_By_Id_ShouldReturnExistingBook()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/book/1");

            var result = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<BookDto>(result);

			BookAsserts(book);
        }

        [TestMethod]
        public async Task Post_Book_ShouldReturnCreatedResponse()         
        {
            var book = new CreateBookCommand
            {
                AuthorIds = new List<int> { 1, 2},
                Title = "SQL LITE",
                Description = "Learn ASP.NET",
                PublishedOn = DateTime.Today.AddDays(-10),
                Publisher = "Test Publisher",
                Price = 150
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/book",
                new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task Post_Book_ShouldReturnCreatedBook()
        {
            var newBook = new CreateBookCommand
            {
                AuthorIds = new List<int> { 1, 2 },
                Title = "gsdgsdg",
                Description = "Learn ASP.NET",
                PublishedOn = DateTime.Today.AddDays(-10),
                Publisher = "Test Publisher",
                Price = 150
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/book",
                new StringContent(JsonConvert.SerializeObject(newBook), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<BookDto>(result);

            Assert.AreEqual(newBook.Title, book.Title);
            Assert.AreEqual(newBook.Description, book.Description);
            Assert.AreEqual(newBook.PublishedOn, book.PublishedOn);
            Assert.AreEqual(newBook.Publisher, book.Publisher);
            Assert.AreEqual(newBook.Price, book.Price);
            Assert.AreEqual(2, book.Authors.Count);
            Assert.IsTrue(book.Authors.Any(a => a.Name == "John Smith"));
            Assert.IsTrue(book.Authors.Any(a => a.Name == "Dan Brown"));
        }

        [TestMethod]
        public async Task Put_Book_ShouldReturnUpdatedBook() 
        {
            var command = new UpdateBookCommand
            {
                BookId = 3,
                Description = "Updated Description",
                Price = 250
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("/api/book/3",
                new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<BookDto>(result);

            Assert.AreEqual(command.BookId, book.Id);
            Assert.AreEqual(command.Description, book.Description);            
            Assert.AreEqual(command.Price, book.Price);
        }

        public async Task Delete_Book_ShouldReturnNoContentResponse() 
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/book/2");
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

        private static void BookAsserts(BookDto book) 
        {
            Assert.AreEqual("Learning C#", book.Title);
            Assert.AreEqual("Learn C# Programming Language", book.Description);
            Assert.AreEqual(DateTime.Today.AddDays(-100), book.PublishedOn);
            Assert.AreEqual("Cool Publisher", book.Publisher);
            Assert.AreEqual(200, book.Price);
            Assert.AreEqual(2, book.Authors.Count);
            Assert.IsTrue(book.Authors.Any(a => a.Name == "John Smith"));
            Assert.IsTrue(book.Authors.Any(a => a.Name == "Laura Palmer"));
        }
    }
}
