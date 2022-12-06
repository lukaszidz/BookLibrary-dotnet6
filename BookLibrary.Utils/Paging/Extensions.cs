namespace BookLibrary.Utils.Paging;

using Microsoft.EntityFrameworkCore;

public static class Extensions
{
    public static async Task<PagedResult<T>> ApplyPaging<T>(this IQueryable<T> query, PagedParams paging)
    {
        if (paging.PageSize == 0)
        {
            return new PagedResult<T>(await query.ToListAsync(), false);
        }

        query = query.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize + 1);
        var result = await query.ToListAsync();

        return new PagedResult<T>(result, result.Count > paging.PageSize);
    }
}
