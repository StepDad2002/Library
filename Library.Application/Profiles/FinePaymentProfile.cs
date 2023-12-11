using AutoMapper;
using Library.Application.DTOs.FinePayment;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Profiles;

public class FinePaymentProfile : Profile
{
    public FinePaymentProfile()
    {
        CreateMap<FinePayment, FinePaymentDto>()
            /*.ForMember(x => x.PaymentDate,
                opt => opt.MapFrom(x => x.CreatedDate))*/
            .ReverseMap();
        CreateMap<FinePayment, CreateFinePaymentDto>().ReverseMap();
        CreateMap<FinePayment, UpdateFinePaymentDto>().ReverseMap();
        CreateMap<FinePayment, FinePaymentListDto>().ReverseMap();
    }
}