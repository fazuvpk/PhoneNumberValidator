using System;
namespace ValidatorExceptions
{
    public class EmptyInputException : Exception
    {
        public EmptyInputException() : base("Input string is empty.") { }

        public EmptyInputException(string message) : base(message) { }

        public EmptyInputException(string message, Exception inner) : base(message, inner) { }
    }
}

