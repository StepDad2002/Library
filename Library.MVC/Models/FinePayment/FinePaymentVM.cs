using Library.MVC.Models.Customer;

namespace Library.MVC.Models.FinePayment;

public class FinePaymentVM : UpdateFinePaymentVM
{
    public CustomerListVM Customer { get; set; }
    
    public new DateTime PaymentDate { get; set; }
}