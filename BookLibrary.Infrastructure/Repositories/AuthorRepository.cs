namespace BookLibrary.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

using BookLibrary.Core.Authors;
using BookLibrary.Infrastructure.Configuration;

using Microsoft.EntityFrameworkCore;

internal sealed class AuthorRepository : IAuthorRepository
{
    private readonly BookContext _context;

    public AuthorRepository(BookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAuthors() => await _context.Authors.ToListAsync();
}
