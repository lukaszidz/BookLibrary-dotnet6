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
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAuthorRepository _authorRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
        _authorRepository = authorRepository;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategories();
        var authors = await _authorRepository.GetAuthors();

        var bookCategory = categories.FirstOrDefault(c => c.Name.Equals(request.Category, StringComparison.InvariantCultureIgnoreCase));
        var bookAuthors = authors.Where(a => request.Authors.Any(ra => a.Name.Equals(ra, StringComparison.InvariantCultureIgnoreCase)));

        var book = new Book(
            request.Title,
            request.Type,
            request.Isbn,
            bookCategory ?? new Category(request.Category),
            bookAuthors.Any() ? bookAuthors.ToList() : request.Authors.Select(a => new Author(a)).ToList(),
            request.Publisher,
            request.AllCopies);

       return await _bookRepository.Create(book);
    }
}
