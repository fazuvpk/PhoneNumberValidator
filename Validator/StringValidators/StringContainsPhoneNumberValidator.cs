using System;
using System.Text;
using System.Text.RegularExpressions;
using ValidatorExceptions;

namespace Validator.StringValidators
{
    public class StringContainsPhoneNumberValidator : BaseValidator<string>, IStringContainsPhoneNumberValidator
    {
        readonly string phoneNumberPattern;
        readonly Dictionary<string, string> digitWords = new Dictionary<string, string>
    {
        {"ZERO", "0"}, {"ONE", "1"}, {"TWO", "2"}, {"THREE", "3"}, {"FOUR", "4"},
        {"FIVE", "5"}, {"SIX", "6"}, {"SEVEN", "7"}, {"EIGHT", "8"}, {"NINE", "9"},
        {"शून्य", "0"}, {"एक", "1"}, {"दो", "2"}, {"तीन", "3"}, {"चार", "4"},
        {"पांच", "5"}, {"छह", "6"}, {"सात", "7"}, {"आठ", "8"}, {"नौ", "9"}
    };
        public StringContainsPhoneNumberValidator()
        {
            phoneNumberPattern = @"(\+\d{1,3}[-.\s]?\(?\d{1,4}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,9})|(\(\d{1,4}\)\s?\d{1,4}[-\s]?\d{1,4})|(\d{10})";
        }
        protected override ValidationResult ValidateInternal(ValidationInput<string> input)
        {
            if (string.IsNullOrEmpty(input.Value))
                throw new EmptyInputException();
            List<PhoneNumberInfo> phoneNumbers = new List<PhoneNumberInfo>();
            string replacedDigits = ReplaceDigitWords(input.Value);
            string[] parts = replacedDigits.Split(new char[] { ' ', '\t', '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string regexSource = string.Join("", parts);
            MatchCollection matches = Regex.Matches(regexSource, phoneNumberPattern);
            foreach (Match match in matches)
            {
                phoneNumbers.Add(new PhoneNumberInfo { PhoneNumber = match.Value });
                regexSource = regexSource.Replace(match.Value, String.Empty);
            }
            if (phoneNumbers.Count > 0)
                return new PhoneNumberValidationResult(phoneNumbers);

            return new PhoneNumberValidationResult(ValidationStatus.Success, string.Empty);
        }


        private string ReplaceDigitWords(string input)
        {
            StringBuilder result = new StringBuilder();
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToUpper();

                if (digitWords.ContainsKey(currentWord))
                {
                    string combinedDigits = digitWords[currentWord];

                    while (i + 1 < words.Length && digitWords.ContainsKey(words[i + 1].ToUpper()))
                    {
                        combinedDigits += digitWords[words[++i].ToUpper()];
                    }

                    result.Append(combinedDigits);
                    result.Append(" ");
                }
                else
                {
                    result.Append(words[i]);
                    result.Append(" ");
                }
            }

            return result.ToString().Trim();
        }


    }
}

