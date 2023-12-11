using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Review;
using Library.Application.Exeptions;
using Library.Application.Features.Review.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Review.Handlers.Queries;

public class GetReviewRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetReviewRequest, ReviewDto>
{
    public async Task<ReviewDto> Handle(GetReviewRequest request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetReviewWithDetailsAsync(request.Id);
        
        if (review is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Review), request.Id);
        
        return mapper.Map<ReviewDto>(review);
    }
}