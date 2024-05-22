using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Exceptions
{
    public class EmailIsNotUniqueException : Exception
    {
        public EmailIsNotUniqueException(string message) : base(message)
        {
        }
    }
}
