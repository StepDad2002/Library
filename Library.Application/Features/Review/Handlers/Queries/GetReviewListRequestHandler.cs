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