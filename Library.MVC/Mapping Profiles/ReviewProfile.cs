using AutoMapper;
using Library.MVC.Models.Review;
using Library.MVC.Services.Base;

namespace Library.MVC.Mapping_Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewDto, ReviewVM>().ReverseMap();
        CreateMap<ReviewDtoNoCustomer, ReviewNoCustomerVM>().ReverseMap();
        CreateMap<CreateReviewDto, CreateReviewVM>().ReverseMap();
        CreateMap<UpdateReviewDto, UpdateReviewVM>().ReverseMap();
        CreateMap<ReviewListDto, ReviewListVM>().ReverseMap();
    }
}