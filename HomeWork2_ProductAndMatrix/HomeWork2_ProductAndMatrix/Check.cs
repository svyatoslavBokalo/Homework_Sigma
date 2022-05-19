using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class Check
    {
        static public void Inform(Product product, Buy buy)
        {
            string res = product.ToString() +"\n" + buy.ToString();
            Console.WriteLine(res);
        }
    }
}
