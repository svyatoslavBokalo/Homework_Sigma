﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
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
