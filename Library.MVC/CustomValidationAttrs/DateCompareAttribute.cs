using System.ComponentModel.DataAnnotations;

namespace Library.MVC.CustomValidationAttrs;

public class DateCompareAttribute(bool date1ShouldBeGreater, string propertyToCompare) : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var propertyInfo = validationContext.ObjectType.GetProperty(propertyToCompare);
        var date2Value = (DateTime)propertyInfo.GetValue(validationContext.ObjectInstance);

        var date1Value = (DateTime)value;

        if (date1ShouldBeGreater)
        {
            if (date1Value >= date2Value)
                return ValidationResult.Success;
            return new ValidationResult($"{validationContext.DisplayName} should be greater than {propertyToCompare}");
        }

        if (date1Value <= date2Value)
            return ValidationResult.Success;
        return new ValidationResult($"{validationContext.DisplayName}  should be less than {propertyToCompare}");
    }
}