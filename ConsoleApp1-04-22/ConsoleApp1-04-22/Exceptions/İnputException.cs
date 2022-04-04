using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1_04_22.Exceptions
{
    class İnputException : Exception
    {
        public İnputException(string message) : base(message) { }
    }
}
