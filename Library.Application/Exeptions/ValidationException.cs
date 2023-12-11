using FluentValidation.Results;

namespace Library.Application.Exeptions;

public class ValidationException : ApplicationException
{
    public List<string> Errors { get; set; } = new();

    public ValidationException(ValidationResult validationResult)
    {
        validationResult.Errors.ForEach(x => Errors.Add(x.ErrorMessage));
    }
}