using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8ExampleInterface
{
    internal class Pair
    {
        private int number;
        private int freq;

        public Pair()
        {
            number = 0;
            freq = 0;
        }
        public Pair(int number, int freq)
        {
            this.Number = number;
            this.Freq = freq;
        }



        public int Number { get => number; set => number = value; }
        public int Freq { get => freq; set => freq = value; }

        public override bool Equals(object? obj)
        {
            if(obj == null || !(obj is Pair))
            {
                return false;
            }

            return(this.Number == ((Pair)obj).Number && this.Freq == ((Pair)obj).Freq);
            //return obj is Pair pair &&
            //       number == pair.number &&
            //       freq == pair.freq &&
            //       Number == pair.Number &&
            //       Freq == pair.Freq;
        }

        public override string ToString()
        {
            return $"{number} - {freq}";
        }


    }
}
