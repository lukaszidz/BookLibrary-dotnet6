namespace BookLibrary.Core.Categories;

using BookLibrary.Core.Books;
using BookLibrary.Core.BuildingBlocks;

public sealed class Category : Entity
{
    public Category(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    public ICollection<Book> Books { get; init; }
}
