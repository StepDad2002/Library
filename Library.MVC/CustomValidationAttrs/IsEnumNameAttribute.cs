using System.ComponentModel.DataAnnotations;
using Library.Domain.Enums;

namespace Library.MVC.CustomValidationAttrs;

public class IsEnumNameAttribute(Type enumType) : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string enumName = value.ToString();

        if (enumType.IsEnum)
        {
            var isValidEnumName = enumType.GetEnumNames().Contains(enumName);
            return isValidEnumName ? ValidationResult.Success : new ValidationResult($"Allowed values: {string.Join(", ", Enum.GetNames(enumType))}");
        }

        return new ValidationResult("Type of passed enum is not enum");
    }
}