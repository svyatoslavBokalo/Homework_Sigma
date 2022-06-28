using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class UseMenu
    {
        static public uint WritePrice()
        {
            int count = 0;
            uint price = 0;
            Console.Write("input number: ");
            string line = Console.ReadLine();
            if(!uint.TryParse(line, out price))
            {
                Console.WriteLine("inccorect number, please input number again");
                line = Console.ReadLine();
                if(!uint.TryParse(line, out price))
                {
                    throw new FormatException("again inccorect number of price product");
                }
            }
            return price;
        }
    }
}
