using System;
using System.Runtime.Serialization;

namespace Services.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException() { }
        public BaseException(string message) : base(message)
        {
        }
    }
}
