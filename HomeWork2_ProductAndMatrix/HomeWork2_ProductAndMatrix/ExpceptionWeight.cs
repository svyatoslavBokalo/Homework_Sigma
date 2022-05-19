using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class ExpceptionWeight: Exception
    {
        public ExpceptionWeight(string message) : base(message) { }
    }
}
