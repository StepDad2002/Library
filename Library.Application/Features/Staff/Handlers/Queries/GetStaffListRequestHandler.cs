using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs;
using Library.Application.Exeptions;
using MediatR;

namespace Library.Application.Features.Staff.Requests.Queries;

public class GetStaffListRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetStaffListRequest,List<StaffListDto>>
{
    public async Task<List<StaffListDto>> Handle(GetStaffListRequest request, CancellationToken cancellationToken)
    {
        var staffList = await unitOfWork.StaffRepository.GetAllAsync();
        
        return mapper.Map<List<StaffListDto>>(staffList);
    }
}