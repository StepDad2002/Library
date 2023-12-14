using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffByEmailRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetStaffByEmailRequest,StaffListDto>
{
    public async Task<StaffListDto> Handle(GetStaffByEmailRequest request, CancellationToken cancellationToken)
    {
        var staff = await unitOfWork.StaffRepository.GetByEmailAsync(request.Email);
        
        if (staff is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Staff), request.Email);
        
        return mapper.Map<StaffListDto>(staff);
    }
}