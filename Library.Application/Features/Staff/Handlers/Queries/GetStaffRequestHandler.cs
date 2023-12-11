using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetStaffRequest,StaffDto>
{
    public async Task<StaffDto> Handle(GetStaffRequest request, CancellationToken cancellationToken)
    {
        var staff = await unitOfWork.StaffRepository.GetAsync(request.Id);
        
        if (staff is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Staff), request.Id);
        
        return mapper.Map<StaffDto>(staff);
    }
}