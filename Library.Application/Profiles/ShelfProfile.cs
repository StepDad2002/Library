using AutoMapper;
using Library.Application.DTOs.Shelf;
using Library.Domain.Entities.Schemas.BookSchema;

namespace Library.Application.Profiles;

public class ShelfProfile : Profile
{
    public ShelfProfile()
    {
        CreateMap<Shelf,ShelfDto>().ReverseMap();
        CreateMap<Shelf,CreateShelfDto>().ReverseMap();
        CreateMap<Shelf,UpdateShelfDto>().ReverseMap();
    }
}