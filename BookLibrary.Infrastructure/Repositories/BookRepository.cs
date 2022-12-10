namespace BookLibrary.Infrastructure.Repositories;

using BookLibrary.App.Models;
using BookLibrary.Core.Books;
using BookLibrary.Infrastructure.Configuration;
using BookLibrary.Utils.Paging;

using Microsoft.EntityFrameworkCore;

internal sealed class BookRepository : IBookRepository
{
    private readonly BookContext _context;

    public BookRepository(BookContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book.Id;
    }

    public Task<PagedResult<Book>> Filter(BookFilter filter, PagedParams paging)
    {
        var query = _context.Books
            .Include(b => b.Category)
            .Include(b => b.Authors)
            .AsNoTracking();

        var filterQuery = ApplyFilters(query, filter);

        return filterQuery
            .ApplyPaging(paging);
    }

    private IQueryable<Book> ApplyFilters(IQueryable<Book> query, BookFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(b => b.Title.ToLower().Contains(filter.Title.ToLower()));
        }

        if (!string.IsNullOrEmpty(filter.Publisher))
        {
            query = query.Where(b => b.Publisher.ToLower().Contains(filter.Publisher.ToLower()));
        }

        if (!string.IsNullOrEmpty(filter.Isbn))
        {
            query = query.Where(b => b.Isbn.ToLower().Contains(filter.Isbn.ToLower()));
        }

        if (!string.IsNullOrEmpty(filter.Author))
        {
            query = query.Where(b => b.Authors.Any(a => a.Name.ToLower().Contains(filter.Author.ToLower())));
        }

        if (filter.Type.HasValue)
        {
            query = query.Where(b => b.Type.Equals(filter.Type));
        }

        if (!string.IsNullOrEmpty(filter.Category))
        {
            query = query.Where(b => b.Category.Name.ToLower().Contains(filter.Category.ToLower()));
        }

        return query;
    }
}
