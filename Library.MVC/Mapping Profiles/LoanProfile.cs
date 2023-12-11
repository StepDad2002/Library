using AutoMapper;
using Library.MVC.Models.Loan;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class LoanProfile : Profile
{
    public LoanProfile()
    {
        CreateMap<CreateLoanDto, LoanVM>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.DueDate, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore())
            .ForMember(dest => dest.Customer, opt => opt.Ignore());

        CreateMap<LoanDto, LoanVM>().ReverseMap();
        CreateMap<CreateLoanDto, CreateLoanVM>().ReverseMap();
        CreateMap<UpdateLoanDto, UpdateLoanVM>().ReverseMap();
        CreateMap<LoanListDto, LoanListVM>().ReverseMap();
        CreateMap<LoanListNoCustomerDto, LoanListNoCustomerVM>().ReverseMap();
    }
}