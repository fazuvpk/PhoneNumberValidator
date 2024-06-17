using Validator.StringValidators;
namespace Validator.Tests
{
    public class StringContainsPhoneNumberValidatorTests
    {
        [Fact]
        public void ValidateInternal_WithValidPhoneNumbers_ReturnsExpectedResult()
        {
            // Arrange
            var validator = new StringContainsPhoneNumberValidator();
            var input = "This is a test string with phone numbers +1 123-4567, (555) 7890 and some phone numbers like 9 8 ONE ZERO zero two 3 4 five five";

            // Act
            var validationResult = (PhoneNumberValidationResult) validator.Validate(new ValidationInput<string>(input));

            // Assert
            Assert.NotNull(validationResult);
            Assert.True(validationResult.Status == ValidationStatus.Failure);
            Assert.Equal(3, validationResult.PhoneNumbers.Count); // Assuming it finds three phone numbers in the provided input
        }

        [Fact]
        public void ValidateInternal_WithNoPhoneNumbers_ReturnsEmptyResult()
        {
            // Arrange
            var validator = new StringContainsPhoneNumberValidator();
            var input = "This string does not contain any phone numbers";

            // Act
            var validationResult = (PhoneNumberValidationResult) validator.Validate(new ValidationInput<string>(input));

            // Assert
            Assert.NotNull(validationResult);
            Assert.True(validationResult.Status == ValidationStatus.Success);
            Assert.Null(validationResult.PhoneNumbers);
        }
    }
}