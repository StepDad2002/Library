using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation;
using Library.Application.Features.Reservation.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Queries;

public class GetReservationByCustomerPhoneListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetReservationByCustomerPhoneListRequest, List<ReservationListDto>>
{
    public async Task<List<ReservationListDto>> Handle(GetReservationByCustomerPhoneListRequest request, CancellationToken cancellationToken)
    {
        var reservation = await unitOfWork.ReservationRepository.GetReservationByCustomerPhone(request.Phone);
        
       
        return mapper.Map<List<ReservationListDto>>(reservation);
    }
}