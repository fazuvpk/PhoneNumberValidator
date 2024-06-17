using System;
namespace Validator
{
    public class ValidationInput<T>
    {
        public T Value { get; set; }
        public object Options { get; set; }

        public ValidationInput(T input)
        {
            Value = input;
            Options = null;
        }
        public ValidationInput(T input, object options)
        {
            Value = input;
            Options = options;
        }
    }
}

