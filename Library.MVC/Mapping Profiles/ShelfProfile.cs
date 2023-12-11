using AutoMapper;
using Library.MVC.Models.Shelf;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class ShelfProfile : Profile
{
    public ShelfProfile()
    {
        CreateMap<ShelfDto, ShelfVM>().ReverseMap();
        CreateMap<CreateShelfDto, CreateShelfVM>().ReverseMap();
        CreateMap<UpdateShelfDto, UpdateShelfVM>().ReverseMap();
    }
}