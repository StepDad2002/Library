using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Validators;
using Library.Application.Features.Staff.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Staff.Handlers.Commands;

public class CreateStaffCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<CreateStaffCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
    {
        var commandResponse = new BaseCommandResponse();
        var validator = new StaffDtoValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Staff);

        if (validationResult.IsValid == false)
        {
            commandResponse.Success = false;
            commandResponse.Message = "Creating Failed";
            commandResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var staff = mapper.Map<Domain.Entities.Schemas.Management.Staff>(request.Staff);
            await unitOfWork.StaffRepository.AddAsync(staff);
            commandResponse.Message = "Creating Success";
            await unitOfWork.SaveAsync();
            commandResponse.Id = staff.Id;
        }

        return commandResponse;
    }
}