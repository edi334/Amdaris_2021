using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineBookingStore.Application.Commands.Book;
using OnlineBookingStore.Application.DtoModels;
using OnlineBookingStore.Application.Interfaces;
using OnlineBookStore.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookingStore.Application.CommandHandlers.BookCommandHandlers
{
	public class BookCommandHandler :
		IRequestHandler<CreateBookCommand, BookDto>,
		IRequestHandler<UpdateBookCommand, BookDto>,
		IRequestHandler<DeleteBookCommand>
	{
		private readonly IRepository<Book> _repository;
		private readonly IRepository<Author> _authorRepository;

		public BookCommandHandler(IRepository<Book> repository, IRepository<Author> authorRepository) 
		{
			_repository = repository;
			_authorRepository = authorRepository;
		}

		public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
		{
			var authors = await _authorRepository.Read().Where(a => request.AuthorIds.Contains(a.Id)).ToListAsync();

			var book = new Book(request.Title, request.Description, request.PublishedOn, request.Publisher, request.Price, authors);

			book = await _repository.AddAsync(book);

			await _repository.UnitOfWork.SaveChangesAsync();

			return BookDto.From(book);
		}

		public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
		{
			var book = await _repository.GetByIdAsync(request.Id);

			_repository.Delete(book);

			await _repository.UnitOfWork.SaveChangesAsync();

			return Unit.Value;
		}

		public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
		{
			var book = await _repository.Read().Include(b => b.Authors).SingleOrDefaultAsync(b => b.Id == request.BookId);

			book.Description = request.Description;
			book.Price = request.Price;
			
			_repository.Update(book);
			await _repository.UnitOfWork.SaveChangesAsync();

			return BookDto.From(book);
		}
	}
}
