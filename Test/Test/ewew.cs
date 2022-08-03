using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class ewew
    {
        public void ReverseArray<T>(T[] array)
        {
            for(int i = 0; i< array.Length/2; i++)
            {
                T buff = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = buff;
            }
        }
    }

    internal class Base
    {
        public virtual void Print()
        {
            Console.WriteLine("Base");
        }
    }

    internal class Child1: Base
    {
        public override void Print()
        {
            Console.WriteLine("Child1");
        }
    }

    internal class Child2 : Base
    {
        public new void Print()
        {
            Console.WriteLine("Child2");
        }
    }
}

