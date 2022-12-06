namespace BookLibrary.Core.Books;
using BookLibrary.Core.Authors;
using BookLibrary.Core.BuildingBlocks;
using BookLibrary.Core.Categories;

public sealed class Book : Entity
{
    private Book(string title, BookType type, string isbn, string publisher, int allCopies)
    {
        Title = title;
        Type = type;
        Isbn = isbn;
        Publisher = publisher;
        AvailableCopies = allCopies;
        AllCopies = allCopies;
    }

    public Book(string title, BookType type, string isbn, Category category, ICollection<Author> authors, string publisher, int allCopies)
        : this(title, type, isbn, publisher, allCopies)
    {
        Category = category;
        Authors = authors;
    }

    public string Title { get; init; }
    public BookType Type { get; init; }
    public string Isbn { get; init; }
    public Category Category { get; init; }
    public ICollection<Author> Authors { get; init; }
    public string Publisher { get; init; }
    public int AvailableCopies { get; init; }
    public int AllCopies { get; init; }
}
