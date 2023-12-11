using AutoMapper;
using Library.Application.DTOs.Publisher;
using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Profiles;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        
        
        CreateMap<Publisher, PublisherDto>().ReverseMap();
        CreateMap<Publisher, CreatePublisherDto>().ReverseMap();
        CreateMap<Publisher, UpdatePublisherDto>().ReverseMap();
    }
}