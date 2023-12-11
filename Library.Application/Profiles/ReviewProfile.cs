using AutoMapper;
using Library.Application.DTOs.Review;
using Library.Domain.Common;
using Library.Domain.Entities.Schemas.Management;

namespace Library.Application.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        
        
        CreateMap<ManagementBaseDomainEntity, ReviewDto>()
            .ReverseMap();
        CreateMap<Review, ReviewDto>().IncludeBase<ManagementBaseDomainEntity, ReviewDto>().ReverseMap();
        CreateMap<Review, ReviewDtoNoCustomer>().ReverseMap();
        CreateMap<Review,CreateReviewDto>().ReverseMap();
        CreateMap<Review,ReviewDto>()
            .ReverseMap();
        CreateMap<Review,UpdateReviewDto>()
            .ReverseMap();
        CreateMap<Review,ReviewListDto>()
            .ReverseMap();
    }
}