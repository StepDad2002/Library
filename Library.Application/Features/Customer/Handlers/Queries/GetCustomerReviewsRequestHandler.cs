using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Customer;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Customer.Requests.Queries;

public class GetCustomerReviewsRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetCustomerReviewsRequest,CustomerReviewsDto>
{
    public async Task<CustomerReviewsDto> Handle(GetCustomerReviewsRequest request, CancellationToken cancellationToken)
    {
        var customerReviews = await unitOfWork.CustomerRepository.GetCustomerReviewsAsync(request.Id);
        
        if (customerReviews is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Customer), request.Id);
        
        return mapper.Map<CustomerReviewsDto>(customerReviews);
    }
}