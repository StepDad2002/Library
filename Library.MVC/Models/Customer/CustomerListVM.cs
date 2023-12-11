namespace Library.MVC.Models.Customer;

public class CustomerListVM: IPersonVM
{
    public int Id { get; set; }
    
    public string FName { get; set; }
    
    public string LName { get; set; }
    
    public string? Email { get; set; }
    
    public string Phone { get; set; }
}