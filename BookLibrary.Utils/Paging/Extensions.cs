namespace BookLibrary.Utils.Paging;

using Microsoft.EntityFrameworkCore;

public static class Extensions
{
    public static async Task<PagedResult<T>> ApplyPaging<T>(this IQueryable<T> query, PagedParams paging)
    {
        if (paging.PageSize == 0)
        {
            var items = await query.ToListAsync();
            return new PagedResult<T>(items, items.Count, false);
        }

        var totalCount = await query.CountAsync();

        query = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize);
        var result = await query.ToListAsync();

        return new PagedResult<T>(result, totalCount, result.Count > paging.PageSize);
    }
}
