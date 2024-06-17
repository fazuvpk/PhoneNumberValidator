using System;
namespace Validator
{
    public interface IValidator<T>
    {
        ValidationResult Validate(ValidationInput<T> input);
    }
}