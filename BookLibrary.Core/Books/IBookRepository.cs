namespace BookLibrary.Core.Books;

using BookLibrary.App.Models;
using BookLibrary.Utils.Paging;

public interface IBookRepository
{
    Task<int> Create(Book book);
    Task<PagedResult<Book>> Filter(BookFilter filter, PagedParams paging);
}
