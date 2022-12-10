namespace BookLibrary.Core.Authors;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthors();
}
