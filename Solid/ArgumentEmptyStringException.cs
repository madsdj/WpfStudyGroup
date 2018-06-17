using System;

namespace Solid
{
    public class ArgumentEmptyStringException : ArgumentException
    {
        public ArgumentEmptyStringException(string paramName) : base("Empty String is not allowed.", paramName) { }
    }
}
