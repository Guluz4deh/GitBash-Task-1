using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1_04_22.Exceptions
{
    class IndexOutTheRangeException : İnputException
    {
        public IndexOutTheRangeException(string message) : base(message) { }
    }
}
