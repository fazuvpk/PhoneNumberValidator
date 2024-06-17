using System;
namespace ValidatorExceptions
{
    public class PhoneNumberDetectedException<T> : Exception
    {
        public IEnumerable<T> DetectedPhoneNumbers { get; }

        public PhoneNumberDetectedException(IEnumerable<T> detectedPhoneNumbers)
            : base("Phone numbers detected in the input string.")
        {
            DetectedPhoneNumbers = detectedPhoneNumbers;
        }

        public PhoneNumberDetectedException(string message, IEnumerable<T> detectedPhoneNumbers)
            : base(message)
        {
            DetectedPhoneNumbers = detectedPhoneNumbers;
        }

        public PhoneNumberDetectedException(string message, Exception inner, IEnumerable<T> detectedPhoneNumbers)
            : base(message, inner)
        {
            DetectedPhoneNumbers = detectedPhoneNumbers;
        }
    }
}

