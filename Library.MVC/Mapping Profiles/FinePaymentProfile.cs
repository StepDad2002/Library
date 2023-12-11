using AutoMapper;
using Library.MVC.Models.FinePayment;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class FinePaymentProfile : Profile
{
    public FinePaymentProfile()
    {
        CreateMap<CreateFinePaymentDto, CreateFinePaymentVM>().ReverseMap();
        CreateMap<FinePaymentDto, FinePaymentVM>().ReverseMap();
        CreateMap<UpdateFinePaymentDto, UpdateFinePaymentVM>().ReverseMap();
        CreateMap<FinePaymentListDto, FinePaymentListVM>().ReverseMap();
    }
}