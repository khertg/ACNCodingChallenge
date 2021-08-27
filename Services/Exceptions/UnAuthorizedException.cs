using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Exceptions
{
    public class UnAuthorizedException : BaseException
    {
        public UnAuthorizedException(string message = "Unauthorized.") : base(message)
        {
        }
    }
}
