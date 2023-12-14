using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffByPhoneRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetStaffByPhoneRequest,StaffListDto>
{
    public async Task<StaffListDto> Handle(GetStaffByPhoneRequest request, CancellationToken cancellationToken)
    {
        var staff = await unitOfWork.StaffRepository.GetByPhoneAsync(request.Phone);
        
        if (staff is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Staff), request.Phone);
        
        return mapper.Map<StaffListDto>(staff);
    }
}