namespace BookLibrary.Api.Controllers;

using BookLibrary.App.Queries.FilterBook;
using MediatR;

using Microsoft.AspNetCore.Mvc;

/// <summary>
///  Controller for Books
/// </summary>
[Route("api/[controller]")]
[ApiController]
public sealed class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("filter")]
    public async Task<IActionResult> Filter(FilterBookQuery query) => Ok(await _mediator.Send(query));
}
