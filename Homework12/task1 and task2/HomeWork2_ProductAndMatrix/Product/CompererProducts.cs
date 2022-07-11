using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class CompererProducts : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            return x.Name.CompareTo(y.Name) == 0 && x.Price.CompareTo(y.Price) == 0 && x.Weight.CompareTo(y.Weight) == 0 ? 1:0;
        }
    }
}
