using System;
namespace Validator.StringValidators
{
    public class PhoneNumberValidationResult : ValidationResult
    {

        public List<PhoneNumberInfo> PhoneNumbers;
        public PhoneNumberValidationResult(ValidationStatus status, string message)
            : base(status, message)
        {
        }
        public PhoneNumberValidationResult(List<PhoneNumberInfo> phoneNumbers):
            base(ValidationStatus.Failure,"Found phone number in text")
        {
            PhoneNumbers = phoneNumbers;
        }
    }
}

