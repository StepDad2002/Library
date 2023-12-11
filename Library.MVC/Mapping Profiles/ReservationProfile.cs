using AutoMapper;
using Library.MVC.Models.Reservation;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<ReservationDto, ReservationVM>().ReverseMap();
        CreateMap<CreateReservationDto, CreateReservationVM>().ReverseMap();
        CreateMap<UpdateReservationDto, UpdateReservationVM>().ReverseMap();
        CreateMap<ReservationListDto, ReservationListVM>().ReverseMap();
        CreateMap<ReservationListNoCustomerDto, ReservationListNoCustomerVM>().ReverseMap();
    }
}