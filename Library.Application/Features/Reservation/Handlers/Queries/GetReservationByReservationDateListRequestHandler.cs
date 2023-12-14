using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation;
using Library.Application.Features.Reservation.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Queries;

public class GetReservationByReservationDateListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetReservationByReservationDateListRequest, List<ReservationListDto>>
{
    public async Task<List<ReservationListDto>> Handle(GetReservationByReservationDateListRequest request, CancellationToken cancellationToken)
    {
        var reservation = await unitOfWork.ReservationRepository.GetReservationByReservationDate(request.ReservationDate);
        
       
        return mapper.Map<List<ReservationListDto>>(reservation);
    }
}