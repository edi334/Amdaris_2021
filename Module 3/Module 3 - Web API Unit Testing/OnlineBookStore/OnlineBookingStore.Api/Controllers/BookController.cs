using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingStore.Application.Commands.Book;
using OnlineBookingStore.Application.DtoModels;
using OnlineBookingStore.Application.Queries.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineBookingStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[ApiExplorerSettings(GroupName = "v1")]
	public class BookController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BookController(IMediator mediator) 
		{
			_mediator = mediator;
		}

		// GET: api/<BookController>
		[HttpGet]
		public async Task<ActionResult<IList<BookDto>>> Get()
		{
			var query = new GetAllBooksQuery();
			var books = await _mediator.Send(query);

			return Ok(books);
		}

		// GET api/<BookController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<BookDto>> Get(int id)
		{
			var query = new GetBookQuery { BookId = id };
			var book = await _mediator.Send(query);

			return Ok(book);
		}

		// POST api/<BookController>
		[HttpPost]
		public async Task<ActionResult<BookDto>> Post([FromBody] CreateBookCommand command)
		{
			var book = await _mediator.Send(command);

			return CreatedAtRoute(new { id = book.Id }, book);
		}

		// PUT api/<BookController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult<BookDto>> Put(int id, [FromBody] UpdateBookCommand command)
		{
			command.BookId = id;
			
			var book = await _mediator.Send(command);

			return Ok(book);
		}

		// PUT api/<BookController>/5/review
		[HttpPut("{id}/review")]
		public async Task<ActionResult<ReviewDto>> AddReview(int id, [FromBody] AddReviewCommand command)
		{
			command.BookId = id;
			
			var review = await _mediator.Send(command);

			return Ok(review);
		}

		[HttpDelete("{id}")]
		public async Task<NoContentResult> Delete(int id) 
		{
			var command = new DeleteBookCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
