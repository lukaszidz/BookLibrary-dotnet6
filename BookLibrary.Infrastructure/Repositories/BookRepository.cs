namespace BookLibrary.Infrastructure.Repositories;
using BookLibrary.Core.Books;
using BookLibrary.Core.BuildingBlocks;
using BookLibrary.Core.BuildingBlocks.Paging;
using BookLibrary.Infrastructure.Configuration;

using Microsoft.EntityFrameworkCore;

internal sealed class BookRepository : IBookRepository
{
    private readonly BookContext _context;

    public BookRepository(BookContext context)
    {
        _context = context;
    }

    public Task<PagedResult<Book>> Filter(BookFilter filter, PagedParams paging)
    {
        var query = _context.Books
            .Include(b => b.Category)
            .Include(b => b.Authors)
            .AsNoTracking();

        var filterQuery = ApplyFilters(_context.Books.AsQueryable(), filter);

        return filterQuery
            .ApplyPaging(paging);
    }

    private IQueryable<Book> ApplyFilters(IQueryable<Book> query, BookFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(b => b.Title.IgnoreCaseEquals(filter.Title));
        }

        if (!string.IsNullOrEmpty(filter.Publisher))
        {
            query = query.Where(b => b.Publisher.IgnoreCaseEquals(filter.Publisher));
        }

        if (!string.IsNullOrEmpty(filter.Isbn))
        {
            query = query.Where(b => b.Isbn.IgnoreCaseEquals(filter.Isbn));
        }

        if (filter.AuthorId.HasValue)
        {
            query = query.Where(b => b.Authors.Any(a => a.Id == filter.AuthorId));
        }

        if (filter.Type.HasValue)
        {
            query = query.Where(b => b.Type.Equals(filter.Type));
        }

        if (filter.CategoryId.HasValue)
        {
            query = query.Where(b => b.Category.Id == filter.CategoryId);
        }

        return query;
    }
}
