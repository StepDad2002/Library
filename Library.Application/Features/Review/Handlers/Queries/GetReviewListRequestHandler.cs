using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Review;
using Library.Application.Exeptions;
using Library.Application.Features.Review.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Review.Handlers.Queries;

public class GetReviewListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetReviewListRequest, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewListRequest request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetReviewsWithDetailsAsync();
        
       
        return mapper.Map<List<ReviewDto>>(review);
    }
}

public class GetReviewByDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetReviewByDateListRequest, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewByDateListRequest request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetReviewsByDateAsync(request.Date);
        
       
        return mapper.Map<List<ReviewDto>>(review);
    }
}

public class GetReviewByBookTitleListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetReviewByBookTitleListRequest, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewByBookTitleListRequest request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetReviewsByBookTitleAsync(request.BookTitle);
        
       
        return mapper.Map<List<ReviewDto>>(review);
    }
}

public class GetReviewByCustomerPhoneListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetReviewByCustomerPhoneListRequest, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewByCustomerPhoneListRequest request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetReviewsByCustomerPhoneAsync(request.Phone);
        
       
        return mapper.Map<List<ReviewDto>>(review);
    }
}

public class GetReviewByRatingListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetReviewByRatingListRequest, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewByRatingListRequest request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetReviewsByRatingAsync(request.MinRating, request.MaxRating);
        
       
        return mapper.Map<List<ReviewDto>>(review);
    }
}