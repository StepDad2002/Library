using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.Staff.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Staff.Handlers.Commands;

public class UpdateStaffCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<UpdateStaffCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateStaffDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Staff);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.Staff;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {

            var staff = await unitOfWork.StaffRepository.GetAsync(request.Staff.Id);

            if (staff is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Staff), request.Staff.Id);
            
            mapper.Map(request.Staff, staff);
            await unitOfWork.StaffRepository.UpdateAsync(staff);
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = staff.Id;
        }

        return response;
    }
}