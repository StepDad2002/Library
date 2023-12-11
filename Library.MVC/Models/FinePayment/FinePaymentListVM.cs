using Library.MVC.Models.Customer;

namespace Library.MVC.Models.FinePayment;

public class FinePaymentListVM : CreateFinePaymentVM
{
    public CustomerListVM Customer { get; set; }
    public int Id { get; set; }
}