using System;
using System.Collections.Generic;
using System.Text;

namespace FMStatHub.Exceptions
{
    internal class AppException : Exception
    {
        public AppException(string message) : base(message) { }

        public AppException(string message, Exception inner)
            : base(message, inner) { }
    }
}
