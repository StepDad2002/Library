namespace Library.MVC.Services.Base;

public class Response<T>
{
    public string Message { get; set; }
    
    public string ValidationErrors { get; set; }
    
    public bool Successs { get; set; }
    
    public T Data { get; set; }
}