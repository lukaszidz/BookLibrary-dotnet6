namespace BookLibrary.App.Commands;

using BookLibrary.Core.Books;

using MediatR;

public sealed record CreateBookCommand(string Title, BookType Type, string Isbn, string Category, IEnumerable<string> Authors, string Publisher, int AllCopies) : IRequest<int>;
