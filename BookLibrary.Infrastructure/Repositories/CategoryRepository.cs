namespace BookLibrary.Infrastructure.Repositories;

using System.Collections.Generic;

using BookLibrary.Core.Categories;
using BookLibrary.Infrastructure.Configuration;

using Microsoft.EntityFrameworkCore;

internal sealed class CategoryRepository : ICategoryRepository
{
    private readonly BookContext _context;

    public CategoryRepository(BookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategories() => await _context.Categories.ToListAsync();
}
