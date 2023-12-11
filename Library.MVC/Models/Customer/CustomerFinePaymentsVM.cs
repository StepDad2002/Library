using System.ComponentModel.DataAnnotations;
using Library.MVC.Models.FinePayment;

namespace Library.MVC.Models.Customer;

public class CustomerFinePaymentsVM : IPersonVM
{
    [Range(0, Int32.MaxValue,MinimumIsExclusive = true)]
    public int Id { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string? Email { get; set; }
    public string Phone { get; set; }
    public ICollection<FinePaymentListVM> FinePayments { get; set; }
}