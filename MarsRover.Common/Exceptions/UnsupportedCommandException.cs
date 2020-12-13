using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Exceptions
{
    public class UnsupportedCommandException : Exception
    {
        public UnsupportedCommandException(string message) : base(message)
        {
        }
    }
}

