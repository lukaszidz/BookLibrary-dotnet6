namespace BookLibrary.Utils.Paging;

public sealed record PagedResult<T>(IEnumerable<T> Items, int TotalCount, bool HasNextPage);
