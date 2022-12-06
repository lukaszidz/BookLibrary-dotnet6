namespace BookLibrary.Core.BuildingBlocks.Paging;

public sealed record PagedResult<T>(IEnumerable<T> Items, bool HasNextPage);
