using AutoMapper;
using Library.Application.DTOs.Author;
using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, CreateAuthorDto>().ReverseMap();
        CreateMap<Author, UpdateAuthorDto>().ReverseMap();
    }
}