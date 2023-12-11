using Library.MVC.Models.Reservation;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IReservationService
{
    Task<List<ReservationListVM>> GetReservations();
    Task<ReservationVM> GetReservation(int id);
    Task<Response<int>> UpdateReservation(UpdateReservationVM reservation);
    Task<Response<int>> CreateReservation(CreateReservationVM reservation);
    Task<Response<int>> DeleteReservation(int id);
}