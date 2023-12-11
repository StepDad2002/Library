using AutoMapper;
using Library.MVC.Models.Author;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<CreateAuthorDto, AuthorVM>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Books, opt => opt.Ignore());
        CreateMap<AuthorDto, AuthorVM>().ReverseMap();
        CreateMap<CreateAuthorDto, CreateAuthorVM>().ReverseMap();
        CreateMap<UpdateAuthorDto, UpdateAuthorVM>().ReverseMap();
    }
}