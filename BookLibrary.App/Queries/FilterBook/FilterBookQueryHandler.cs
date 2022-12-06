namespace BookLibrary.App.Queries.FilterBook;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using BookLibrary.App.Models;
using BookLibrary.Core.Books;
using BookLibrary.Utils.Paging;

using MediatR;

internal sealed class FilterBookQueryHandler : IRequestHandler<FilterBookQuery, PagedResult<BookModel>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public FilterBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<PagedResult<BookModel>> Handle(FilterBookQuery request, CancellationToken cancellationToken)
    {
        var pagedResult = await _bookRepository.Filter(request.Filter, request.Paging);
        return _mapper.Map<PagedResult<BookModel>>(pagedResult);
    }
}
