namespace BookLibrary.App.Queries.FilterBook
{
    using BookLibrary.App.Models;
    using BookLibrary.Utils.Paging;

    using MediatR;

    public sealed record FilterBookQuery(BookFilter Filter, PagedParams Paging) : IRequest<PagedResult<BookResult>>;
}
