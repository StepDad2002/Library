using AutoMapper;
using Library.Application.DTOs.Reservation;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, CreateReservationDto>().ReverseMap();
        CreateMap<Reservation, ReservationDto>().ReverseMap();
        CreateMap<Reservation, ReservationListDto>().ReverseMap();
        CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
        CreateMap<Reservation, ReservationListNoCustomerDto>().ReverseMap();
    }
}