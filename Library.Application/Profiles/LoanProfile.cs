using AutoMapper;
using Library.Application.DTOs.Loan;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Profiles;

public class LoanProfile : Profile
{
    public LoanProfile()
    {
        CreateMap<Loan, LoanDto>()
            .ForMember(dest => dest.LoanDate,
                opt => opt.MapFrom(x => x.CreatedDate))
            .ReverseMap();
        CreateMap<Loan, CreateLoanDto>().ReverseMap();
        CreateMap<Loan, LoanListDto>().ReverseMap();
        CreateMap<Loan, LoanListNoCustomerDto>().ReverseMap();
        CreateMap<Loan, UpdateLoanDto>().ReverseMap();
    }
}