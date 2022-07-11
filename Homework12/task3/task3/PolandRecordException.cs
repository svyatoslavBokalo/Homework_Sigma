using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class PolandRecordException : Exception
    {
        public PolandRecordException()
        {
        }

        public PolandRecordException(string? message) : base(message)
        {
        }
    }
}
