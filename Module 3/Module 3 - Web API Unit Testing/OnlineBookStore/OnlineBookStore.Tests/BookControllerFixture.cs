using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookingStore.Api.Controllers;
using OnlineBookingStore.Application.DtoModels;
using OnlineBookingStore.Application.Queries.Book;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookStore.Tests
{
	[TestClass]
	public class BookControllerFixture
	{
		private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

		[TestMethod]
		public async Task Get_All_Books_GetAllBooksQueryIsCalled()
		{
			//Arrange
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>()))				
				.Verifiable();

			//Act
			var controller = new BookController(_mockMediator.Object);
			await controller.Get();

			_mockMediator.Verify(x => x.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>()), Times.Once());
		}

		[TestMethod]
		public async Task Get_Book_By_Id_GetBookQueryIsCalled()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookQuery>(), It.IsAny<CancellationToken>()))				
				.Verifiable();

			var controller = new BookController(_mockMediator.Object);

			await controller.Get(1);
			
			_mockMediator.Verify(x => x.Send(It.IsAny<GetBookQuery>(), It.IsAny<CancellationToken>()), Times.Once());			
		}

		[TestMethod]
		public async Task Get_Book_By_Id_GetBookQueryWithCorrectBookIdIsCalled()
		{
			int bookId = 0;

			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookQuery>(), It.IsAny<CancellationToken>()))
				.Returns<GetBookQuery, CancellationToken>(async (q, c) =>
				{
					bookId = q.BookId;
					return await Task.FromResult(
						new BookDto
						{
							Id = q.BookId,
							Title = "Learning C#",
							Authors = new List<AuthorDto>
							{
								new AuthorDto
								{
									Id = 1,
									Name = "John Smith"
								}
							}
						});
				});

			var controller = new BookController(_mockMediator.Object);

			await controller.Get(1);
			
			Assert.AreEqual(bookId, 1);
		}


		[TestMethod]
		public async Task Get_Book_By_Id_ShouldReturnOkStatusCode()
		{
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(
						new BookDto
						{
							Id = 1,
							Title = "Learning C#",
							Authors = new List<AuthorDto>
							{
								new AuthorDto
								{
									Id = 1,
									Name = "John Smith"
								}
							}
						});

			var controller = new BookController(_mockMediator.Object);

			var result = await controller.Get(1);

			var okResult = result.Result as OkObjectResult;

			Assert.AreEqual((int) HttpStatusCode.OK, okResult.StatusCode);			
		}

		[TestMethod]
		public async Task Get_Book_By_Id_ShouldReturnFoundBook()
		{
			//Arrange
			var book = new BookDto
			{
				Id = 1,
				Title = "Learning C#",
				Authors = new List<AuthorDto>
							{
								new AuthorDto
								{
									Id = 1,
									Name = "John Smith"
								}
							}
			};
			_mockMediator
				.Setup(m => m.Send(It.IsAny<GetBookQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(book);

			//Act
			var controller = new BookController(_mockMediator.Object);
			var result = await controller.Get(1);

			var okResult = result.Result as OkObjectResult;

			//Assert
			Assert.AreEqual(book, okResult.Value);
		}
	}
}
