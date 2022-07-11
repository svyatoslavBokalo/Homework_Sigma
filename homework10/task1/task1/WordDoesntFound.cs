using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class WordDoesntFound : Exception
    {
        public WordDoesntFound() : base()
        {
        }

        public WordDoesntFound(string message) : base(message)
        {
        }


    }
}
