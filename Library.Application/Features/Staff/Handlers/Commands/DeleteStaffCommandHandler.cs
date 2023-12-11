using Library.Application.Contracts.Persistence;
using Library.Application.Exeptions;
using Library.Application.Features.Staff.Requests.Commands;
using MediatR;

namespace Library.Application.Features.Staff.Handlers.Commands;

public class DeleteStaffCommandHandler(IUnitOfWork unitOfWork) :
    IRequestHandler<DeleteStaffCommand, Unit>
{
    public async Task<Unit> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = await unitOfWork.StaffRepository.GetAsync(request.Id);

        if (staff == null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Staff),request.Id);

        await unitOfWork.StaffRepository.DeleteAsync(staff);
        await unitOfWork.SaveAsync();
        
        return Unit.Value;
    }
}