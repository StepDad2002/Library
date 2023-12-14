using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation;
using Library.Application.Features.Reservation.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Queries;

public class GetReservationByStatusListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetReservationByStatusListRequest, List<ReservationListDto>>
{
    public async Task<List<ReservationListDto>> Handle(GetReservationByStatusListRequest request, CancellationToken cancellationToken)
    {
        var reservation = await unitOfWork.ReservationRepository.GetReservationByStatus(request.Status);
        
       
        return mapper.Map<List<ReservationListDto>>(reservation);
    }
}