using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.FinePayment.Validators;
using Library.Application.Exeptions;
using Library.Application.Features.FinePayment.Requests.Commands;
using Library.Application.Responses;
using MediatR;

namespace Library.Application.Features.FinePayment.Handlers.Commands;

public class UpdateFinePaymentCommandHandler (IUnitOfWork unitOfWork, IMapper mapper):
    IRequestHandler<UpdateFinePaymentCommand, UpdateCommandResponse>
{
    public async Task<UpdateCommandResponse> Handle(UpdateFinePaymentCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateCommandResponse();
        var validator = new UpdateFinePaymentValidator();
        var validationResult = await validator.ValidateAsync(request.FinePayment);

        if (validationResult.IsValid == false)
        {
            response.UpdatedMember = request.FinePayment;
            response.Success = false;
            response.Message = "Update failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var finePayment = await unitOfWork.FinePaymentRepository.GetAsync(request.FinePayment.Id);
            
            if (finePayment is null)
                throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.FinePayment),
                    request.FinePayment.Id);
            
            mapper.Map(request.FinePayment, finePayment);
            await unitOfWork.FinePaymentRepository.UpdateAsync(finePayment);
            
            await unitOfWork.SaveAsync();
            response.Message = "Update succeeded";
            response.Id = finePayment.Id;
        }

        return response;
    }
}