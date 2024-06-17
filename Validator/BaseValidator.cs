using System;
namespace Validator
{
    public abstract class BaseValidator<TValue> : IValidator<TValue>
    {
        public ValidationResult Validate(ValidationInput<TValue> input)
        {
            if (!(input.Value is TValue))
            {
                return new ValidationResult(ValidationStatus.Failure, $"Invalid input type: {typeof(TValue).Name}");
            }

            return ValidateInternal(input);
        }

        protected abstract ValidationResult ValidateInternal(ValidationInput<TValue> input);
    }
}       