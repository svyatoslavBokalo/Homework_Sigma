using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    internal interface ICassa
    {
        public event CassaDelegate OnEventCassa;
        public int Count { get; }

        public double Cordinate { get; }
    }
}
