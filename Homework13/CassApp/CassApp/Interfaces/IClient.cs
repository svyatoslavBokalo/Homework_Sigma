using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    internal interface IClient : IPerson
    {
        public Guid Id { get; }
        public int TimeServise { get; set; }
        public double Coordinate { get; }
    }
}
