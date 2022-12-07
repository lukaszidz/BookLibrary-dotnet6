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

        CreateMap<Book, BookResult>()
            .ForCtorParam(nameof(BookResult.Category), opt => opt.MapFrom(b => b.Category.Name))
            .ForCtorParam(nameof(BookResult.Authors), opt => opt.MapFrom(b => b.Authors.Select(a => a.Name)));
    }
}
