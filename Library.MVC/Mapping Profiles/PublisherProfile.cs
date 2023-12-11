using AutoMapper;
using Library.MVC.Models.Publisher;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        CreateMap<PublisherDto, PublisherVM>().ReverseMap();
        CreateMap<PublisherDto, PublisherListVM>().ReverseMap();
        CreateMap<CreatePublisherDto, CreatePublisherVM>().ReverseMap();
        CreateMap<UpdatePublisherDto, UpdatePublisherVM>().ReverseMap();
    }
}