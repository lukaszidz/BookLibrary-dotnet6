namespace BookLibrary.Core.Authors;

using BookLibrary.Core.Books;
using BookLibrary.Core.BuildingBlocks;

public sealed class Author : Entity
{
    public Author(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    public ICollection<Book> Books { get; init; }
}
