using Library.MVC.Models.FinePayment;
using Library.MVC.Services.Base;

namespace Library.MVC.Contracts;

public interface IFinePaymentService
{
    Task<List<FinePaymentListVM>> GetFinePayments();
    Task<FinePaymentVM> GetFinePayment(int id);
    Task<Response<int>> UpdateFinePayment(UpdateFinePaymentVM payment);
    Task<Response<int>> CreateFinePayment(CreateFinePaymentVM payment);
    Task<Response<int>> DeleteFinePayment(int id);
}