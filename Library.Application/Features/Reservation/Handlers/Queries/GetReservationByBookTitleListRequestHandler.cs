using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.Reservation;
using Library.Application.Features.Reservation.Requests.Queries;
using MediatR;

namespace Library.Application.Features.Reservation.Handlers.Queries;

public class GetReservationByBookTitleListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<GetReservationByBookTitleListRequest, List<ReservationListDto>>
{
    public async Task<List<ReservationListDto>> Handle(GetReservationByBookTitleListRequest request, CancellationToken cancellationToken)
    {
        var reservation = await unitOfWork.ReservationRepository.GetReservationByBookTitle(request.BookTitle);
        
       
        return mapper.Map<List<ReservationListDto>>(reservation);
    }
}