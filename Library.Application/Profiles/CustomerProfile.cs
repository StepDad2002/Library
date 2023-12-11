using AutoMapper;
using Library.Application.DTOs.Customer;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerFinePaymentsDto>().ReverseMap();
        CreateMap<Customer, CustomerListDto>().ReverseMap();
        CreateMap<Customer, CustomerLoansDto>().ReverseMap();
        CreateMap<Customer, CustomerReservationsDto>().ReverseMap();
        CreateMap<Customer, CustomerReviewsDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
    }
}