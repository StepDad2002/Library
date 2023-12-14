using Library.MVC.Models.Reservation;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IReservationService
{
    Task<List<ReservationListVM>> GetReservations();
    Task<List<ReservationListVM>> GetReservationsByDate(DateTime date);
    Task<List<ReservationListVM>> GetReservationsByDueDate(DateTime date);
    Task<List<ReservationListVM>> GetReservationsByBookTitle(string title);
    Task<List<ReservationListVM>> GetReservationsByCustomerPhone(string phone);
    Task<List<ReservationListVM>> GetReservationsByStatus(string status);
    Task<ReservationVM> GetReservation(int id);
    Task<Response<int>> UpdateReservation(UpdateReservationVM reservation);
    Task<Response<int>> CreateReservation(CreateReservationVM reservation);
    Task<Response<int>> DeleteReservation(int id);
}