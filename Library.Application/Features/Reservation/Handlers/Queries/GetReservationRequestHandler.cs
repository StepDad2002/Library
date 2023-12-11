using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation;
using Library.Application.Exeptions;
using Library.Application.Features.Reservation.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Queries;

public class GetReservationRequestHandler (IUnitOfWork unitOfWork, IMapper mapper) : 
    IRequestHandler<GetReservationRequest, ReservationDto>
{
    public async Task<ReservationDto> Handle(GetReservationRequest request, CancellationToken cancellationToken)
    {
        var reservation = await unitOfWork.ReservationRepository.GetReservationWithDetailsAsync(request.Id);
        
        if(reservation is null)
            throw new NotFoundException(nameof(Domain.Entities.Schemas.Management.Reservation), request.Id);
        
        return mapper.Map<ReservationDto>(reservation);
    }
}