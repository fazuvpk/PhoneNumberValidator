namespace Validator
{
    public class ValidationResult
    {
        public ValidationStatus Status { get; private set; }
        public string Message { get; private set; }

        

        public ValidationResult(ValidationStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}

