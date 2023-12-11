using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Common.Validators;
using Library.Application.Features.Staff.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.Staff.Handlers.Commands;

public class StaffLoginCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<StaffLoginCommand, BaseCommandResponse>
{
    public async Task<BaseCommandResponse> Handle(StaffLoginCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new LogInStaffValidator(unitOfWork);
        var validationResult = await validator.ValidateAsync(request.Login);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Not valid credentials";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            response.Success = true;
            response.Message = "Welcome to system";
            response.Id =
                await unitOfWork.StaffRepository.TryLogInAsync(request.Login.Email, request.Login.Password);
        }

        return response;
    }
}