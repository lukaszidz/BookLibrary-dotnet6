namespace BookLibrary.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Query Controller for Books
/// </summary>
[Route("api/[controller]")]
[Authorize]
[ApiController]
internal sealed class BookController : ControllerBase
{
    //[HttpGet]
    //public IEnumerable<> Get()
    //{
    //}
}
