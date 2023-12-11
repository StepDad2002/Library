using AutoMapper;
using Library.MVC.Models.Customer;
using Library.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.MVC.Mapping_Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, CustomerVm>()
            .ReverseMap();
        CreateMap<CustomerFinePaymentsDto, CustomerFinePaymentsVM>().ReverseMap();
        CreateMap<CustomerListDto, CustomerListVM>().ReverseMap();
        CreateMap<CustomerLoansDto, CustomerLoansVM>().ReverseMap();
        CreateMap<CustomerReservationsDto, CustomerReservationsVM>().ReverseMap();
        CreateMap<CustomerReviewsDto, CustomerReviewsVM>()
            .ReverseMap();

        CreateMap<UpdateCustomerDto, UpdateCustomerVM>()
            .ReverseMap();
        CreateMap<CreateCustomerDto, CreateCustomerVM>()
            .ReverseMap();
    }
}