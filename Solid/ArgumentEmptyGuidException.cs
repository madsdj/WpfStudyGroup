using System;

namespace Solid
{
    public class ArgumentEmptyGuidException : ArgumentException
    {
        public ArgumentEmptyGuidException(string paramName) : base("Empty Guid is not allowed.", paramName) { }
    }
}
