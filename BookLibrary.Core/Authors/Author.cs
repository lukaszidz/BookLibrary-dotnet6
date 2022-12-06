namespace BookLibrary.Core.Authors;
using BookLibrary.Core.BuildingBlocks;

public sealed class Author : Entity
{
    public Author(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
}
