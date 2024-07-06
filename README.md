# A C# library to detect the phone number from a provided string.

Number formats
 - 10-digit numbers (e.g., 123-456-7890).
 - Numbers with country codes (e.g., +1-123-456-7890, +91-1234567890,).
 - Numbers with parentheses for area codes (e.g., (91) 1234567890, (123) 456-7890).
 - Numbers with spaces or dashes as separators (e.g., 123 456 7890, 123-456-7890, 91-123-456-7890, 91 123 456 7890, (91)1234567890, 01234567890 (without country code), 0123-4567890 (without country code), 1234567890
 - English: ONE TWO THREE FOUR FIVE SIX SEVEN EIGHT NINE ZERO
 - Hindi: एक दो तीन चार पांच छह सात आठ नौ आठ.
 - Combination of English & Hindi: ONE दो तीन FOUR FIVE छह SEVEN EIGHT NINE ZERO
