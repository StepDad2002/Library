using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Library.MVC.CustomValidationAttrs;

public class DateRangeAttribute : ValidationAttribute
{
    private readonly DateTime _minDate;
    private readonly DateTime _maxDate;

    public DateRangeAttribute(string minDate, string maxDate)
    {
        if (!DateTime.TryParse(minDate, out _minDate) || !DateTime.TryParse(maxDate, out _maxDate))
        {
            throw new ArgumentException("Invalid date format");
        }
    }
    public bool ShouldNotBeInFuture { get; set; } = true;
    public override bool IsValid(object value)
    {
        if (value is DateTime date)
        {
            if (ShouldNotBeInFuture)
            {
                if (date > DateTime.UtcNow)
                    return false;
            }
            if (date < _minDate || date > _maxDate)
            {
                return false;
            }
        }
        return true;
    }
}