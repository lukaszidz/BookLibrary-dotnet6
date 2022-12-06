namespace BookLibrary.Core.Books;
using BookLibrary.Core.BuildingBlocks;
using BookLibrary.Core.BuildingBlocks.Paging;

public interface IBookRepository
{
    Task<PagedResult<Book>> Filter(BookFilter filter, PagedParams paging);
}
