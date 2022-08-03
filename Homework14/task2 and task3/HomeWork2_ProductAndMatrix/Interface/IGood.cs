using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal interface IGood
    {
        string Name { get; set; }
        double Price { get; set; }
        string Producer { get; set; }
        void ChangePrice(double percent);
        void Parse(string str);

    }
}
