namespace Library.Application.Exeptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}