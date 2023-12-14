using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation;
using Library.Application.Features.Reservation.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Queries;

public class GetReservationByDueDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetReservationByDueDateListRequest, List<ReservationListDto>>
{
    public async Task<List<ReservationListDto>> Handle(GetReservationByDueDateListRequest request, CancellationToken cancellationToken)
    {
        var reservation = await unitOfWork.ReservationRepository.GetReservationByDueDate(request.DueDate);
        
       
        return mapper.Map<List<ReservationListDto>>(reservation);
    }
}