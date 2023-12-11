using System.ComponentModel.DataAnnotations;

namespace Library.MVC.CustomValidationAttrs;

public class DateNotInFutureAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var date = value is DateTime ? (DateTime)value : (DateTime?)null;
        if (date == null)
            return false;
        
        if (date > DateTime.UtcNow)
        {
            return false;
        }
        return true;
    }
}
