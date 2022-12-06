namespace BookLibrary.Core.Books;

using BookLibrary.App.Models;
using BookLibrary.Utils.Paging;

public interface IBookRepository
{
    Task<PagedResult<Book>> Filter(BookFilter filter, PagedParams paging);
}
