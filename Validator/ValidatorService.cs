using System;
using Validator.StringValidators;
using ValidatorExceptions;

namespace Validator
{
	public class ValidatorService
	{
		IStringContainsPhoneNumberValidator _validator;
        public ValidatorService(IStringContainsPhoneNumberValidator validator)
		{
			_validator = validator;
		}

		public bool DoesNotContainPhone(string input)
		{
			var result = (PhoneNumberValidationResult) _validator.Validate(new ValidationInput<string>(input));
			if (result.Status == ValidationStatus.Failure)
				throw new PhoneNumberDetectedException<PhoneNumberInfo>(result.PhoneNumbers);
			return true;
        }
	}
}

