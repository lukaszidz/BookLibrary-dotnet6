namespace BookLibrary.App.Commands;

using System.Threading;
using System.Threading.Tasks;

using BookLibrary.Core.Authors;
using BookLibrary.Core.Books;
using BookLibrary.Core.Categories;

using MediatR;

internal sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(
            request.Title,
            request.Type,
            request.Isbn,
            new Category(request.Category),
            request.Authors.Select(a => new Author(a)).ToList(),
            request.Publisher,
            request.AllCopies);

       return _bookRepository.Create(book);
    }
}
