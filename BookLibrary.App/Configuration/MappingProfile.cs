namespace BookLibrary.App.Configuration;

using AutoMapper;

using BookLibrary.App.Models;
using BookLibrary.Core.Books;
using BookLibrary.Utils.Paging;

internal sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));

        CreateMap<Book, BookModel>();
    }
}
